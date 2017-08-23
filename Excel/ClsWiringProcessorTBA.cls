VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
END
Attribute VB_Name = "ClsWiringProcessorTBA"
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
Private Const COLUMN_INDEX_TEXT_TBA_INT_POWER                   As String = "169"
Private Const COLUMN_INDEX_TEXT_TBA_EXT_POWER                   As String = "170"
Private Const COLUMN_INDEX_TEXT_TBA_CN_NO                       As String = "138"
Private Const COLUMN_INDEX_TEXT_TBA_TBD_3                       As String = "102"

'================================================================================
' 별도 데이터 시트(DATA1, DATA2, DATA3) 값 주소
'================================================================================
Private Const CELL_ADDRESS_WIRING_DIAGRAM_NO_POWER_CN_NO_1      As String = "AA10"            ' DATA3 시트

Private Const CELL_ADDRESS_WIRING_DIAGRAM_EXT_POWER_CN_NO_1     As String = "AA8"             ' DATA3 시트
Private Const CELL_ADDRESS_WIRING_DIAGRAM_EXT_POWER_CN_NO_17    As String = "AA9"             ' DATA3 시트
Private Const CELL_ADDRESS_WIRING_DIAGRAM_INT_POWER_CN_NO_1     As String = "AA12"            ' DATA3 시트
Private Const CELL_ADDRESS_WIRING_DIAGRAM_INT_POWER_CN_NO_17    As String = "AA13"            ' DATA3 시트
Private Const CELL_ADDRESS_WIRING_DIAGRAM_BOTH_POWER_CN_NO_1    As String = "AA10"            ' DATA3 시트
Private Const CELL_ADDRESS_WIRING_DIAGRAM_BOTH_POWER_CN_NO_17   As String = "AA11"            ' DATA3 시트

Private Const CELL_ADDRESS_WIRING_DIAGRAM_TBA1                  As String = "AD5"             ' DATA3 시트
Private Const CELL_ADDRESS_WIRING_DIAGRAM_TBA2                  As String = "AG5"             ' DATA3 시트
Private Const CELL_ADDRESS_WIRING_DIAGRAM_TBA5                  As String = "AD8"             ' DATA3 시트
Private Const CELL_ADDRESS_WIRING_DIAGRAM_TBA5_1                As String = "AD9"             ' DATA3 시트
Private Const CELL_ADDRESS_WIRING_DIAGRAM_TBA6                  As String = "AD10"            ' DATA3 시트
Private Const CELL_ADDRESS_WIRING_DIAGRAM_TBA6_1                As String = "AD11"            ' DATA3 시트
Private Const CELL_ADDRESS_WIRING_DIAGRAM_TBA7                  As String = "AD12"            ' DATA3 시트
Private Const CELL_ADDRESS_WIRING_DIAGRAM_TBA7_1                As String = "AD13"            ' DATA3 시트


' TBA 공통 2~16 Point
' TBA 공통 18~32 Point
Private Const TBA_COMMON_ROW_INDEX_START                        As Long = 14                  ' DATA3 시트, Common을 비교하는 Row 시작 인덱스
Private Const TBA_COMMON_SUB_ROW_INDEX_END                      As Long = 28                  ' DATA3 시트, "TBA Sub" Common을 비교하는 Row 마지막 인덱스
Private Const TBA_COMMON_ROW_INDEX_END                          As Long = 43                  ' DATA3 시트, Common을 비교하는 Row 마지막 인덱스
Private Const TBA_COMMON_COLUMN_PREFIX_CN_NO_COMPARE            As String = "AA"              ' DATA3 시트, CN NO 값을 비교하는 컬럼
Private Const TBA_COMMON_COLUMN_PREFIX_TBA_MACRO                As String = "AD"              ' DATA3 시트, TBA 매크로를 가져오는 컬럼
Private Const TBA_COMMON_COLUMN_PREFIX_TBA_1_MACRO              As String = "AG"              ' DATA3 시트, TBA-1 매크로를 가져오는 컬럼


Private clsCommon As ClsWiringCommon

Private Sub Class_Initialize()

    Set clsCommon = New ClsWiringCommon
    
End Sub

Private Sub Class_Terminate()
    
    Set clsCommon = Nothing

End Sub


'================================================================================================================================================================
' TBA 처리
' 받은 Row Index 값을 가지고 필요한 경우에 +1 해서 작업
' 현재 작업한 라인 Row Index 값을 돌려 줌
'================================================================================================================================================================
Public Function Process(rowIndex As Long, ioListDataRowIndex As Long, workingSheet As Worksheet, wiringDiagramSheet As Worksheet, cellValues As Collection) As Long

    Dim needProcessing             As Boolean                                                                                                              ' 프로세싱 여부
    Dim localRowIndex              As Long
    Dim tbaCNNo                    As Variant
    Dim tbaIntPower                As Variant
    Dim tbaExtPower                As Variant
    Dim tbaTbd3                    As Variant
    Dim selectedCellValue          As Variant                                                                                                              ' 복사 대상으로 선택된 DATA3 Cell 값
    Dim variantIndex               As Long
    Dim variantIndexText           As String
    Dim tbaWiringDiagramRowIndex   As Long
    Dim compareCellAddressText     As String
    Dim macroCellAddressText       As String

    
    needProcessing = False
    localRowIndex = rowIndex
    tbaCNNo = cellValues.Item(COLUMN_INDEX_TEXT_TBA_CN_NO)
    tbaIntPower = cellValues.Item(COLUMN_INDEX_TEXT_TBA_INT_POWER)
    tbaExtPower = cellValues.Item(COLUMN_INDEX_TEXT_TBA_EXT_POWER)
    tbaTbd3 = cellValues.Item(COLUMN_INDEX_TEXT_TBA_TBD_3)
    
    variantIndex = 1                                                                                     '  Variant 유형 "B"에서 시작
        
    ' TBA Sub 공통 2~16
    For tbaWiringDiagramRowIndex = TBA_COMMON_ROW_INDEX_START To TBA_COMMON_SUB_ROW_INDEX_END
    
        compareCellAddressText = TBA_COMMON_COLUMN_PREFIX_CN_NO_COMPARE & tbaWiringDiagramRowIndex        '  비교 대상 Cell 주소,  AAxx
        macroCellAddressText = TBA_COMMON_COLUMN_PREFIX_TBA_1_MACRO & tbaWiringDiagramRowIndex            '  TBA-1 매크로 Cell 주소, AGxx
       
        If (tbaCNNo = wiringDiagramSheet.Range(compareCellAddressText) And tbaTbd3 <> "") Then             ' 현재 값과 DATA3에서 CNxx(CN2~16) 값과 비교, TB3값이 존재하는 경우
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
   
    Next tbaWiringDiagramRowIndex
        
        
    ' TBA Sub에서 일치하는 값이 없으면
    If Not (needProcessing) Then
    
        variantIndex = 1                                                                                      '  Variant 유형 "B"로 Reset
    
        ' TBA 공통 2~16, 18~32
        For tbaWiringDiagramRowIndex = TBA_COMMON_ROW_INDEX_START To TBA_COMMON_ROW_INDEX_END
    
            compareCellAddressText = TBA_COMMON_COLUMN_PREFIX_CN_NO_COMPARE & tbaWiringDiagramRowIndex        '  비교 대상 Cell 주소,  AAxx
            macroCellAddressText = TBA_COMMON_COLUMN_PREFIX_TBA_MACRO & tbaWiringDiagramRowIndex              '  TBA 매크로 Cell 주소, ADxx
       
            If (tbaCNNo = wiringDiagramSheet.Range(compareCellAddressText)) Then                              ' 현재 값과 DATA3에서 CNxx(CN2~16, CN18~32) 값과 비교해서 일치하는 경우
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
   
        Next tbaWiringDiagramRowIndex
        
    End If
    
    
    ' 공통에서 일치하는 값이 없으면, TBA1 ~ TBA7
    If Not (needProcessing) Then                                                                                                             ' Common에서 일치하는 값이 발견되지 않은 경우
         
        variantIndexText = "A"                                                                                                               ' 이하 Variant Type은 모두 "A"
        If (tbaIntPower > 0 And tbaExtPower > 0) Then                                                                                        ' INT. POWER & EXT. POWER 모두 존재하면
           
           If (tbaCNNo = wiringDiagramSheet.Range(CELL_ADDRESS_WIRING_DIAGRAM_BOTH_POWER_CN_NO_17)) Then                                     ' INT. POWER & EXT POWER 확인/CN NO 17 확인
               needProcessing = True
               selectedCellValue = wiringDiagramSheet.Range(CELL_ADDRESS_WIRING_DIAGRAM_TBA7_1)                                              ' TBA7-1 매크로 입력
           
           ElseIf (tbaCNNo = wiringDiagramSheet.Range(CELL_ADDRESS_WIRING_DIAGRAM_BOTH_POWER_CN_NO_1)) Then                                  ' INT. POWER & EXT POWER 확인/CN NO 1 확인
               needProcessing = True
               selectedCellValue = wiringDiagramSheet.Range(CELL_ADDRESS_WIRING_DIAGRAM_TBA7)                                                ' TBA7 매크로 입력
           
           End If

        ElseIf (tbaIntPower > 0) Then                                                                                                        ' INT. POWER만 존재하면
        
           If (tbaCNNo = wiringDiagramSheet.Range(CELL_ADDRESS_WIRING_DIAGRAM_INT_POWER_CN_NO_17)) Then                                      ' INT. POWER 확인/CN NO 17 확인
               needProcessing = True
               selectedCellValue = wiringDiagramSheet.Range(CELL_ADDRESS_WIRING_DIAGRAM_TBA6_1)                                              ' TBA6-1 매크로 입력
           
           ElseIf (tbaCNNo = wiringDiagramSheet.Range(CELL_ADDRESS_WIRING_DIAGRAM_INT_POWER_CN_NO_1)) Then                                   ' INT. POWER 확인/CN NO 1 확인
               needProcessing = True
               selectedCellValue = wiringDiagramSheet.Range(CELL_ADDRESS_WIRING_DIAGRAM_TBA6)                                                ' TBA6 매크로 입력
           
           End If
        
        ElseIf (tbaExtPower > 0) Then                                                                                                        ' EXT. POWER만 존재하면
        
           If (tbaCNNo = wiringDiagramSheet.Range(CELL_ADDRESS_WIRING_DIAGRAM_EXT_POWER_CN_NO_17)) Then                                      ' EXT. POWER 확인/CN NO 17 확인
               needProcessing = True
               selectedCellValue = wiringDiagramSheet.Range(CELL_ADDRESS_WIRING_DIAGRAM_TBA5_1)                                              ' TBA5-1 매크로 입력
           
           ElseIf (tbaCNNo = wiringDiagramSheet.Range(CELL_ADDRESS_WIRING_DIAGRAM_EXT_POWER_CN_NO_1)) Then                                   ' EXT. POWER 확인/CN NO 1 확인
               needProcessing = True
               selectedCellValue = wiringDiagramSheet.Range(CELL_ADDRESS_WIRING_DIAGRAM_TBA5)                                                ' TBA5 매크로 입력
           
           End If
        
        Else                                                                                                                                 ' 모두 존재하지 않으면
        
           If (tbaCNNo = wiringDiagramSheet.Range(CELL_ADDRESS_WIRING_DIAGRAM_NO_POWER_CN_NO_1) And tbaTbd3 <> "") Then                      ' INT. EXT POWER 없음/CN NO 1 확인/TBD(3) 값이 있으면
               needProcessing = True
               selectedCellValue = wiringDiagramSheet.Range(CELL_ADDRESS_WIRING_DIAGRAM_TBA2)                                                ' TBA2 매크로 입력
           
           ElseIf (tbaCNNo = wiringDiagramSheet.Range(CELL_ADDRESS_WIRING_DIAGRAM_NO_POWER_CN_NO_1)) Then                                    ' INT. EXT POWER 없음/CN NO 1 확인
               needProcessing = True
               selectedCellValue = wiringDiagramSheet.Range(CELL_ADDRESS_WIRING_DIAGRAM_TBA1)                                                ' TBA1 매크로 입력(A1BA4D, A1BR4D,A1BT4D)
           
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



