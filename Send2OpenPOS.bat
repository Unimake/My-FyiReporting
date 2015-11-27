@ECHO OFF
CLS
DIR

@ECHO =======================================
@ECHO   Compilando projeto em modo release
@ECHO =======================================

CALL "%ProgramFiles% (x86)\Microsoft Visual Studio 11.0\Common7\IDE\devenv.exe" /Build Release "\MajorsilenceReporting.sln"

@ECHO =======================================
@ECHO    Copiando arquivos para o OpenPOS
@ECHO =======================================
COPY DataProviders\bin\Release\DataProviders.dll			  ..\..\..\..\..\OpenPOS\OpenPOS\trunk\references\MajorSilence /Y
REM COPY ICSharpCode.SharpZipLib.dll  ..\..\..\..\..\OpenPOS\OpenPOS\trunk\references\MajorSilence /Y
REM COPY itextsharp.dll               ..\..\..\..\..\OpenPOS\OpenPOS\trunk\references\MajorSilence /Y
COPY RdlCri\bin\Release\RdlCri.dll                   ..\..\..\..\..\OpenPOS\OpenPOS\trunk\references\MajorSilence /Y
COPY RdlDesign\bin\Release\RdlDesigner.exe              ..\..\..\..\..\OpenPOS\OpenPOS\trunk\references\MajorSilence /Y
COPY RdlDesign\bin\Release\RdlDesigner.exe.config       ..\..\..\..\..\OpenPOS\OpenPOS\trunk\references\MajorSilence /Y
COPY RdlEngine\bin\Release\RdlEngine.dll                ..\..\..\..\..\OpenPOS\OpenPOS\trunk\references\MajorSilence /Y
COPY RdlViewer\bin\Release\RdlViewer.dll ..\..\..\..\..\OpenPOS\OpenPOS\trunk\references\MajorSilence /Y
COPY zxing.dll                    ..\..\..\..\..\OpenPOS\OpenPOS\trunk\references\MajorSilence /Y

COPY ..\..\..\..\..\OpenPOS\OpenPOS\trunk\references\MajorSilence\*.* ..\..\..\..\..\OpenPOS\OpenPOS\trunk\fontes\OpenPOS\Reports\OpenPOS.Reports\Embedded\ /Y

@ECHO =======================================
@ECHO    Processo concluido
@ECHO =======================================
PAUSE
EXIT