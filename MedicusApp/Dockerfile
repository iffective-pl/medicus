FROM mcr.microsoft.com/dotnet/sdk:6.0
RUN dotnet tool install -g dotnet-ef
ENV PATH="${PATH}:/root/.dotnet/tools"
RUN curl -fsSL https://deb.nodesource.com/setup_16.x | bash -
RUN apt-get install -y nodejs
WORKDIR /app
COPY . ./
RUN dotnet build