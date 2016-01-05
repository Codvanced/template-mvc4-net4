@echo off
cd "%~dp0\.rename"
PowerShell.exe -ExecutionPolicy Bypass -File ".\rename.ps1"
