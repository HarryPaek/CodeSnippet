VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
END
Attribute VB_Name = "ClsTotalProcessorFactory"
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
Private Const CELL_VALUE_PAGE_MACRO_NAME             As String = "PAGE\Empty_Page_Loop"
Private Const CELL_VALUE_FUNCTIONAL_ASSIGNMENT       As String = "TOTAL_LOOP_DIAGRAM"
Private Const CELL_VALUE_HIGHER_LEVEL_FUNCTION       As String = "TOTAL_LOOP"
Private Const CELL_VALUE_PAGE_DESCRIPTION            As String = "Total Loop Diagram"

Private progressBar                                  As ClsProgressBar
Private clsCommon                                    As ClsTotalCommon
Private basicMacroSelector                           As ClsTotalBasicMacroSelector
Private locationBoxProcessor                         As ClsTotalProcessorLocationBox
Private area1Processor                               As ClsTotalProcessorArea1
Private area2Processor                               As ClsTotalProcessorArea2
Private area2TBProcessor                             As ClsTotalProcessorArea2TB
Private area2RelayProcessor                          As ClsTotalProcessorArea2Relay
Private area3Processor                               As ClsTotalProcessorArea3
Private area5Processor                               As ClsTotalProcessorArea5


Private Sub Class_Initialize()

    'MsgBox "ClsTotalProcessorFactory Class is being initialized"
    
    Set progressBar = New ClsProgressBar
    Set clsCommon = New ClsTotalCommon
    Set basicMacroSelector = New ClsTotalBasicMacroSelector
    Set locationBoxProcessor = New ClsTotalProcessorLocationBox
    Set area1Processor = New ClsTotalProcessorArea1
    Set area2Processor = New ClsTotalProcessorArea2
    Set area2TBProcessor = New ClsTotalProcessorArea2TB
    Set area2RelayProcessor = New ClsTotalProcessorArea2Relay
    Set area3Processor = New ClsTotalProcessorArea3
    Set area5Processor = New ClsTotalProcessorArea5

End Sub


Private Sub Class_Terminate()
    
    'MsgBox "ClsTotalProcessorFactory Class is being terminated"
    
    Set progressBar = Nothing
    Set clsCommon = Nothing
    Set basicMacroSelector = Nothing
    Set locationBoxProcessor = Nothing
    Set area1Processor = Nothing
    Set area2Processor = Nothing
    Set area2TBProcessor = Nothing
    Set area2RelayProcessor = Nothing
    Set area3Processor = Nothing
    Set area5Processor = Nothing

End Sub

Public Function Process(workingSheet As Worksheet, totalAreaSheet As Worksheet, cellValuesList As Collection, columnMappingList As Collection, maxNumberOfRowsPerSheet As Long) As Worksheet
    
    Dim rowIndex                     As Long
    Dim dataIndex                    As Long
    Dim dataRowCount                 As Long
    Dim previousPageName             As Variant          '' ���� IO Sheet Data Row�� ������ ��ȣ
    Dim currentPageName              As Variant          '' ���� IO Sheet Date Row�� ������ ��ȣ
    Dim tagType                      As Variant
    Dim cellValues                   As Collection

   '================================================================================================================================================================
   ' ������ ���� ��Ʈ�� �� ���� ó��
   '================================================================================================================================================================
    previousPageName = 0
    dataRowCount = cellValuesList.Count
    rowIndex = clsCommon.ROW_INDEX_TOTAL_RESULT_DATA_START
    
    progressBar.Max = dataRowCount
    progressBar.Show
    
    For dataIndex = 0 To dataRowCount - 1
        Set cellValues = cellValuesList.Item(dataIndex + 1)
        currentPageName = cellValues.Item(clsCommon.COLUMN_INDEX_TEXT_TOTAL_PAGE_NAME)
        
        '' �������� �ٲ�� ���� Row Index�� �ִ� ��� �������� ������, �߰��� �ű� ��Ʈ ����
        If (currentPageName <> previousPageName And rowIndex > maxNumberOfRowsPerSheet) Then
            clsCommon.SetBasicColumnsHeaderText workingSheet                                                                                     '���� ��Ʈ, �⺻ Cell Header Text �� ����
            
            Set workingSheet = clsCommon.CopyFromTemplate
            clsCommon.ClearBasicColumnsHeaderText workingSheet                                                                                   '�ű� ��Ʈ, �⺻ Cell Header Text �� ����
            rowIndex = clsCommon.ROW_INDEX_TOTAL_RESULT_DATA_START
        End If
    
        rowIndex = ProcessSingleRow(rowIndex, dataIndex, workingSheet, totalAreaSheet, cellValues, columnMappingList, previousPageName)
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
Private Function ProcessSingleRow(rowStartIndex As Long, dataIndex As Long, workingSheet As Worksheet, totalAreaSheet As Worksheet, _
                                  cellValues As Collection, columnMappingList As Collection, previousPageName As Variant) As Long
                                  
    Dim localRowIndex As Long                                                                                         ' ���� ������ ó���ϴ� Row Index, +2 �Ͽ� ������
    
    localRowIndex = rowStartIndex                                                                                     '
    localRowIndex = SetPageMacroInfo(localRowIndex, dataIndex, workingSheet, cellValues, previousPageName)            ' ù ���ο� ������ ��ũ�� �� ���� ������ ����
    
    CopyIOSheetDateToResultSheet localRowIndex, workingSheet, cellValues, columnMappingList                           ' IO Sheet ���� ����
    SetBasicMacroAndProperty localRowIndex, dataIndex, workingSheet, totalAreaSheet, cellValues                       ' �⺻ ��ũ��, ������ No, Variant �� �Ӽ��� ������
    
    localRowIndex = ProcessInternal(localRowIndex, workingSheet, totalAreaSheet, cellValues)                          ' ���� Row ó��
    
    ProcessSingleRow = localRowIndex + 2                                                                              ' ���� �۾����� ��ġ�� (���� �� ���� ����) +2�Ͽ� ���� �������� ���� ��ġ�� ����
    
End Function

Private Function ProcessInternal(ioListDataRowIndex As Long, workingSheet As Worksheet, totalAreaSheet As Worksheet, cellValues As Collection) As Long

    Dim localRowIndex As Long                                                                                                                               ' ���� ������ ó���ϴ� Local Row Index
    localRowIndex = ioListDataRowIndex
    
    localRowIndex = locationBoxProcessor.Process(localRowIndex, ioListDataRowIndex, workingSheet, totalAreaSheet, cellValues)                               ' Location Box ���μ���
    localRowIndex = area1Processor.Process(localRowIndex, ioListDataRowIndex, workingSheet, totalAreaSheet, cellValues)                                     ' Area1 ���μ���
    localRowIndex = area2Processor.Process(localRowIndex, ioListDataRowIndex, workingSheet, totalAreaSheet, cellValues)                                     ' Area2 ���μ���
    localRowIndex = area2TBProcessor.Process(localRowIndex, ioListDataRowIndex, workingSheet, totalAreaSheet, cellValues)                                   ' Area2-TB ���μ���
    localRowIndex = area2RelayProcessor.Process(localRowIndex, ioListDataRowIndex, workingSheet, totalAreaSheet, cellValues)                                ' Area2-Relay Power ���μ���
    localRowIndex = area3Processor.Process(localRowIndex, ioListDataRowIndex, workingSheet, totalAreaSheet, cellValues)                                     ' Area3 ���μ���
    localRowIndex = area5Processor.Process(localRowIndex, ioListDataRowIndex, workingSheet, totalAreaSheet, cellValues)                                     ' Area5 ���μ���
    
    ProcessInternal = localRowIndex
    
End Function


'================================================================================================================================================================
' �� ���� IO �����Ϳ� ���Ͽ�, �� ó�����ο�, �⺻ ��ũ��, ������ No, Variant �� �Ӽ��� ������
'================================================================================================================================================================
Private Function SetPageMacroInfo(rowIndex As Long, dataIndex As Long, workingSheet As Worksheet, cellValues As Collection, previousPageName As Variant) As Long
    Dim currentPageName           As Variant                                                                                                           ' ���� IO Sheet Date Row�� ������ ��ȣ
    Dim localRowIndex             As Long
    
    localRowIndex = rowIndex
                                     
    If (cellValues.Item(clsCommon.COLUMN_INDEX_TEXT_TOTAL_LOCATION1) <> "") Then                                                                       ' Location1�� ���� ������
        currentPageName = cellValues.Item(clsCommon.COLUMN_INDEX_TEXT_TOTAL_PAGE_NAME)
        
        If (currentPageName <> previousPageName) Then                                                                                                  ' �������� �ٲ� ���� ������ ��ũ�� ����
            workingSheet.Cells(localRowIndex, Constants.COLUMN_INDEX_MACRO_NAME).value = CELL_VALUE_PAGE_MACRO_NAME                                    ' Page Macro Name
            workingSheet.Cells(localRowIndex, Constants.COLUMN_INDEX_FUNCTIONAL_ASSIGNMENT).value = CELL_VALUE_FUNCTIONAL_ASSIGNMENT                   ' Functional assignment
            workingSheet.Cells(localRowIndex, Constants.COLUMN_INDEX_HIGHER_LEVEL_FUNCTION).value = CELL_VALUE_HIGHER_LEVEL_FUNCTION                   ' Higher-level function
            workingSheet.Cells(localRowIndex, Constants.COLUMN_INDEX_PAGE_NAME).value = cellValues.Item(clsCommon.COLUMN_INDEX_TEXT_TOTAL_PAGE_NAME)   ' Page Number Setting (Copy)
            workingSheet.Cells(localRowIndex, clsCommon.COLUMN_INDEX_TOTAL_PAGE_DESCRIPTION).value = CELL_VALUE_PAGE_DESCRIPTION                       ' ������ ����, Page Description
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
' ������ IO �����Ϳ� ���Ͽ�, �⺻ ��ũ�� �� �Ӽ��� ������
'================================================================================================================================================================
Private Sub SetBasicMacroAndProperty(rowIndex As Long, dataIndex As Long, workingSheet As Worksheet, totalAreaSheet As Worksheet, cellValues As Collection)
                                     
    basicMacroSelector.Process rowIndex, workingSheet, totalAreaSheet, cellValues

End Sub


