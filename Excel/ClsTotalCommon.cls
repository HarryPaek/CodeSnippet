VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
END
Attribute VB_Name = "ClsTotalCommon"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = False
Option Explicit

Private Const INTERNAL_ROW_INDEX_IOLIST_DATA_START                  As Long = 2
Private Const INTERNAL_ROW_INDEX_RESULT_DATA_START                  As Long = 2
Private Const INTERNAL_NUMBER_OF_DATA_PER_TOTAL_DRAWING_PAGE        As Long = 4
Private Const INTERNAL_COLUMN_INDEX_TOTAL_PAGE_DESCRIPTION          As Long = 157            ' ��� ��Ʈ Page Description �÷�

'===== ===== ===== ================================================================================
' CellValues Collection �ε���
'  - CellValues Collection�� ���� ��� ��Ʈ Column Number Text(��, "15")�� Ű �������Ͽ� ����
'  - �Ʒ��� ������ ��, �ݵ�� ���ڿ��� ������ ��
'===== ===== ===== ================================================================================
Private Const INTERNAL_COLUMN_INDEX_TEXT_TOTAL_PAGE_NAME            As String = "9"          ' ����� CellValues Collection�� Page Name �÷�
Private Const INTERNAL_COLUMN_INDEX_TEXT_TOTAL_LOCATION1            As String = "15"         ' ����� CellValues Collection�� Location1 �÷�


Private eplanVariantList As Variant

Private Sub Class_Initialize()

    eplanVariantList = Array("A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P")
    
End Sub

Private Sub Class_Terminate()
    
    Set eplanVariantList = Nothing

End Sub

Public Property Get ROW_INDEX_TOTAL_IOLIST_DATA_START() As Long

    ROW_INDEX_TOTAL_IOLIST_DATA_START = INTERNAL_ROW_INDEX_RESULT_DATA_START
    
End Property

Public Property Get ROW_INDEX_TOTAL_RESULT_DATA_START() As Long

    ROW_INDEX_TOTAL_RESULT_DATA_START = INTERNAL_ROW_INDEX_IOLIST_DATA_START
    
End Property

Public Property Get NUMBER_OF_DATA_PER_TOTAL_DRAWING_PAGE() As Long

    NUMBER_OF_DATA_PER_TOTAL_DRAWING_PAGE = INTERNAL_NUMBER_OF_DATA_PER_TOTAL_DRAWING_PAGE
    
End Property

Public Property Get COLUMN_INDEX_TEXT_TOTAL_PAGE_NAME() As String

    COLUMN_INDEX_TEXT_TOTAL_PAGE_NAME = INTERNAL_COLUMN_INDEX_TEXT_TOTAL_PAGE_NAME
    
End Property


Public Property Get COLUMN_INDEX_TEXT_TOTAL_LOCATION1() As String

    COLUMN_INDEX_TEXT_TOTAL_LOCATION1 = INTERNAL_COLUMN_INDEX_TEXT_TOTAL_LOCATION1
    
End Property

Public Property Get COLUMN_INDEX_TOTAL_PAGE_DESCRIPTION() As Long

    COLUMN_INDEX_TOTAL_PAGE_DESCRIPTION = INTERNAL_COLUMN_INDEX_TOTAL_PAGE_DESCRIPTION
    
End Property

'================================================================================================================================================================
' ��ƿ��Ƽ �Լ�
'  - ������ �ε��� ���� �̿��Ͽ� �̿��Ͽ� ������ �ѹ� ����
'================================================================================================================================================================
Public Function ToPageNumber(dataRowIndex As Long) As String

    ToPageNumber = Utilities.ToString((dataRowIndex \ INTERNAL_NUMBER_OF_DATA_PER_TOTAL_DRAWING_PAGE) + 1)
    
End Function


'================================================================================================================================================================
' ��ƿ��Ƽ �Լ�
'  - ������ �ε��� ���� �̿��Ͽ� Variant �� ����
'================================================================================================================================================================
Public Function ToVariantText(dataRowIndex As Long) As String
   
   ToVariantText = eplanVariantList(dataRowIndex Mod INTERNAL_NUMBER_OF_DATA_PER_TOTAL_DRAWING_PAGE)
   
End Function


'================================================================================================================================================================
' ��ƿ��Ƽ �Լ�
'  - Single-Line 2 ���� �����ϰ� Variant ���� Copy
'================================================================================================================================================================
Public Sub SetSingleLine2AndCopyVariant(rowIndex As Long, ioListDataRowIndex As Long, workingSheet As Worksheet)

    SetSingleLine2 rowIndex, workingSheet
    CopyVariant rowIndex, ioListDataRowIndex, workingSheet

End Sub


'================================================================================================================================================================
' ��ƿ��Ƽ �Լ�
'  - Single-Line 2 ���� �����ϰ� Variant ���� �־��� �Ķ���� ������ ����
'================================================================================================================================================================
Public Sub SetSingleLine2AndVariantValue(rowIndex As Long, ioListDataRowIndex As Long, variantValue As String, workingSheet As Worksheet)

    SetSingleLine2 rowIndex, workingSheet
    SetVariantValue rowIndex, variantValue, workingSheet

End Sub


'================================================================================================================================================================
' ��ƿ��Ƽ �Լ�
'  - Single-Line 2 �� ����
'================================================================================================================================================================
Public Sub SetSingleLine2(rowIndex As Long, workingSheet As Worksheet)

    workingSheet.Cells(rowIndex, Constants.COLUMN_INDEX_SINGLE_LINE2).value = Constants.CELL_VALUE_SINGLE_LINE_2

End Sub


'================================================================================================================================================================
' ��ƿ��Ƽ �Լ�
'  - Variant �� Copy
'================================================================================================================================================================
Public Sub CopyVariant(rowIndex As Long, ioListDataRowIndex As Long, workingSheet As Worksheet)

    workingSheet.Cells(ioListDataRowIndex, Constants.COLUMN_INDEX_VARIANT).Copy workingSheet.Cells(rowIndex, Constants.COLUMN_INDEX_VARIANT)                 ' Variant ���� ioList ���� ������ Copy

End Sub


'================================================================================================================================================================
' ��ƿ��Ƽ �Լ�
'  - Variant �� ����
'================================================================================================================================================================
Public Sub SetVariantValue(rowIndex As Long, variantValue As String, workingSheet As Worksheet)

    workingSheet.Cells(rowIndex, Constants.COLUMN_INDEX_VARIANT).value = variantValue                                                                        ' �־��� ������ Variant �� ����

End Sub


Sub ClearBasicColumnsHeaderText(workingSheet As Worksheet)

    workingSheet.Cells(Constants.RESULT_ROW_INDEX_DATA_HEADER, Constants.COLUMN_INDEX_MACRO_NAME).value = ""    ' (1, 1),  "A1"  TYPICAL EEC ����
    workingSheet.Cells(Constants.RESULT_ROW_INDEX_DATA_HEADER, Constants.COLUMN_INDEX_SINGLE_LINE2).value = ""  ' (1, 10), "A10" ������ ����(Representation Type) ����

End Sub


Sub SetBasicColumnsHeaderText(workingSheet As Worksheet)

    workingSheet.Cells(Constants.RESULT_ROW_INDEX_DATA_HEADER, Constants.COLUMN_INDEX_MACRO_NAME).value = Constants.HEADER_TEXT_TYPICAL_EEC            ' (1, 1),  "A1" "TYPICAL EEC" ����
    workingSheet.Cells(Constants.RESULT_ROW_INDEX_DATA_HEADER, Constants.COLUMN_INDEX_SINGLE_LINE2).value = Constants.HEADER_TEXT_REPRESENTATION_TYPE  ' (1, 10), "A10" Representation Type ����

End Sub


Public Function CopyFromTemplate() As Worksheet
    
    Const sourceTemplate As String = Constants.TOTALLOOP_TEMPLATE_SHEET
    Dim targetSheetPrefix As String
    
    targetSheetPrefix = "TotalLoop"
    Set CopyFromTemplate = Utilities.CopyTemplateToNewSheet(sourceTemplate, targetSheetPrefix)

End Function

