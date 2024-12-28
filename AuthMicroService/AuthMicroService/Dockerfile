FROM mcr.microsoft.com/dotnet/aspnet:6.0-nanoserver-ltsc2022 AS base  # Windows-based
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0-nanoserver-ltsc2022 AS build  # Windows-based
WORKDIR /src
COPY ["AuthMicroService.csproj", "."]
RUN dotnet restore "./AuthMicroService.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "AuthMicroService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AuthMicroService.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AuthMicroService.dll"]
