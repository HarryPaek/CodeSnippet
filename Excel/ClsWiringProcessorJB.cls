VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
END
Attribute VB_Name = "ClsWiringProcessorJB"
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
Private Const COLUMN_INDEX_TEXT_JB_GRP_NO            As String = "35"
Private Const COLUMN_INDEX_TEXT_JB_3                 As String = "38"

'================================================================================
' 별도 데이터 시트(DATA1, DATA2, DATA3) 값 주소
'================================================================================
Private Const CELL_ADDRESS_WIRING_DIAGRAM_JB         As String = "G5"             ' DATA3 시트
Private Const CELL_ADDRESS_WIRING_DIAGRAM_JB_1       As String = "I5"             ' DATA3 시트

Private clsCommon As ClsWiringCommon

Private Sub Class_Initialize()

    'MsgBox "ProcessorJB Class is being initialized"
    
    Set clsCommon = New ClsWiringCommon
    
End Sub

Private Sub Class_Terminate()
    
    'MsgBox "ProcessorJB Class is being terminated"
    
    Set clsCommon = Nothing

End Sub

'================================================================================================================================================================
' JB 처리
' 받은 Row Index 값을 가지고 필요한 경우에 +1 해서 작업
' 현재 작업한 라인 Row Index 값을 돌려 줌
'================================================================================================================================================================
Public Function Process(rowIndex As Long, ioListDataRowIndex As Long, workingSheet As Worksheet, wiringDiagramSheet As Worksheet, cellValues As Collection) As Long

    Dim needProcessing As Boolean                                                                                                                          ' 프로세싱 여부
    Dim localRowIndex As Long
    Dim jbGroupNo As Variant
    Dim selectedCellValue As Variant                                                                                                                       ' 복사 대상으로 선택된 DATA3 Cell 값
    
    needProcessing = False
    localRowIndex = rowIndex
    jbGroupNo = cellValues.Item(COLUMN_INDEX_TEXT_JB_GRP_NO)
    
    
    If (cellValues.Item(COLUMN_INDEX_TEXT_JB_3) > 0 And jbGroupNo <> "") Then                                                                              ' JB(3) 값, JB GRP NO 값이 있으면
       needProcessing = True
       selectedCellValue = wiringDiagramSheet.Range(CELL_ADDRESS_WIRING_DIAGRAM_JB_1)                                                                      ' JB-1 매크로 입력
    ElseIf (jbGroupNo > 0) Then                                                                                                                            ' JB GRP NO가 있으면
       needProcessing = True
       selectedCellValue = wiringDiagramSheet.Range(CELL_ADDRESS_WIRING_DIAGRAM_JB)                                                                        ' JB 매크로 입력
    End If
    
    If (needProcessing) Then                                                                                                                               ' 처리 작업이 필요하면
        localRowIndex = localRowIndex + 1
        clsCommon.SetSingleLine2AndCopyVariant localRowIndex, ioListDataRowIndex, workingSheet
        workingSheet.Cells(localRowIndex, Constants.COLUMN_INDEX_MACRO_NAME).value = selectedCellValue                                                     ' 선택된 매크로 입력
    End If
    
    Process = localRowIndex
    
End Function

