Attribute VB_Name = "Constants"
Option Explicit

'================================================================================
' 컬럼 인덱스
'================================================================================
Public Const COLUMN_INDEX_MACRO_NAME As Long = 1                  ' 결과 시트 매크로 이름 컬럼
Public Const COLUMN_INDEX_PAGE_NAME  As Long = 9                  ' 결과 시트 페이지 넘버 컬럼
Public Const COLUMN_INDEX_SINGLE_LINE2 As Long = 10               ' 결과 시트 도면 유형(Single-line <2>) 컬럼
Public Const COLUMN_INDEX_VARIANT As Long = 11                    ' 결과 시트 매크로 유형(Variant) 컬럼

Public Const COLUMN_INDEX_FUNCTIONAL_ASSIGNMENT As Long = 2       ' 결과 시트 Functional assignment 컬럼
Public Const COLUMN_INDEX_HIGHER_LEVEL_FUNCTION As Long = 3       ' 결과 시트 Higher-level function 컬럼

Public Const IOLIST_COLUMN_INDEX_GET_DATA_COUNT As Long = 1       ' IO 시트 데이터 개수를 판단하는 No Column  위치

'================================================================================
' 행(ROW) 인덱스
'================================================================================
Public Const RESULT_ROW_INDEX_DATA_HEADER As Long = 1


'================================================================================
' 시트 이름
'================================================================================
Public Const DATA_SHEET_DATA1 As String = "Data1"
Public Const DATA_SHEET_TOTAL_AREAS As String = "Data2"
Public Const DATA_SHEET_WIRING_DIAGRAM As String = "Data3"

Public Const WIRING_TEMPLATE_SHEET As String = "Wiring@Template"
Public Const TOTALLOOP_TEMPLATE_SHEET As String = "TotalLoop@Template"

Public Const IOLIST_DATE_SHEET_FOR_WIRING As String = "Wiring@IOList"
Public Const IOLIST_DATE_SHEET_FOR_TOTALLOOP As String = "TotalLoop@IOList"


'================================================================================
' 기타 기본 값
'================================================================================
Public Const DEFAULT_ROW_NUMBER_PER_SHEET As Long = 65000
Public Const DEFAULT_MACRO_FOLDER As String = "C:\Users\Public\EPLAN\Data\매크로"


'================================================================================
' UI 라벨
'================================================================================
Public Const DEFAULT_LABEL_FOR_WIRING As String = "Wiring"
Public Const DEFAULT_LABEL_FOR_TOTALLOOP As String = "Total Loop"


'================================================================================
' 결과 시트 셀 기본 값
'================================================================================
Public Const HEADER_TEXT_TYPICAL_EEC As String = "TYPICAL EEC"
Public Const HEADER_TEXT_REPRESENTATION_TYPE As String = "Representation Type"
Public Const HEADER_TEXT_PAGE_NAME As String = "Page name"
Public Const HEADER_TEXT_VARIANT As String = "Variant"

Public Const CELL_VALUE_SPARE As String = "SPARE"
Public Const CELL_VALUE_SINGLE_LINE_2 As String = "Single-line <2>"


