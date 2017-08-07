@echo off
set "CMD=C:\Users\fleite\Documents\Visual Studio 2015\Projects\PenDriveMaker\PenDriveMaker\bin\Debug\dd.exe"
echo cmd /K ""%CMD%" if=\dev\zero of=\\?\Device\Harddisk1\Partition0 bs=512 count=1 --size --progress"
cmd /K ""%CMD%" if=/dev/zero of=\\?\Device\Harddisk1\Partition0 bs=512 count=1 --size --progress"