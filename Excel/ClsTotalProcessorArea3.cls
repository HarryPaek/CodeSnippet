VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
END
Attribute VB_Name = "ClsTotalProcessorArea3"
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
Private Const COLUMN_INDEX_TEXT_CNA                    As String = "103"
Private Const COLUMN_INDEX_TEXT_SLOT_NO_1              As String = "136"
Private Const COLUMN_INDEX_TEXT_SLOT_NO_2              As String = "137"


'================================================================================
' 별도 데이터 시트(DATA1, DATA2, DATA3) 값 주소
'================================================================================
Private Const CELL_ADDRESS_TOTAL_AREA_AREA3_CN         As String = "AB6"             ' DATA2 시트

Private Const CELL_ADDRESS_TOTAL_AREA_SYSTEM1_MACRO    As String = "AC6"             ' DATA2 시트
Private Const CELL_ADDRESS_TOTAL_AREA_SYSTEM2_MACRO    As String = "AC7"             ' DATA2 시트

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
' AREA3 처리
' 받은 Row Index 값을 가지고 필요한 경우에 +1 해서 작업
' 현재 작업한 라인 Row Index 값을 돌려 줌
'================================================================================================================================================================
Public Function Process(rowIndex As Long, ioListDataRowIndex As Long, workingSheet As Worksheet, totalAreaSheet As Worksheet, cellValues As Collection) As Long

    Dim needProcessing               As Boolean                                                                                                            ' 프로세싱 여부
    Dim localRowIndex                As Long
    Dim inStrResult                  As Integer                                                                                                            ' InStr 비교한 결과 값
    
    Dim cnTotalAreaSheetValue        As Variant                                                                                                             ' 비교 대상으로 선택된 DATA2 Cell 값 (CN)
    
    Dim cnA                          As Variant
    Dim slotNo1                      As Variant
    Dim slotNo2                      As Variant
        
    Dim selectedCellValue            As Variant                                                                                                            ' 복사 대상으로 선택된 DATA2 Cell 값
    
    needProcessing = False
    localRowIndex = rowIndex
    
    ''cnA = cellValues.Item(COLUMN_INDEX_TEXT_CNA)
    cnA = collectionExtension.TryGetValue(cellValues, COLUMN_INDEX_TEXT_CNA)                                       'CY, IO 시트에 없는 경우를 대비하여 Extension Method 사용
    
    ''slotNo1 = cellValues.Item(COLUMN_INDEX_TEXT_SLOT_NO_1)
    slotNo1 = collectionExtension.TryGetValue(cellValues, COLUMN_INDEX_TEXT_SLOT_NO_1)                             'EF, IO 시트에 없는 경우를 대비하여 Extension Method 사용
    
    ''slotNo2 = cellValues.Item(COLUMN_INDEX_TEXT_SLOT_NO_2)
    slotNo2 = collectionExtension.TryGetValue(cellValues, COLUMN_INDEX_TEXT_SLOT_NO_2)                             'EG, IO 시트에 없는 경우를 대비하여 Extension Method 사용
    
    cnTotalAreaSheetValue = totalAreaSheet.Range(CELL_ADDRESS_TOTAL_AREA_AREA3_CN)
    
    inStrResult = InStr(cnA, cnTotalAreaSheetValue)
    
    If (inStrResult > 0 And slotNo2 <> "") Then                                                                                                            ' CNA 값이 있고, SLOT NO2 값이 있으면
       needProcessing = True
       selectedCellValue = totalAreaSheet.Range(CELL_ADDRESS_TOTAL_AREA_SYSTEM2_MACRO)                                                                     ' SYSTEM2 매크로 삽입
    ElseIf (inStrResult > 0 And slotNo1 <> "") Then                                                                                                        ' CNA 값이 있고, SLOT NO1 값이 있으면
       needProcessing = True
       selectedCellValue = totalAreaSheet.Range(CELL_ADDRESS_TOTAL_AREA_SYSTEM1_MACRO)                                                                     ' SYSTEM1 매크로 입력
    End If
    
    If (needProcessing) Then                                                                                                                               ' 처리 작업이 필요하면
        localRowIndex = localRowIndex + 1
        clsCommon.SetSingleLine2AndCopyVariant localRowIndex, ioListDataRowIndex, workingSheet
        workingSheet.Cells(localRowIndex, Constants.COLUMN_INDEX_MACRO_NAME).value = selectedCellValue                                                     ' 선택된 매크로 입력
    End If
    
    Process = localRowIndex
    
End Function




