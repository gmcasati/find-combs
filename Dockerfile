FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["FindCombsApi/FindCombsApi.csproj", "FindCombsApi/"]
RUN dotnet restore "FindCombsApi/FindCombsApi.csproj"
COPY ./FindCombsApi ./FindCombsApi
WORKDIR "/src/FindCombsApi"
RUN dotnet build "FindCombsApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FindCombsApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

RUN useradd -m findcombsuser
USER findcombsuser

CMD ASPNETCORE_URLS="http://*:$PORT" dotnet FindCombsApi.dll