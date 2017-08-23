VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
END
Attribute VB_Name = "ClsColumnMapping"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = False
Option Explicit

Public ColumnDescription As String

Private sourceColumnIndex As Long
Private targetColumnIndex As Long

Private sourceColumnIndexText As String
Private targetColumnIndexText As String

Private sourceColumnName As String
Private targetColumnName As String

Public Property Let SourceColumn(columnIndex As Long)

    sourceColumnIndex = columnIndex
    sourceColumnIndexText = Utilities.ToString(columnIndex)
    sourceColumnName = Utilities.ConverColumnIndexToLetter(columnIndex)

End Property

Public Property Let TargetColumn(columnIndex As Long)

    targetColumnIndex = columnIndex
    targetColumnIndexText = Utilities.ToString(columnIndex)
    targetColumnName = Utilities.ConverColumnIndexToLetter(columnIndex)

End Property

Public Property Get SourceColumn() As Long

    SourceColumn = sourceColumnIndex
    
End Property

Public Property Get TargetColumn() As Long

    TargetColumn = targetColumnIndex
    
End Property

Public Property Get SourceColumnText() As String

    SourceColumnText = sourceColumnIndexText
    
End Property

Public Property Get TargetColumnText() As String

    TargetColumnText = targetColumnIndexText
    
End Property

Public Property Get SourceColumnLetter() As String

    SourceColumnLetter = sourceColumnName
    
End Property

Public Property Get TargetColumnLetter() As String

    TargetColumnLetter = targetColumnName
    
End Property

