VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
END
Attribute VB_Name = "ClsWiringProcessorFCS"
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
Private Const COLUMN_INDEX_TEXT_FCS_CNA                         As String = "103"
Private Const COLUMN_INDEX_TEXT_FCS_CNB                         As String = "104"
Private Const COLUMN_INDEX_TEXT_FCS_CN_NO                       As String = "138"
Private Const COLUMN_INDEX_TEXT_FCS_NEST                        As String = "141"

'================================================================================
' 별도 데이터 시트(DATA1, DATA2, DATA3) 값 주소
'================================================================================
Private Const CELL_ADDRESS_WIRING_DIAGRAM_FCS_CNA_1SLOT         As String = "AK5"             ' DATA3 시트
Private Const CELL_ADDRESS_WIRING_DIAGRAM_FCS_CNA_1SLOT_RIO     As String = "AK37"            ' DATA3 시트
Private Const CELL_ADDRESS_WIRING_DIAGRAM_FCS_CNB_2SLOT         As String = "AK6"             ' DATA3 시트
Private Const CELL_ADDRESS_WIRING_DIAGRAM_FCS_CNB_2SLOT_RIO     As String = "AK38"            ' DATA3 시트

Private Const CELL_ADDRESS_WIRING_DIAGRAM_1SLOT_MACRO           As String = "AL5"             ' DATA3 시트
Private Const CELL_ADDRESS_WIRING_DIAGRAM_1SLOT_RIO_MACRO       As String = "AL37"            ' DATA3 시트
Private Const CELL_ADDRESS_WIRING_DIAGRAM_2SLOT_MACRO           As String = "AL6"             ' DATA3 시트
Private Const CELL_ADDRESS_WIRING_DIAGRAM_2SLOT_RIO_MACRO       As String = "AL38"            ' DATA3 시트


' FCS 공통 2~16 Point
' FCS 공통 18~32 Point
Private Const FCS_COMMON_ROW_INDEX_START                        As Long = 7                   ' DATA3 시트, Common을 비교하는 Row 시작 인덱스
Private Const FCS_COMMON_ROW_INDEX_END                          As Long = 36                  ' DATA3 시트, Common을 비교하는 Row 마지막 인덱스

Private Const FCS_COMMON_COLUMN_PREFIX_CN_NO_COMPARE            As String = "AK"              ' DATA3 시트, CN NO 값을 비교하는 컬럼
Private Const FCS_COMMON_COLUMN_PREFIX_WIRING_MACRO             As String = "AL"              ' DATA3 시트, Wiring 매크로를 가져오는 컬럼


Private clsCommon As ClsWiringCommon

Private Sub Class_Initialize()

    Set clsCommon = New ClsWiringCommon
    
End Sub

Private Sub Class_Terminate()
    
    Set clsCommon = Nothing

End Sub


'================================================================================================================================================================
' FCS 처리
' 받은 Row Index 값을 가지고 필요한 경우에 +1 해서 작업
' 현재 작업한 라인 Row Index 값을 돌려 줌
'================================================================================================================================================================
Public Function Process(rowIndex As Long, ioListDataRowIndex As Long, workingSheet As Worksheet, wiringDiagramSheet As Worksheet, cellValues As Collection) As Long

    Dim needProcessing             As Boolean                                                                                                              ' 프로세싱 여부
    Dim localRowIndex              As Long
    Dim fcsCNA                     As Variant
    Dim fcsCNB                     As Variant
    Dim fcsCNNo                    As Variant
    Dim fcsNest                    As Variant
    
    Dim fcsWiringDiagramRowIndex   As Long
    Dim selectedCellValue          As Variant                                                                                                              ' 복사 대상으로 선택된 DATA3 Cell 값
    Dim variantIndex               As Long
    Dim variantIndexText           As String
    Dim compareCellAddressText     As String
    Dim macroCellAddressText       As String

    
    needProcessing = False
    localRowIndex = rowIndex
    fcsCNA = cellValues.Item(COLUMN_INDEX_TEXT_FCS_CNA)
    fcsCNNo = cellValues.Item(COLUMN_INDEX_TEXT_FCS_CN_NO)
    fcsNest = cellValues.Item(COLUMN_INDEX_TEXT_FCS_NEST)
    fcsCNB = cellValues.Item(COLUMN_INDEX_TEXT_FCS_CNB)
    
    variantIndex = 1                                                                                     '  Variant 유형 "B"에서 시작
        
    ' FCS 공통 2~16, 18~32
    For fcsWiringDiagramRowIndex = FCS_COMMON_ROW_INDEX_START To FCS_COMMON_ROW_INDEX_END
    
       compareCellAddressText = FCS_COMMON_COLUMN_PREFIX_CN_NO_COMPARE & fcsWiringDiagramRowIndex        '  비교 대상 Cell 주소,  AKxx
       macroCellAddressText = FCS_COMMON_COLUMN_PREFIX_WIRING_MACRO & fcsWiringDiagramRowIndex           '  Wiring 매크로 Cell 주소, ALxx
       
       If (fcsCNNo = wiringDiagramSheet.Range(compareCellAddressText)) Then                              ' 현재 값과 DATA3에서 CNxx(CN2~16, CN18~32) 값과 비교해서 일치하는 경우
           needProcessing = True
           selectedCellValue = wiringDiagramSheet.Range(macroCellAddressText)
           variantIndexText = clsCommon.ToVariantText(variantIndex)
           
           ' MsgBox "Variant Index =[" & variantIndex & "], variantIndexText = [" & variantIndexText & "]"

           Exit For                                                                                      ' 일치되는 경우 현재 값을 저장하고 바로 For Loop 종료
       End If
       
       variantIndex = variantIndex + 1                                                                   ' 다음 Variant 유형으로
       
       If (variantIndex Mod clsCommon.NUMBER_OF_DATA_PER_WIRING_DRAWING_PAGE = 0) Then                   ' Variant "A"(16, 32, 48, ...)는 현재 범위에서 제외됨, 즉 B ~ P까지만 해당됨
          variantIndex = variantIndex + 1
       End If
   
    Next fcsWiringDiagramRowIndex
    
    
    ' 공통에서 일치하는 값이 없으면, 개별 FCS 확인
    If Not (needProcessing) Then                                                                                                             ' Common에서 일치하는 값이 발견되지 않은 경우
         
        variantIndexText = "A"                                                                                                               ' 이하 Variant Type은 모두 "A"
        If (fcsCNB > 0 And fcsNest <> "") Then                                                                                               ' CN B번 확인/NEST 값 확인
           
           If (fcsCNNo = wiringDiagramSheet.Range(CELL_ADDRESS_WIRING_DIAGRAM_FCS_CNB_2SLOT_RIO)) Then                                       ' CNB 1번 확인
               needProcessing = True
               selectedCellValue = wiringDiagramSheet.Range(CELL_ADDRESS_WIRING_DIAGRAM_2SLOT_RIO_MACRO)                                     ' 2SLOT_RIO 매크로 입력
           
           ElseIf (fcsCNNo = "17") Then                                                                                                      ' CN 17번 확인
               needProcessing = True
               selectedCellValue = wiringDiagramSheet.Range(CELL_ADDRESS_WIRING_DIAGRAM_2SLOT_RIO_MACRO)                                     ' 2SLOT_RIO 매크로 입력
           
           End If

        ElseIf (fcsCNB > 0) Then                                                                                                             ' CN B번 확인
        
           If (fcsCNNo = wiringDiagramSheet.Range(CELL_ADDRESS_WIRING_DIAGRAM_FCS_CNB_2SLOT)) Then                                           ' CNB 1번 확인
               needProcessing = True
               selectedCellValue = wiringDiagramSheet.Range(CELL_ADDRESS_WIRING_DIAGRAM_2SLOT_MACRO)                                         ' 2SLOT 매크로 입력
           
           ElseIf (fcsCNNo = "17") Then                                                                                                      ' CN 17번 확인
               needProcessing = True
               selectedCellValue = wiringDiagramSheet.Range(CELL_ADDRESS_WIRING_DIAGRAM_2SLOT_MACRO)                                         ' 2SLOT 매크로 입력
           
           End If
        
        ElseIf (fcsCNA > 0 And fcsNest <> "") Then                                                                                           ' CN A번 확인/NEST 값 확인
           
           If (fcsCNNo = wiringDiagramSheet.Range(CELL_ADDRESS_WIRING_DIAGRAM_FCS_CNA_1SLOT_RIO)) Then                                       ' CNA 1번 확인
               needProcessing = True
               selectedCellValue = wiringDiagramSheet.Range(CELL_ADDRESS_WIRING_DIAGRAM_1SLOT_RIO_MACRO)                                     ' 1SLOT_RIO 매크로 입력
           
           ElseIf (fcsCNNo = "17") Then                                                                                                      ' CN 17번 확인
               needProcessing = True
               selectedCellValue = wiringDiagramSheet.Range(CELL_ADDRESS_WIRING_DIAGRAM_1SLOT_RIO_MACRO)                                      ' 1SLOT_RIO 매크로 입력
           
           End If

        ElseIf (fcsCNA > 0) Then                                                                                                             ' CN A번 확인
        
           If (fcsCNNo = wiringDiagramSheet.Range(CELL_ADDRESS_WIRING_DIAGRAM_FCS_CNA_1SLOT)) Then                                           ' CN 1번 확인
               needProcessing = True
               selectedCellValue = wiringDiagramSheet.Range(CELL_ADDRESS_WIRING_DIAGRAM_1SLOT_MACRO)                                         ' 1SLOT 매크로 입력
           
           ElseIf (fcsCNNo = "17") Then                                                                                                      ' CN 17번 확인
               needProcessing = True
               selectedCellValue = wiringDiagramSheet.Range(CELL_ADDRESS_WIRING_DIAGRAM_1SLOT_MACRO)                                         ' 1SLOT 매크로 입력
           
           End If
        
        End If
    End If
    
    If (needProcessing) Then                                                                                                                 ' 처리 작업이 필요하면
        localRowIndex = localRowIndex + 1
        clsCommon.SetSingleLine2AndVariantValue localRowIndex, ioListDataRowIndex, variantIndexText, workingSheet
        workingSheet.Cells(localRowIndex, Constants.COLUMN_INDEX_MACRO_NAME).value = selectedCellValue                                       ' 선택된 매크로 입력
    End If
    
    Process = localRowIndex
    
End Function

