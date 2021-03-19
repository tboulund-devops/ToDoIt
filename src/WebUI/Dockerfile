FROM mcr.microsoft.com/dotnet/aspnet
WORKDIR /app
COPY ./src/WebUI/bin/Debug/net5.0 .
COPY ./src/WebUI/wwwroot ./wwwroot
ENTRYPOINT ["dotnet", "WebUI.dll"]