VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
END
Attribute VB_Name = "ClsTotalProcessorArea2TB"
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
Private Const COLUMN_INDEX_TEXT_TB_GRP_NO_1            As String = "63"
Private Const COLUMN_INDEX_TEXT_TB1_3                  As String = "66"
Private Const COLUMN_INDEX_TEXT_TB_GRP_NO_2            As String = "75"
Private Const COLUMN_INDEX_TEXT_TB2_3                  As String = "78"
Private Const COLUMN_INDEX_TEXT_RELAY_NAME             As String = "107"


'================================================================================
' 별도 데이터 시트(DATA1, DATA2, DATA3) 값 주소
'================================================================================
Private Const CELL_ADDRESS_TOTAL_AREA_AREA2_TB         As String = "L6"              ' DATA2 시트
Private Const CELL_ADDRESS_TOTAL_AREA_AREA2_TB_TB      As String = "M7"              ' DATA2 시트
Private Const CELL_ADDRESS_TOTAL_AREA_AREA2_TB_R       As String = "M8"              ' DATA2 시트

Private Const CELL_ADDRESS_TOTAL_AREA_TB1_MACRO        As String = "P6"              ' DATA2 시트
Private Const CELL_ADDRESS_TOTAL_AREA_TB1_1_MACRO      As String = "S6"              ' DATA2 시트
Private Const CELL_ADDRESS_TOTAL_AREA_TB2_MACRO        As String = "P7"              ' DATA2 시트
Private Const CELL_ADDRESS_TOTAL_AREA_TB2_1_MACRO      As String = "S7"              ' DATA2 시트
Private Const CELL_ADDRESS_TOTAL_AREA_RY_MACRO         As String = "P8"              ' DATA2 시트

Private clsCommon As ClsWiringCommon
Private collectionExtension As ClsCollectionExtension

Private Sub Class_Initialize()

    'MsgBox "ClsTotalProcessorArea1 Class is being initialized"
    
    Set clsCommon = New ClsWiringCommon
    Set collectionExtension = New ClsCollectionExtension
    
End Sub

Private Sub Class_Terminate()
    
    'MsgBox "ClsTotalProcessorArea1 Class is being terminated"
    
    Set clsCommon = Nothing
    Set collectionExtension = Nothing

End Sub

'================================================================================================================================================================
' AREA2 TB 처리
' 받은 Row Index 값을 가지고 필요한 경우에 +1 해서 작업
' 현재 작업한 라인 Row Index 값을 돌려 줌
'================================================================================================================================================================
Public Function Process(rowIndex As Long, ioListDataRowIndex As Long, workingSheet As Worksheet, totalAreaSheet As Worksheet, cellValues As Collection) As Long

    Dim needProcessing               As Boolean                                                                                                            ' 프로세싱 여부
    Dim localRowIndex                As Long
    
    Dim tbInStrResult                As Integer                                                                                                            ' InStr 비교한 결과 값
    Dim tbTbInStrResult              As Integer                                                                                                            ' InStr 비교한 결과 값
    Dim tbRInStrResult               As Integer                                                                                                            ' InStr 비교한 결과 값
    
    Dim tbTotalAreaSheetValue        As Variant                                                                                                            ' 비교 대상으로 선택된 DATA2 Cell 값 (CN)
    Dim tbTbTotalAreaSheetValue      As Variant                                                                                                            ' 비교 대상으로 선택된 DATA2 Cell 값 (TB)
    Dim tbRTotalAreaSheetValue       As Variant                                                                                                            ' 비교 대상으로 선택된 DATA2 Cell 값 (TB)
    
    Dim tbGroupNo1                   As Variant
    Dim tb13                         As Variant
    Dim tbGroupNo2                   As Variant
    Dim tb23                         As Variant
    Dim relayName                    As Variant
    
    Dim selectedCellValue            As Variant                                                                                                            ' 복사 대상으로 선택된 DATA2 Cell 값
    
    needProcessing = False
    localRowIndex = rowIndex
    
    ''tbGroupNo1 = cellValues.Item(COLUMN_INDEX_TEXT_TB_GRP_NO_1)
    tbGroupNo1 = collectionExtension.TryGetValue(cellValues, COLUMN_INDEX_TEXT_TB_GRP_NO_1)                        'BK, IO 시트에 없는 경우를 대비하여 Extension Method 사용
    
    '' tb13 = cellValues.Item(COLUMN_INDEX_TEXT_TB1_3)
    tb13 = collectionExtension.TryGetValue(cellValues, COLUMN_INDEX_TEXT_TB1_3)                                    'BN, IO 시트에 없는 경우를 대비하여 Extension Method 사용
    
    ''tbGroupNo2 = cellValues.Item(COLUMN_INDEX_TEXT_TB_GRP_NO_2)
    tbGroupNo2 = collectionExtension.TryGetValue(cellValues, COLUMN_INDEX_TEXT_TB_GRP_NO_2)                        'BW, IO 시트에 없는 경우를 대비하여 Extension Method 사용
    
    ''tb23 = cellValues.Item(COLUMN_INDEX_TEXT_TB2_3)
    tb23 = collectionExtension.TryGetValue(cellValues, COLUMN_INDEX_TEXT_TB2_3)                                    'BZ, IO 시트에 없는 경우를 대비하여 Extension Method 사용
    
    ''relayName = cellValues.Item(COLUMN_INDEX_TEXT_RELAY_NAME)
    relayName = collectionExtension.TryGetValue(cellValues, COLUMN_INDEX_TEXT_RELAY_NAME)                          'DC, IO 시트에 없는 경우를 대비하여 Extension Method 사용
    
    tbTotalAreaSheetValue = totalAreaSheet.Range(CELL_ADDRESS_TOTAL_AREA_AREA2_TB)
    tbTbTotalAreaSheetValue = totalAreaSheet.Range(CELL_ADDRESS_TOTAL_AREA_AREA2_TB_TB)
    tbRTotalAreaSheetValue = totalAreaSheet.Range(CELL_ADDRESS_TOTAL_AREA_AREA2_TB_R)
    
    tbInStrResult = InStr(tbGroupNo1, tbTotalAreaSheetValue)
    tbTbInStrResult = InStr(tbGroupNo2, tbTbTotalAreaSheetValue)
    tbRInStrResult = InStr(relayName, tbRTotalAreaSheetValue)
    
    If (tbRInStrResult > 0) Then                                                                                                                           ' RELAY NAME 값이 있으면
       needProcessing = True
       selectedCellValue = totalAreaSheet.Range(CELL_ADDRESS_TOTAL_AREA_RY_MACRO)                                                                          ' RY(DRY) 매크로 삽입
    ElseIf (tb23 > 0) Then                                                                                                                                 ' TB2-3 값이 있으면
       needProcessing = True
       selectedCellValue = totalAreaSheet.Range(CELL_ADDRESS_TOTAL_AREA_TB2_1_MACRO)                                                                       ' TB2-1 매크로 삽입
    ElseIf (tbTbInStrResult > 0) Then                                                                                                                      ' TB GRP NO2 값이 있으면
       needProcessing = True
       selectedCellValue = totalAreaSheet.Range(CELL_ADDRESS_TOTAL_AREA_TB2_MACRO)                                                                         ' TB2 매크로 삽입
    ElseIf (tb13 > 0) Then                                                                                                                                 ' TB1-3 값이 있으면
       needProcessing = True
       selectedCellValue = totalAreaSheet.Range(CELL_ADDRESS_TOTAL_AREA_TB1_1_MACRO)                                                                       ' TB1-1 매크로 입력
    ElseIf (tbInStrResult > 0) Then                                                                                                                        ' TB GRP NO1 값이 있으면
       needProcessing = True
       selectedCellValue = totalAreaSheet.Range(CELL_ADDRESS_TOTAL_AREA_TB1_MACRO)                                                                         ' TB1 매크로 입력
    End If
    
    If (needProcessing) Then                                                                                                                               ' 처리 작업이 필요하면
        localRowIndex = localRowIndex + 1
        clsCommon.SetSingleLine2AndCopyVariant localRowIndex, ioListDataRowIndex, workingSheet
        workingSheet.Cells(localRowIndex, Constants.COLUMN_INDEX_MACRO_NAME).value = selectedCellValue                                                     ' 선택된 매크로 입력
    End If
    
    Process = localRowIndex
    
End Function




