@echo off
set /p userInput=Enter ID : 
.\bin\Debug\PDII_F.exe -r %userInput%
popd

pause