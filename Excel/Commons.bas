Attribute VB_Name = "Commons"
Option Explicit

Public Function ShowMainForm(title As String, noOfRowPerSheet As Long) As ClsFormResult

    Dim oFormResult As New ClsFormResult

    With New MainForm
        .lblModuleText.Caption = title
        .txtMaxRowNumberOfSheet.value = noOfRowPerSheet
    
        .Show vbModal
    
        If .IsCancelled Then
            oFormResult.IsCancelled = True
        Else
            oFormResult.IsCancelled = False
            oFormResult.numberOfRowsPerSheet = .numberOfRowsPerSheet
            oFormResult.IOSheetFullPath = .IOSheetFullPath
        End If
    End With
    Unload MainForm

    Set ShowMainForm = oFormResult

End Function

