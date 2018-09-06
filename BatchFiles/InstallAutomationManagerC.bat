@ECHO OFF

ECHO "Install Automation Manager to C:\EPLAN ..."

XCOPY .\EPLAN\ C:\ /S/Y
XCOPY C:\EPLAN\AutomationManager\config.samples\E_Eplan.LSCable.DrawingAutomationManager.exe.config C:\EPLAN\AutomationManager\Eplan.LSCable.DrawingAutomationManager.exe.config /Y
