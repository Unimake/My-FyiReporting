@ECHO OFF
CLS

@ECHO =======================================
@ECHO   Compilando projeto em modo release
@ECHO =======================================

CALL "%ProgramFiles% (x86)\Microsoft Visual Studio 11.0\Common7\IDE\devenv.exe" /Build Release "\MajorsilenceReporting.sln"

@ECHO =======================================
@ECHO    Copiando arquivos para o OpenPOS
@ECHO =======================================
COPY RdlDesign\bin\x86\Release\DataProviders.dll			 ..\..\OpenPOS\OpenPOS\trunk\references\MajorSilence	/Y
COPY RdlDesign\bin\x86\Release\ICSharpCode.SharpZipLib.dll  ..\..\OpenPOS\OpenPOS\trunk\references\MajorSilence   /Y
COPY RdlDesign\bin\x86\Release\itextsharp.dll               ..\..\OpenPOS\OpenPOS\trunk\references\MajorSilence   /Y
COPY RdlDesign\bin\x86\Release\RdlCri.dll                   ..\..\OpenPOS\OpenPOS\trunk\references\MajorSilence   /Y
COPY RdlDesign\bin\x86\Release\RdlCri.pdb                   ..\..\OpenPOS\OpenPOS\trunk\references\MajorSilence   /Y
COPY RdlDesign\bin\x86\Release\RdlDesigner.exe              ..\..\OpenPOS\OpenPOS\trunk\references\MajorSilence   /Y
COPY RdlDesign\bin\x86\Release\RdlDesigner.exe.config       ..\..\OpenPOS\OpenPOS\trunk\references\MajorSilence   /Y
COPY RdlDesign\bin\x86\Release\RdlEngine.dll                ..\..\OpenPOS\OpenPOS\trunk\references\MajorSilence   /Y
COPY RdlDesign\bin\x86\Release\RdlEngineConfig.Linux.xml    ..\..\OpenPOS\OpenPOS\trunk\references\MajorSilence   /Y
COPY RdlDesign\bin\x86\Release\RdlEngineConfig.xml          ..\..\OpenPOS\OpenPOS\trunk\references\MajorSilence   /Y
COPY RdlDesign\bin\x86\Release\RdlViewer.dll                ..\..\OpenPOS\OpenPOS\trunk\references\MajorSilence   /Y
COPY RdlDesign\bin\x86\Release\zxing.dll                    ..\..\OpenPOS\OpenPOS\trunk\references\MajorSilence   /Y

COPY ..\..\OpenPOS\OpenPOS\trunk\references\MajorSilence\*.* ..\..\OpenPOS\OpenPOS\trunk\fontes\OpenPOS\Reports\OpenPOS.Reports\Embedded\ /Y

@ECHO =======================================
@ECHO    Processo concluido
@ECHO =======================================
pause