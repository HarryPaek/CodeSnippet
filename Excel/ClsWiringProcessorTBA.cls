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
' CellValues Collection �ε���
'  - CellValues Collection�� ���� ��� ��Ʈ Column Number Text(��, "15")�� Ű �������Ͽ� ����
'  - �Ʒ��� ������ ��, �ݵ�� ���ڿ��� ������ ��
'===== ===== ===== ================================================================================
Private Const COLUMN_INDEX_TEXT_TBA_INT_POWER                   As String = "169"
Private Const COLUMN_INDEX_TEXT_TBA_EXT_POWER                   As String = "170"
Private Const COLUMN_INDEX_TEXT_TBA_CN_NO                       As String = "138"
Private Const COLUMN_INDEX_TEXT_TBA_TBD_3                       As String = "102"

'================================================================================
' ���� ������ ��Ʈ(DATA1, DATA2, DATA3) �� �ּ�
'================================================================================
Private Const CELL_ADDRESS_WIRING_DIAGRAM_NO_POWER_CN_NO_1      As String = "AA10"            ' DATA3 ��Ʈ

Private Const CELL_ADDRESS_WIRING_DIAGRAM_EXT_POWER_CN_NO_1     As String = "AA8"             ' DATA3 ��Ʈ
Private Const CELL_ADDRESS_WIRING_DIAGRAM_EXT_POWER_CN_NO_17    As String = "AA9"             ' DATA3 ��Ʈ
Private Const CELL_ADDRESS_WIRING_DIAGRAM_INT_POWER_CN_NO_1     As String = "AA12"            ' DATA3 ��Ʈ
Private Const CELL_ADDRESS_WIRING_DIAGRAM_INT_POWER_CN_NO_17    As String = "AA13"            ' DATA3 ��Ʈ
Private Const CELL_ADDRESS_WIRING_DIAGRAM_BOTH_POWER_CN_NO_1    As String = "AA10"            ' DATA3 ��Ʈ
Private Const CELL_ADDRESS_WIRING_DIAGRAM_BOTH_POWER_CN_NO_17   As String = "AA11"            ' DATA3 ��Ʈ

Private Const CELL_ADDRESS_WIRING_DIAGRAM_TBA1                  As String = "AD5"             ' DATA3 ��Ʈ
Private Const CELL_ADDRESS_WIRING_DIAGRAM_TBA2                  As String = "AG5"             ' DATA3 ��Ʈ
Private Const CELL_ADDRESS_WIRING_DIAGRAM_TBA5                  As String = "AD8"             ' DATA3 ��Ʈ
Private Const CELL_ADDRESS_WIRING_DIAGRAM_TBA5_1                As String = "AD9"             ' DATA3 ��Ʈ
Private Const CELL_ADDRESS_WIRING_DIAGRAM_TBA6                  As String = "AD10"            ' DATA3 ��Ʈ
Private Const CELL_ADDRESS_WIRING_DIAGRAM_TBA6_1                As String = "AD11"            ' DATA3 ��Ʈ
Private Const CELL_ADDRESS_WIRING_DIAGRAM_TBA7                  As String = "AD12"            ' DATA3 ��Ʈ
Private Const CELL_ADDRESS_WIRING_DIAGRAM_TBA7_1                As String = "AD13"            ' DATA3 ��Ʈ


' TBA ���� 2~16 Point
' TBA ���� 18~32 Point
Private Const TBA_COMMON_ROW_INDEX_START                        As Long = 14                  ' DATA3 ��Ʈ, Common�� ���ϴ� Row ���� �ε���
Private Const TBA_COMMON_SUB_ROW_INDEX_END                      As Long = 28                  ' DATA3 ��Ʈ, "TBA Sub" Common�� ���ϴ� Row ������ �ε���
Private Const TBA_COMMON_ROW_INDEX_END                          As Long = 43                  ' DATA3 ��Ʈ, Common�� ���ϴ� Row ������ �ε���
Private Const TBA_COMMON_COLUMN_PREFIX_CN_NO_COMPARE            As String = "AA"              ' DATA3 ��Ʈ, CN NO ���� ���ϴ� �÷�
Private Const TBA_COMMON_COLUMN_PREFIX_TBA_MACRO                As String = "AD"              ' DATA3 ��Ʈ, TBA ��ũ�θ� �������� �÷�
Private Const TBA_COMMON_COLUMN_PREFIX_TBA_1_MACRO              As String = "AG"              ' DATA3 ��Ʈ, TBA-1 ��ũ�θ� �������� �÷�


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
' TBA ó��
' ���� Row Index ���� ������ �ʿ��� ��쿡 +1 �ؼ� �۾�
' ���� �۾��� ���� Row Index ���� ���� ��
'================================================================================================================================================================
Public Function Process(rowIndex As Long, ioListDataRowIndex As Long, workingSheet As Worksheet, wiringDiagramSheet As Worksheet, cellValues As Collection) As Long

    Dim needProcessing             As Boolean                                                                                                              ' ���μ��� ����
    Dim localRowIndex              As Long
    Dim tbaCNNo                    As Variant
    Dim tbaIntPower                As Variant
    Dim tbaExtPower                As Variant
    Dim tbaTbd3                    As Variant
    Dim selectedCellValue          As Variant                                                                                                              ' ���� ������� ���õ� DATA3 Cell ��
    Dim variantIndex               As Long
    Dim variantIndexText           As String
    Dim tbaWiringDiagramRowIndex   As Long
    Dim compareCellAddressText     As String
    Dim macroCellAddressText       As String

    
    needProcessing = False
    localRowIndex = rowIndex

    ''tbaCNNo = cellValues.Item(COLUMN_INDEX_TEXT_TBA_CN_NO)
    tbaCNNo = collectionExtension.TryGetValue(cellValues, COLUMN_INDEX_TEXT_TBA_CN_NO)                                   'EH, IO ��Ʈ�� ���� ��츦 ����Ͽ� Extension Method ���

    ''tbaIntPower = cellValues.Item(COLUMN_INDEX_TEXT_TBA_INT_POWER)
    tbaIntPower = collectionExtension.TryGetValue(cellValues, COLUMN_INDEX_TEXT_TBA_INT_POWER)                           'FM, IO ��Ʈ�� ���� ��츦 ����Ͽ� Extension Method ���

    ''tbaExtPower = cellValues.Item(COLUMN_INDEX_TEXT_TBA_EXT_POWER)
    tbaExtPower = collectionExtension.TryGetValue(cellValues, COLUMN_INDEX_TEXT_TBA_EXT_POWER)                           'FN, IO ��Ʈ�� ���� ��츦 ����Ͽ� Extension Method ���

    ''tbaTbd3 = cellValues.Item(COLUMN_INDEX_TEXT_TBA_TBD_3)
    tbaTbd3 = collectionExtension.TryGetValue(cellValues, COLUMN_INDEX_TEXT_TBA_TBD_3)                                   'CX, IO ��Ʈ�� ���� ��츦 ����Ͽ� Extension Method ���
    
    variantIndex = 1                                                                                     '  Variant ���� "B"���� ����
        
    ' TBA Sub ���� 2~16
    For tbaWiringDiagramRowIndex = TBA_COMMON_ROW_INDEX_START To TBA_COMMON_SUB_ROW_INDEX_END
    
        compareCellAddressText = TBA_COMMON_COLUMN_PREFIX_CN_NO_COMPARE & tbaWiringDiagramRowIndex        '  �� ��� Cell �ּ�,  AAxx
        macroCellAddressText = TBA_COMMON_COLUMN_PREFIX_TBA_1_MACRO & tbaWiringDiagramRowIndex            '  TBA-1 ��ũ�� Cell �ּ�, AGxx
       
        If (tbaCNNo = wiringDiagramSheet.Range(compareCellAddressText) And tbaTbd3 <> "") Then             ' ���� ���� DATA3���� CNxx(CN2~16) ���� ��, TB3���� �����ϴ� ���
            needProcessing = True
            selectedCellValue = wiringDiagramSheet.Range(macroCellAddressText)
            variantIndexText = clsCommon.ToVariantText(variantIndex)
            
            ' MsgBox "Variant Index =[" & variantIndex & "], variantIndexText = [" & variantIndexText & "]"

            Exit For                                                                                      ' ��ġ�Ǵ� ��� ���� ���� �����ϰ� �ٷ� For Loop ����
        End If
       
        variantIndex = variantIndex + 1                                                                   ' ���� Variant ��������
       
        If (variantIndex Mod clsCommon.NUMBER_OF_DATA_PER_WIRING_DRAWING_PAGE = 0) Then                   ' Variant "A"(16, 32, 48, ...)�� ���� �������� ���ܵ�, �� B ~ P������ �ش��
           variantIndex = variantIndex + 1
        End If
   
    Next tbaWiringDiagramRowIndex
        
        
    ' TBA Sub���� ��ġ�ϴ� ���� ������
    If Not (needProcessing) Then
    
        variantIndex = 1                                                                                      '  Variant ���� "B"�� Reset
    
        ' TBA ���� 2~16, 18~32
        For tbaWiringDiagramRowIndex = TBA_COMMON_ROW_INDEX_START To TBA_COMMON_ROW_INDEX_END
    
            compareCellAddressText = TBA_COMMON_COLUMN_PREFIX_CN_NO_COMPARE & tbaWiringDiagramRowIndex        '  �� ��� Cell �ּ�,  AAxx
            macroCellAddressText = TBA_COMMON_COLUMN_PREFIX_TBA_MACRO & tbaWiringDiagramRowIndex              '  TBA ��ũ�� Cell �ּ�, ADxx
       
            If (tbaCNNo = wiringDiagramSheet.Range(compareCellAddressText)) Then                              ' ���� ���� DATA3���� CNxx(CN2~16, CN18~32) ���� ���ؼ� ��ġ�ϴ� ���
                needProcessing = True
                selectedCellValue = wiringDiagramSheet.Range(macroCellAddressText)
                variantIndexText = clsCommon.ToVariantText(variantIndex)
           
                ' MsgBox "Variant Index =[" & variantIndex & "], variantIndexText = [" & variantIndexText & "]"

                Exit For                                                                                      ' ��ġ�Ǵ� ��� ���� ���� �����ϰ� �ٷ� For Loop ����
            End If
       
            variantIndex = variantIndex + 1                                                                   ' ���� Variant ��������
       
            If (variantIndex Mod clsCommon.NUMBER_OF_DATA_PER_WIRING_DRAWING_PAGE = 0) Then                   ' Variant "A"(16, 32, 48, ...)�� ���� �������� ���ܵ�, �� B ~ P������ �ش��
                variantIndex = variantIndex + 1
            End If
   
        Next tbaWiringDiagramRowIndex
        
    End If
    
    
    ' ���뿡�� ��ġ�ϴ� ���� ������, TBA1 ~ TBA7
    If Not (needProcessing) Then                                                                                                             ' Common���� ��ġ�ϴ� ���� �߰ߵ��� ���� ���
         
        variantIndexText = "A"                                                                                                               ' ���� Variant Type�� ��� "A"
        If (tbaIntPower > 0 And tbaExtPower > 0) Then                                                                                        ' INT. POWER & EXT. POWER ��� �����ϸ�
           
           If (tbaCNNo = wiringDiagramSheet.Range(CELL_ADDRESS_WIRING_DIAGRAM_BOTH_POWER_CN_NO_17)) Then                                     ' INT. POWER & EXT POWER Ȯ��/CN NO 17 Ȯ��
               needProcessing = True
               selectedCellValue = wiringDiagramSheet.Range(CELL_ADDRESS_WIRING_DIAGRAM_TBA7_1)                                              ' TBA7-1 ��ũ�� �Է�
           
           ElseIf (tbaCNNo = wiringDiagramSheet.Range(CELL_ADDRESS_WIRING_DIAGRAM_BOTH_POWER_CN_NO_1)) Then                                  ' INT. POWER & EXT POWER Ȯ��/CN NO 1 Ȯ��
               needProcessing = True
               selectedCellValue = wiringDiagramSheet.Range(CELL_ADDRESS_WIRING_DIAGRAM_TBA7)                                                ' TBA7 ��ũ�� �Է�
           
           End If

        ElseIf (tbaIntPower > 0) Then                                                                                                        ' INT. POWER�� �����ϸ�
        
           If (tbaCNNo = wiringDiagramSheet.Range(CELL_ADDRESS_WIRING_DIAGRAM_INT_POWER_CN_NO_17)) Then                                      ' INT. POWER Ȯ��/CN NO 17 Ȯ��
               needProcessing = True
               selectedCellValue = wiringDiagramSheet.Range(CELL_ADDRESS_WIRING_DIAGRAM_TBA6_1)                                              ' TBA6-1 ��ũ�� �Է�
           
           ElseIf (tbaCNNo = wiringDiagramSheet.Range(CELL_ADDRESS_WIRING_DIAGRAM_INT_POWER_CN_NO_1)) Then                                   ' INT. POWER Ȯ��/CN NO 1 Ȯ��
               needProcessing = True
               selectedCellValue = wiringDiagramSheet.Range(CELL_ADDRESS_WIRING_DIAGRAM_TBA6)                                                ' TBA6 ��ũ�� �Է�
           
           End If
        
        ElseIf (tbaExtPower > 0) Then                                                                                                        ' EXT. POWER�� �����ϸ�
        
           If (tbaCNNo = wiringDiagramSheet.Range(CELL_ADDRESS_WIRING_DIAGRAM_EXT_POWER_CN_NO_17)) Then                                      ' EXT. POWER Ȯ��/CN NO 17 Ȯ��
               needProcessing = True
               selectedCellValue = wiringDiagramSheet.Range(CELL_ADDRESS_WIRING_DIAGRAM_TBA5_1)                                              ' TBA5-1 ��ũ�� �Է�
           
           ElseIf (tbaCNNo = wiringDiagramSheet.Range(CELL_ADDRESS_WIRING_DIAGRAM_EXT_POWER_CN_NO_1)) Then                                   ' EXT. POWER Ȯ��/CN NO 1 Ȯ��
               needProcessing = True
               selectedCellValue = wiringDiagramSheet.Range(CELL_ADDRESS_WIRING_DIAGRAM_TBA5)                                                ' TBA5 ��ũ�� �Է�
           
           End If
        
        Else                                                                                                                                 ' ��� �������� ������
        
           If (tbaCNNo = wiringDiagramSheet.Range(CELL_ADDRESS_WIRING_DIAGRAM_NO_POWER_CN_NO_1) And tbaTbd3 <> "") Then                      ' INT. EXT POWER ����/CN NO 1 Ȯ��/TBD(3) ���� ������
               needProcessing = True
               selectedCellValue = wiringDiagramSheet.Range(CELL_ADDRESS_WIRING_DIAGRAM_TBA2)                                                ' TBA2 ��ũ�� �Է�
           
           ElseIf (tbaCNNo = wiringDiagramSheet.Range(CELL_ADDRESS_WIRING_DIAGRAM_NO_POWER_CN_NO_1)) Then                                    ' INT. EXT POWER ����/CN NO 1 Ȯ��
               needProcessing = True
               selectedCellValue = wiringDiagramSheet.Range(CELL_ADDRESS_WIRING_DIAGRAM_TBA1)                                                ' TBA1 ��ũ�� �Է�(A1BA4D, A1BR4D,A1BT4D)
           
           End If
        
        End If
    End If
    
    If (needProcessing) Then                                                                                                                 ' ó�� �۾��� �ʿ��ϸ�
        localRowIndex = localRowIndex + 1
        clsCommon.SetSingleLine2AndVariantValue localRowIndex, ioListDataRowIndex, variantIndexText, workingSheet
        workingSheet.Cells(localRowIndex, Constants.COLUMN_INDEX_MACRO_NAME).value = selectedCellValue                                       ' ���õ� ��ũ�� �Է�
    End If
    
    Process = localRowIndex
    
End Function


