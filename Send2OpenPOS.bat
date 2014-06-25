@ECHO OFF
CLS

@ECHO =======================================
@ECHO   Compilando projeto em modo release
@ECHO =======================================

CALL "%ProgramFiles% (x86)\Microsoft Visual Studio 11.0\Common7\IDE\devenv.exe" /Build Release "D:\Documents\GitHub\My-FyiReporting\MajorsilenceReporting.sln"

@ECHO =======================================
@ECHO    Copiando arquivos para o OpenPOS
@ECHO =======================================
COPY D:\Documents\GitHub\My-FyiReporting\RdlDesign\bin\x86\Release\DataProviders.dll			Z:\OpenPOS\OpenPOS\trunk\references\MajorSilence\	/Y
COPY D:\Documents\GitHub\My-FyiReporting\RdlDesign\bin\x86\Release\ICSharpCode.SharpZipLib.dll  Z:\OpenPOS\OpenPOS\trunk\references\MajorSilence\   /Y
COPY D:\Documents\GitHub\My-FyiReporting\RdlDesign\bin\x86\Release\itextsharp.dll               Z:\OpenPOS\OpenPOS\trunk\references\MajorSilence\   /Y
COPY D:\Documents\GitHub\My-FyiReporting\RdlDesign\bin\x86\Release\RdlCri.dll                   Z:\OpenPOS\OpenPOS\trunk\references\MajorSilence\   /Y
COPY D:\Documents\GitHub\My-FyiReporting\RdlDesign\bin\x86\Release\RdlCri.pdb                   Z:\OpenPOS\OpenPOS\trunk\references\MajorSilence\   /Y
COPY D:\Documents\GitHub\My-FyiReporting\RdlDesign\bin\x86\Release\RdlDesigner.exe              Z:\OpenPOS\OpenPOS\trunk\references\MajorSilence\   /Y
COPY D:\Documents\GitHub\My-FyiReporting\RdlDesign\bin\x86\Release\RdlDesigner.exe.config       Z:\OpenPOS\OpenPOS\trunk\references\MajorSilence\   /Y
COPY D:\Documents\GitHub\My-FyiReporting\RdlDesign\bin\x86\Release\RdlEngine.dll                Z:\OpenPOS\OpenPOS\trunk\references\MajorSilence\   /Y
COPY D:\Documents\GitHub\My-FyiReporting\RdlDesign\bin\x86\Release\RdlEngineConfig.Linux.xml    Z:\OpenPOS\OpenPOS\trunk\references\MajorSilence\   /Y
COPY D:\Documents\GitHub\My-FyiReporting\RdlDesign\bin\x86\Release\RdlEngineConfig.xml          Z:\OpenPOS\OpenPOS\trunk\references\MajorSilence\   /Y
COPY D:\Documents\GitHub\My-FyiReporting\RdlDesign\bin\x86\Release\RdlViewer.dll                Z:\OpenPOS\OpenPOS\trunk\references\MajorSilence\   /Y
COPY D:\Documents\GitHub\My-FyiReporting\RdlDesign\bin\x86\Release\zxing.dll                    Z:\OpenPOS\OpenPOS\trunk\references\MajorSilence\   /Y

COPY Z:\OpenPOS\OpenPOS\trunk\references\MajorSilence\*.* Z:\OpenPOS\OpenPOS\trunk\fontes\OpenPOS\Reports\OpenPOS.Reports\Embedded\ /Y

@ECHO =======================================
@ECHO    Processo concluido
@ECHO =======================================
pause