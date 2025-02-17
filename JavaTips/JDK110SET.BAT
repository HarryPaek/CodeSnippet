@ECHO OFF
SET JAVA_HOME=E:\Java\JDK11.0.26
REM SET JTOOL_HOME=D:\JavaTool
REM SET ANT_HOME=%JTOOL_HOME%\ant_1_6_5
REM SET LOG4J_HOME=%JTOOL_HOME%\log4j_1_2_14
REM SET JCHART_HOME=%JTOOL_HOME%\jfreechart_1_0_2
REM SET JCOMMON_HOME=%JTOOL_HOME%\jcommon_1_0_6
SET ORA_HOME=E:\oracle\product\10.2.0\client_1
REM SET TOMCAT_HOME=D:\JavaTool\Tomcat 4.1
REM SET AXIS_HOME=%TOMCAT_HOME%\webapps\axis
REM SET AXIS_LIB=%AXIS_HOME%\WEB-INF\lib

SET PATH=%JAVA_HOME%\Bin;%JAVA_HOME%\Jre\Bin;%ANT_HOME%\Bin;C:\Windows\System32;C:\Windows;C:\Windows\System32\WindowsPowerShell\v1.0
SET CLASSPATH=.;%JAVA_HOME%\lib\tools.jar;%ORA_HOME%\jdbc\lib\classes12.jar;%ORA_HOME%\jdbc\lib\nls_charset12.jar;
REM SET CLASSPATH=%CLASSPATH%;%LOG4J_HOME%\dist\lib\log4j-1.2.14.jar;
REM SET CLASSPATH=%CLASSPATH%;%JCOMMON_HOME%\jcommon-1.0.6.jar;%JCHART_HOME%\lib\jfreechart-1.0.2.jar;
REM SET CLASSPATH=%CLASSPATH%;D:\eclipse32\swt\swt.jar;

REM SET CLASSPATH=%CLASSPATH%;%TOMCAT_HOME%\common\lib\servlet.jar;%TOMCAT_HOME%\common\lib\jasper-compiler.jar;
REM SET AXISCLASSPATH=%AXIS_LIB%\axis.jar;%AXIS_LIB%\axis-ant.jar;%AXIS_LIB%\commons-discovery.jar;%AXIS_LIB%\commons-logging.jar;%AXIS_LIB%\jaxrpc.jar;%AXIS_LIB%\log4j-1.2.8.jar;%AXIS_LIB%\saaj.jar;%AXIS_LIB%\wsdl4j.jar;%AXIS_LIB%\xercesImpl.jar;%AXIS_LIB%\xercesSamples.jar;%AXIS_LIB%\xml-apis.jar;%AXIS_LIB%\xmlParserAPIs.jar
REM SET CLASSPATH=%CLASSPATH%;%AXISCLASSPATH%;
SET PROMPT=You Are In JAVA 11.0 Mode ...... $_$P$G
