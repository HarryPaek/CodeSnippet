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
' CellValues Collection 인덱스
'  - CellValues Collection의 값은 결과 시트 Column Number Text(예, "15")를 키 값으로하여 저장
'  - 아래에 정의할 때, 반드시 문자열로 정의할 것
'===== ===== ===== ================================================================================
Private Const COLUMN_INDEX_TEXT_PID_TAG              As String = "18"
Private Const COLUMN_INDEX_TEXT_TB3                  As String = "23"

'================================================================================
' 별도 데이터 시트(DATA1, DATA2, DATA3) 값 주소
'================================================================================
Private Const CELL_ADDRESS_WIRING_DIAGRAM_PID        As String = "C5"             ' DATA3 시트
Private Const CELL_ADDRESS_WIRING_DIAGRAM_PID_1      As String = "E5"             ' DATA3 시트

'================================================================================
' 결과 시트 셀에 배치하는 값들
' - 매크로 이름, 페이지 설명 등등
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
    Dim previousPageName             As Variant          '' 이전 IO Sheet Data Row의 페이지 번호
    Dim currentPageName              As Variant          '' 현재 IO Sheet Date Row의 페이지 번호
    Dim tagType                      As Variant
    Dim cellValues                   As Collection

   '================================================================================================================================================================
   ' 수집된 정렬 시트의 각 행을 처리
   '================================================================================================================================================================
    previousPageName = 0
    dataRowCount = cellValuesList.Count
    rowIndex = clsCommon.ROW_INDEX_TOTAL_RESULT_DATA_START
    
    progressBar.Max = dataRowCount
    progressBar.Show
    
    For dataIndex = 0 To dataRowCount - 1
        Set cellValues = cellValuesList.Item(dataIndex + 1)
        currentPageName = cellValues.Item(clsCommon.COLUMN_INDEX_TEXT_TOTAL_PAGE_NAME)
        
        '' 페이지가 바뀌고 현재 Row Index가 최대 허용 개수보다 많으면, 추가로 신규 시트 생성
        If (currentPageName <> previousPageName And rowIndex > maxNumberOfRowsPerSheet) Then
            clsCommon.SetBasicColumnsHeaderText workingSheet                                                                                     '기존 시트, 기본 Cell Header Text 값 복원
            
            Set workingSheet = clsCommon.CopyFromTemplate
            clsCommon.ClearBasicColumnsHeaderText workingSheet                                                                                   '신규 시트, 기본 Cell Header Text 값 삭제
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
' 정렬 시트에서 가져온 한 라인 데이터를 처리함
'
' 처리가 완료되면 다음 라인 데이터를 위한 Row Index를 리턴함
'================================================================================================================================================================
Private Function ProcessSingleRow(rowStartIndex As Long, dataIndex As Long, workingSheet As Worksheet, totalAreaSheet As Worksheet, _
                                  cellValues As Collection, columnMappingList As Collection, previousPageName As Variant) As Long
                                  
    Dim localRowIndex As Long                                                                                         ' 현재 라인을 처리하는 Row Index, +2 하여 리턴함
    
    localRowIndex = rowStartIndex                                                                                     '
    localRowIndex = SetPageMacroInfo(localRowIndex, dataIndex, workingSheet, cellValues, previousPageName)            ' 첫 라인에 페이지 매크로 및 관련 정보를 삽입
    
    CopyIOSheetDateToResultSheet localRowIndex, workingSheet, cellValues, columnMappingList                           ' IO Sheet 값을 복사
    SetBasicMacroAndProperty localRowIndex, dataIndex, workingSheet, totalAreaSheet, cellValues                       ' 기본 매크로, 페이지 No, Variant 및 속성을 설정함
    
    localRowIndex = ProcessInternal(localRowIndex, workingSheet, totalAreaSheet, cellValues)                          ' 현재 Row 처리
    
    ProcessSingleRow = localRowIndex + 2                                                                              ' 현재 작업중인 위치에 (공백 한 줄을 포함) +2하여 다음 데이터의 시작 위치로 리턴
    
End Function

Private Function ProcessInternal(ioListDataRowIndex As Long, workingSheet As Worksheet, totalAreaSheet As Worksheet, cellValues As Collection) As Long

    Dim localRowIndex As Long                                                                                                                               ' 현재 라인을 처리하는 Local Row Index
    localRowIndex = ioListDataRowIndex
    
    localRowIndex = locationBoxProcessor.Process(localRowIndex, ioListDataRowIndex, workingSheet, totalAreaSheet, cellValues)                               ' Location Box 프로세싱
    localRowIndex = area1Processor.Process(localRowIndex, ioListDataRowIndex, workingSheet, totalAreaSheet, cellValues)                                     ' Area1 프로세싱
    localRowIndex = area2Processor.Process(localRowIndex, ioListDataRowIndex, workingSheet, totalAreaSheet, cellValues)                                     ' Area2 프로세싱
    localRowIndex = area2TBProcessor.Process(localRowIndex, ioListDataRowIndex, workingSheet, totalAreaSheet, cellValues)                                   ' Area2-TB 프로세싱
    localRowIndex = area2RelayProcessor.Process(localRowIndex, ioListDataRowIndex, workingSheet, totalAreaSheet, cellValues)                                ' Area2-Relay Power 프로세싱
    localRowIndex = area3Processor.Process(localRowIndex, ioListDataRowIndex, workingSheet, totalAreaSheet, cellValues)                                     ' Area3 프로세싱
    localRowIndex = area5Processor.Process(localRowIndex, ioListDataRowIndex, workingSheet, totalAreaSheet, cellValues)                                     ' Area5 프로세싱
    
    ProcessInternal = localRowIndex
    
End Function


'================================================================================================================================================================
' 각 행의 IO 데이터에 대하여, 맨 처음라인에, 기본 매크로, 페이지 No, Variant 및 속성을 설정함
'================================================================================================================================================================
Private Function SetPageMacroInfo(rowIndex As Long, dataIndex As Long, workingSheet As Worksheet, cellValues As Collection, previousPageName As Variant) As Long
    Dim currentPageName           As Variant                                                                                                           ' 현재 IO Sheet Date Row의 페이지 번호
    Dim localRowIndex             As Long
    
    localRowIndex = rowIndex
                                     
    If (cellValues.Item(clsCommon.COLUMN_INDEX_TEXT_TOTAL_LOCATION1) <> "") Then                                                                       ' Location1에 값이 있으면
        currentPageName = cellValues.Item(clsCommon.COLUMN_INDEX_TEXT_TOTAL_PAGE_NAME)
        
        If (currentPageName <> previousPageName) Then                                                                                                  ' 페이지가 바뀔 때만 페이지 매크로 삽입
            workingSheet.Cells(localRowIndex, Constants.COLUMN_INDEX_MACRO_NAME).value = CELL_VALUE_PAGE_MACRO_NAME                                    ' Page Macro Name
            workingSheet.Cells(localRowIndex, Constants.COLUMN_INDEX_FUNCTIONAL_ASSIGNMENT).value = CELL_VALUE_FUNCTIONAL_ASSIGNMENT                   ' Functional assignment
            workingSheet.Cells(localRowIndex, Constants.COLUMN_INDEX_HIGHER_LEVEL_FUNCTION).value = CELL_VALUE_HIGHER_LEVEL_FUNCTION                   ' Higher-level function
            workingSheet.Cells(localRowIndex, Constants.COLUMN_INDEX_PAGE_NAME).value = cellValues.Item(clsCommon.COLUMN_INDEX_TEXT_TOTAL_PAGE_NAME)   ' Page Number Setting (Copy)
            workingSheet.Cells(localRowIndex, clsCommon.COLUMN_INDEX_TOTAL_PAGE_DESCRIPTION).value = CELL_VALUE_PAGE_DESCRIPTION                       ' 페이지 설명, Page Description
            localRowIndex = localRowIndex + 1
        End If
    End If
    
    SetPageMacroInfo = localRowIndex

End Function


'================================================================================================================================================================
' 두번째 라인에, 정렬 시트의 값을 결과 시트에 복사
'================================================================================================================================================================
Private Sub CopyIOSheetDateToResultSheet(rowIndex As Long, workingSheet As Worksheet, cellValues As Collection, columnMappingList As Collection)

    Dim columnMapping As ClsColumnMapping

    For Each columnMapping In columnMappingList
        workingSheet.Cells(rowIndex, columnMapping.TargetColumn).value = cellValues.Item(columnMapping.TargetColumnText)
    Next columnMapping

   Set columnMapping = Nothing

End Sub


'================================================================================================================================================================
' 복사한 IO 데이터에 대하여, 기본 매크로 및 속성을 설정함
'================================================================================================================================================================
Private Sub SetBasicMacroAndProperty(rowIndex As Long, dataIndex As Long, workingSheet As Worksheet, totalAreaSheet As Worksheet, cellValues As Collection)
                                     
    basicMacroSelector.Process rowIndex, workingSheet, totalAreaSheet, cellValues

End Sub



