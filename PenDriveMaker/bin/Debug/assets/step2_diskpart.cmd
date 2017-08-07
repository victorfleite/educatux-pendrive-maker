@echo off
set "COMMANDS=C:\Users\fleite\Documents\Visual Studio 2015\Projects\PenDriveMaker\PenDriveMaker\bin\Debug\assets\diskpart_commands.txt"
set "LOGFILE=C:\Users\fleite\Documents\Visual Studio 2015\Projects\PenDriveMaker\PenDriveMaker\bin\Debug\assets\logfile.txt"
diskpart /s "%COMMANDS%" > "%LOGFILE%" 