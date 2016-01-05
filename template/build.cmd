@echo off
cd "%~dp0\.build"
PowerShell.exe -ExecutionPolicy Bypass -File "build.ps1"
pause