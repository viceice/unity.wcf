@rem ..\..\tools\nuget pack
@nuget pack Unity.Wcf\Unity.Wcf.csproj -properties Configuration=Release -symbols -build -OutputDirectory bin

@rem pause
