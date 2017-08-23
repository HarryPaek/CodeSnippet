VERSION 5.00
Begin {C62A69F0-16DC-11CE-9E98-00AA00574A4F} MainForm 
   Caption         =   "::: EPLAN Drawing Generator For EEC One"
   ClientHeight    =   3765
   ClientLeft      =   45
   ClientTop       =   390
   ClientWidth     =   9510.001
   OleObjectBlob   =   "MainForm.frx":0000
   StartUpPosition =   1  '소유자 가운데
End
Attribute VB_Name = "MainForm"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Private cancelling As Boolean

Public Property Get IOSheetFullPath() As String
    IOSheetFullPath = Me.txtIOListFile.value
End Property

Public Property Get numberOfRowsPerSheet() As Long
    numberOfRowsPerSheet = Me.txtMaxRowNumberOfSheet.value
End Property

Public Property Get IsCancelled() As Boolean
    IsCancelled = cancelling
End Property

Private Sub cmdCancel_Click()
    cancelling = True
    Me.Hide
End Sub

Private Sub cmdExeute_Click()
    If Validate() Then
        Me.Hide
    End If
End Sub

Private Sub cmdSelectIOListFile_Click()
    Dim SelectedFile As Variant
        
    SelectedFile = Application.GetOpenFilename(FileFilter:="엑셀 파일(*.xls*), *.xls*", title:="정렬 시트 선택", MultiSelect:=False)
    
    If SelectedFile <> False Then
        Me.txtIOListFile.value = SelectedFile
    End If
    
End Sub


Private Sub UserForm_QueryClose(Cancel As Integer, CloseMode As Integer)
    If CloseMode = VbQueryClose.vbFormControlMenu Then
        cancelling = True
        Me.Hide
    End If
End Sub

Private Sub txtMaxRowNumberOfSheet_Change()

    With Me.txtMaxRowNumberOfSheet
        .Text = Format(.value, "#,###")
        .TextAlign = fmTextAlignRight
    End With

End Sub

Private Sub txtMaxRowNumberOfSheet_KeyDown(ByVal KeyCode As MSForms.ReturnInteger, ByVal Shift As Integer)

    Me.txtMaxRowNumberOfSheet.MaxLength = 7           '최대 입력문자 7자로 제한
    
    If IsNum(KeyCode) = False Then                    '입력한 코드가 숫자 아니면
        MsgBox "숫자(0~9)만 입력 가능합니다."         '메시지 출력
        KeyCode = 0                                   'Enter
    End If
    
End Sub

Private Function Validate() As Boolean

    Validate = Validations.Validate(Me.txtMaxRowNumberOfSheet.value, Me.txtIOListFile.value)
    
End Function

