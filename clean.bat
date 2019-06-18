@ECHO OFF

ECHO Entferne alle Bin Verzeichnisse...
CALL :DeleteFolder bin
ECHO.

ECHO Entferne alle obj Verzeichnisse...
CALL :DeleteFolder obj
ECHO.

ECHO Entferne Roslyn Compiler Engine Verzeichnis...
CALL :DeleteFolder *.sln.ide
ECHO.

ECHO Entferne Visual Studios lokale Nutzer- und Umgebungsinformationen...
RMDIR /S /Q .vs
ECHO.

ECHO Fertig!
PAUSE
GOTO :EOF 

:DeleteFolder
REM NOTE: Setting the delimiter to a zero string ignores spaces within paths.
FOR /F "delims=" %%D IN ('DIR /AD /S /B "%~1"') DO RMDIR /S /Q "%%D"
GOTO :EOF 