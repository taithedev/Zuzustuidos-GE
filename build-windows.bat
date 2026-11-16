@echo off
cd /d "%~dp0"
dotnet publish src\ZuzuStudios\ZuzuStudios.csproj -c Release -r win-x64 --self-contained true /p:PublishSingleFile=true -o dist\Windows
if errorlevel 1 pause
echo Copy projects\StarterProject next to the EXE or pass --project to choose a location.
