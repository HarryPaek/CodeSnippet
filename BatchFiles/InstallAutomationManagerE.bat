@ECHO OFF

ECHO "Install Automation Manager to E:\EPLAN ..."

XCOPY .\EPLAN\ E:\ /S/Y
XCOPY E:\EPLAN\AutomationManager\config.samples\E_Eplan.LSCable.DrawingAutomationManager.exe.config E:\EPLAN\AutomationManager\Eplan.LSCable.DrawingAutomationManager.exe.config /Y
