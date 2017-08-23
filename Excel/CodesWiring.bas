Attribute VB_Name = "CodesWiring"
Option Explicit

Sub Exceute(workingSheet As Worksheet, iOSheetFileFullPath As String, maxNumberOfRowsPerSheet As Long)
    
    Dim wiringProcessorFactory As ClsWiringProcessorFactory
    Dim clsCommon As ClsWiringCommon
    Dim columnMappingList As Collection                           ' Collection은 Index = 1에서 시작, 접근 시 주의할 것
    Dim columnMapping As ClsColumnMapping                         ' 타겟(결과) 시트 셀 컬럼값을 키로 접근함.
    
    Dim rowIndex As Long
    Dim dataRowCount As Long
    Dim cellValues As Collection
    Dim cellValuesList As Collection
        
    Dim workingSheetFirstRow As Range                             ' 통합파일 첫 행의 문자를 넣을 변수
    Dim workingSheetCell As Range                                 ' 통합파일 첫 행 각 셀을 넣을 변수
    
    Dim ioSheetWorkBook As Workbook                               ' 정렬 시트(데이터 파일)를 넣을 변수
    Dim ioSheetDataSheet As Worksheet                             ' 정렬 시트(데이터 시트)를 넣을 변수
    Dim ioSheetFirstRow As Range                                  ' 데이터 파일 첫 행의 문자를 넣을 변수
    Dim ioSheetCell As Range                                      ' 데이터 파일 첫 행 각 셀을 넣을 변수
    Dim ioSheetColumnData As Range                                ' 데이터 파일내 한 컬럼의 전체 Row 데이터를 넣을 변수
    Dim wiringDiagramSheet As Worksheet                           ' DATA_SHEET_WIRING_DIAGRAM
    
    
    Set clsCommon = New ClsWiringCommon
    clsCommon.ClearBasicColumnsHeaderText workingSheet                                                               '작업 시트, 기본 Cell Header Text 값 삭제
    
    workingSheet.UsedRange.Offset(1).ClearContents                                                                   '기존 데이터 삭제
    Set workingSheetFirstRow = workingSheet.Rows(1).SpecialCells(xlCellTypeConstants)                                '통합파일 첫 행의 문자를 변수에 넣음
    
    Set ioSheetWorkBook = Workbooks.Open(iOSheetFileFullPath)                                                        '파일을 열고 개체변수에 넣음
    Set ioSheetDataSheet = ioSheetWorkBook.ActiveSheet                                                               '데이터 파일에서 실제 데이터가 있는 시트
    Set ioSheetFirstRow = ioSheetDataSheet.Rows(1).SpecialCells(xlCellTypeConstants)                                 '데이터 파일 첫 행의 문자를 변수에 넣음
    Set ioSheetColumnData = ioSheetDataSheet.Range(Cells(clsCommon.ROW_INDEX_WIRING_IOLIST_DATA_START, _
                                                         Constants.IOLIST_COLUMN_INDEX_GET_DATA_COUNT), _
                                                   Cells(ioSheetDataSheet.Rows.Count, _
                                                         Constants.IOLIST_COLUMN_INDEX_GET_DATA_COUNT).End(xlUp))    'IO Sheet 데이터의 갯수를 파악하기 위해 영역을 판단

   '================================================================================================================================================================
   ' 정렬 시트와 결과 시트의 Column Mapping을 columnMappingList에 저장
   '================================================================================================================================================================
    Set columnMappingList = New Collection
    
    For Each workingSheetCell In workingSheetFirstRow.Cells                                                          '통합파일 첫 행 각 셀을 순환
        For Each ioSheetCell In ioSheetFirstRow.Cells                                                                '데이터 파일 첫 행 각 셀을 순환
            If workingSheetCell = ioSheetCell Then                                                                   '두 데이터가 일치하면
                
                Set columnMapping = New ClsColumnMapping
                columnMapping.ColumnDescription = ioSheetCell
                columnMapping.TargetColumn = workingSheetCell.Column
                columnMapping.SourceColumn = ioSheetCell.Column
                
                columnMappingList.add columnMapping
                Set columnMapping = Nothing
                
                Exit For                                                                                             ' 일치하는 값을 찾으면 다음 workingSheetCell로
            End If
        Next ioSheetCell
    Next workingSheetCell
    
   '================================================================================================================================================================
   ' 정렬 시트 값을 cellValuesList에 저장
   '================================================================================================================================================================
    Set cellValuesList = New Collection
    dataRowCount = ioSheetColumnData.Rows.Count
    
    For rowIndex = 0 To dataRowCount - 1
        Set cellValues = New Collection
        
        For Each columnMapping In columnMappingList
            cellValues.add Item:=ioSheetDataSheet.Cells(clsCommon.ROW_INDEX_WIRING_IOLIST_DATA_START + rowIndex, columnMapping.SourceColumn).value, key:=columnMapping.TargetColumnText
        Next columnMapping
        
        cellValuesList.add cellValues
        Set cellValues = Nothing
    Next rowIndex
        
    ioSheetWorkBook.Close False                                                                                  '원본 파일을 저장없이 닫음

   '================================================================================================================================================================
   ' 수집된 정렬 시트의 각 행을 처리
   '================================================================================================================================================================
    Set wiringDiagramSheet = Worksheets(Constants.DATA_SHEET_WIRING_DIAGRAM)
    Set wiringProcessorFactory = New ClsWiringProcessorFactory
    
    Set workingSheet = wiringProcessorFactory.Process(workingSheet, wiringDiagramSheet, cellValuesList, columnMappingList, maxNumberOfRowsPerSheet)

    clsCommon.SetBasicColumnsHeaderText workingSheet                                                             ' 작업 시트, 기본 Cell Header Text 값 복원

    Set wiringProcessorFactory = Nothing                                                                         ' 개체변수(들) 초기화(메모리 비우기)
    Set wiringDiagramSheet = Nothing                                                                             ' 개체변수(들) 초기화(메모리 비우기)
    Set cellValues = Nothing                                                                                     ' 개체변수(들) 초기화(메모리 비우기)
    Set cellValuesList = Nothing                                                                                 ' 개체변수(들) 초기화(메모리 비우기)
    
    Set columnMapping = Nothing                                                                                  ' 개체변수(들) 초기화(메모리 비우기)
    Set columnMappingList = Nothing                                                                              ' 개체변수(들) 초기화(메모리 비우기)
    
    Set ioSheetCell = Nothing                                                                                    ' 개체변수(들) 초기화(메모리 비우기)
    Set workingSheetCell = Nothing                                                                               ' 개체변수(들) 초기화(메모리 비우기)
    
    Set ioSheetColumnData = Nothing                                                                              ' 개체변수(들) 초기화(메모리 비우기)
    Set ioSheetFirstRow = Nothing                                                                                ' 개체변수(들) 초기화(메모리 비우기)
    Set ioSheetDataSheet = Nothing                                                                               ' 개체변수(들) 초기화(메모리 비우기)
    Set ioSheetWorkBook = Nothing                                                                                ' 개체변수(들) 초기화(메모리 비우기)
    Set workingSheetFirstRow = Nothing                                                                           ' 개체변수(들) 초기화(메모리 비우기)
    Set clsCommon = Nothing                                                                                      ' 개체변수(들) 초기화(메모리 비우기)

End Sub

