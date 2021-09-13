FROM mcr.microsoft.com/dotnet/sdk:5.0 as build
WORKDIR /src
COPY CommitZeroBack.csproj .
RUN dotnet restore

COPY / .
RUN dotnet publish -c Release -o /out

FROM mcr.microsoft.com/dotnet/aspnet:5.0 
WORKDIR /app
COPY --from=build /out/ /app

EXPOSE 80
ENTRYPOINT ["dotnet", "/app/CommitZeroBack.dll"]