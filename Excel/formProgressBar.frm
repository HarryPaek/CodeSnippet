VERSION 5.00
Begin {C62A69F0-16DC-11CE-9E98-00AA00574A4F} formProgressBar 
   Caption         =   "Progress Bar"
   ClientHeight    =   1260
   ClientLeft      =   45
   ClientTop       =   390
   ClientWidth     =   8505.001
   Enabled         =   0   'False
   OleObjectBlob   =   "formProgressBar.frx":0000
   ShowModal       =   0   'False
   StartUpPosition =   2  '화면 가운데
End
Attribute VB_Name = "formProgressBar"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Private Sub UserForm_QueryClose(Cancel As Integer, CloseMode As Integer)
    If CloseMode = VbQueryClose.vbFormControlMenu Then
        Cancel = True
    End If
End Sub
