VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
END
Attribute VB_Name = "ClsWiringProcessorTB1"
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
Private Const COLUMN_INDEX_TEXT_TB_GRP_NO            As String = "63"
Private Const COLUMN_INDEX_TEXT_TB_FUSE              As String = "204"
Private Const COLUMN_INDEX_TEXT_TB_DISCONNECT        As String = "205"
Private Const COLUMN_INDEX_TEXT_TB1_3                As String = "66"

'================================================================================
' ���� ������ ��Ʈ(DATA1, DATA2, DATA3) �� �ּ�
'================================================================================
Private Const CELL_ADDRESS_WIRING_DIAGRAM_TB_1       As String = "M5"             ' DATA3 ��Ʈ
Private Const CELL_ADDRESS_WIRING_DIAGRAM_FTB_1      As String = "M6"             ' DATA3 ��Ʈ
Private Const CELL_ADDRESS_WIRING_DIAGRAM_DTB        As String = "M7"             ' DATA3 ��Ʈ
Private Const CELL_ADDRESS_WIRING_DIAGRAM_TB1_1      As String = "O5"             ' DATA3 ��Ʈ

Private clsCommon As ClsWiringCommon
Private collectionExtension As ClsCollectionExtension

Private Sub Class_Initialize()

    'MsgBox "ProcessorTB1 Class is being initialized"
    
    Set clsCommon = New ClsWiringCommon
    Set collectionExtension = New ClsCollectionExtension
    
End Sub

Private Sub Class_Terminate()
    
    'MsgBox "ProcessorTB1 Class is being terminated"
    
    Set clsCommon = Nothing
    Set collectionExtension = Nothing

End Sub


'================================================================================================================================================================
' TB1 ó��
' ���� Row Index ���� ������ �ʿ��� ��쿡 +1 �ؼ� �۾�
' ���� �۾��� ���� Row Index ���� ���� ��
'================================================================================================================================================================
Public Function Process(rowIndex As Long, ioListDataRowIndex As Long, workingSheet As Worksheet, wiringDiagramSheet As Worksheet, cellValues As Collection) As Long

    Dim needProcessing    As Boolean                                                                                                        ' ���μ��� ����
    Dim localRowIndex     As Long
    Dim tbGroupNo         As Variant
    Dim tbFuse            As Variant
    Dim tbDisconnect      As Variant
    Dim tb13              As Variant
    Dim selectedCellValue As Variant                                                                                                        ' ���� ������� ���õ� DATA3 Cell ��
    
    needProcessing = False
    localRowIndex = rowIndex
    
    ''tbGroupNo = cellValues.Item(COLUMN_INDEX_TEXT_TB_GRP_NO)
    tbGroupNo = collectionExtension.TryGetValue(cellValues, COLUMN_INDEX_TEXT_TB_GRP_NO)                                 'BK, IO ��Ʈ�� ���� ��츦 ����Ͽ� Extension Method ���

    ''tbFuse = cellValues.Item(COLUMN_INDEX_TEXT_TB_FUSE)
    tbFuse = collectionExtension.TryGetValue(cellValues, COLUMN_INDEX_TEXT_TB_FUSE)                                      'GV, IO ��Ʈ�� ���� ��츦 ����Ͽ� Extension Method ���

    ''tbDisconnect = cellValues.Item(COLUMN_INDEX_TEXT_TB_DISCONNECT)
    tbDisconnect = collectionExtension.TryGetValue(cellValues, COLUMN_INDEX_TEXT_TB_DISCONNECT)                          'GW, IO ��Ʈ�� ���� ��츦 ����Ͽ� Extension Method ���

    ''tb13 = cellValues.Item(COLUMN_INDEX_TEXT_TB1_3)
    tb13 = collectionExtension.TryGetValue(cellValues, COLUMN_INDEX_TEXT_TB1_3)                                          'BN, IO ��Ʈ�� ���� ��츦 ����Ͽ� Extension Method ���
    
    If (tb13 > 0 And tbGroupNo <> "") Then                                                                                                  ' TB1-3 ��, TB GRP NO1 ���� ������
       needProcessing = True
       selectedCellValue = wiringDiagramSheet.Range(CELL_ADDRESS_WIRING_DIAGRAM_TB1_1)                                                      ' TB1-1 ��ũ�� �Է�
    ElseIf (tbDisconnect > 0) Then                                                                                                          ' TB_Disconnection ���� ������
       needProcessing = True
       selectedCellValue = wiringDiagramSheet.Range(CELL_ADDRESS_WIRING_DIAGRAM_DTB)                                                        ' DTB ��ũ�� �Է�
    ElseIf (tbFuse > 0) Then                                                                                                                ' TB_Fuse ���� ������
       needProcessing = True
       selectedCellValue = wiringDiagramSheet.Range(CELL_ADDRESS_WIRING_DIAGRAM_FTB_1)                                                      ' FTB1 ��ũ�� �Է�
    ElseIf (tbGroupNo > 0) Then                                                                                                             ' TB GRP NO1 ���� ������
       needProcessing = True
       selectedCellValue = wiringDiagramSheet.Range(CELL_ADDRESS_WIRING_DIAGRAM_TB_1)                                                       ' TB1 ��ũ�� �Է�
    End If
    
    If (needProcessing) Then                                                                                                                ' �۾��� �ʿ��ϸ�
        localRowIndex = localRowIndex + 1
        clsCommon.SetSingleLine2AndCopyVariant localRowIndex, ioListDataRowIndex, workingSheet
        workingSheet.Cells(localRowIndex, Constants.COLUMN_INDEX_MACRO_NAME).value = selectedCellValue                                      ' ���õ� ��ũ�� �Է�
    End If
    
    Process = localRowIndex
    
End Function
