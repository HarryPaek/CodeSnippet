VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
END
Attribute VB_Name = "ClsTotalProcessorLocationBox"
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
Private Const COLUMN_INDEX_TEXT_PAGE_NAME            As String = "9"
Private Const COLUMN_INDEX_TEXT_MACRO_VARIANT_TYPE   As String = "11"
Private Const COLUMN_INDEX_TEXT_COMP_NO_1            As String = "17"   '' 확인해서 유효한 값으로 정리할 것

'================================================================================
' 별도 데이터 시트(DATA1, DATA2, DATA3) 값 주소
'================================================================================
Private Const CELL_ADDRESS_TOTAL_AREA_PL_BOX_1       As String = "G38"            ' DATA2 시트
Private Const CELL_ADDRESS_TOTAL_AREA_PL_BOX_2       As String = "G39"            ' DATA2 시트
Private Const CELL_ADDRESS_TOTAL_AREA_PL_BOX_3       As String = "G40"            ' DATA2 시트

Private clsCommon As ClsWiringCommon
Private collectionExtension As ClsCollectionExtension

Private Sub Class_Initialize()

    'MsgBox "ClsTotalProcessorLocationBox Class is being initialized"
    
    Set clsCommon = New ClsWiringCommon
    Set collectionExtension = New ClsCollectionExtension
    
End Sub

Private Sub Class_Terminate()
    
    'MsgBox "ClsTotalProcessorLocationBox Class is being terminated"
    
    Set clsCommon = Nothing
    Set collectionExtension = Nothing

End Sub

'================================================================================================================================================================
' LOCATION BOX 페이지 상단 표시
' 받은 Row Index 값을 가지고 필요한 경우에 +1 해서 작업
' 현재 작업한 라인 Row Index 값을 돌려 줌
'================================================================================================================================================================
Public Function Process(rowIndex As Long, ioListDataRowIndex As Long, workingSheet As Worksheet, totalAreaSheet As Worksheet, cellValues As Collection) As Long

    Dim localRowIndex          As Long
    Dim macroVariantType       As Variant
    Dim pageName               As Variant
    Dim nextRowPageName        As Variant
    Dim compNo1                As Variant
    
    localRowIndex = rowIndex
    ' compNo1 = cellValues.Item(COLUMN_INDEX_TEXT_COMP_NO_1)
    compNo1 = collectionExtension.TryGetValue(cellValues, COLUMN_INDEX_TEXT_COMP_NO_1)                                   'Q, IO 시트에 없는 경우를 대비하여 Extension Method 사용
    
    macroVariantType = cellValues.Item(COLUMN_INDEX_TEXT_MACRO_VARIANT_TYPE)
    pageName = cellValues.Item(COLUMN_INDEX_TEXT_PAGE_NAME)
    nextRowPageName = workingSheet.Cells(ioListDataRowIndex + 1, Constants.COLUMN_INDEX_PAGE_NAME)                       'IO 시트 복사 값 다음 Row는 현재 작업할 Row가 (ioListDataRowIndex + 1) 됨
    
    '' ======================================================================================================================================
    '' 페이지가 바뀌는 상단에 모두 표시
    ''
    '' 2017년 8월, 다시 작성하면서 분석한 아래 내용
    ''
    ''  - 페이지가 변경되는지 여부를 판단하는 로직으로 보임. 그러나 이전(과거)처럼 먼저 공백을 삽입하는 경우에는 작동할 수 없는 로직임,
    ''   -- 실제 페이지 변경을 사용하는지 파악 필요함
    ''   -- 과거 코드는
    ''    -- If macroType = "A" And Cells(i, 9).Value <> Cells(i + 1, 9).Value And Cells(i, 17) <> "" Then
    ''
    ''  - 또 매크로 타입이 'A'이면 페이지가 변경되는 것이므로 결국 동일한 체크를 두 번 하는 결과임
    ''  - 그리고, (현재 제공된 예제 시트에서)17번째 컬럼(Q, Comp. No1)은 언제나 공백임
    ''  - 따라서 첫번째 로직은 현재 작동하는 경우를 발견하지 못함.
    ''
    '' ======================================================================================================================================
    
    If (macroVariantType = "A" And pageName <> nextRowPageName And compNo1 <> "") Then                                                                     ' 매크로 Variant "A", Comp No1에 값이 있으면
        localRowIndex = localRowIndex + 1
        workingSheet.Cells(localRowIndex, Constants.COLUMN_INDEX_MACRO_NAME).value = totalAreaSheet.Range(CELL_ADDRESS_TOTAL_AREA_PL_BOX_1)                ' PL_BOX1 매크로 입력
        clsCommon.SetSingleLine2AndCopyVariant localRowIndex, ioListDataRowIndex, workingSheet
    End If
    
    If (macroVariantType = "A" And pageName <> nextRowPageName) Then                                                                                       ' 매크로 Variant "A"
        localRowIndex = localRowIndex + 1
        workingSheet.Cells(localRowIndex, Constants.COLUMN_INDEX_MACRO_NAME).value = totalAreaSheet.Range(CELL_ADDRESS_TOTAL_AREA_PL_BOX_3)                ' PL_BOX3 매크로 입력
        clsCommon.SetSingleLine2AndCopyVariant localRowIndex, ioListDataRowIndex, workingSheet
        
        localRowIndex = localRowIndex + 1
        workingSheet.Cells(localRowIndex, Constants.COLUMN_INDEX_MACRO_NAME).value = totalAreaSheet.Range(CELL_ADDRESS_TOTAL_AREA_PL_BOX_2)                ' PL_BOX2 매크로 입력
        clsCommon.SetSingleLine2AndCopyVariant localRowIndex, ioListDataRowIndex, workingSheet
    End If
    
    Process = localRowIndex
    
End Function

