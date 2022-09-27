FROM mcr.microsoft.com/dotnet/sdk:6.0
RUN dotnet tool install -g dotnet-ef
ENV PATH="${PATH}:/root/.dotnet/tools"
WORKDIR /app
COPY . ./
RUN dotnet build