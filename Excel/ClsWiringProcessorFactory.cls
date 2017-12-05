VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
END
Attribute VB_Name = "ClsWiringProcessorFactory"
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
Private Const COLUMN_INDEX_TEXT_PID_TAG              As String = "18"
Private Const COLUMN_INDEX_TEXT_TB3                  As String = "23"

'================================================================================
' ���� ������ ��Ʈ(DATA1, DATA2, DATA3) �� �ּ�
'================================================================================
Private Const CELL_ADDRESS_WIRING_DIAGRAM_PID        As String = "C5"             ' DATA3 ��Ʈ
Private Const CELL_ADDRESS_WIRING_DIAGRAM_PID_1      As String = "E5"             ' DATA3 ��Ʈ

'================================================================================
' ��� ��Ʈ ���� ��ġ�ϴ� ����
' - ��ũ�� �̸�, ������ ���� ���
'================================================================================
Private Const CELL_VALUE_PAGE_MACRO_NAME             As String = "PAGE\Empty_Page_Wiring"
Private Const CELL_VALUE_FUNCTIONAL_ASSIGNMENT       As String = "WIRING_DIAGRAM"
Private Const CELL_VALUE_HIGHER_LEVEL_FUNCTION       As String = "WIRING"
Private Const CELL_VALUE_PAGE_DESCRIPTION            As String = "Wiring Diagram"

Private progressBar                                  As ClsProgressBar
Private clsCommon                                    As ClsWiringCommon
Private collectionExtension                          As ClsCollectionExtension

Private jbProcessor                                  As ClsWiringProcessorJB
Private tb1Processor                                 As ClsWiringProcessorTB1
Private tb2Processor                                 As ClsWiringProcessorTB2

Private tb3Processor                                 As ClsWiringProcessorTB3
Private ry1Processor                                 As ClsWiringProcessorRY1
Private saProcessor                                  As ClsWiringProcessorSA
Private tbaProcessor                                 As ClsWiringProcessorTBA
Private fcsProcessor                                 As ClsWiringProcessorFCS
Private tba4WireProcessor                            As ClsWiringProcessorTBA4WIRE


Private Sub Class_Initialize()

    'MsgBox "WiringProcessorFactory Class is being initialized"
    
    Set progressBar = New ClsProgressBar
    Set clsCommon = New ClsWiringCommon
    Set collectionExtension = New ClsCollectionExtension

    Set jbProcessor = New ClsWiringProcessorJB
    Set tb1Processor = New ClsWiringProcessorTB1
    Set tb2Processor = New ClsWiringProcessorTB2
    
    Set tb3Processor = New ClsWiringProcessorTB3
    Set ry1Processor = New ClsWiringProcessorRY1
    Set saProcessor = New ClsWiringProcessorSA
    Set tbaProcessor = New ClsWiringProcessorTBA
    Set fcsProcessor = New ClsWiringProcessorFCS
    Set tba4WireProcessor = New ClsWiringProcessorTBA4WIRE

End Sub


Private Sub Class_Terminate()
    
    'MsgBox "WiringProcessorFactory Class is being terminated"
    
    Set progressBar = Nothing
    Set clsCommon = Nothing
    Set collectionExtension = Nothing

    Set jbProcessor = Nothing
    Set tb1Processor = Nothing
    Set tb2Processor = Nothing
    
    Set tb3Processor = Nothing
    Set ry1Processor = Nothing
    Set saProcessor = Nothing
    Set tbaProcessor = Nothing
    Set fcsProcessor = Nothing
    Set tba4WireProcessor = Nothing

End Sub

Public Function Process(workingSheet As Worksheet, wiringDiagramSheet As Worksheet, cellValuesList As Collection, columnMappingList As Collection, maxNumberOfRowsPerSheet As Long) As Worksheet
    
    Dim rowIndex As Long
    Dim dataIndex As Long
    Dim dataRowCount As Long
    Dim previousPageName             As Variant          '' ���� IO Sheet Data Row�� ������ ��ȣ
    Dim currentPageName              As Variant          '' ���� IO Sheet Date Row�� ������ ��ȣ
    Dim cellValues As Collection

   '================================================================================================================================================================
   ' ������ ���� ��Ʈ�� �� ���� ó��
   '================================================================================================================================================================
    previousPageName = 0
    dataRowCount = cellValuesList.Count
    rowIndex = clsCommon.ROW_INDEX_WIRING_RESULT_DATA_START
    
    progressBar.Max = dataRowCount
    progressBar.Show
    
    For dataIndex = 0 To dataRowCount - 1
        Set cellValues = cellValuesList.Item(dataIndex + 1)
        currentPageName = clsCommon.ToPageNumber(dataIndex)                                                                ' Page Number ���
        
        '' �������� �ٲ�� ���� Row Index�� �ִ� ��� �������� ������, �߰��� �ű� ��Ʈ ����
        If (currentPageName <> previousPageName And rowIndex > maxNumberOfRowsPerSheet) Then
            clsCommon.SetBasicColumnsHeaderText workingSheet                                                               '���� ��Ʈ, �⺻ Cell Header Text �� ����
            
            Set workingSheet = clsCommon.CopyFromTemplate
            clsCommon.ClearBasicColumnsHeaderText workingSheet                                                             '�ű� ��Ʈ, �⺻ Cell Header Text �� ����
            rowIndex = clsCommon.ROW_INDEX_WIRING_RESULT_DATA_START
        End If

        rowIndex = ProcessSingleRow(rowIndex, dataIndex, workingSheet, wiringDiagramSheet, cellValues, columnMappingList, previousPageName)
        previousPageName = currentPageName
        
        Set cellValues = Nothing
        progressBar.value = dataIndex + 1
        DoEvents
    Next dataIndex

    progressBar.Hide
    Set Process = workingSheet
    
End Function


'================================================================================================================================================================
' ���� ��Ʈ���� ������ �� ���� �����͸� ó����
'
' ó���� �Ϸ�Ǹ� ���� ���� �����͸� ���� Row Index�� ������
'================================================================================================================================================================
Private Function ProcessSingleRow(rowStartIndex As Long, dataIndex As Long, workingSheet As Worksheet, wiringDiagramSheet As Worksheet, _
                                  cellValues As Collection, columnMappingList As Collection, previousPageName As Variant) As Long
                                  
    Dim localRowIndex As Long                                                                                         ' ���� ������ ó���ϴ� Row Index, +2 �Ͽ� ������
    
    localRowIndex = rowStartIndex                                                                                     '
    localRowIndex = SetPageMacroInfo(localRowIndex, dataIndex, workingSheet, cellValues, previousPageName)            ' ù ���ο� ������ ��ũ�� �� ���� ������ ����
    
    CopyIOSheetDateToResultSheet localRowIndex, workingSheet, cellValues, columnMappingList                           ' IO Sheet ���� ����
    SetBasicMacroAndProperty localRowIndex, dataIndex, workingSheet, wiringDiagramSheet, cellValues                   ' �⺻ ��ũ��, ������ No, Variant �� �Ӽ��� ������
    
    localRowIndex = ProcessInternal(localRowIndex, workingSheet, wiringDiagramSheet, cellValues)                      ' ���� Row ó��
    
    ProcessSingleRow = localRowIndex + 2                                                                              ' ���� �۾����� ��ġ�� (���� �� ���� ����) +2�Ͽ� ���� �������� ���� ��ġ�� ����
    
End Function

Private Function ProcessInternal(ioListDataRowIndex As Long, workingSheet As Worksheet, wiringDiagramSheet As Worksheet, cellValues As Collection) As Long

    Dim localRowIndex As Long                                                                                                           ' ���� ������ ó���ϴ� Local Row Index
    localRowIndex = ioListDataRowIndex
    
    localRowIndex = jbProcessor.Process(localRowIndex, ioListDataRowIndex, workingSheet, wiringDiagramSheet, cellValues)                ' JB ���μ���
    localRowIndex = tb1Processor.Process(localRowIndex, ioListDataRowIndex, workingSheet, wiringDiagramSheet, cellValues)               ' TB1 ���μ���
    localRowIndex = tb2Processor.Process(localRowIndex, ioListDataRowIndex, workingSheet, wiringDiagramSheet, cellValues)               ' TB2 ���μ���

    localRowIndex = tb3Processor.Process(localRowIndex, ioListDataRowIndex, workingSheet, wiringDiagramSheet, cellValues)               ' TB3 ���μ���
    localRowIndex = ry1Processor.Process(localRowIndex, ioListDataRowIndex, workingSheet, wiringDiagramSheet, cellValues)               ' RY1 ���μ���
    localRowIndex = saProcessor.Process(localRowIndex, ioListDataRowIndex, workingSheet, wiringDiagramSheet, cellValues)                ' SA1/SA2 ���μ���
    localRowIndex = tbaProcessor.Process(localRowIndex, ioListDataRowIndex, workingSheet, wiringDiagramSheet, cellValues)               ' TBA  ���μ���
    localRowIndex = fcsProcessor.Process(localRowIndex, ioListDataRowIndex, workingSheet, wiringDiagramSheet, cellValues)               ' FCS  ���μ���
    localRowIndex = tba4WireProcessor.Process(localRowIndex, ioListDataRowIndex, workingSheet, wiringDiagramSheet, cellValues)          ' TBA 4-Wire ���μ���
    
    ProcessInternal = localRowIndex
    
End Function


'================================================================================================================================================================
' �� ���� IO �����Ϳ� ���Ͽ�, �� ó�����ο�, �⺻ ��ũ��, ������ No, Variant �� �Ӽ��� ������
'================================================================================================================================================================
Private Function SetPageMacroInfo(rowIndex As Long, dataIndex As Long, workingSheet As Worksheet, cellValues As Collection, previousPageName As Variant) As Long
    Dim currentPageName           As Variant                                                                                                     ' ���� IO Sheet Date Row�� ������ ��ȣ
    Dim localRowIndex             As Long
    
    localRowIndex = rowIndex
                                     
    If (cellValues.Item(clsCommon.COLUMN_INDEX_TEXT_WIRING_LOCATION1) <> "") Then                                                                ' Location1�� ���� ������
        currentPageName = clsCommon.ToPageNumber(dataIndex)                                                                                      ' ���� ������ �ѹ� ���
        
        If (currentPageName <> previousPageName) Then                                                                                            ' �������� �ٲ� ���� ������ ��ũ�� ����
            workingSheet.Cells(localRowIndex, Constants.COLUMN_INDEX_MACRO_NAME).value = CELL_VALUE_PAGE_MACRO_NAME                              ' Page Macro Name
            workingSheet.Cells(localRowIndex, Constants.COLUMN_INDEX_FUNCTIONAL_ASSIGNMENT).value = CELL_VALUE_FUNCTIONAL_ASSIGNMENT             ' Functional assignment
            workingSheet.Cells(localRowIndex, Constants.COLUMN_INDEX_HIGHER_LEVEL_FUNCTION).value = CELL_VALUE_HIGHER_LEVEL_FUNCTION             ' Higher-level function
            workingSheet.Cells(localRowIndex, Constants.COLUMN_INDEX_PAGE_NAME).value = currentPageName                                          ' Page Number Setting
            workingSheet.Cells(localRowIndex, clsCommon.COLUMN_INDEX_WIRING_PAGE_DESCRIPTION).value = CELL_VALUE_PAGE_DESCRIPTION                ' ������ ����, Page Description
            localRowIndex = localRowIndex + 1
        End If
    End If
    
    SetPageMacroInfo = localRowIndex

End Function


'================================================================================================================================================================
' �ι�° ���ο�, ���� ��Ʈ�� ���� ��� ��Ʈ�� ����
'================================================================================================================================================================
Private Sub CopyIOSheetDateToResultSheet(rowIndex As Long, workingSheet As Worksheet, cellValues As Collection, columnMappingList As Collection)

    Dim columnMapping As ClsColumnMapping

    For Each columnMapping In columnMappingList
        workingSheet.Cells(rowIndex, columnMapping.TargetColumn).value = cellValues.Item(columnMapping.TargetColumnText)
    Next columnMapping

   Set columnMapping = Nothing

End Sub


'================================================================================================================================================================
' ������ IO �����Ϳ� ���Ͽ�, �⺻ ��ũ��, ������ No, Variant �� �Ӽ��� ������
'================================================================================================================================================================
Private Sub SetBasicMacroAndProperty(rowIndex As Long, dataIndex As Long, workingSheet As Worksheet, wiringDiagramSheet As Worksheet, cellValues As Collection)

    Dim pidTag                     As Variant
    Dim tb3                        As Variant
                                     
    ' 1. Page Number, Variant
    workingSheet.Cells(rowIndex, Constants.COLUMN_INDEX_PAGE_NAME).value = clsCommon.ToPageNumber(dataIndex)                                                 ' Page Number Setting
    workingSheet.Cells(rowIndex, Constants.COLUMN_INDEX_VARIANT).value = clsCommon.ToVariantText(dataIndex)                                                  ' Eplan Variant �� �Է�
    
    ''pidTag = cellValues.Item(COLUMN_INDEX_TEXT_PID_TAG)
    pidTag = collectionExtension.TryGetValue(cellValues, COLUMN_INDEX_TEXT_PID_TAG)                                          'R, IO ��Ʈ�� ���� ��츦 ����Ͽ� Extension Method ���

    ''tb3 = cellValues.Item(COLUMN_INDEX_TEXT_TB3)
    tb3 = collectionExtension.TryGetValue(cellValues, COLUMN_INDEX_TEXT_TB3)                                                 'W, IO ��Ʈ�� ���� ��츦 ����Ͽ� Extension Method ���

    ' 2. �⺻ ��ũ�� ��
    If (pidTag > 0 And tb3 > 0) Then                                                                                                                         ' P&ID TAG �� TB3 ���� ������
        workingSheet.Cells(rowIndex, Constants.COLUMN_INDEX_MACRO_NAME).value = wiringDiagramSheet.Range(CELL_ADDRESS_WIRING_DIAGRAM_PID_1)                  ' PID-1 ��ũ�� �Է�
        workingSheet.Cells(rowIndex, Constants.COLUMN_INDEX_SINGLE_LINE2).value = Constants.CELL_VALUE_SINGLE_LINE_2
    
    ElseIf (pidTag > 0) Then                                                                                                                                 ' P&ID TAG�� ������
        workingSheet.Cells(rowIndex, Constants.COLUMN_INDEX_MACRO_NAME).value = wiringDiagramSheet.Range(CELL_ADDRESS_WIRING_DIAGRAM_PID)                    ' PID ��ũ�� �Է�
        workingSheet.Cells(rowIndex, Constants.COLUMN_INDEX_SINGLE_LINE2).value = Constants.CELL_VALUE_SINGLE_LINE_2
    
    ElseIf (pidTag = "") Then
        workingSheet.Cells(rowIndex, Constants.COLUMN_INDEX_MACRO_NAME).value = ""                                                                           ' Constants.CELL_VALUE_SPARE
        
    End If

End Sub
