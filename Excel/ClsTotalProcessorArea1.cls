VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
END
Attribute VB_Name = "ClsTotalProcessorArea1"
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
Private Const COLUMN_INDEX_TEXT_JB_GRP_NO            As String = "35"
Private Const COLUMN_INDEX_TEXT_JB_3                 As String = "38"
Private Const COLUMN_INDEX_TEXT_FJB_GRP_NO           As String = "44"

'================================================================================
' ���� ������ ��Ʈ(DATA1, DATA2, DATA3) �� �ּ�
'================================================================================
Private Const CELL_ADDRESS_TOTAL_AREA_AREA1_FCS      As String = "E30"            ' DATA2 ��Ʈ

Private Const CELL_ADDRESS_TOTAL_AREA_JB_MACRO       As String = "G29"             ' DATA2 ��Ʈ
Private Const CELL_ADDRESS_TOTAL_AREA_JB1_MACRO      As String = "I29"             ' DATA2 ��Ʈ
Private Const CELL_ADDRESS_TOTAL_AREA_FJB_MACRO      As String = "G30"             ' DATA2 ��Ʈ

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
' AREA1 ó��
' ���� Row Index ���� ������ �ʿ��� ��쿡 +1 �ؼ� �۾�
' ���� �۾��� ���� Row Index ���� ���� ��
'================================================================================================================================================================
Public Function Process(rowIndex As Long, ioListDataRowIndex As Long, workingSheet As Worksheet, totalAreaSheet As Worksheet, cellValues As Collection) As Long

    Dim needProcessing               As Boolean                                                                                                            ' ���μ��� ����
    Dim localRowIndex                As Long
    Dim inStrResult                  As Integer                                                                                                            ' InStr ���� ��� ��
    
    Dim fjbTotalAreaSheetValue       As Variant                                                                                                            ' �� ������� ���õ� DATA2 Cell �� (TAG TYPE)
    Dim jbGroupNo                    As Variant
    Dim jb3                          As Variant
    Dim fjbGroupNo                   As Variant
    
    Dim selectedCellValue            As Variant                                                                                                            ' ���� ������� ���õ� DATA2 Cell ��
    
    needProcessing = False
    localRowIndex = rowIndex
    
    ''jbGroupNo = cellValues.Item(COLUMN_INDEX_TEXT_JB_GRP_NO)
    jbGroupNo = collectionExtension.TryGetValue(cellValues, COLUMN_INDEX_TEXT_JB_GRP_NO)                                 'AI, IO ��Ʈ�� ���� ��츦 ����Ͽ� Extension Method ���
    
    ''jb3 = cellValues.Item(COLUMN_INDEX_TEXT_JB_3)
    jb3 = collectionExtension.TryGetValue(cellValues, COLUMN_INDEX_TEXT_JB_3)                                            'AL, IO ��Ʈ�� ���� ��츦 ����Ͽ� Extension Method ���
    
    ''fjbGroupNo = cellValues.Item(COLUMN_INDEX_TEXT_FJB_GRP_NO)
    fjbGroupNo = collectionExtension.TryGetValue(cellValues, COLUMN_INDEX_TEXT_FJB_GRP_NO)                               'AR, IO ��Ʈ�� ���� ��츦 ����Ͽ� Extension Method ���
        
    fjbTotalAreaSheetValue = totalAreaSheet.Range(CELL_ADDRESS_TOTAL_AREA_AREA1_FCS)
    
    inStrResult = InStr(fjbGroupNo, fjbTotalAreaSheetValue)
    
    If (inStrResult > 0) Then                                                                                                                              ' FJB GRP NO, DATA2 ��Ʈ�� FJB �� ��
       needProcessing = True
       selectedCellValue = totalAreaSheet.Range(CELL_ADDRESS_TOTAL_AREA_FJB_MACRO)                                                                         ' FJB ��ũ�� ����
    ElseIf (jb3 <> "") Then                                                                                                                                ' JB(3) ���� ������
       needProcessing = True
       selectedCellValue = totalAreaSheet.Range(CELL_ADDRESS_TOTAL_AREA_JB1_MACRO)                                                                         ' JB1 ��ũ�� �Է�
    ElseIf (jbGroupNo > 0) Then                                                                                                                            ' JB GRP NO ���� ������
       needProcessing = True
       selectedCellValue = totalAreaSheet.Range(CELL_ADDRESS_TOTAL_AREA_JB_MACRO)                                                                               ' JB ��ũ�� �Է�
    End If
    
    If (needProcessing) Then                                                                                                                               ' ó�� �۾��� �ʿ��ϸ�
        localRowIndex = localRowIndex + 1
        clsCommon.SetSingleLine2AndCopyVariant localRowIndex, ioListDataRowIndex, workingSheet
        workingSheet.Cells(localRowIndex, Constants.COLUMN_INDEX_MACRO_NAME).value = selectedCellValue                                                     ' ���õ� ��ũ�� �Է�
    End If
    
    Process = localRowIndex
    
End Function

