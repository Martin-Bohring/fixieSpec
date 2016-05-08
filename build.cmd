@echo off
cls

.paket\paket.bootstrapper.exe
if errorlevel 1 (
  exit /b %errorlevel%
)

.paket\paket.exe restore
if errorlevel 1 (
  exit /b %errorlevel%
)

if [%1] == [] (
    packages\build\FAKE\tools\FAKE.exe build.fsx --listTargets
) else (
    packages\build\FAKE\tools\FAKE.exe build.fsx %*
)
