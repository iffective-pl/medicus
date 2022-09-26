FROM mcr.microsoft.com/dotnet/sdk:6.0
WORKDIR /app
COPY . ./
RUN dotnet restore
RUN dotnet build -c Release -o out
WORKDIR /app/out
ENTRYPOINT ["dotnet", "MedicusS3.dll"]