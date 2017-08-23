Attribute VB_Name = "Utilities"
Option Explicit


Public Function CopyTemplateToNewSheet(sourceSheet As String, targetSheetPrefix As String) As Worksheet

    Dim copiedSheet  As Worksheet

    Worksheets(sourceSheet).Copy After:=Worksheets(Worksheets.Count)
    Set copiedSheet = ActiveSheet
    copiedSheet.Name = targetSheetPrefix + "_" + GetSheetNameSerialFromDateTime()

    Set CopyTemplateToNewSheet = copiedSheet

End Function


Public Function ConverColumnIndexToLetter(columnIndex As Long) As String
    Dim cellAddressArray
    
    cellAddressArray = Split(Cells(1, columnIndex).Address(True, False), "$")
    ConverColumnIndexToLetter = cellAddressArray(0)
    
End Function


Public Function ToString(number As Long) As String

    ToString = Format(number)
    
End Function


Private Function GetSheetNameSerialFromDateTime() As String

    GetSheetNameSerialFromDateTime = Format(Now, "YYMMDD_HHMMSS.") & Right(Format(Timer * 100, "0"), 2)    ' 0.01초 단위로 파일 이름 구분
    'GetSheetNameSerialFromDateTime = Format(Now, "YYMMDD_HHMMSS.") & Right(Format(Timer * 10, "0"), 1)    ' 0.1초 단위로 파일 이름 구분
    'GetSheetNameSerialFromDateTime = Format(Now, "YYMMDD_HHMMSS")                                         ' 1초 단위로 파일 이름 구분
    
End Function


Public Sub EnableApplicationScreenUpdating(enabled As Boolean)

    Application.ScreenUpdating = enabled
    Application.EnableEvents = enabled
    
    If (enabled) Then
        Application.Calculation = xlCalculationAutomatic
    Else
        Application.Calculation = xlCalculationManual
    End If
    
End Sub

