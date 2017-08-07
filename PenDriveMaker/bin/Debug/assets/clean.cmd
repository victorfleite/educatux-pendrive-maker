@echo off
cls 
set "CMD=C:\Users\Aderbal Botelho\Documents\educatux-magic\PenDriveMaker\dd.exe"
echo cmd /K ""%CMD%" if=\dev\zero of=\\?\Device\Harddisk1\Partition0 bs=512 count=1 --size --progress"
cmd /K ""%CMD%" if=/dev/zero of=\\?\Device\Harddisk1\Partition0 bs=512 count=1 --size --progress"