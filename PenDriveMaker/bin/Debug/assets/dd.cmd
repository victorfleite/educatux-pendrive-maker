@echo off
cls 
set "CMD=C:\Users\Aderbal Botelho\Documents\educatux-magic\PenDriveMaker\dd.exe"
set "ISO=C:\Users\Aderbal Botelho\Downloads\educatux_8gb_multilazer.bin"
echo cmd /K ""%CMD%" if="%ISO%" of=\\?\Device\Harddisk1\Partition0 bs=4M --size --progress"
cmd /K ""%CMD%" if="%ISO%" of=\\?\Device\Harddisk1\Partition0 bs=4M --size --progress"