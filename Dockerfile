# syntax=docker/dockerfile:1.6

# ---------- BUILD STAGE ----------
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG TARGETARCH
WORKDIR /src

COPY NotesService/NotesService/*.csproj ./NotesService/
RUN dotnet restore NotesService/NotesService.csproj

COPY NotesService/NotesService/. ./NotesService/

RUN dotnet publish NotesService/NotesService.csproj \
    -c Release \
    -o /app/publish \
    -r linux-$TARGETARCH \
    --self-contained false

# ---------- RUNTIME STAGE ----------
FROM --platform=$TARGETPLATFORM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 8082

ENTRYPOINT ["dotnet", "NotesService.dll"]