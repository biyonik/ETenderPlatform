FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ETenderPlatform.ProductApi/ETenderPlatform.ProductApi.csproj", "ETenderPlatform.ProductApi/"]
RUN dotnet restore "ETenderPlatform.ProductApi/ETenderPlatform.ProductApi.csproj"
COPY . .
WORKDIR "/src/ETenderPlatform.ProductApi"
RUN dotnet build "ETenderPlatform.ProductApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ETenderPlatform.ProductApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ETenderPlatform.ProductApi.dll"]
