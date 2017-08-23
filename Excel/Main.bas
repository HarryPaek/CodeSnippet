Attribute VB_Name = "Main"
Option Explicit

Sub ExecuteWiring()

    Dim clsCommon As ClsWiringCommon
    Dim oFormResult As New ClsFormResult
    Dim newSheet  As Worksheet
    Dim stopWatch As ClsStopWatch
    
    Set oFormResult = ShowMainForm(Constants.DEFAULT_LABEL_FOR_WIRING, Constants.DEFAULT_ROW_NUMBER_PER_SHEET)
    
    Set stopWatch = New ClsStopWatch
    stopWatch.StartTimer
    
    If Not oFormResult.IsCancelled Then
        
        EnableApplicationScreenUpdating False                                                                        '화면 업데이트 (일시) 정지
        
        Set clsCommon = New ClsWiringCommon
        Set newSheet = clsCommon.CopyFromTemplate
        CodesWiring.Exceute newSheet, oFormResult.IOSheetFullPath, oFormResult.numberOfRowsPerSheet
        
        EnableApplicationScreenUpdating True                                                                         '화면 업데이트 (일시) 복구
        
        If (stopWatch.IsRunning) Then
            stopWatch.StopTimer
            MsgBox "Execution Time = [" & Format(stopWatch.ElapsedSeconds, "#,###.00") & "] Seconds."
        End If
    End If
    
    Set stopWatch = Nothing
    Set oFormResult = Nothing
    Set clsCommon = Nothing
    
End Sub

Sub ExecuteTotalLoop()

    Dim clsCommon As ClsTotalCommon
    Dim oFormResult As New ClsFormResult
    Dim newSheet  As Worksheet
    Dim stopWatch As ClsStopWatch
    
    Set oFormResult = ShowMainForm(Constants.DEFAULT_LABEL_FOR_TOTALLOOP, Constants.DEFAULT_ROW_NUMBER_PER_SHEET)
    
    Set stopWatch = New ClsStopWatch
    stopWatch.StartTimer
    
    If Not oFormResult.IsCancelled Then
        
        EnableApplicationScreenUpdating False                                                                        '화면 업데이트 (일시) 정지
        
        Set clsCommon = New ClsTotalCommon
        Set newSheet = clsCommon.CopyFromTemplate
        CodesTotalLoop.Exceute newSheet, oFormResult.IOSheetFullPath, oFormResult.numberOfRowsPerSheet
        
        EnableApplicationScreenUpdating True                                                                         '화면 업데이트 (일시) 복구
        
        If (stopWatch.IsRunning) Then
            stopWatch.StopTimer
            MsgBox "Execution Time = [" & Format(stopWatch.ElapsedSeconds, "#,###.00") & "] Seconds."
        End If
    End If
    
    Set stopWatch = Nothing
    Set oFormResult = Nothing
    Set clsCommon = Nothing
    
End Sub

