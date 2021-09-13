FROM mcr.microsoft.com/dotnet/sdk:5.0 as build
WORKDIR /src
COPY CommitZeroBack.csproj .
RUN dotnet restore

COPY / .
RUN dotnet publish -c Release -o /out

FROM mcr.microsoft.com/dotnet/aspnet:5.0 
WORKDIR /app
COPY --from=build /out/ /app

ARG POSTGRES_DB
ARG POSTGRES_USER
ARG POSTGRES_PASSWORD
ARG POSTGRES_PORT
ARG API_KEY

ENV POSTGRES_DB=$POSTGRES_DB
ENV POSTGRES_USER=$POSTGRES_USER
ENV POSTGRES_PASSWORD=$POSTGRES_PASSWORD
ENV POSTGRES_PORT=$POSTGRES_PORT
ENV API_KEY=$API_KEY

EXPOSE 80
ENTRYPOINT ["dotnet", "/app/CommitZeroBack.dll"]