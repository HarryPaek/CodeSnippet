VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
END
Attribute VB_Name = "ClsTotalProcessorLocationBox"
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
Private Const COLUMN_INDEX_TEXT_PAGE_NAME            As String = "9"
Private Const COLUMN_INDEX_TEXT_MACRO_VARIANT_TYPE   As String = "11"
Private Const COLUMN_INDEX_TEXT_COMP_NO_1            As String = "17"   '' Ȯ���ؼ� ��ȿ�� ������ ������ ��

'================================================================================
' ���� ������ ��Ʈ(DATA1, DATA2, DATA3) �� �ּ�
'================================================================================
Private Const CELL_ADDRESS_TOTAL_AREA_PL_BOX_1       As String = "G38"            ' DATA2 ��Ʈ
Private Const CELL_ADDRESS_TOTAL_AREA_PL_BOX_2       As String = "G39"            ' DATA2 ��Ʈ
Private Const CELL_ADDRESS_TOTAL_AREA_PL_BOX_3       As String = "G40"            ' DATA2 ��Ʈ

Private clsCommon As ClsWiringCommon
Private collectionExtension As ClsCollectionExtension

Private Sub Class_Initialize()

    'MsgBox "ClsTotalProcessorLocationBox Class is being initialized"
    
    Set clsCommon = New ClsWiringCommon
    Set collectionExtension = New ClsCollectionExtension
    
End Sub

Private Sub Class_Terminate()
    
    'MsgBox "ClsTotalProcessorLocationBox Class is being terminated"
    
    Set clsCommon = Nothing
    Set collectionExtension = Nothing

End Sub

'================================================================================================================================================================
' LOCATION BOX ������ ��� ǥ��
' ���� Row Index ���� ������ �ʿ��� ��쿡 +1 �ؼ� �۾�
' ���� �۾��� ���� Row Index ���� ���� ��
'================================================================================================================================================================
Public Function Process(rowIndex As Long, ioListDataRowIndex As Long, workingSheet As Worksheet, totalAreaSheet As Worksheet, cellValues As Collection) As Long

    Dim localRowIndex          As Long
    Dim macroVariantType       As Variant
    Dim pageName               As Variant
    Dim nextRowPageName        As Variant
    Dim compNo1                As Variant
    
    localRowIndex = rowIndex
    ' compNo1 = cellValues.Item(COLUMN_INDEX_TEXT_COMP_NO_1)
    compNo1 = collectionExtension.TryGetValue(cellValues, COLUMN_INDEX_TEXT_COMP_NO_1)                                   'Q, IO ��Ʈ�� ���� ��츦 ����Ͽ� Extension Method ���
    
    macroVariantType = cellValues.Item(COLUMN_INDEX_TEXT_MACRO_VARIANT_TYPE)
    pageName = cellValues.Item(COLUMN_INDEX_TEXT_PAGE_NAME)
    nextRowPageName = workingSheet.Cells(ioListDataRowIndex + 1, Constants.COLUMN_INDEX_PAGE_NAME)                       'IO ��Ʈ ���� �� ���� Row�� ���� �۾��� Row�� (ioListDataRowIndex + 1) ��
    
    '' ======================================================================================================================================
    '' �������� �ٲ�� ��ܿ� ��� ǥ��
    ''
    '' 2017�� 8��, �ٽ� �ۼ��ϸ鼭 �м��� �Ʒ� ����
    ''
    ''  - �������� ����Ǵ��� ���θ� �Ǵ��ϴ� �������� ����. �׷��� ����(����)ó�� ���� ������ �����ϴ� ��쿡�� �۵��� �� ���� ������,
    ''   -- ���� ������ ������ ����ϴ��� �ľ� �ʿ���
    ''   -- ���� �ڵ��
    ''    -- If macroType = "A" And Cells(i, 9).Value <> Cells(i + 1, 9).Value And Cells(i, 17) <> "" Then
    ''
    ''  - �� ��ũ�� Ÿ���� 'A'�̸� �������� ����Ǵ� ���̹Ƿ� �ᱹ ������ üũ�� �� �� �ϴ� �����
    ''  - �׸���, (���� ������ ���� ��Ʈ����)17��° �÷�(Q, Comp. No1)�� ������ ������
    ''  - ���� ù��° ������ ���� �۵��ϴ� ��츦 �߰����� ����.
    ''
    '' ======================================================================================================================================
    
    If (macroVariantType = "A" And pageName <> nextRowPageName And compNo1 <> "") Then                                                                     ' ��ũ�� Variant "A", Comp No1�� ���� ������
        localRowIndex = localRowIndex + 1
        workingSheet.Cells(localRowIndex, Constants.COLUMN_INDEX_MACRO_NAME).value = totalAreaSheet.Range(CELL_ADDRESS_TOTAL_AREA_PL_BOX_1)                ' PL_BOX1 ��ũ�� �Է�
        clsCommon.SetSingleLine2AndCopyVariant localRowIndex, ioListDataRowIndex, workingSheet
    End If
    
    If (macroVariantType = "A" And pageName <> nextRowPageName) Then                                                                                       ' ��ũ�� Variant "A"
        localRowIndex = localRowIndex + 1
        workingSheet.Cells(localRowIndex, Constants.COLUMN_INDEX_MACRO_NAME).value = totalAreaSheet.Range(CELL_ADDRESS_TOTAL_AREA_PL_BOX_3)                ' PL_BOX3 ��ũ�� �Է�
        clsCommon.SetSingleLine2AndCopyVariant localRowIndex, ioListDataRowIndex, workingSheet
        
        localRowIndex = localRowIndex + 1
        workingSheet.Cells(localRowIndex, Constants.COLUMN_INDEX_MACRO_NAME).value = totalAreaSheet.Range(CELL_ADDRESS_TOTAL_AREA_PL_BOX_2)                ' PL_BOX2 ��ũ�� �Է�
        clsCommon.SetSingleLine2AndCopyVariant localRowIndex, ioListDataRowIndex, workingSheet
    End If
    
    Process = localRowIndex
    
End Function
