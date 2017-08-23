VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
END
Attribute VB_Name = "ClsTotalBasicMacroSelector"
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
Private Const COLUMN_INDEX_TEXT_TAG_TYPE             As String = "178"

'================================================================================
' 별도 데이터 시트(DATA1, DATA2, DATA3) 값 주소
'================================================================================

' TAG TYPE CHECK          AM6 ~ AM48
' TAG TYPE에 따른 매크로  AN6 ~ AN48
Private Const TAG_TYPE_CHECK_ROW_INDEX_START                    As Long = 6                   ' DATA2 시트, Tag Type이 정의된 Row 시작 인덱스
Private Const TAG_TYPE_CHECK_ROW_INDEX_END                      As Long = 48                  ' DATA2 시트, Tag Type이 정의된 Row 마지막 인덱스

Private Const TAG_TYPE_CHECK_COLUMN_PREFIX_TO_COMPARE           As String = "AM"              ' DATA2 시트, Tag Type 값을 비교하는 컬럼
Private Const TAG_TYPE_CHECK_COLUMN_PREFIX_FOR_MAXRO            As String = "AN"              ' DATA2 시트, 선택된 매크로를 가져오는 컬럼

Private clsCommon As ClsTotalCommon
Private collectionExtension As ClsCollectionExtension

Private Sub Class_Initialize()

    'MsgBox "ClsTotalBasicMacroSelector Class is being initialized"
    
    Set clsCommon = New ClsTotalCommon
    Set collectionExtension = New ClsCollectionExtension
    
End Sub

Private Sub Class_Terminate()
    
    'MsgBox "ClsTotalBasicMacroSelector Class is being terminated"
    
    Set clsCommon = Nothing
    Set collectionExtension = Nothing

End Sub


'================================================================================================================================================================
' 복사한 IO 데이터에 대하여, 기본 매크로 및 속성을 설정함
'================================================================================================================================================================
Public Sub Process(rowIndex As Long, workingSheet As Worksheet, totalAreaSheet As Worksheet, cellValues As Collection)

    Dim tagType                      As Variant
    Dim tagTypeTotalAreaSheetValue   As Variant                               ' 비교 대상으로 선택된 DATA2 Cell 값 (TAG TYPE)
    Dim totalAreaRowIndex            As Long
    Dim compareCellAddressText       As String
    Dim macroCellAddressText         As String
    Dim inStrResult                  As Integer                               ' InStr 비교한 결과 값

    
    '' tagType = cellValues.Item(COLUMN_INDEX_TEXT_TAG_TYPE)
    tagType = collectionExtension.TryGetValue(cellValues, COLUMN_INDEX_TEXT_TAG_TYPE)                                    'FV, IO 시트에 없는 경우를 대비하여 Extension Method 사용
    
    '===========================================================================================================================
    ' 중요!!!
    ' 단순 문자열 비교(InStr)이므로, "AA"에서 "A"가 선택되지 않도록 아래에서 위(긴 문자열에서 짧은 문자열) 방향으로 비교함
    '===========================================================================================================================
    For totalAreaRowIndex = TAG_TYPE_CHECK_ROW_INDEX_END To TAG_TYPE_CHECK_ROW_INDEX_START Step -1
    
        compareCellAddressText = TAG_TYPE_CHECK_COLUMN_PREFIX_TO_COMPARE & totalAreaRowIndex                                                 ' 비교 대상 Cell 주소,  AMxx
        macroCellAddressText = TAG_TYPE_CHECK_COLUMN_PREFIX_FOR_MAXRO & totalAreaRowIndex                                                    ' 선택된 매크로 Cell 주소, ANxx
        
        tagTypeTotalAreaSheetValue = totalAreaSheet.Range(compareCellAddressText)
        inStrResult = InStr(tagType, tagTypeTotalAreaSheetValue)
    
        ' 문자열이 존재하는지 비교
        If inStrResult > 0 Then                                                                                                              ' 비교 결과, 해당 문자열이 존재하는 경우
            workingSheet.Cells(rowIndex, Constants.COLUMN_INDEX_MACRO_NAME).value = totalAreaSheet.Range(macroCellAddressText)               ' 선택된 매크로 입력
            clsCommon.SetSingleLine2 rowIndex, workingSheet
            
            Exit For                                                                                                                         ' 일치한 값이 발견되면, 여기서 종료
        End If

    Next totalAreaRowIndex
    
End Sub

