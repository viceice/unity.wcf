@rem nuget pack Unity.Wcf\Unity.Wcf.csproj -properties Configuration=Release -symbols -build -OutputDirectory bin %*

@echo off

for /f "usebackq tokens=*" %%i in (`vswhere -latest -products * -requires Microsoft.Component.MSBuild -property installationPath`) do (
  set InstallDir=%%i
)

if exist "%InstallDir%\MSBuild\15.0\Bin\MSBuild.exe" (
  "%InstallDir%\MSBuild\15.0\Bin\MSBuild.exe" Unity.Wcf.sln /nologo /p:Configuration=Release /m /v:m %*
)
