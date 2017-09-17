VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
END
Attribute VB_Name = "ClsWiringProcessorTBA4WIRE"
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
Private Const COLUMN_INDEX_TEXT_4WIRE_TBD_PLUS                  As String = "100"

'================================================================================
' 별도 데이터 시트(DATA1, DATA2, DATA3) 값 주소
'================================================================================
Private Const CELL_ADDRESS_WIRING_DIAGRAM_4WIRE_CN_NO_AA46      As String = "AA46"            ' DATA3 시트

Private Const CELL_ADDRESS_WIRING_DIAGRAM_4WIRE_MACRO           As String = "AD46"            ' DATA3 시트

Private clsCommon As ClsWiringCommon
Private collectionExtension As ClsCollectionExtension

Private Sub Class_Initialize()

    Set clsCommon = New ClsWiringCommon
    Set collectionExtension = New ClsCollectionExtension
    
End Sub

Private Sub Class_Terminate()
    
    Set clsCommon = Nothing
    Set collectionExtension = Nothing

End Sub


'================================================================================================================================================================
' FCS 처리
' 받은 Row Index 값을 가지고 필요한 경우에 +1 해서 작업
' 현재 작업한 라인 Row Index 값을 돌려 줌
'================================================================================================================================================================
Public Function Process(rowIndex As Long, ioListDataRowIndex As Long, workingSheet As Worksheet, wiringDiagramSheet As Worksheet, cellValues As Collection) As Long

    Dim localRowIndex              As Long
    Dim tba4WireTbdPlus            As Variant
    Dim tba4WireDiagramSheetValue  As Variant                                                                                                              ' WIRING DIAGRAM (Data3) 시트 값
    Dim inStrResult                As Integer                                                                                                              ' InStr 비교한 결과 값
    Dim selectedCellValue          As Variant                                                                                                              ' 복사 대상으로 선택된 DATA3 Cell 값
    
    localRowIndex = rowIndex

    ''tba4WireTbdPlus = cellValues.Item(COLUMN_INDEX_TEXT_4WIRE_TBD_PLUS)
    tba4WireTbdPlus = collectionExtension.TryGetValue(cellValues, COLUMN_INDEX_TEXT_4WIRE_TBD_PLUS)                      'CV, IO 시트에 없는 경우를 대비하여 Extension Method 사용

    tba4WireDiagramSheetValue = wiringDiagramSheet.Range(CELL_ADDRESS_WIRING_DIAGRAM_4WIRE_CN_NO_AA46)
    selectedCellValue = wiringDiagramSheet.Range(CELL_ADDRESS_WIRING_DIAGRAM_4WIRE_MACRO)
    
    inStrResult = InStr(tba4WireTbdPlus, tba4WireDiagramSheetValue)
    
    ' 문자열이 존재하는지 비교
    If inStrResult > 0 Then                                                                                                                  ' B 확인
        localRowIndex = localRowIndex + 1
        workingSheet.Cells(localRowIndex, Constants.COLUMN_INDEX_MACRO_NAME).value = selectedCellValue                                       ' 선택된 매크로 입력
        clsCommon.SetSingleLine2AndCopyVariant localRowIndex, ioListDataRowIndex, workingSheet
    
    End If
    
    Process = localRowIndex
    
End Function


