VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
END
Attribute VB_Name = "ClsTotalProcessorArea2"
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
Private Const COLUMN_INDEX_TEXT_TB_GRP_NO_2            As String = "75"
Private Const COLUMN_INDEX_TEXT_TBD_3                  As String = "102"
Private Const COLUMN_INDEX_TEXT_CNA                    As String = "103"
Private Const COLUMN_INDEX_TEXT_INT_POWER              As String = "170"
Private Const COLUMN_INDEX_TEXT_EXT_POWER              As String = "171"


'================================================================================
' 별도 데이터 시트(DATA1, DATA2, DATA3) 값 주소
'================================================================================
Private Const CELL_ADDRESS_TOTAL_AREA_AREA2_CN         As String = "T6"              ' DATA2 시트
Private Const CELL_ADDRESS_TOTAL_AREA_AREA2_TB         As String = "U7"              ' DATA2 시트


Private Const CELL_ADDRESS_TOTAL_AREA_TBA1_MACRO       As String = "W6"              ' DATA2 시트
Private Const CELL_ADDRESS_TOTAL_AREA_TBA1_1_MACRO     As String = "Z6"              ' DATA2 시트
Private Const CELL_ADDRESS_TOTAL_AREA_TBA2_MACRO       As String = "W7"              ' DATA2 시트
Private Const CELL_ADDRESS_TOTAL_AREA_TBA2_1_MACRO     As String = "Z7"              ' DATA2 시트
Private Const CELL_ADDRESS_TOTAL_AREA_TBA3_MACRO       As String = "W8"              ' DATA2 시트
Private Const CELL_ADDRESS_TOTAL_AREA_TBA4_MACRO       As String = "W9"              ' DATA2 시트
Private Const CELL_ADDRESS_TOTAL_AREA_TBA5_MACRO       As String = "W10"             ' DATA2 시트


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
' AREA2 처리
' 받은 Row Index 값을 가지고 필요한 경우에 +1 해서 작업
' 현재 작업한 라인 Row Index 값을 돌려 줌
'================================================================================================================================================================
Public Function Process(rowIndex As Long, ioListDataRowIndex As Long, workingSheet As Worksheet, totalAreaSheet As Worksheet, cellValues As Collection) As Long

    Dim needProcessing               As Boolean                                                                                                            ' 프로세싱 여부
    Dim localRowIndex                As Long
    Dim cnInStrResult                As Integer                                                                                                            ' InStr 비교한 결과 값
    Dim tbInStrResult                As Integer                                                                                                            ' InStr 비교한 결과 값
    
    Dim cnTotalAreaSheetValue        As Variant                                                                                                             ' 비교 대상으로 선택된 DATA2 Cell 값 (CN)
    Dim tbTotalAreaSheetValue        As Variant                                                                                                             ' 비교 대상으로 선택된 DATA2 Cell 값 (TB)
    
    Dim tbGroupNo2                   As Variant
    Dim tbd3                         As Variant
    Dim cnA                          As Variant
    Dim intPower                     As Variant
    Dim extPower                     As Variant
    
    Dim selectedCellValue            As Variant                                                                                                            ' 복사 대상으로 선택된 DATA2 Cell 값
    
    needProcessing = False
    localRowIndex = rowIndex
    
    ''tbGroupNo2 = cellValues.Item(COLUMN_INDEX_TEXT_TB_GRP_NO_2)
    tbGroupNo2 = collectionExtension.TryGetValue(cellValues, COLUMN_INDEX_TEXT_TB_GRP_NO_2)                        'BW, IO 시트에 없는 경우를 대비하여 Extension Method 사용
    
    ''tbd3 = cellValues.Item(COLUMN_INDEX_TEXT_TBD_3)
    tbd3 = collectionExtension.TryGetValue(cellValues, COLUMN_INDEX_TEXT_TBD_3)                                    'CX, IO 시트에 없는 경우를 대비하여 Extension Method 사용
    
    ''cnA = cellValues.Item(COLUMN_INDEX_TEXT_CNA)
    cnA = collectionExtension.TryGetValue(cellValues, COLUMN_INDEX_TEXT_CNA)                                       'CY, IO 시트에 없는 경우를 대비하여 Extension Method 사용
    
    ''intPower = cellValues.Item(COLUMN_INDEX_TEXT_INT_POWER)
    intPower = collectionExtension.TryGetValue(cellValues, COLUMN_INDEX_TEXT_INT_POWER)                            'FN, IO 시트에 없는 경우를 대비하여 Extension Method 사용
    
    ''extPower = cellValues.Item(COLUMN_INDEX_TEXT_EXT_POWER)
    extPower = collectionExtension.TryGetValue(cellValues, COLUMN_INDEX_TEXT_EXT_POWER)                            'FO, IO 시트에 없는 경우를 대비하여 Extension Method 사용
    
    cnTotalAreaSheetValue = totalAreaSheet.Range(CELL_ADDRESS_TOTAL_AREA_AREA2_CN)
    tbTotalAreaSheetValue = totalAreaSheet.Range(CELL_ADDRESS_TOTAL_AREA_AREA2_TB)
    
    cnInStrResult = InStr(cnA, cnTotalAreaSheetValue)
    tbInStrResult = InStr(tbGroupNo2, tbTotalAreaSheetValue)
    
    If (intPower > 0 And extPower = "" And tbGroupNo2 = "") Then                                                                                           ' INT 값이 있고, EXT 값,TB GRP NO2 값이 없으면
       needProcessing = True
       selectedCellValue = totalAreaSheet.Range(CELL_ADDRESS_TOTAL_AREA_TBA5_MACRO)                                                                        ' TBA5 매크로 삽입
    ElseIf (extPower > 0 And intPower = "" And tbGroupNo2 = "") Then                                                                                       ' EXT 값이 있고, INT 값,TB GRP NO2 값이 없으면
       needProcessing = True
       selectedCellValue = totalAreaSheet.Range(CELL_ADDRESS_TOTAL_AREA_TBA4_MACRO)                                                                        ' TBA4 매크로 삽입
    ElseIf (intPower > 0 And extPower > 0 And tbGroupNo2 = "") Then                                                                                        ' INT/EXT 값이 있고, TB GRP NO2 값이 없으면
       needProcessing = True
       selectedCellValue = totalAreaSheet.Range(CELL_ADDRESS_TOTAL_AREA_TBA3_MACRO)                                                                        ' TBA3 매크로 삽입
    ElseIf (tbInStrResult > 0 And tbd3 <> "") Then                                                                                                         ' TB GRP NO2 값이 있고,TBD(3)도 있으면
       needProcessing = True
       selectedCellValue = totalAreaSheet.Range(CELL_ADDRESS_TOTAL_AREA_TBA2_1_MACRO)                                                                      ' TBA2-1 매크로 입력
    ElseIf (tbInStrResult > 0) Then                                                                                                                        ' TB GRP NO2 값이 있으면
       needProcessing = True
       selectedCellValue = totalAreaSheet.Range(CELL_ADDRESS_TOTAL_AREA_TBA2_MACRO)                                                                        ' TBA2 매크로 입력
    ElseIf (cnInStrResult > 0 And tbd3 <> "" And tbGroupNo2 = "") Then                                                                                     ' CNA 값이 있고,TBD(3) 값도 있으나, TB GRP NO2 값이 없으면
       needProcessing = True
       selectedCellValue = totalAreaSheet.Range(CELL_ADDRESS_TOTAL_AREA_TBA1_1_MACRO)                                                                      ' TBA1-1 매크로 입력
    ElseIf (cnInStrResult > 0 And tbGroupNo2 = "") Then                                                                                                    ' CNA 값이 있고, TB GRP NO2 값이 없으면
       needProcessing = True
       selectedCellValue = totalAreaSheet.Range(CELL_ADDRESS_TOTAL_AREA_TBA1_MACRO)                                                                        ' TBA1 매크로 입력
    End If
    
    If (needProcessing) Then                                                                                                                               ' 처리 작업이 필요하면
        localRowIndex = localRowIndex + 1
        clsCommon.SetSingleLine2AndCopyVariant localRowIndex, ioListDataRowIndex, workingSheet
        workingSheet.Cells(localRowIndex, Constants.COLUMN_INDEX_MACRO_NAME).value = selectedCellValue                                                     ' 선택된 매크로 입력
    End If
    
    Process = localRowIndex
    
End Function



