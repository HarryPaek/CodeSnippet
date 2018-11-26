@ECHO OFF 

Echo "Valiating Windows x64..."

IF Exist C:\Windows\SysWOW64 (
    Echo "Windows x64"
	Exit /B 0
) ELSE (
    Echo "Windows x86"
	Exit /B -1
)



