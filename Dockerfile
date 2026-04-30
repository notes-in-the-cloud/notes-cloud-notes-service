# ---------- BUILD STAGE ----------
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY NotesService/NotesService/*.csproj ./NotesService/

RUN dotnet restore NotesService/NotesService.csproj

COPY NotesService/NotesService/. ./NotesService/

RUN dotnet publish NotesService/NotesService.csproj -c Release -o /app/publish

# ---------- RUNTIME STAGE ----------
#FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
#WORKDIR /app

#COPY --from=build /app/publish .

#EXPOSE 8080

#ENTRYPOINT ["dotnet", "NotesService.dll"]
