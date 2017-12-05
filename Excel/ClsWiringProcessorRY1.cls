VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
END
Attribute VB_Name = "ClsWiringProcessorRY1"
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
Private Const COLUMN_INDEX_TEXT_RY_NAME              As String = "107"
Private Const COLUMN_INDEX_TEXT_RY_POWER             As String = "112"

'================================================================================
' ���� ������ ��Ʈ(DATA1, DATA2, DATA3) �� �ּ�
'================================================================================
Private Const CELL_ADDRESS_WIRING_DIAGRAM_RY_1       As String = "M22"             ' DATA3 ��Ʈ
Private Const CELL_ADDRESS_WIRING_DIAGRAM_RY_2       As String = "O22"             ' DATA3 ��Ʈ

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
    Dim ryName            As Variant
    Dim ryPower           As Variant
    Dim selectedCellValue As Variant                                                                                                                       ' ���� ������� ���õ� DATA3 Cell ��
    
    needProcessing = False
    localRowIndex = rowIndex

    ''ryName = cellValues.Item(COLUMN_INDEX_TEXT_RY_NAME)
    ryName = collectionExtension.TryGetValue(cellValues, COLUMN_INDEX_TEXT_RY_NAME)                                      'DC, IO ��Ʈ�� ���� ��츦 ����Ͽ� Extension Method ���
    
    ''ryPower = cellValues.Item(COLUMN_INDEX_TEXT_RY_POWER)
    ryPower = collectionExtension.TryGetValue(cellValues, COLUMN_INDEX_TEXT_RY_POWER)                                    'DH, IO ��Ʈ�� ���� ��츦 ����Ͽ� Extension Method ���
    
    If (ryPower > 0 And ryName <> "") Then                                                                                                                 ' RY NAME ��, RY POWER ���� ������
       needProcessing = True
       selectedCellValue = wiringDiagramSheet.Range(CELL_ADDRESS_WIRING_DIAGRAM_RY_2)                                                                      ' RY2 ��ũ�� �Է�
    ElseIf (ryName > 0) Then                                                                                                                               ' RY NAME ���� ������
       needProcessing = True
       selectedCellValue = wiringDiagramSheet.Range(CELL_ADDRESS_WIRING_DIAGRAM_RY_1)                                                                      ' RY1 ��ũ�� �Է�
    End If
    
    If (needProcessing) Then                                                                                                                               ' ó�� �۾��� �ʿ��ϸ�
        localRowIndex = localRowIndex + 1
        clsCommon.SetSingleLine2AndCopyVariant localRowIndex, ioListDataRowIndex, workingSheet
        workingSheet.Cells(localRowIndex, Constants.COLUMN_INDEX_MACRO_NAME).value = selectedCellValue                                                     ' ���õ� ��ũ�� �Է�
    End If
    
    Process = localRowIndex
    
End Function

