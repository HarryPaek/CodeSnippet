@ECHO OFF 

Echo "Install DRM Files x64..."

CALL ValidateX64.bat

ECHO %ERRORLEVEL% 

IF %ERRORLEVEL% NEQ 0
    GOTO :EOF

CALL DoDRMFileCopy.bat

:EOF

Exit /B %ERRORLEVEL%
