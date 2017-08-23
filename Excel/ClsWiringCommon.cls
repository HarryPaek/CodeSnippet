VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
END
Attribute VB_Name = "ClsWiringCommon"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = False
Option Explicit

Private Const INTERNAL_ROW_INDEX_IOLIST_DATA_START                  As Long = 2
Private Const INTERNAL_ROW_INDEX_RESULT_DATA_START                  As Long = 2
Private Const INTERNAL_NUMBER_OF_DATA_PER_WIRING_DRAWING_PAGE       As Long = 16
Private Const INTERNAL_COLUMN_INDEX_WIRING_PAGE_DESCRIPTION         As Long = 157            ' 결과 시트 Page Description 컬럼

'===== ===== ===== ================================================================================
' CellValues Collection 인덱스
'  - CellValues Collection의 값은 결과 시트 Column Number Text(예, "15")를 키 값으로하여 저장
'  - 아래에 정의할 때, 반드시 문자열로 정의할 것
'===== ===== ===== ================================================================================
Private Const INTERNAL_COLUMN_INDEX_TEXT_WIRING_PAGE_NAME           As String = "9"          ' 복사된 CellValues Collection의 Page Name 컬럼
Private Const INTERNAL_COLUMN_INDEX_TEXT_WIRING_LOCATION1           As String = "15"         ' 복사된 CellValues Collection의 Location1 컬럼


Private eplanVariantList As Variant

Private Sub Class_Initialize()

    eplanVariantList = Array("A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P")
    
End Sub

Private Sub Class_Terminate()
    
    Set eplanVariantList = Nothing

End Sub

Public Property Get ROW_INDEX_WIRING_IOLIST_DATA_START() As Long

    ROW_INDEX_WIRING_IOLIST_DATA_START = INTERNAL_ROW_INDEX_IOLIST_DATA_START
    
End Property

Public Property Get ROW_INDEX_WIRING_RESULT_DATA_START() As Long

    ROW_INDEX_WIRING_RESULT_DATA_START = INTERNAL_ROW_INDEX_RESULT_DATA_START
    
End Property

Public Property Get NUMBER_OF_DATA_PER_WIRING_DRAWING_PAGE() As Long

    NUMBER_OF_DATA_PER_WIRING_DRAWING_PAGE = INTERNAL_NUMBER_OF_DATA_PER_WIRING_DRAWING_PAGE
    
End Property

Public Property Get COLUMN_INDEX_TEXT_WIRING_PAGE_NAME() As String

    COLUMN_INDEX_TEXT_WIRING_PAGE_NAME = INTERNAL_COLUMN_INDEX_TEXT_WIRING_PAGE_NAME
    
End Property

Public Property Get COLUMN_INDEX_TEXT_WIRING_LOCATION1() As String

    COLUMN_INDEX_TEXT_WIRING_LOCATION1 = INTERNAL_COLUMN_INDEX_TEXT_WIRING_LOCATION1
    
End Property

Public Property Get COLUMN_INDEX_WIRING_PAGE_DESCRIPTION() As Long

    COLUMN_INDEX_WIRING_PAGE_DESCRIPTION = INTERNAL_COLUMN_INDEX_WIRING_PAGE_DESCRIPTION
    
End Property

'================================================================================================================================================================
' 유틸리티 함수
'  - 데이터 인덱스 값을 이용하여 이용하여 페이지 넘버 생성
'================================================================================================================================================================
Public Function ToPageNumber(dataRowIndex As Long) As String

    ToPageNumber = Utilities.ToString((dataRowIndex \ INTERNAL_NUMBER_OF_DATA_PER_WIRING_DRAWING_PAGE) + 1)
    
End Function


'================================================================================================================================================================
' 유틸리티 함수
'  - 데이터 인덱스 값을 이용하여 Variant 값 생성
'================================================================================================================================================================
Public Function ToVariantText(dataRowIndex As Long) As String
   
   ToVariantText = eplanVariantList(dataRowIndex Mod INTERNAL_NUMBER_OF_DATA_PER_WIRING_DRAWING_PAGE)
   
End Function


'================================================================================================================================================================
' 유틸리티 함수
'  - Single-Line 2 값을 설정하고 Variant 값을 Copy
'================================================================================================================================================================
Public Sub SetSingleLine2AndCopyVariant(rowIndex As Long, ioListDataRowIndex As Long, workingSheet As Worksheet)

    SetSingleLine2 rowIndex, workingSheet
    CopyVariant rowIndex, ioListDataRowIndex, workingSheet

End Sub


'================================================================================================================================================================
' 유틸리티 함수
'  - Single-Line 2 값을 설정하고 Variant 값을 주어진 파라미터 값으로 설정
'================================================================================================================================================================
Public Sub SetSingleLine2AndVariantValue(rowIndex As Long, ioListDataRowIndex As Long, variantValue As String, workingSheet As Worksheet)

    SetSingleLine2 rowIndex, workingSheet
    SetVariantValue rowIndex, variantValue, workingSheet

End Sub


'================================================================================================================================================================
' 유틸리티 함수
'  - Single-Line 2 값 설정
'================================================================================================================================================================
Public Sub SetSingleLine2(rowIndex As Long, workingSheet As Worksheet)

    workingSheet.Cells(rowIndex, Constants.COLUMN_INDEX_SINGLE_LINE2).value = Constants.CELL_VALUE_SINGLE_LINE_2

End Sub


'================================================================================================================================================================
' 유틸리티 함수
'  - Variant 값 Copy
'================================================================================================================================================================
Public Sub CopyVariant(rowIndex As Long, ioListDataRowIndex As Long, workingSheet As Worksheet)

    workingSheet.Cells(ioListDataRowIndex, Constants.COLUMN_INDEX_VARIANT).Copy workingSheet.Cells(rowIndex, Constants.COLUMN_INDEX_VARIANT)                 ' Variant 값을 ioList 복사 값에서 Copy

End Sub


'================================================================================================================================================================
' 유틸리티 함수
'  - Variant 값 설정
'================================================================================================================================================================
Public Sub SetVariantValue(rowIndex As Long, variantValue As String, workingSheet As Worksheet)

    workingSheet.Cells(rowIndex, Constants.COLUMN_INDEX_VARIANT).value = variantValue                                                                        ' 주어진 값으로 Variant 값 설정

End Sub


Sub ClearBasicColumnsHeaderText(workingSheet As Worksheet)

    workingSheet.Cells(Constants.RESULT_ROW_INDEX_DATA_HEADER, Constants.COLUMN_INDEX_MACRO_NAME).value = ""    ' (1, 1),  "A1"  TYPICAL EEC 삭제
    workingSheet.Cells(Constants.RESULT_ROW_INDEX_DATA_HEADER, Constants.COLUMN_INDEX_PAGE_NAME).value = ""     ' (1, 9),  "A9"  PAGE NAME 삭제
    workingSheet.Cells(Constants.RESULT_ROW_INDEX_DATA_HEADER, Constants.COLUMN_INDEX_SINGLE_LINE2).value = ""  ' (1, 10), "A10" 페이지 유형(Representation Type) 삭제
    workingSheet.Cells(Constants.RESULT_ROW_INDEX_DATA_HEADER, Constants.COLUMN_INDEX_VARIANT).value = ""       ' (1, 11), "A11" VARIANT 삭제

End Sub


Sub SetBasicColumnsHeaderText(workingSheet As Worksheet)

    workingSheet.Cells(Constants.RESULT_ROW_INDEX_DATA_HEADER, Constants.COLUMN_INDEX_MACRO_NAME).value = Constants.HEADER_TEXT_TYPICAL_EEC            ' (1, 1),  "A1" "TYPICAL EEC" 설정
    workingSheet.Cells(Constants.RESULT_ROW_INDEX_DATA_HEADER, Constants.COLUMN_INDEX_PAGE_NAME).value = Constants.HEADER_TEXT_PAGE_NAME               ' (1, 9),  "A9"  PAGE NAME 설정
    workingSheet.Cells(Constants.RESULT_ROW_INDEX_DATA_HEADER, Constants.COLUMN_INDEX_SINGLE_LINE2).value = Constants.HEADER_TEXT_REPRESENTATION_TYPE  ' (1, 10), "A10" Representation Type 설정
    workingSheet.Cells(Constants.RESULT_ROW_INDEX_DATA_HEADER, Constants.COLUMN_INDEX_VARIANT).value = Constants.HEADER_TEXT_VARIANT                   ' (1, 11), "A11" VARIANT 설정

End Sub


Public Function CopyFromTemplate() As Worksheet
    
    Const sourceTemplate As String = Constants.WIRING_TEMPLATE_SHEET
    Dim targetSheetPrefix As String
    
    targetSheetPrefix = "Wiring"
    Set CopyFromTemplate = Utilities.CopyTemplateToNewSheet(sourceTemplate, targetSheetPrefix)

End Function

