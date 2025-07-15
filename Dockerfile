# ---------- BUILD STAGE ----------
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Kopiranje .sln i .csproj
COPY *.sln .
COPY Artikli/*.csproj ./Artikli/
RUN dotnet restore

# Kopiranje ostatka aplikacije
COPY Artikli/. ./Artikli/
WORKDIR /src/Artikli

# Publish aplikacije
RUN dotnet publish -c Release -o /app/publish

# ---------- RUNTIME STAGE ----------
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

COPY --from=build /app/publish .

# Port koji izlažemo
EXPOSE 80

# Ulazna tačka aplikacije
ENTRYPOINT ["dotnet", "Artikli.dll"]
