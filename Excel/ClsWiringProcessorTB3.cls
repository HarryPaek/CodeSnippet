VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
END
Attribute VB_Name = "ClsWiringProcessorTB3"
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
Private Const COLUMN_INDEX_TEXT_TB_GRP_NO3           As String = "87"
Private Const COLUMN_INDEX_TEXT_TB3_3                As String = "90"

'================================================================================
' ���� ������ ��Ʈ(DATA1, DATA2, DATA3) �� �ּ�
'================================================================================
Private Const CELL_ADDRESS_WIRING_DIAGRAM_TB_3       As String = "U5"             ' DATA3 ��Ʈ
Private Const CELL_ADDRESS_WIRING_DIAGRAM_TB3_1      As String = "W5"             ' DATA3 ��Ʈ

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
' TB3 ó��
' ���� Row Index ���� ������ �ʿ��� ��쿡 +1 �ؼ� �۾�
' ���� �۾��� ���� Row Index ���� ���� ��
'================================================================================================================================================================
Public Function Process(rowIndex As Long, ioListDataRowIndex As Long, workingSheet As Worksheet, wiringDiagramSheet As Worksheet, cellValues As Collection) As Long

    Dim needProcessing    As Boolean                                                                                                                          ' ���μ��� ����
    Dim localRowIndex     As Long
    Dim tbGroupNo3        As Variant
    Dim tb33              As Variant
    Dim selectedCellValue As Variant                                                                                                                       ' ���� ������� ���õ� DATA3 Cell ��
    
    needProcessing = False
    localRowIndex = rowIndex

    ''tbGroupNo3 = cellValues.Item(COLUMN_INDEX_TEXT_TB_GRP_NO3)
    tbGroupNo3 = collectionExtension.TryGetValue(cellValues, COLUMN_INDEX_TEXT_TB_GRP_NO3)                               'CI, IO ��Ʈ�� ���� ��츦 ����Ͽ� Extension Method ���

    ''tb33 = cellValues.Item(COLUMN_INDEX_TEXT_TB3_3)
    tb33 = collectionExtension.TryGetValue(cellValues, COLUMN_INDEX_TEXT_TB3_3)                                          'CL, IO ��Ʈ�� ���� ��츦 ����Ͽ� Extension Method ���
    
    If (tb33 > 0 And tbGroupNo3 <> "") Then                                                                                                                ' TB3-3 ��, TB GRP NO3 ���� ������
       needProcessing = True
       selectedCellValue = wiringDiagramSheet.Range(CELL_ADDRESS_WIRING_DIAGRAM_TB3_1)                                                                     ' TB3-1 ��ũ�� �Է�
    ElseIf (tbGroupNo3 > 0) Then                                                                                                                           ' TB GRP NO3�� ������
       needProcessing = True
       selectedCellValue = wiringDiagramSheet.Range(CELL_ADDRESS_WIRING_DIAGRAM_TB_3)                                                                      ' TB3 ��ũ�� �Է�
    End If
    
    If (needProcessing) Then                                                                                                                               ' ó�� �۾��� �ʿ��ϸ�
        localRowIndex = localRowIndex + 1
        clsCommon.SetSingleLine2AndCopyVariant localRowIndex, ioListDataRowIndex, workingSheet
        workingSheet.Cells(localRowIndex, Constants.COLUMN_INDEX_MACRO_NAME).value = selectedCellValue                                                     ' ���õ� ��ũ�� �Է�
    End If
    
    Process = localRowIndex
    
End Function

