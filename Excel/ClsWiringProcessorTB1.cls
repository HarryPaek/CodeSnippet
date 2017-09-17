VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
END
Attribute VB_Name = "ClsWiringProcessorTB1"
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
Private Const COLUMN_INDEX_TEXT_TB_GRP_NO            As String = "63"
Private Const COLUMN_INDEX_TEXT_TB_FUSE              As String = "204"
Private Const COLUMN_INDEX_TEXT_TB_DISCONNECT        As String = "205"
Private Const COLUMN_INDEX_TEXT_TB1_3                As String = "66"

'================================================================================
' 별도 데이터 시트(DATA1, DATA2, DATA3) 값 주소
'================================================================================
Private Const CELL_ADDRESS_WIRING_DIAGRAM_TB_1       As String = "M5"             ' DATA3 시트
Private Const CELL_ADDRESS_WIRING_DIAGRAM_FTB_1      As String = "M6"             ' DATA3 시트
Private Const CELL_ADDRESS_WIRING_DIAGRAM_DTB        As String = "M7"             ' DATA3 시트
Private Const CELL_ADDRESS_WIRING_DIAGRAM_TB1_1      As String = "O5"             ' DATA3 시트

Private clsCommon As ClsWiringCommon
Private collectionExtension As ClsCollectionExtension

Private Sub Class_Initialize()

    'MsgBox "ProcessorTB1 Class is being initialized"
    
    Set clsCommon = New ClsWiringCommon
    Set collectionExtension = New ClsCollectionExtension
    
End Sub

Private Sub Class_Terminate()
    
    'MsgBox "ProcessorTB1 Class is being terminated"
    
    Set clsCommon = Nothing
    Set collectionExtension = Nothing

End Sub


'================================================================================================================================================================
' TB1 처리
' 받은 Row Index 값을 가지고 필요한 경우에 +1 해서 작업
' 현재 작업한 라인 Row Index 값을 돌려 줌
'================================================================================================================================================================
Public Function Process(rowIndex As Long, ioListDataRowIndex As Long, workingSheet As Worksheet, wiringDiagramSheet As Worksheet, cellValues As Collection) As Long

    Dim needProcessing    As Boolean                                                                                                        ' 프로세싱 여부
    Dim localRowIndex     As Long
    Dim tbGroupNo         As Variant
    Dim tbFuse            As Variant
    Dim tbDisconnect      As Variant
    Dim tb13              As Variant
    Dim selectedCellValue As Variant                                                                                                        ' 복사 대상으로 선택된 DATA3 Cell 값
    
    needProcessing = False
    localRowIndex = rowIndex
    
    ''tbGroupNo = cellValues.Item(COLUMN_INDEX_TEXT_TB_GRP_NO)
    tbGroupNo = collectionExtension.TryGetValue(cellValues, COLUMN_INDEX_TEXT_TB_GRP_NO)                                 'BK, IO 시트에 없는 경우를 대비하여 Extension Method 사용

    ''tbFuse = cellValues.Item(COLUMN_INDEX_TEXT_TB_FUSE)
    tbFuse = collectionExtension.TryGetValue(cellValues, COLUMN_INDEX_TEXT_TB_FUSE)                                      'GV, IO 시트에 없는 경우를 대비하여 Extension Method 사용

    ''tbDisconnect = cellValues.Item(COLUMN_INDEX_TEXT_TB_DISCONNECT)
    tbDisconnect = collectionExtension.TryGetValue(cellValues, COLUMN_INDEX_TEXT_TB_DISCONNECT)                          'GW, IO 시트에 없는 경우를 대비하여 Extension Method 사용

    ''tb13 = cellValues.Item(COLUMN_INDEX_TEXT_TB1_3)
    tb13 = collectionExtension.TryGetValue(cellValues, COLUMN_INDEX_TEXT_TB1_3)                                          'BN, IO 시트에 없는 경우를 대비하여 Extension Method 사용
    
    If (tb13 > 0 And tbGroupNo <> "") Then                                                                                                  ' TB1-3 값, TB GRP NO1 값이 있으면
       needProcessing = True
       selectedCellValue = wiringDiagramSheet.Range(CELL_ADDRESS_WIRING_DIAGRAM_TB1_1)                                                      ' TB1-1 매크로 입력
    ElseIf (tbDisconnect > 0) Then                                                                                                          ' TB_Disconnection 값이 있으면
       needProcessing = True
       selectedCellValue = wiringDiagramSheet.Range(CELL_ADDRESS_WIRING_DIAGRAM_DTB)                                                        ' DTB 매크로 입력
    ElseIf (tbFuse > 0) Then                                                                                                                ' TB_Fuse 값이 있으면
       needProcessing = True
       selectedCellValue = wiringDiagramSheet.Range(CELL_ADDRESS_WIRING_DIAGRAM_FTB_1)                                                      ' FTB1 매크로 입력
    ElseIf (tbGroupNo > 0) Then                                                                                                             ' TB GRP NO1 값이 있으면
       needProcessing = True
       selectedCellValue = wiringDiagramSheet.Range(CELL_ADDRESS_WIRING_DIAGRAM_TB_1)                                                       ' TB1 매크로 입력
    End If
    
    If (needProcessing) Then                                                                                                                ' 작업이 필요하면
        localRowIndex = localRowIndex + 1
        clsCommon.SetSingleLine2AndCopyVariant localRowIndex, ioListDataRowIndex, workingSheet
        workingSheet.Cells(localRowIndex, Constants.COLUMN_INDEX_MACRO_NAME).value = selectedCellValue                                      ' 선택된 매크로 입력
    End If
    
    Process = localRowIndex
    
End Function

