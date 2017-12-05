VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
END
Attribute VB_Name = "ClsWiringProcessorSA"
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
Private Const COLUMN_INDEX_TEXT_SA1_NAME              As String = "114"
Private Const COLUMN_INDEX_TEXT_SA2_NAME              As String = "121"

'================================================================================
' ���� ������ ��Ʈ(DATA1, DATA2, DATA3) �� �ּ�
'================================================================================
Private Const CELL_ADDRESS_WIRING_DIAGRAM_SA_1        As String = "R22"             ' DATA3 ��Ʈ
Private Const CELL_ADDRESS_WIRING_DIAGRAM_SA_2        As String = "T22"             ' DATA3 ��Ʈ

Private clsCommon As ClsWiringCommon
Private collectionExtension As ClsCollectionExtension

Private Sub Class_Initialize()

    Set clsCommon = New ClsWiringCommon
    Set collectionExtension = New ClsCollectionExtension
    
End Sub

Private Sub Class_Terminate()
    
    Set clsCommon = Nothing
    Set collectionExtension = Nothing

End Sub


'================================================================================================================================================================
' RY1 ó��
' ���� Row Index ���� ������ �ʿ��� ��쿡 +1 �ؼ� �۾�
' ���� �۾��� ���� Row Index ���� ���� ��
'================================================================================================================================================================
Public Function Process(rowIndex As Long, ioListDataRowIndex As Long, workingSheet As Worksheet, wiringDiagramSheet As Worksheet, cellValues As Collection) As Long

    Dim needProcessing    As Boolean                                                                                                                       ' ���μ��� ����
    Dim localRowIndex     As Long
    Dim sa1Name           As Variant
    Dim sa2Name           As Variant
    Dim selectedCellValue As Variant                                                                                                                       ' ���� ������� ���õ� DATA3 Cell ��
    
    needProcessing = False
    localRowIndex = rowIndex

    ''sa1Name = cellValues.Item(COLUMN_INDEX_TEXT_SA1_NAME)
    sa1Name = collectionExtension.TryGetValue(cellValues, COLUMN_INDEX_TEXT_SA1_NAME)                                    'DJ, IO ��Ʈ�� ���� ��츦 ����Ͽ� Extension Method ���
    
    ''sa2Name = cellValues.Item(COLUMN_INDEX_TEXT_SA2_NAME)
    sa2Name = collectionExtension.TryGetValue(cellValues, COLUMN_INDEX_TEXT_SA2_NAME)                                    'DQ, IO ��Ʈ�� ���� ��츦 ����Ͽ� Extension Method ���
    
    If (sa2Name > 0) Then                                                                                                                                  ' SA2 NAME ���� ������,
       needProcessing = True
       selectedCellValue = wiringDiagramSheet.Range(CELL_ADDRESS_WIRING_DIAGRAM_SA_2)                                                                      ' SA2 ��ũ�� �Է�
    ElseIf (sa1Name > 0) Then                                                                                                                              ' SA1 NAME ���� ������
       needProcessing = True
       selectedCellValue = wiringDiagramSheet.Range(CELL_ADDRESS_WIRING_DIAGRAM_SA_1)                                                                      ' SA1 ��ũ�� �Է�
    End If
    
    If (needProcessing) Then                                                                                                                               ' ó�� �۾��� �ʿ��ϸ�
        localRowIndex = localRowIndex + 1
        clsCommon.SetSingleLine2AndCopyVariant localRowIndex, ioListDataRowIndex, workingSheet
        workingSheet.Cells(localRowIndex, Constants.COLUMN_INDEX_MACRO_NAME).value = selectedCellValue                                                     ' ���õ� ��ũ�� �Է�
    End If
    
    Process = localRowIndex
    
End Function


