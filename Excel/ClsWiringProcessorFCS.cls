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
' CellValues Collection �ε���
'  - CellValues Collection�� ���� ��� ��Ʈ Column Number Text(��, "15")�� Ű �������Ͽ� ����
'  - �Ʒ��� ������ ��, �ݵ�� ���ڿ��� ������ ��
'===== ===== ===== ================================================================================
Private Const COLUMN_INDEX_TEXT_FCS_CNA                         As String = "103"
Private Const COLUMN_INDEX_TEXT_FCS_CNB                         As String = "104"
Private Const COLUMN_INDEX_TEXT_FCS_CN_NO                       As String = "138"
Private Const COLUMN_INDEX_TEXT_FCS_NEST                        As String = "141"

'================================================================================
' ���� ������ ��Ʈ(DATA1, DATA2, DATA3) �� �ּ�
'================================================================================
Private Const CELL_ADDRESS_WIRING_DIAGRAM_FCS_CNA_1SLOT         As String = "AK5"             ' DATA3 ��Ʈ
Private Const CELL_ADDRESS_WIRING_DIAGRAM_FCS_CNA_1SLOT_RIO     As String = "AK37"            ' DATA3 ��Ʈ
Private Const CELL_ADDRESS_WIRING_DIAGRAM_FCS_CNB_2SLOT         As String = "AK6"             ' DATA3 ��Ʈ
Private Const CELL_ADDRESS_WIRING_DIAGRAM_FCS_CNB_2SLOT_RIO     As String = "AK38"            ' DATA3 ��Ʈ

Private Const CELL_ADDRESS_WIRING_DIAGRAM_1SLOT_MACRO           As String = "AL5"             ' DATA3 ��Ʈ
Private Const CELL_ADDRESS_WIRING_DIAGRAM_1SLOT_RIO_MACRO       As String = "AL37"            ' DATA3 ��Ʈ
Private Const CELL_ADDRESS_WIRING_DIAGRAM_2SLOT_MACRO           As String = "AL6"             ' DATA3 ��Ʈ
Private Const CELL_ADDRESS_WIRING_DIAGRAM_2SLOT_RIO_MACRO       As String = "AL38"            ' DATA3 ��Ʈ


' FCS ���� 2~16 Point
' FCS ���� 18~32 Point
Private Const FCS_COMMON_ROW_INDEX_START                        As Long = 7                   ' DATA3 ��Ʈ, Common�� ���ϴ� Row ���� �ε���
Private Const FCS_COMMON_ROW_INDEX_END                          As Long = 36                  ' DATA3 ��Ʈ, Common�� ���ϴ� Row ������ �ε���

Private Const FCS_COMMON_COLUMN_PREFIX_CN_NO_COMPARE            As String = "AK"              ' DATA3 ��Ʈ, CN NO ���� ���ϴ� �÷�
Private Const FCS_COMMON_COLUMN_PREFIX_WIRING_MACRO             As String = "AL"              ' DATA3 ��Ʈ, Wiring ��ũ�θ� �������� �÷�


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
' FCS ó��
' ���� Row Index ���� ������ �ʿ��� ��쿡 +1 �ؼ� �۾�
' ���� �۾��� ���� Row Index ���� ���� ��
'================================================================================================================================================================
Public Function Process(rowIndex As Long, ioListDataRowIndex As Long, workingSheet As Worksheet, wiringDiagramSheet As Worksheet, cellValues As Collection) As Long

    Dim needProcessing             As Boolean                                                                                                              ' ���μ��� ����
    Dim localRowIndex              As Long
    Dim fcsCNA                     As Variant
    Dim fcsCNB                     As Variant
    Dim fcsCNNo                    As Variant
    Dim fcsNest                    As Variant
    
    Dim fcsWiringDiagramRowIndex   As Long
    Dim selectedCellValue          As Variant                                                                                                              ' ���� ������� ���õ� DATA3 Cell ��
    Dim variantIndex               As Long
    Dim variantIndexText           As String
    Dim compareCellAddressText     As String
    Dim macroCellAddressText       As String

    
    needProcessing = False
    localRowIndex = rowIndex
    
    ''fcsCNA = cellValues.Item(COLUMN_INDEX_TEXT_FCS_CNA)
    fcsCNA = collectionExtension.TryGetValue(cellValues, COLUMN_INDEX_TEXT_FCS_CNA)                                          'CY, IO ��Ʈ�� ���� ��츦 ����Ͽ� Extension Method ���

    ''fcsCNNo = cellValues.Item(COLUMN_INDEX_TEXT_FCS_CN_NO)
    fcsCNNo = collectionExtension.TryGetValue(cellValues, COLUMN_INDEX_TEXT_FCS_CN_NO)                                       'EH, IO ��Ʈ�� ���� ��츦 ����Ͽ� Extension Method ���
    
    ''fcsNest = cellValues.Item(COLUMN_INDEX_TEXT_FCS_NEST)
    fcsNest = collectionExtension.TryGetValue(cellValues, COLUMN_INDEX_TEXT_FCS_NEST)                                        'EK, IO ��Ʈ�� ���� ��츦 ����Ͽ� Extension Method ���
        
    ''fcsCNB = cellValues.Item(COLUMN_INDEX_TEXT_FCS_CNB)
    fcsCNB = collectionExtension.TryGetValue(cellValues, COLUMN_INDEX_TEXT_FCS_CNB)                                          'CZ, IO ��Ʈ�� ���� ��츦 ����Ͽ� Extension Method ���
    
    variantIndex = 1                                                                                     '  Variant ���� "B"���� ����
        
    ' FCS ���� 2~16, 18~32
    For fcsWiringDiagramRowIndex = FCS_COMMON_ROW_INDEX_START To FCS_COMMON_ROW_INDEX_END
    
       compareCellAddressText = FCS_COMMON_COLUMN_PREFIX_CN_NO_COMPARE & fcsWiringDiagramRowIndex        '  �� ��� Cell �ּ�,  AKxx
       macroCellAddressText = FCS_COMMON_COLUMN_PREFIX_WIRING_MACRO & fcsWiringDiagramRowIndex           '  Wiring ��ũ�� Cell �ּ�, ALxx
       
       If (fcsCNNo = wiringDiagramSheet.Range(compareCellAddressText)) Then                              ' ���� ���� DATA3���� CNxx(CN2~16, CN18~32) ���� ���ؼ� ��ġ�ϴ� ���
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
   
    Next fcsWiringDiagramRowIndex
    
    
    ' ���뿡�� ��ġ�ϴ� ���� ������, ���� FCS Ȯ��
    If Not (needProcessing) Then                                                                                                             ' Common���� ��ġ�ϴ� ���� �߰ߵ��� ���� ���
         
        variantIndexText = "A"                                                                                                               ' ���� Variant Type�� ��� "A"
        If (fcsCNB > 0 And fcsNest <> "") Then                                                                                               ' CN B�� Ȯ��/NEST �� Ȯ��
           
           If (fcsCNNo = wiringDiagramSheet.Range(CELL_ADDRESS_WIRING_DIAGRAM_FCS_CNB_2SLOT_RIO)) Then                                       ' CNB 1�� Ȯ��
               needProcessing = True
               selectedCellValue = wiringDiagramSheet.Range(CELL_ADDRESS_WIRING_DIAGRAM_2SLOT_RIO_MACRO)                                     ' 2SLOT_RIO ��ũ�� �Է�
           
           ElseIf (fcsCNNo = "17") Then                                                                                                      ' CN 17�� Ȯ��
               needProcessing = True
               selectedCellValue = wiringDiagramSheet.Range(CELL_ADDRESS_WIRING_DIAGRAM_2SLOT_RIO_MACRO)                                     ' 2SLOT_RIO ��ũ�� �Է�
           
           End If

        ElseIf (fcsCNB > 0) Then                                                                                                             ' CN B�� Ȯ��
        
           If (fcsCNNo = wiringDiagramSheet.Range(CELL_ADDRESS_WIRING_DIAGRAM_FCS_CNB_2SLOT)) Then                                           ' CNB 1�� Ȯ��
               needProcessing = True
               selectedCellValue = wiringDiagramSheet.Range(CELL_ADDRESS_WIRING_DIAGRAM_2SLOT_MACRO)                                         ' 2SLOT ��ũ�� �Է�
           
           ElseIf (fcsCNNo = "17") Then                                                                                                      ' CN 17�� Ȯ��
               needProcessing = True
               selectedCellValue = wiringDiagramSheet.Range(CELL_ADDRESS_WIRING_DIAGRAM_2SLOT_MACRO)                                         ' 2SLOT ��ũ�� �Է�
           
           End If
        
        ElseIf (fcsCNA > 0 And fcsNest <> "") Then                                                                                           ' CN A�� Ȯ��/NEST �� Ȯ��
           
           If (fcsCNNo = wiringDiagramSheet.Range(CELL_ADDRESS_WIRING_DIAGRAM_FCS_CNA_1SLOT_RIO)) Then                                       ' CNA 1�� Ȯ��
               needProcessing = True
               selectedCellValue = wiringDiagramSheet.Range(CELL_ADDRESS_WIRING_DIAGRAM_1SLOT_RIO_MACRO)                                     ' 1SLOT_RIO ��ũ�� �Է�
           
           ElseIf (fcsCNNo = "17") Then                                                                                                      ' CN 17�� Ȯ��
               needProcessing = True
               selectedCellValue = wiringDiagramSheet.Range(CELL_ADDRESS_WIRING_DIAGRAM_1SLOT_RIO_MACRO)                                      ' 1SLOT_RIO ��ũ�� �Է�
           
           End If

        ElseIf (fcsCNA > 0) Then                                                                                                             ' CN A�� Ȯ��
        
           If (fcsCNNo = wiringDiagramSheet.Range(CELL_ADDRESS_WIRING_DIAGRAM_FCS_CNA_1SLOT)) Then                                           ' CN 1�� Ȯ��
               needProcessing = True
               selectedCellValue = wiringDiagramSheet.Range(CELL_ADDRESS_WIRING_DIAGRAM_1SLOT_MACRO)                                         ' 1SLOT ��ũ�� �Է�
           
           ElseIf (fcsCNNo = "17") Then                                                                                                      ' CN 17�� Ȯ��
               needProcessing = True
               selectedCellValue = wiringDiagramSheet.Range(CELL_ADDRESS_WIRING_DIAGRAM_1SLOT_MACRO)                                         ' 1SLOT ��ũ�� �Է�
           
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
