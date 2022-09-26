FROM mcr.microsoft.com/dotnet/sdk:6.0
RUN dotnet tool install -g dotnet-ef
RUN export PATH="$PATH:/root/.dotnet/tools"
WORKDIR /app
COPY . ./