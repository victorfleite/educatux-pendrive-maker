@echo off
cls 
cd "C:\Users\fleite\Documents\Visual Studio 2015\Projects\PenDriveMaker\PenDriveMaker\bin\Debug\"
set "CMD=C:\Users\fleite\Documents\Visual Studio 2015\Projects\PenDriveMaker\PenDriveMaker\bin\Debug\dd.exe"
set "ISO=E:\educatux\e.iso"
echo cmd /K /D ""%CMD%" if="%ISO%" of=\\?\Device\Harddisk1\Partition0 bs=512 count=1 --size --progress"
cmd /K ""%CMD%" if=E:\educatux\e.iso of=\\?\Device\Harddisk1\Partition0 bs=512 count=1 --size --progress"
::start cmd /K ""%CMD%" --list"