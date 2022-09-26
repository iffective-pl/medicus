FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
RUN curl -fsSL https://deb.nodesource.com/setup_16.x | bash -
RUN apt-get install -y nodejs
WORKDIR /app
COPY . ./
RUN dotnet restore
RUN dotnet publish MedicusApp -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "MedicusApp.dll"]