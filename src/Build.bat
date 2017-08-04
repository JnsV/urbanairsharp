Call ..\NuKit\Strap.bat

set /P NUGETKEY=<ApiKey.noscm.txt

MSBuild UrbanAirSharp\UrbanAirSharp.csproj /p:Configuration="Release"
MSBuild UrbanAirSharp\UrbanAirSharp.csproj /p:Configuration="Debug"

nuget pack UrbanAirSharp\UrbanAirSharp.csproj -Prop Configuration=Release -Symbols

nuget push UrbanAirSharp.Mk2.1.2.1.2.nupkg %NUGETKEY% 

pause