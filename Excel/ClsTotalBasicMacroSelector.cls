VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
END
Attribute VB_Name = "ClsTotalBasicMacroSelector"
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
Private Const COLUMN_INDEX_TEXT_TAG_TYPE             As String = "178"

'================================================================================
' ���� ������ ��Ʈ(DATA1, DATA2, DATA3) �� �ּ�
'================================================================================

' TAG TYPE CHECK          AM6 ~ AM48
' TAG TYPE�� ���� ��ũ��  AN6 ~ AN48
Private Const TAG_TYPE_CHECK_ROW_INDEX_START                    As Long = 6                   ' DATA2 ��Ʈ, Tag Type�� ���ǵ� Row ���� �ε���
Private Const TAG_TYPE_CHECK_ROW_INDEX_END                      As Long = 48                  ' DATA2 ��Ʈ, Tag Type�� ���ǵ� Row ������ �ε���

Private Const TAG_TYPE_CHECK_COLUMN_PREFIX_TO_COMPARE           As String = "AM"              ' DATA2 ��Ʈ, Tag Type ���� ���ϴ� �÷�
Private Const TAG_TYPE_CHECK_COLUMN_PREFIX_FOR_MAXRO            As String = "AN"              ' DATA2 ��Ʈ, ���õ� ��ũ�θ� �������� �÷�

Private clsCommon As ClsTotalCommon
Private collectionExtension As ClsCollectionExtension

Private Sub Class_Initialize()

    'MsgBox "ClsTotalBasicMacroSelector Class is being initialized"
    
    Set clsCommon = New ClsTotalCommon
    Set collectionExtension = New ClsCollectionExtension
    
End Sub

Private Sub Class_Terminate()
    
    'MsgBox "ClsTotalBasicMacroSelector Class is being terminated"
    
    Set clsCommon = Nothing
    Set collectionExtension = Nothing

End Sub


'================================================================================================================================================================
' ������ IO �����Ϳ� ���Ͽ�, �⺻ ��ũ�� �� �Ӽ��� ������
'================================================================================================================================================================
Public Sub Process(rowIndex As Long, workingSheet As Worksheet, totalAreaSheet As Worksheet, cellValues As Collection)

    Dim tagType                      As Variant
    Dim tagTypeTotalAreaSheetValue   As Variant                               ' �� ������� ���õ� DATA2 Cell �� (TAG TYPE)
    Dim totalAreaRowIndex            As Long
    Dim compareCellAddressText       As String
    Dim macroCellAddressText         As String
    Dim inStrResult                  As Integer                               ' InStr ���� ��� ��

    
    '' tagType = cellValues.Item(COLUMN_INDEX_TEXT_TAG_TYPE)
    tagType = collectionExtension.TryGetValue(cellValues, COLUMN_INDEX_TEXT_TAG_TYPE)                                    'FV, IO ��Ʈ�� ���� ��츦 ����Ͽ� Extension Method ���
    
    '===========================================================================================================================
    ' �߿�!!!
    ' �ܼ� ���ڿ� ��(InStr)�̹Ƿ�, "AA"���� "A"�� ���õ��� �ʵ��� �Ʒ����� ��(�� ���ڿ����� ª�� ���ڿ�) �������� ����
    '===========================================================================================================================
    For totalAreaRowIndex = TAG_TYPE_CHECK_ROW_INDEX_END To TAG_TYPE_CHECK_ROW_INDEX_START Step -1
    
        compareCellAddressText = TAG_TYPE_CHECK_COLUMN_PREFIX_TO_COMPARE & totalAreaRowIndex                                                 ' �� ��� Cell �ּ�,  AMxx
        macroCellAddressText = TAG_TYPE_CHECK_COLUMN_PREFIX_FOR_MAXRO & totalAreaRowIndex                                                    ' ���õ� ��ũ�� Cell �ּ�, ANxx
        
        tagTypeTotalAreaSheetValue = totalAreaSheet.Range(compareCellAddressText)
        inStrResult = InStr(tagType, tagTypeTotalAreaSheetValue)
    
        ' ���ڿ��� �����ϴ��� ��
        If inStrResult > 0 Then                                                                                                              ' �� ���, �ش� ���ڿ��� �����ϴ� ���
            workingSheet.Cells(rowIndex, Constants.COLUMN_INDEX_MACRO_NAME).value = totalAreaSheet.Range(macroCellAddressText)               ' ���õ� ��ũ�� �Է�
            clsCommon.SetSingleLine2 rowIndex, workingSheet
            
            Exit For                                                                                                                         ' ��ġ�� ���� �߰ߵǸ�, ���⼭ ����
        End If

    Next totalAreaRowIndex
    
End Sub
