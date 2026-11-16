@echo off
cd /d "%~dp0"
dotnet run --project src\ZuzuStudios\ZuzuStudios.csproj -- --project projects\StarterProject --game
if errorlevel 1 pause
