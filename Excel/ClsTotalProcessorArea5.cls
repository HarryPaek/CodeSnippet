VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
END
Attribute VB_Name = "ClsTotalProcessorArea5"
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
Private Const COLUMN_INDEX_TEXT_MACRO_NAME             As String = "151"

'================================================================================
' 별도 데이터 시트(DATA1, DATA2, DATA3) 값 주소
'================================================================================
Private Const MACRO_INDEX_COLUMN_PREFIX_FOR_MAXRO      As String = "AJ"              ' DATA2 시트, 선택된 매크로를 가져오는 컬럼

Private clsCommon As ClsWiringCommon
Private collectionExtension As ClsCollectionExtension
Private cellValueAndMacroIndexMapping As Collection

Private Sub Class_Initialize()

    'MsgBox "ClsTotalProcessorArea1 Class is being initialized"
    
    Set clsCommon = New ClsWiringCommon
    Set collectionExtension = New ClsCollectionExtension
    
    InitializeMacroIndex
    
End Sub

Private Sub Class_Terminate()
    
    'MsgBox "ClsTotalProcessorArea1 Class is being terminated"
    
    Set clsCommon = Nothing
    Set collectionExtension = Nothing
    Set cellValueAndMacroIndexMapping = Nothing

End Sub


'================================================================================================================================================================
' AREA3 처리
' 받은 Row Index 값을 가지고 필요한 경우에 +1 해서 작업
' 현재 작업한 라인 Row Index 값을 돌려 줌
'================================================================================================================================================================
Public Function Process(rowIndex As Long, ioListDataRowIndex As Long, workingSheet As Worksheet, totalAreaSheet As Worksheet, cellValues As Collection) As Long

    Dim localRowIndex                As Long
    Dim selectedMacroRowIndex        As Variant
    
    Dim macroName                    As Variant
    Dim macroCellAddressText         As String
    
    localRowIndex = rowIndex
    
    ''macroName = cellValues.Item(COLUMN_INDEX_TEXT_MACRO_NAME)
    macroName = collectionExtension.TryGetValue(cellValues, COLUMN_INDEX_TEXT_MACRO_NAME)                          'EU, IO 시트에 없는 경우를 대비하여 Extension Method 사용
    selectedMacroRowIndex = collectionExtension.TryGetValue(cellValueAndMacroIndexMapping, macroName)              '해당 값이 없는 경우를 대비하여 Extension Method 사용
    
    If (selectedMacroRowIndex <> "" And selectedMacroRowIndex > 0) Then
        macroCellAddressText = MACRO_INDEX_COLUMN_PREFIX_FOR_MAXRO & selectedMacroRowIndex
    
        localRowIndex = localRowIndex + 1
        clsCommon.SetSingleLine2AndCopyVariant localRowIndex, ioListDataRowIndex, workingSheet
        workingSheet.Cells(localRowIndex, Constants.COLUMN_INDEX_MACRO_NAME).value = totalAreaSheet.Range(macroCellAddressText)                            ' 선택된 매크로 입력
    'Else
    '    If Trim(macroName) = "" Then
    '        macroName = "(공백)"
    '    End If
    '
    '    MsgBox "정렬 시트(결과시트 [" & ioListDataRowIndex & "]행)에 입력된 매크로 [" & macroName & "]은(는) Area5에 존재하지 않습니다."
    End If
    
    Process = localRowIndex
    
End Function


'================================================================================================================================================================
' AREA5 IO시트값 대비 매크로 이름 Row Index 초기화
'  - 매크로 이름과, Area5 해당 영역의 Row Index 값을 초기화 한다
'  - 사용할 때는 여기서 얻어지 값과 별도 Column Index을 조합하여 사용한다
'   -- 예) "DCS_TAG_AA01" => "AJ6"  ("AJ" + "6")가 됨
'
'================================================================================================================================================================
Private Sub InitializeMacroIndex()

    Set cellValueAndMacroIndexMapping = New Collection
    
    cellValueAndMacroIndexMapping.add Item:=6, key:="DCS_TAG_AA01"
    cellValueAndMacroIndexMapping.add Item:=7, key:="DCS_TAG_AA02"
    cellValueAndMacroIndexMapping.add Item:=8, key:="DCS_TAG_AA03"
    cellValueAndMacroIndexMapping.add Item:=9, key:="DCS_TAG_AA04"
    cellValueAndMacroIndexMapping.add Item:=10, key:="DCS_TAG_AA05"
    cellValueAndMacroIndexMapping.add Item:=11, key:="DCS_TAG_AA06"
    cellValueAndMacroIndexMapping.add Item:=12, key:="DCS_TAG_AA07"
    cellValueAndMacroIndexMapping.add Item:=13, key:="DCS_TAG_AA08"
    cellValueAndMacroIndexMapping.add Item:=14, key:="DCS_TAG_AA09"
    cellValueAndMacroIndexMapping.add Item:=15, key:="DCS_TAG_AA10"
    cellValueAndMacroIndexMapping.add Item:=16, key:="DCS_TAG_AB01"
    cellValueAndMacroIndexMapping.add Item:=17, key:="DCS_TAG_AB02"
    cellValueAndMacroIndexMapping.add Item:=18, key:="DCS_TAG_AB03"
    cellValueAndMacroIndexMapping.add Item:=19, key:="DCS_TAG_AB04"
    cellValueAndMacroIndexMapping.add Item:=20, key:="DCS_TAG_AB05"
    cellValueAndMacroIndexMapping.add Item:=21, key:="DCS_TAG_AB06"
    cellValueAndMacroIndexMapping.add Item:=22, key:="DCS_TAG_AB07"
    cellValueAndMacroIndexMapping.add Item:=23, key:="DCS_TAG_AB08"
    cellValueAndMacroIndexMapping.add Item:=24, key:="DCS_TAG_AB09"
    cellValueAndMacroIndexMapping.add Item:=25, key:="DCS_TAG_AB10"
    cellValueAndMacroIndexMapping.add Item:=26, key:="DCS_TAG_AC01"
    cellValueAndMacroIndexMapping.add Item:=27, key:="DCS_TAG_AC02"
    cellValueAndMacroIndexMapping.add Item:=28, key:="DCS_TAG_AC03"
    cellValueAndMacroIndexMapping.add Item:=29, key:="DCS_TAG_AC04"
    cellValueAndMacroIndexMapping.add Item:=30, key:="DCS_TAG_AC05"
    cellValueAndMacroIndexMapping.add Item:=31, key:="DCS_TAG_AC06"
    cellValueAndMacroIndexMapping.add Item:=32, key:="DCS_TAG_AC07"
    cellValueAndMacroIndexMapping.add Item:=33, key:="DCS_TAG_AC08"
    cellValueAndMacroIndexMapping.add Item:=34, key:="DCS_TAG_AC09"
    cellValueAndMacroIndexMapping.add Item:=35, key:="DCS_TAG_AC10"
    cellValueAndMacroIndexMapping.add Item:=36, key:="DCS_TAG_AD01"
    cellValueAndMacroIndexMapping.add Item:=37, key:="DCS_TAG_AD02"
    cellValueAndMacroIndexMapping.add Item:=38, key:="DCS_TAG_AD03"
    cellValueAndMacroIndexMapping.add Item:=39, key:="DCS_TAG_AD04"
    cellValueAndMacroIndexMapping.add Item:=40, key:="DCS_TAG_AD05"
    cellValueAndMacroIndexMapping.add Item:=41, key:="DCS_TAG_AD06"
    cellValueAndMacroIndexMapping.add Item:=42, key:="DCS_TAG_AD07"
    cellValueAndMacroIndexMapping.add Item:=43, key:="DCS_TAG_AD08"
    cellValueAndMacroIndexMapping.add Item:=44, key:="DCS_TAG_AD09"
    cellValueAndMacroIndexMapping.add Item:=45, key:="DCS_TAG_AD10"
    cellValueAndMacroIndexMapping.add Item:=46, key:="DCS_TAG_BA01"
    cellValueAndMacroIndexMapping.add Item:=47, key:="DCS_TAG_BA02"
    cellValueAndMacroIndexMapping.add Item:=48, key:="DCS_TAG_BA03"
    cellValueAndMacroIndexMapping.add Item:=49, key:="DCS_TAG_BA04"
    cellValueAndMacroIndexMapping.add Item:=50, key:="DCS_TAG_BA05"
    cellValueAndMacroIndexMapping.add Item:=51, key:="DCS_TAG_BA06"
    cellValueAndMacroIndexMapping.add Item:=52, key:="DCS_TAG_BA07"
    cellValueAndMacroIndexMapping.add Item:=53, key:="DCS_TAG_BA08"
    cellValueAndMacroIndexMapping.add Item:=54, key:="DCS_TAG_BA09"
    cellValueAndMacroIndexMapping.add Item:=55, key:="DCS_TAG_BA10"
    cellValueAndMacroIndexMapping.add Item:=56, key:="DCS_TAG_BA11"
    cellValueAndMacroIndexMapping.add Item:=57, key:="DCS_TAG_BA12"
    cellValueAndMacroIndexMapping.add Item:=58, key:="DCS_TAG_BA13"
    cellValueAndMacroIndexMapping.add Item:=59, key:="DCS_TAG_BA14"
    cellValueAndMacroIndexMapping.add Item:=60, key:="DCS_TAG_BB01"
    cellValueAndMacroIndexMapping.add Item:=61, key:="DCS_TAG_BB02"
    cellValueAndMacroIndexMapping.add Item:=62, key:="DCS_TAG_BB03"
    cellValueAndMacroIndexMapping.add Item:=63, key:="DCS_TAG_BB04"
    cellValueAndMacroIndexMapping.add Item:=64, key:="DCS_TAG_BB05"
    cellValueAndMacroIndexMapping.add Item:=65, key:="DCS_TAG_BB06"
    cellValueAndMacroIndexMapping.add Item:=66, key:="DCS_TAG_BB07"
    cellValueAndMacroIndexMapping.add Item:=67, key:="DCS_TAG_BB08"
    cellValueAndMacroIndexMapping.add Item:=68, key:="DCS_TAG_BB09"
    cellValueAndMacroIndexMapping.add Item:=69, key:="DCS_TAG_BB10"
    cellValueAndMacroIndexMapping.add Item:=70, key:="DCS_TAG_BC01"
    cellValueAndMacroIndexMapping.add Item:=71, key:="DCS_TAG_BC02"
    cellValueAndMacroIndexMapping.add Item:=72, key:="DCS_TAG_BC03"
    cellValueAndMacroIndexMapping.add Item:=73, key:="DCS_TAG_BC04"
    cellValueAndMacroIndexMapping.add Item:=74, key:="DCS_TAG_BC05"
    cellValueAndMacroIndexMapping.add Item:=75, key:="DCS_TAG_BC06"
    cellValueAndMacroIndexMapping.add Item:=76, key:="DCS_TAG_BC07"
    cellValueAndMacroIndexMapping.add Item:=77, key:="DCS_TAG_BC08"
    cellValueAndMacroIndexMapping.add Item:=78, key:="DCS_TAG_BC09"
    cellValueAndMacroIndexMapping.add Item:=79, key:="DCS_TAG_BC10"
    cellValueAndMacroIndexMapping.add Item:=80, key:="DCS_TAG_BD01"
    cellValueAndMacroIndexMapping.add Item:=81, key:="DCS_TAG_BD02"
    cellValueAndMacroIndexMapping.add Item:=82, key:="DCS_TAG_BD03"
    cellValueAndMacroIndexMapping.add Item:=83, key:="DCS_TAG_BD04"
    cellValueAndMacroIndexMapping.add Item:=84, key:="DCS_TAG_BD05"
    cellValueAndMacroIndexMapping.add Item:=85, key:="DCS_TAG_BD06"
    cellValueAndMacroIndexMapping.add Item:=86, key:="DCS_TAG_BD07"
    cellValueAndMacroIndexMapping.add Item:=87, key:="DCS_TAG_BD08"
    cellValueAndMacroIndexMapping.add Item:=88, key:="DCS_TAG_BD09"
    cellValueAndMacroIndexMapping.add Item:=89, key:="DCS_TAG_BD10"
    cellValueAndMacroIndexMapping.add Item:=90, key:="DCS_TAG_IN01"
    cellValueAndMacroIndexMapping.add Item:=91, key:="DCS_TAG_IN02"
    cellValueAndMacroIndexMapping.add Item:=92, key:="DCS_TAG_IN03"
    cellValueAndMacroIndexMapping.add Item:=93, key:="DCS_TAG_IN04"
    cellValueAndMacroIndexMapping.add Item:=94, key:="DCS_TAG_IN05"
    cellValueAndMacroIndexMapping.add Item:=95, key:="DCS_TAG_IN06"
    cellValueAndMacroIndexMapping.add Item:=96, key:="DCS_TAG_IN07"
    cellValueAndMacroIndexMapping.add Item:=97, key:="DCS_TAG_IN08"
    cellValueAndMacroIndexMapping.add Item:=98, key:="DCS_TAG_IN09"
    cellValueAndMacroIndexMapping.add Item:=99, key:="DCS_TAG_IN10"
    cellValueAndMacroIndexMapping.add Item:=100, key:="DCS_TAG_CO01"
    cellValueAndMacroIndexMapping.add Item:=101, key:="DCS_TAG_CO02"

End Sub


