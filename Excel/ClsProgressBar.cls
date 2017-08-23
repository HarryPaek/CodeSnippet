VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
END
Attribute VB_Name = "ClsProgressBar"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = False
Option Explicit

Private Const MIN_PERCENT_TO_CAPTION_DISPLAY    As Single = 0.1
Private Const MIN_PROGRESS_BAR_LENGTH   As Long = 0
Private Const MAX_PROGRESS_BAR_LENGTH   As Long = 400

Private progressBar                     As formProgressBar
Private progressMin                     As Long
Private progressMax                     As Long
Private progressValue                   As Long


Private Sub Class_Initialize()

    ' MsgBox "ClsProgressBar Class is being initialized"
    
    progressMin = 0
    progressMax = 100
    progressValue = 0
    Set progressBar = New formProgressBar
    
    UpdateProgressBarStatus
    
End Sub


Private Sub Class_Terminate()
    
    ' MsgBox "ClsProgressBar Class is being terminated"
    
    Unload progressBar
    Set progressBar = Nothing

End Sub


Public Property Let Min(minValue As Long)

    If (minValue < 0) Then
        minValue = 0
    End If
        
    progressMin = minValue

End Property


Public Property Let Max(maxValue As Long)

    If (maxValue < 1) Then
        maxValue = 1
    End If

    progressMax = maxValue

End Property


Public Property Let value(currentValue As Long)

    If (currentValue < 0) Then
        currentValue = 0
    End If

    progressValue = currentValue
    
    UpdateProgressBarStatus

End Property


Public Sub Show()

    progressBar.Show

End Sub


Public Sub Hide()

    progressBar.Hide

End Sub


Private Sub UpdateProgressBarStatus()

   Dim progressPercent As Single
   Dim progressWidth As Long
   
   progressPercent = progressValue / progressMax
   progressWidth = progressPercent * MAX_PROGRESS_BAR_LENGTH
   
   If (progressWidth < MIN_PROGRESS_BAR_LENGTH) Then
       progressWidth = MIN_PROGRESS_BAR_LENGTH
    End If
       
   If (progressWidth > MAX_PROGRESS_BAR_LENGTH) Then
       progressWidth = MAX_PROGRESS_BAR_LENGTH
   End If
   
   progressBar.lblProgressBar.Width = progressWidth
   progressBar.lblProgressMessage.Caption = Format(progressValue, "#,##0") & " / " & Format(progressMax, "#,##0") & " 항목이 완료되었습니다."
   
   If (progressPercent >= MIN_PERCENT_TO_CAPTION_DISPLAY) Then
       progressBar.lblProgressBar.Caption = vbCrLf & Format(progressPercent * 100, "##0.0") & " %"
   Else
       progressBar.lblProgressBar.Caption = ""
   End If
   
   progressBar.Repaint
   
   DoEvents

End Sub

