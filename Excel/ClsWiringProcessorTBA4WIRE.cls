VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
END
Attribute VB_Name = "ClsWiringProcessorTBA4WIRE"
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
Private Const COLUMN_INDEX_TEXT_4WIRE_TBD_PLUS                  As String = "100"

'================================================================================
' ���� ������ ��Ʈ(DATA1, DATA2, DATA3) �� �ּ�
'================================================================================
Private Const CELL_ADDRESS_WIRING_DIAGRAM_4WIRE_CN_NO_AA46      As String = "AA46"            ' DATA3 ��Ʈ

Private Const CELL_ADDRESS_WIRING_DIAGRAM_4WIRE_MACRO           As String = "AD46"            ' DATA3 ��Ʈ

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
' FCS ó��
' ���� Row Index ���� ������ �ʿ��� ��쿡 +1 �ؼ� �۾�
' ���� �۾��� ���� Row Index ���� ���� ��
'================================================================================================================================================================
Public Function Process(rowIndex As Long, ioListDataRowIndex As Long, workingSheet As Worksheet, wiringDiagramSheet As Worksheet, cellValues As Collection) As Long

    Dim localRowIndex              As Long
    Dim tba4WireTbdPlus            As Variant
    Dim tba4WireDiagramSheetValue  As Variant                                                                                                              ' WIRING DIAGRAM (Data3) ��Ʈ ��
    Dim inStrResult                As Integer                                                                                                              ' InStr ���� ��� ��
    Dim selectedCellValue          As Variant                                                                                                              ' ���� ������� ���õ� DATA3 Cell ��
    
    localRowIndex = rowIndex

    ''tba4WireTbdPlus = cellValues.Item(COLUMN_INDEX_TEXT_4WIRE_TBD_PLUS)
    tba4WireTbdPlus = collectionExtension.TryGetValue(cellValues, COLUMN_INDEX_TEXT_4WIRE_TBD_PLUS)                      'CV, IO ��Ʈ�� ���� ��츦 ����Ͽ� Extension Method ���

    tba4WireDiagramSheetValue = wiringDiagramSheet.Range(CELL_ADDRESS_WIRING_DIAGRAM_4WIRE_CN_NO_AA46)
    selectedCellValue = wiringDiagramSheet.Range(CELL_ADDRESS_WIRING_DIAGRAM_4WIRE_MACRO)
    
    inStrResult = InStr(tba4WireTbdPlus, tba4WireDiagramSheetValue)
    
    ' ���ڿ��� �����ϴ��� ��
    If inStrResult > 0 Then                                                                                                                  ' B Ȯ��
        localRowIndex = localRowIndex + 1
        workingSheet.Cells(localRowIndex, Constants.COLUMN_INDEX_MACRO_NAME).value = selectedCellValue                                       ' ���õ� ��ũ�� �Է�
        clsCommon.SetSingleLine2AndCopyVariant localRowIndex, ioListDataRowIndex, workingSheet
    
    End If
    
    Process = localRowIndex
    
End Function

