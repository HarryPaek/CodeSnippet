VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
END
Attribute VB_Name = "ClsWiringProcessorTB2"
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
Private Const COLUMN_INDEX_TEXT_TB_GRP_NO2           As String = "75"
Private Const COLUMN_INDEX_TEXT_TB2_3                As String = "78"

'================================================================================
' ���� ������ ��Ʈ(DATA1, DATA2, DATA3) �� �ּ�
'================================================================================
Private Const CELL_ADDRESS_WIRING_DIAGRAM_TB_2       As String = "Q5"             ' DATA3 ��Ʈ
Private Const CELL_ADDRESS_WIRING_DIAGRAM_TB2_1      As String = "S5"             ' DATA3 ��Ʈ

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
' TB2 ó��
' ���� Row Index ���� ������ �ʿ��� ��쿡 +1 �ؼ� �۾�
' ���� �۾��� ���� Row Index ���� ���� ��
'================================================================================================================================================================
Public Function Process(rowIndex As Long, ioListDataRowIndex As Long, workingSheet As Worksheet, wiringDiagramSheet As Worksheet, cellValues As Collection) As Long

    Dim needProcessing    As Boolean                                                                                                                       ' ���μ��� ����
    Dim localRowIndex     As Long
    Dim tbGroupNo2        As Variant
    Dim tb23              As Variant
    Dim selectedCellValue As Variant                                                                                                                       ' ���� ������� ���õ� DATA3 Cell ��
    
    needProcessing = False
    localRowIndex = rowIndex
    
    ''tbGroupNo2 = cellValues.Item(COLUMN_INDEX_TEXT_TB_GRP_NO2)
    tbGroupNo2 = collectionExtension.TryGetValue(cellValues, COLUMN_INDEX_TEXT_TB_GRP_NO2)                               'BW, IO ��Ʈ�� ���� ��츦 ����Ͽ� Extension Method ���

    ''tb23 = cellValues.Item(COLUMN_INDEX_TEXT_TB2_3)
    tb23 = collectionExtension.TryGetValue(cellValues, COLUMN_INDEX_TEXT_TB2_3)                                          'BZ, IO ��Ʈ�� ���� ��츦 ����Ͽ� Extension Method ���
    
    If (tb23 > 0 And tbGroupNo2 <> "") Then                                                                                                                ' TB2-3 ��, TB GRP NO2 ���� ������
       needProcessing = True
       selectedCellValue = wiringDiagramSheet.Range(CELL_ADDRESS_WIRING_DIAGRAM_TB2_1)                                                                     ' TB2-1 ��ũ�� �Է�
    ElseIf (tbGroupNo2 > 0) Then                                                                                                                           ' TB GRP NO2�� ������
       needProcessing = True
       selectedCellValue = wiringDiagramSheet.Range(CELL_ADDRESS_WIRING_DIAGRAM_TB_2)                                                                      ' TB2 ��ũ�� �Է�
    End If
    
    If (needProcessing) Then                                                                                                                               ' ó�� �۾��� �ʿ��ϸ�
        localRowIndex = localRowIndex + 1
        clsCommon.SetSingleLine2AndCopyVariant localRowIndex, ioListDataRowIndex, workingSheet
        workingSheet.Cells(localRowIndex, Constants.COLUMN_INDEX_MACRO_NAME).value = selectedCellValue                                                     ' ���õ� ��ũ�� �Է�
    End If
    
    Process = localRowIndex
    
End Function
