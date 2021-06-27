FROM mcr.microsoft.com/dotnet/aspnet:5.0
COPY SunCatcher/SunCatcher/SunCatcherService/bin/Release/net5.0/publish/ App/
WORKDIR /App
ENV DOTNET_EnableDiagnostics=0
ENTRYPOINT ["dotnet", "SunCatcherService.dll"]
