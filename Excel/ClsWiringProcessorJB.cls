VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
END
Attribute VB_Name = "ClsWiringProcessorJB"
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

'================================================================================
' ���� ������ ��Ʈ(DATA1, DATA2, DATA3) �� �ּ�
'================================================================================
Private Const CELL_ADDRESS_WIRING_DIAGRAM_JB         As String = "G5"             ' DATA3 ��Ʈ
Private Const CELL_ADDRESS_WIRING_DIAGRAM_JB_1       As String = "I5"             ' DATA3 ��Ʈ

Private clsCommon As ClsWiringCommon
Private collectionExtension As ClsCollectionExtension

Private Sub Class_Initialize()

    'MsgBox "ProcessorJB Class is being initialized"
    
    Set clsCommon = New ClsWiringCommon
    Set collectionExtension = New ClsCollectionExtension
    
End Sub

Private Sub Class_Terminate()
    
    'MsgBox "ProcessorJB Class is being terminated"
    
    Set clsCommon = Nothing
    Set collectionExtension = Nothing

End Sub

'================================================================================================================================================================
' JB ó��
' ���� Row Index ���� ������ �ʿ��� ��쿡 +1 �ؼ� �۾�
' ���� �۾��� ���� Row Index ���� ���� ��
'================================================================================================================================================================
Public Function Process(rowIndex As Long, ioListDataRowIndex As Long, workingSheet As Worksheet, wiringDiagramSheet As Worksheet, cellValues As Collection) As Long

    Dim needProcessing    As Boolean                                                                                                                       ' ���μ��� ����
    Dim localRowIndex     As Long
    Dim jbGroupNo         As Variant
    Dim jb3               As Variant
    Dim selectedCellValue As Variant                                                                                                                       ' ���� ������� ���õ� DATA3 Cell ��
    
    needProcessing = False
    localRowIndex = rowIndex
    
    ''jbGroupNo = cellValues.Item(COLUMN_INDEX_TEXT_JB_GRP_NO)
    jbGroupNo = collectionExtension.TryGetValue(cellValues, COLUMN_INDEX_TEXT_JB_GRP_NO)                                 'AI, IO ��Ʈ�� ���� ��츦 ����Ͽ� Extension Method ���
    
    ''jb3 = cellValues.Item(COLUMN_INDEX_TEXT_JB_3)
    jb3 = collectionExtension.TryGetValue(cellValues, COLUMN_INDEX_TEXT_JB_3)                                            'AL, IO ��Ʈ�� ���� ��츦 ����Ͽ� Extension Method ���
    
    If (jb3 > 0 And jbGroupNo <> "") Then                                                                                                                  ' JB(3) ��, JB GRP NO ���� ������
       needProcessing = True
       selectedCellValue = wiringDiagramSheet.Range(CELL_ADDRESS_WIRING_DIAGRAM_JB_1)                                                                      ' JB-1 ��ũ�� �Է�
    ElseIf (jbGroupNo > 0) Then                                                                                                                            ' JB GRP NO�� ������
       needProcessing = True
       selectedCellValue = wiringDiagramSheet.Range(CELL_ADDRESS_WIRING_DIAGRAM_JB)                                                                        ' JB ��ũ�� �Է�
    End If
    
    If (needProcessing) Then                                                                                                                               ' ó�� �۾��� �ʿ��ϸ�
        localRowIndex = localRowIndex + 1
        clsCommon.SetSingleLine2AndCopyVariant localRowIndex, ioListDataRowIndex, workingSheet
        workingSheet.Cells(localRowIndex, Constants.COLUMN_INDEX_MACRO_NAME).value = selectedCellValue                                                     ' ���õ� ��ũ�� �Է�
    End If
    
    Process = localRowIndex
    
End Function
