@ECHO OFF 

ECHO "Install EPLAN Drawing Automation Package..."

CALL ValidateX64.bat

ECHO %ERRORLEVEL% 

IF %ERRORLEVEL% NEQ 0
    GOTO :EOF

CALL DoDRMFileCopy.bat

IF %ERRORLEVEL% NEQ 0
    GOTO :EOF

CALL InstallAutomationManager.bat

IF %ERRORLEVEL% NEQ 0
    GOTO :EOF

ECHO "Installation Completed..."

:EOF
