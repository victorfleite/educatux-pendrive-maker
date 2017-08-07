@echo off
set "CMD=C:\Users\fleite\Documents\Visual Studio 2015\Projects\PenDriveMaker\PenDriveMaker\bin\Debug\dd.exe"
set "ISO=e:\educatux\e.iso"
echo cmd /K ""%CMD%" if="%ISO%" of=\\?\Device\Harddisk1\Partition0 bs=4M --size --progress"
cmd /K ""%CMD%" if="%ISO%" of=\\?\Device\Harddisk1\Partition0 bs=4M --size --progress"