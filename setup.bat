@echo off
chcp 65001
echo 正在將 MainItem.txt 複製到 bin\Debug...

REM 檢查目標資料夾是否存在，如果不存在則建立
if not exist "bin\Debug" (
    echo 目標資料夾 bin\Debug 不存在，正在建立...
    mkdir "bin\Debug"
)

REM 複製檔案
copy "MainItem.txt" "bin\Debug\"

if %ERRORLEVEL% equ 0 (
    echo 檔案複製成功！
) else (
    echo 檔案複製失敗，請檢查權限或路徑。
)

pause