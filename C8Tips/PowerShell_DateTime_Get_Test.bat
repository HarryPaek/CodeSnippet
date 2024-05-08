@echo off

REM 03. Get Year, Month, Date using VBScript
for /f "usebackq tokens=*" %%a in (`powershell -Command "Get-Date -Format yyyyMMdd"`) do set "date8=%%a"
for /f "usebackq tokens=*" %%b in (`powershell -Command "Get-Date -Format HHmmss"`) do set "time6=%%b"

set datetime14=%date8%_%time6%

echo date8=%date8%
echo time6=%time6%
echo datetime14=%datetime14%
