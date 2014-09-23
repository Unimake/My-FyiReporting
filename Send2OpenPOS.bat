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
COPY DataProviders.dll			  ..\..\..\..\..\OpenPOS\OpenPOS\trunk\references\MajorSilence /Y
COPY ICSharpCode.SharpZipLib.dll  ..\..\..\..\..\OpenPOS\OpenPOS\trunk\references\MajorSilence /Y
COPY itextsharp.dll               ..\..\..\..\..\OpenPOS\OpenPOS\trunk\references\MajorSilence /Y
COPY RdlCri.dll                   ..\..\..\..\..\OpenPOS\OpenPOS\trunk\references\MajorSilence /Y
COPY RdlCri.pdb                   ..\..\..\..\..\OpenPOS\OpenPOS\trunk\references\MajorSilence /Y
COPY RdlDesigner.exe              ..\..\..\..\..\OpenPOS\OpenPOS\trunk\references\MajorSilence /Y
COPY RdlDesigner.exe.config       ..\..\..\..\..\OpenPOS\OpenPOS\trunk\references\MajorSilence /Y
COPY RdlEngine.dll                ..\..\..\..\..\OpenPOS\OpenPOS\trunk\references\MajorSilence /Y
COPY RdlEngineConfig.Linux.xml    ..\..\..\..\..\OpenPOS\OpenPOS\trunk\references\MajorSilence /Y
COPY RdlEngineConfig.xml          ..\..\..\..\..\OpenPOS\OpenPOS\trunk\references\MajorSilence /Y
COPY RdlViewer.dll                ..\..\..\..\..\OpenPOS\OpenPOS\trunk\references\MajorSilence /Y
COPY zxing.dll                    ..\..\..\..\..\OpenPOS\OpenPOS\trunk\references\MajorSilence /Y

COPY ..\..\..\..\..\OpenPOS\OpenPOS\trunk\references\MajorSilence\*.* ..\..\..\..\..\OpenPOS\OpenPOS\trunk\fontes\OpenPOS\Reports\OpenPOS.Reports\Embedded\ /Y

@ECHO =======================================
@ECHO    Processo concluido
@ECHO =======================================
PAUSE