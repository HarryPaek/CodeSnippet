VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
END
Attribute VB_Name = "ClsTotalProcessorArea2TB"
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
Private Const COLUMN_INDEX_TEXT_TB_GRP_NO_1            As String = "63"
Private Const COLUMN_INDEX_TEXT_TB1_3                  As String = "66"
Private Const COLUMN_INDEX_TEXT_TB_GRP_NO_2            As String = "75"
Private Const COLUMN_INDEX_TEXT_TB2_3                  As String = "78"
Private Const COLUMN_INDEX_TEXT_RELAY_NAME             As String = "107"


'================================================================================
' ���� ������ ��Ʈ(DATA1, DATA2, DATA3) �� �ּ�
'================================================================================
Private Const CELL_ADDRESS_TOTAL_AREA_AREA2_TB         As String = "L6"              ' DATA2 ��Ʈ
Private Const CELL_ADDRESS_TOTAL_AREA_AREA2_TB_TB      As String = "M7"              ' DATA2 ��Ʈ
Private Const CELL_ADDRESS_TOTAL_AREA_AREA2_TB_R       As String = "M8"              ' DATA2 ��Ʈ

Private Const CELL_ADDRESS_TOTAL_AREA_TB1_MACRO        As String = "P6"              ' DATA2 ��Ʈ
Private Const CELL_ADDRESS_TOTAL_AREA_TB1_1_MACRO      As String = "S6"              ' DATA2 ��Ʈ
Private Const CELL_ADDRESS_TOTAL_AREA_TB2_MACRO        As String = "P7"              ' DATA2 ��Ʈ
Private Const CELL_ADDRESS_TOTAL_AREA_TB2_1_MACRO      As String = "S7"              ' DATA2 ��Ʈ
Private Const CELL_ADDRESS_TOTAL_AREA_RY_MACRO         As String = "P8"              ' DATA2 ��Ʈ

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
' AREA2 TB ó��
' ���� Row Index ���� ������ �ʿ��� ��쿡 +1 �ؼ� �۾�
' ���� �۾��� ���� Row Index ���� ���� ��
'================================================================================================================================================================
Public Function Process(rowIndex As Long, ioListDataRowIndex As Long, workingSheet As Worksheet, totalAreaSheet As Worksheet, cellValues As Collection) As Long

    Dim needProcessing               As Boolean                                                                                                            ' ���μ��� ����
    Dim localRowIndex                As Long
    
    Dim tbInStrResult                As Integer                                                                                                            ' InStr ���� ��� ��
    Dim tbTbInStrResult              As Integer                                                                                                            ' InStr ���� ��� ��
    Dim tbRInStrResult               As Integer                                                                                                            ' InStr ���� ��� ��
    
    Dim tbTotalAreaSheetValue        As Variant                                                                                                            ' �� ������� ���õ� DATA2 Cell �� (CN)
    Dim tbTbTotalAreaSheetValue      As Variant                                                                                                            ' �� ������� ���õ� DATA2 Cell �� (TB)
    Dim tbRTotalAreaSheetValue       As Variant                                                                                                            ' �� ������� ���õ� DATA2 Cell �� (TB)
    
    Dim tbGroupNo1                   As Variant
    Dim tb13                         As Variant
    Dim tbGroupNo2                   As Variant
    Dim tb23                         As Variant
    Dim relayName                    As Variant
    
    Dim selectedCellValue            As Variant                                                                                                            ' ���� ������� ���õ� DATA2 Cell ��
    
    needProcessing = False
    localRowIndex = rowIndex
    
    ''tbGroupNo1 = cellValues.Item(COLUMN_INDEX_TEXT_TB_GRP_NO_1)
    tbGroupNo1 = collectionExtension.TryGetValue(cellValues, COLUMN_INDEX_TEXT_TB_GRP_NO_1)                        'BK, IO ��Ʈ�� ���� ��츦 ����Ͽ� Extension Method ���
    
    '' tb13 = cellValues.Item(COLUMN_INDEX_TEXT_TB1_3)
    tb13 = collectionExtension.TryGetValue(cellValues, COLUMN_INDEX_TEXT_TB1_3)                                    'BN, IO ��Ʈ�� ���� ��츦 ����Ͽ� Extension Method ���
    
    ''tbGroupNo2 = cellValues.Item(COLUMN_INDEX_TEXT_TB_GRP_NO_2)
    tbGroupNo2 = collectionExtension.TryGetValue(cellValues, COLUMN_INDEX_TEXT_TB_GRP_NO_2)                        'BW, IO ��Ʈ�� ���� ��츦 ����Ͽ� Extension Method ���
    
    ''tb23 = cellValues.Item(COLUMN_INDEX_TEXT_TB2_3)
    tb23 = collectionExtension.TryGetValue(cellValues, COLUMN_INDEX_TEXT_TB2_3)                                    'BZ, IO ��Ʈ�� ���� ��츦 ����Ͽ� Extension Method ���
    
    ''relayName = cellValues.Item(COLUMN_INDEX_TEXT_RELAY_NAME)
    relayName = collectionExtension.TryGetValue(cellValues, COLUMN_INDEX_TEXT_RELAY_NAME)                          'DC, IO ��Ʈ�� ���� ��츦 ����Ͽ� Extension Method ���
    
    tbTotalAreaSheetValue = totalAreaSheet.Range(CELL_ADDRESS_TOTAL_AREA_AREA2_TB)
    tbTbTotalAreaSheetValue = totalAreaSheet.Range(CELL_ADDRESS_TOTAL_AREA_AREA2_TB_TB)
    tbRTotalAreaSheetValue = totalAreaSheet.Range(CELL_ADDRESS_TOTAL_AREA_AREA2_TB_R)
    
    tbInStrResult = InStr(tbGroupNo1, tbTotalAreaSheetValue)
    tbTbInStrResult = InStr(tbGroupNo2, tbTbTotalAreaSheetValue)
    tbRInStrResult = InStr(relayName, tbRTotalAreaSheetValue)
    
    If (tbRInStrResult > 0) Then                                                                                                                           ' RELAY NAME ���� ������
       needProcessing = True
       selectedCellValue = totalAreaSheet.Range(CELL_ADDRESS_TOTAL_AREA_RY_MACRO)                                                                          ' RY(DRY) ��ũ�� ����
    ElseIf (tb23 > 0) Then                                                                                                                                 ' TB2-3 ���� ������
       needProcessing = True
       selectedCellValue = totalAreaSheet.Range(CELL_ADDRESS_TOTAL_AREA_TB2_1_MACRO)                                                                       ' TB2-1 ��ũ�� ����
    ElseIf (tbTbInStrResult > 0) Then                                                                                                                      ' TB GRP NO2 ���� ������
       needProcessing = True
       selectedCellValue = totalAreaSheet.Range(CELL_ADDRESS_TOTAL_AREA_TB2_MACRO)                                                                         ' TB2 ��ũ�� ����
    ElseIf (tb13 > 0) Then                                                                                                                                 ' TB1-3 ���� ������
       needProcessing = True
       selectedCellValue = totalAreaSheet.Range(CELL_ADDRESS_TOTAL_AREA_TB1_1_MACRO)                                                                       ' TB1-1 ��ũ�� �Է�
    ElseIf (tbInStrResult > 0) Then                                                                                                                        ' TB GRP NO1 ���� ������
       needProcessing = True
       selectedCellValue = totalAreaSheet.Range(CELL_ADDRESS_TOTAL_AREA_TB1_MACRO)                                                                         ' TB1 ��ũ�� �Է�
    End If
    
    If (needProcessing) Then                                                                                                                               ' ó�� �۾��� �ʿ��ϸ�
        localRowIndex = localRowIndex + 1
        clsCommon.SetSingleLine2AndCopyVariant localRowIndex, ioListDataRowIndex, workingSheet
        workingSheet.Cells(localRowIndex, Constants.COLUMN_INDEX_MACRO_NAME).value = selectedCellValue                                                     ' ���õ� ��ũ�� �Է�
    End If
    
    Process = localRowIndex
    
End Function



