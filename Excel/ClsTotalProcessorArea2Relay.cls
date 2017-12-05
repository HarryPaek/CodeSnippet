VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
END
Attribute VB_Name = "ClsTotalProcessorArea2Relay"
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
Private Const COLUMN_INDEX_TEXT_TB_RELAY_POWER_PLUS    As String = "112"

'================================================================================
' ���� ������ ��Ʈ(DATA1, DATA2, DATA3) �� �ּ�
'================================================================================
Private Const CELL_ADDRESS_TOTAL_AREA_AREA2_TB_R_V     As String = "N9"              ' DATA2 ��Ʈ

Private Const CELL_ADDRESS_TOTAL_AREA_RY1_MACRO        As String = "P9"              ' DATA2 ��Ʈ

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
' AREA2 RELAY POWER ó��
' ���� Row Index ���� ������ �ʿ��� ��쿡 +1 �ؼ� �۾�
' ���� �۾��� ���� Row Index ���� ���� ��
'================================================================================================================================================================
Public Function Process(rowIndex As Long, ioListDataRowIndex As Long, workingSheet As Worksheet, totalAreaSheet As Worksheet, cellValues As Collection) As Long

    Dim needProcessing               As Boolean                                                                                                            ' ���μ��� ����
    Dim localRowIndex                As Long
    
    Dim inStrResult                  As Integer                                                                                                            ' InStr ���� ��� ��
    Dim tbRVTotalAreaSheetValue      As Variant                                                                                                            ' �� ������� ���õ� DATA2 Cell �� (TB)
    Dim relayPowerPlus               As Variant
    Dim selectedCellValue            As Variant                                                                                                            ' ���� ������� ���õ� DATA2 Cell ��
    
    needProcessing = False
    localRowIndex = rowIndex
    
    ''relayPowerPlus = cellValues.Item(COLUMN_INDEX_TEXT_TB_RELAY_POWER_PLUS)
    relayPowerPlus = collectionExtension.TryGetValue(cellValues, COLUMN_INDEX_TEXT_TB_RELAY_POWER_PLUS)                 'DH, IO ��Ʈ�� ���� ��츦 ����Ͽ� Extension Method ���
    
    tbRVTotalAreaSheetValue = totalAreaSheet.Range(CELL_ADDRESS_TOTAL_AREA_AREA2_TB_R_V)
    
    inStrResult = InStr(relayPowerPlus, tbRVTotalAreaSheetValue)
    
    If (inStrResult > 0) Then                                                                                                                              ' RELAY POWER PLUS ���� ������
       needProcessing = True
       selectedCellValue = totalAreaSheet.Range(CELL_ADDRESS_TOTAL_AREA_RY1_MACRO)                                                                         ' RY1(WER) ��ũ�� ����
    End If
    
    If (needProcessing) Then                                                                                                                               ' ó�� �۾��� �ʿ��ϸ�
        localRowIndex = localRowIndex + 1
        clsCommon.SetSingleLine2AndCopyVariant localRowIndex, ioListDataRowIndex, workingSheet
        workingSheet.Cells(localRowIndex, Constants.COLUMN_INDEX_MACRO_NAME).value = selectedCellValue                                                     ' ���õ� ��ũ�� �Է�
    End If
    
    Process = localRowIndex
    
End Function




