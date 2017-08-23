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
       MsgBox "��� ��Ʈ ������ ���� 100 ~ 1,000,000 ���� ������ �Է��� �ֽʽÿ�.", vbOKOnly, "����"
       Validate = False
    End If
    
    Dim trimmedIOListFileFullPath
    trimmedIOListFileFullPath = Trim(ioListFileFullPath)
    
    If Len(trimmedIOListFileFullPath) = 0 Or Dir(trimmedIOListFileFullPath, vbNormal) = "" Then
       MsgBox "��Ȯ�� ���� ��Ʈ�� ������ �ֽʽÿ�." & vbCrLf & _
              "���� ��Ʈ�� �������� �ʾҰų�, �����Ͻ� ������ �������� �ʽ��ϴ�.", vbOKOnly, "����"
       Validate = False
    End If
    
End Function

