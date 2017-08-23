VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
END
Attribute VB_Name = "ClsStopWatch"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = False
Option Explicit

Private fTimeStart As Single
Private fTimeEnd As Single
Private bIsRunning As Boolean
    
Private Sub Class_Initialize()

    fTimeStart = Timer
    fTimeEnd = 0#
    bIsRunning = False
    
End Sub

Public Sub StartTimer()

    fTimeStart = Timer
    fTimeEnd = 0#
    bIsRunning = True
    
End Sub

Public Sub ResetTimer()

    StartTimer
    
End Sub

Public Sub StopTimer()

    fTimeEnd = Timer
    bIsRunning = False
    
End Sub

Public Property Get IsRunning() As Boolean

    IsRunning = bIsRunning
    
End Property

Public Function ElapsedMilliseconds() As Long

    If (bIsRunning Or fTimeEnd < 0.01) Then
        fTimeEnd = Timer
    End If
    
    ElapsedMilliseconds = (fTimeEnd - fTimeStart) * 1000
    
End Function

Public Function ElapsedSeconds() As Long

    If (bIsRunning Or fTimeEnd < 0.01) Then
        fTimeEnd = Timer
    End If
    
    ElapsedSeconds = fTimeEnd - fTimeStart

End Function
