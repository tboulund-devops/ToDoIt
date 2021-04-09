FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /src
COPY src/WebUI/bin/Debug/net5.0/ .
ENTRYPOINT ["dotnet", "WebUI.dll"]