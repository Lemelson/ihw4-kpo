FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SEHW/SEHW.csproj", "SEHW/"]
RUN dotnet restore "SEHW/SEHW.csproj"
COPY . .
WORKDIR "/src/SEHW"
RUN dotnet build "SEHW.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SEHW.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SEHW.dll"]
