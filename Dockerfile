FROM microsoft/dotnet:2.1-aspnetcore-runtime  AS base
WORKDIR /app

FROM microsoft/dotnet:2.1-sdk AS builder
COPY . .
RUN dotnet restore  
RUN dotnet publish --output /app/ --configuration Release

FROM microsoft/aspnetcore
WORKDIR /app
COPY --from=builder /app .
ENTRYPOINT ["dotnet", "api.dll"]
