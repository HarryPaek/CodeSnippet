VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
END
Attribute VB_Name = "ClsTotalProcessorArea2"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = False
Option Explicit

'===== ===== ===== ================================================================================
' CellValues Collection �ε���
'  - CellValues Collection�� ���� ��� ��Ʈ Column Number Text(��, "15")�� Ű �������Ͽ� ����
'  - �Ʒ��� ������ ��, �ݵ�� ���ڿ��� ������ ��
'===== ===== ===== ================================================================================
Private Const COLUMN_INDEX_TEXT_TB_GRP_NO_2            As String = "75"
Private Const COLUMN_INDEX_TEXT_TBD_3                  As String = "102"
Private Const COLUMN_INDEX_TEXT_CNA                    As String = "103"
Private Const COLUMN_INDEX_TEXT_INT_POWER              As String = "170"
Private Const COLUMN_INDEX_TEXT_EXT_POWER              As String = "171"


'================================================================================
' ���� ������ ��Ʈ(DATA1, DATA2, DATA3) �� �ּ�
'================================================================================
Private Const CELL_ADDRESS_TOTAL_AREA_AREA2_CN         As String = "T6"              ' DATA2 ��Ʈ
Private Const CELL_ADDRESS_TOTAL_AREA_AREA2_TB         As String = "U7"              ' DATA2 ��Ʈ


Private Const CELL_ADDRESS_TOTAL_AREA_TBA1_MACRO       As String = "W6"              ' DATA2 ��Ʈ
Private Const CELL_ADDRESS_TOTAL_AREA_TBA1_1_MACRO     As String = "Z6"              ' DATA2 ��Ʈ
Private Const CELL_ADDRESS_TOTAL_AREA_TBA2_MACRO       As String = "W7"              ' DATA2 ��Ʈ
Private Const CELL_ADDRESS_TOTAL_AREA_TBA2_1_MACRO     As String = "Z7"              ' DATA2 ��Ʈ
Private Const CELL_ADDRESS_TOTAL_AREA_TBA3_MACRO       As String = "W8"              ' DATA2 ��Ʈ
Private Const CELL_ADDRESS_TOTAL_AREA_TBA4_MACRO       As String = "W9"              ' DATA2 ��Ʈ
Private Const CELL_ADDRESS_TOTAL_AREA_TBA5_MACRO       As String = "W10"             ' DATA2 ��Ʈ


Private clsCommon As ClsWiringCommon
Private collectionExtension As ClsCollectionExtension

Private Sub Class_Initialize()

    'MsgBox "ClsTotalProcessorArea1 Class is being initialized"
    
    Set clsCommon = New ClsWiringCommon
    Set collectionExtension = New ClsCollectionExtension
    
End Sub

Private Sub Class_Terminate()
    
    'MsgBox "ClsTotalProcessorArea1 Class is being terminated"
    
    Set clsCommon = Nothing
    Set collectionExtension = Nothing

End Sub

'================================================================================================================================================================
' AREA2 ó��
' ���� Row Index ���� ������ �ʿ��� ��쿡 +1 �ؼ� �۾�
' ���� �۾��� ���� Row Index ���� ���� ��
'================================================================================================================================================================
Public Function Process(rowIndex As Long, ioListDataRowIndex As Long, workingSheet As Worksheet, totalAreaSheet As Worksheet, cellValues As Collection) As Long

    Dim needProcessing               As Boolean                                                                                                            ' ���μ��� ����
    Dim localRowIndex                As Long
    Dim cnInStrResult                As Integer                                                                                                            ' InStr ���� ��� ��
    Dim tbInStrResult                As Integer                                                                                                            ' InStr ���� ��� ��
    
    Dim cnTotalAreaSheetValue        As Variant                                                                                                             ' �� ������� ���õ� DATA2 Cell �� (CN)
    Dim tbTotalAreaSheetValue        As Variant                                                                                                             ' �� ������� ���õ� DATA2 Cell �� (TB)
    
    Dim tbGroupNo2                   As Variant
    Dim tbd3                         As Variant
    Dim cnA                          As Variant
    Dim intPower                     As Variant
    Dim extPower                     As Variant
    
    Dim selectedCellValue            As Variant                                                                                                            ' ���� ������� ���õ� DATA2 Cell ��
    
    needProcessing = False
    localRowIndex = rowIndex
    
    ''tbGroupNo2 = cellValues.Item(COLUMN_INDEX_TEXT_TB_GRP_NO_2)
    tbGroupNo2 = collectionExtension.TryGetValue(cellValues, COLUMN_INDEX_TEXT_TB_GRP_NO_2)                        'BW, IO ��Ʈ�� ���� ��츦 ����Ͽ� Extension Method ���
    
    ''tbd3 = cellValues.Item(COLUMN_INDEX_TEXT_TBD_3)
    tbd3 = collectionExtension.TryGetValue(cellValues, COLUMN_INDEX_TEXT_TBD_3)                                    'CX, IO ��Ʈ�� ���� ��츦 ����Ͽ� Extension Method ���
    
    ''cnA = cellValues.Item(COLUMN_INDEX_TEXT_CNA)
    cnA = collectionExtension.TryGetValue(cellValues, COLUMN_INDEX_TEXT_CNA)                                       'CY, IO ��Ʈ�� ���� ��츦 ����Ͽ� Extension Method ���
    
    ''intPower = cellValues.Item(COLUMN_INDEX_TEXT_INT_POWER)
    intPower = collectionExtension.TryGetValue(cellValues, COLUMN_INDEX_TEXT_INT_POWER)                            'FN, IO ��Ʈ�� ���� ��츦 ����Ͽ� Extension Method ���
    
    ''extPower = cellValues.Item(COLUMN_INDEX_TEXT_EXT_POWER)
    extPower = collectionExtension.TryGetValue(cellValues, COLUMN_INDEX_TEXT_EXT_POWER)                            'FO, IO ��Ʈ�� ���� ��츦 ����Ͽ� Extension Method ���
    
    cnTotalAreaSheetValue = totalAreaSheet.Range(CELL_ADDRESS_TOTAL_AREA_AREA2_CN)
    tbTotalAreaSheetValue = totalAreaSheet.Range(CELL_ADDRESS_TOTAL_AREA_AREA2_TB)
    
    cnInStrResult = InStr(cnA, cnTotalAreaSheetValue)
    tbInStrResult = InStr(tbGroupNo2, tbTotalAreaSheetValue)
    
    If (intPower > 0 And extPower = "" And tbGroupNo2 = "") Then                                                                                           ' INT ���� �ְ�, EXT ��,TB GRP NO2 ���� ������
       needProcessing = True
       selectedCellValue = totalAreaSheet.Range(CELL_ADDRESS_TOTAL_AREA_TBA5_MACRO)                                                                        ' TBA5 ��ũ�� ����
    ElseIf (extPower > 0 And intPower = "" And tbGroupNo2 = "") Then                                                                                       ' EXT ���� �ְ�, INT ��,TB GRP NO2 ���� ������
       needProcessing = True
       selectedCellValue = totalAreaSheet.Range(CELL_ADDRESS_TOTAL_AREA_TBA4_MACRO)                                                                        ' TBA4 ��ũ�� ����
    ElseIf (intPower > 0 And extPower > 0 And tbGroupNo2 = "") Then                                                                                        ' INT/EXT ���� �ְ�, TB GRP NO2 ���� ������
       needProcessing = True
       selectedCellValue = totalAreaSheet.Range(CELL_ADDRESS_TOTAL_AREA_TBA3_MACRO)                                                                        ' TBA3 ��ũ�� ����
    ElseIf (tbInStrResult > 0 And tbd3 <> "") Then                                                                                                         ' TB GRP NO2 ���� �ְ�,TBD(3)�� ������
       needProcessing = True
       selectedCellValue = totalAreaSheet.Range(CELL_ADDRESS_TOTAL_AREA_TBA2_1_MACRO)                                                                      ' TBA2-1 ��ũ�� �Է�
    ElseIf (tbInStrResult > 0) Then                                                                                                                        ' TB GRP NO2 ���� ������
       needProcessing = True
       selectedCellValue = totalAreaSheet.Range(CELL_ADDRESS_TOTAL_AREA_TBA2_MACRO)                                                                        ' TBA2 ��ũ�� �Է�
    ElseIf (cnInStrResult > 0 And tbd3 <> "" And tbGroupNo2 = "") Then                                                                                     ' CNA ���� �ְ�,TBD(3) ���� ������, TB GRP NO2 ���� ������
       needProcessing = True
       selectedCellValue = totalAreaSheet.Range(CELL_ADDRESS_TOTAL_AREA_TBA1_1_MACRO)                                                                      ' TBA1-1 ��ũ�� �Է�
    ElseIf (cnInStrResult > 0 And tbGroupNo2 = "") Then                                                                                                    ' CNA ���� �ְ�, TB GRP NO2 ���� ������
       needProcessing = True
       selectedCellValue = totalAreaSheet.Range(CELL_ADDRESS_TOTAL_AREA_TBA1_MACRO)                                                                        ' TBA1 ��ũ�� �Է�
    End If
    
    If (needProcessing) Then                                                                                                                               ' ó�� �۾��� �ʿ��ϸ�
        localRowIndex = localRowIndex + 1
        clsCommon.SetSingleLine2AndCopyVariant localRowIndex, ioListDataRowIndex, workingSheet
        workingSheet.Cells(localRowIndex, Constants.COLUMN_INDEX_MACRO_NAME).value = selectedCellValue                                                     ' ���õ� ��ũ�� �Է�
    End If
    
    Process = localRowIndex
    
End Function


