Attribute VB_Name = "Validations"
Option Explicit

Public Function IsNum(ByVal KeyCode As MSForms.ReturnInteger) As Boolean
    If (KeyCode >= 48 And KeyCode <= 57) Or _
       (KeyCode >= 96 And KeyCode <= 105) Or _
        KeyCode = vbKeyBack Or _
        KeyCode = vbKeyDelete Or _
        KeyCode = vbKeyLeft Or _
        KeyCode = vbKeyRight Or _
        KeyCode = vbKeyTab Or _
        KeyCode = vbKeyShift Or _
        KeyCode = vbKeyHome Or _
        KeyCode = vbKeyEnd Then
        
        IsNum = True
    Else
        IsNum = False
    End If
End Function

Public Function Validate(ByVal maxRowNumberOfSheet As Long, ByVal ioListFileFullPath) As Boolean
    
    Validate = True
    
    If (maxRowNumberOfSheet < 100 Or maxRowNumberOfSheet > 1000000) Then
       MsgBox "결과 시트 라인의 수는 100 ~ 1,000,000 사이 값으로 입력해 주십시오.", vbOKOnly, "오류"
       Validate = False
    End If
    
    Dim trimmedIOListFileFullPath
    trimmedIOListFileFullPath = Trim(ioListFileFullPath)
    
    If Len(trimmedIOListFileFullPath) = 0 Or Dir(trimmedIOListFileFullPath, vbNormal) = "" Then
       MsgBox "정확한 정렬 시트를 지정해 주십시오." & vbCrLf & _
              "정렬 시트를 지정하지 않았거나, 지정하신 파일이 존재하지 않습니다.", vbOKOnly, "오류"
       Validate = False
    End If
    
End Function

