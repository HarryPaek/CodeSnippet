VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
END
Attribute VB_Name = "ClsTotalProcessorArea3"
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
Private Const COLUMN_INDEX_TEXT_CNA                    As String = "103"
Private Const COLUMN_INDEX_TEXT_SLOT_NO_1              As String = "136"
Private Const COLUMN_INDEX_TEXT_SLOT_NO_2              As String = "137"


'================================================================================
' ���� ������ ��Ʈ(DATA1, DATA2, DATA3) �� �ּ�
'================================================================================
Private Const CELL_ADDRESS_TOTAL_AREA_AREA3_CN         As String = "AB6"             ' DATA2 ��Ʈ

Private Const CELL_ADDRESS_TOTAL_AREA_SYSTEM1_MACRO    As String = "AC6"             ' DATA2 ��Ʈ
Private Const CELL_ADDRESS_TOTAL_AREA_SYSTEM2_MACRO    As String = "AC7"             ' DATA2 ��Ʈ

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
' AREA3 ó��
' ���� Row Index ���� ������ �ʿ��� ��쿡 +1 �ؼ� �۾�
' ���� �۾��� ���� Row Index ���� ���� ��
'================================================================================================================================================================
Public Function Process(rowIndex As Long, ioListDataRowIndex As Long, workingSheet As Worksheet, totalAreaSheet As Worksheet, cellValues As Collection) As Long

    Dim needProcessing               As Boolean                                                                                                            ' ���μ��� ����
    Dim localRowIndex                As Long
    Dim inStrResult                  As Integer                                                                                                            ' InStr ���� ��� ��
    
    Dim cnTotalAreaSheetValue        As Variant                                                                                                             ' �� ������� ���õ� DATA2 Cell �� (CN)
    
    Dim cnA                          As Variant
    Dim slotNo1                      As Variant
    Dim slotNo2                      As Variant
        
    Dim selectedCellValue            As Variant                                                                                                            ' ���� ������� ���õ� DATA2 Cell ��
    
    needProcessing = False
    localRowIndex = rowIndex
    
    ''cnA = cellValues.Item(COLUMN_INDEX_TEXT_CNA)
    cnA = collectionExtension.TryGetValue(cellValues, COLUMN_INDEX_TEXT_CNA)                                       'CY, IO ��Ʈ�� ���� ��츦 ����Ͽ� Extension Method ���
    
    ''slotNo1 = cellValues.Item(COLUMN_INDEX_TEXT_SLOT_NO_1)
    slotNo1 = collectionExtension.TryGetValue(cellValues, COLUMN_INDEX_TEXT_SLOT_NO_1)                             'EF, IO ��Ʈ�� ���� ��츦 ����Ͽ� Extension Method ���
    
    ''slotNo2 = cellValues.Item(COLUMN_INDEX_TEXT_SLOT_NO_2)
    slotNo2 = collectionExtension.TryGetValue(cellValues, COLUMN_INDEX_TEXT_SLOT_NO_2)                             'EG, IO ��Ʈ�� ���� ��츦 ����Ͽ� Extension Method ���
    
    cnTotalAreaSheetValue = totalAreaSheet.Range(CELL_ADDRESS_TOTAL_AREA_AREA3_CN)
    
    inStrResult = InStr(cnA, cnTotalAreaSheetValue)
    
    If (inStrResult > 0 And slotNo2 <> "") Then                                                                                                            ' CNA ���� �ְ�, SLOT NO2 ���� ������
       needProcessing = True
       selectedCellValue = totalAreaSheet.Range(CELL_ADDRESS_TOTAL_AREA_SYSTEM2_MACRO)                                                                     ' SYSTEM2 ��ũ�� ����
    ElseIf (inStrResult > 0 And slotNo1 <> "") Then                                                                                                        ' CNA ���� �ְ�, SLOT NO1 ���� ������
       needProcessing = True
       selectedCellValue = totalAreaSheet.Range(CELL_ADDRESS_TOTAL_AREA_SYSTEM1_MACRO)                                                                     ' SYSTEM1 ��ũ�� �Է�
    End If
    
    If (needProcessing) Then                                                                                                                               ' ó�� �۾��� �ʿ��ϸ�
        localRowIndex = localRowIndex + 1
        clsCommon.SetSingleLine2AndCopyVariant localRowIndex, ioListDataRowIndex, workingSheet
        workingSheet.Cells(localRowIndex, Constants.COLUMN_INDEX_MACRO_NAME).value = selectedCellValue                                                     ' ���õ� ��ũ�� �Է�
    End If
    
    Process = localRowIndex
    
End Function



