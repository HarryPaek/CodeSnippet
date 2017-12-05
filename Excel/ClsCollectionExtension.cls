VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
END
Attribute VB_Name = "ClsCollectionExtension"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = False
Option Explicit


'================================================================================================================================================================
' ��ƿ��Ƽ �Լ�
'  - �־��� Collection�� �ش� Key�� �ִ��� �˻�
'================================================================================================================================================================
Function ContainsKey(coll As Collection, itemKey As Variant) As Boolean
    Dim itemValue As Variant
    
    ' ����� �ϴ� False�� �ʱ�ȭ
    ContainsKey = False
    
    On Error Resume Next
    
    If (itemKey <> "" And itemKey > 0) Then
        itemValue = coll(itemKey)
    
        ContainsKey = (Err.number = 0)
        Err.Clear
    End
        
    
End Function


'================================================================================================================================================================
' ��ƿ��Ƽ �Լ�
'  - �־��� Collection�� �ش� itemKey�� �ִ��� �˻��Ͽ�. ���� ���� ������
'    - ������ �ش� itemValue ��
'    - ������, Empty
'================================================================================================================================================================
Function TryGetValue(coll As Collection, itemKey As Variant) As Variant
    Dim itemValue As Variant
    
    ' ����� �ϴ� 'NULL'�� �ʱ�ȭ
    itemValue = Empty
    
    On Error Resume Next
    
    If (itemKey <> "" And itemKey > 0) Then
        itemValue = coll(itemKey)
    
        If Not (Err.number = 0) Then
    
            itemValue = Empty
    
        End If
    
        Err.Clear
    End If
    
    TryGetValue = itemValue
    
End Function