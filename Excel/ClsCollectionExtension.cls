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
' 유틸리티 함수
'  - 주어진 Collection에 해당 Key가 있는지 검사
'================================================================================================================================================================
Function ContainsKey(coll As Collection, itemKey As Variant) As Boolean
    Dim itemValue As Variant
    
    ' 결과값 일단 False로 초기화
    ContainsKey = False
    
    On Error Resume Next
    
    If (itemKey <> "" And itemKey > 0) Then
        itemValue = coll(itemKey)
    
        ContainsKey = (Err.number = 0)
        Err.Clear
    End
        
    
End Function


'================================================================================================================================================================
' 유틸리티 함수
'  - 주어진 Collection에 해당 itemKey가 있는지 검사하여. 다음 값을 돌려줌
'    - 있으면 해당 itemValue 값
'    - 없으면, Empty
'================================================================================================================================================================
Function TryGetValue(coll As Collection, itemKey As Variant) As Variant
    Dim itemValue As Variant
    
    ' 결과값 일단 'NULL'로 초기화
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
