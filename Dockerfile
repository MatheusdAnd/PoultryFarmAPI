FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["PoultryAPI/PoultryAPI.csproj", "PoultryAPI/"]
RUN dotnet restore "PoultryAPI/PoultryAPI.csproj"
COPY . .
WORKDIR "/src/PoultryAPI"
RUN dotnet build "PoultryAPI.csproj" -c Release -o /app/build

FROM build as publish
RUN dotnet publish "PoultryAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

RUN useradd -m myappuser
USER myappuser

CMD ASPNETCORE_URLS=http://*:$PORT dotnet PoultryAPI.dll