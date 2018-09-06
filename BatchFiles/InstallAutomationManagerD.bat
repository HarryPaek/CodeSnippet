@ECHO OFF

ECHO "Install Automation Manager to D:\EPLAN ..."

XCOPY .\EPLAN\ D:\ /S/Y
XCOPY D:\EPLAN\AutomationManager\config.samples\E_Eplan.LSCable.DrawingAutomationManager.exe.config D:\EPLAN\AutomationManager\Eplan.LSCable.DrawingAutomationManager.exe.config /Y
