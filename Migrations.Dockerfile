FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build

WORKDIR /app/src/MyBrokenPage.Dal.Design
COPY ["src/MyBrokenPage.Dal.Design/MyBrokenPage.Dal.Design.csproj", "./"]
COPY entrypoint.sh entrypoint.sh

RUN dotnet tool install --global dotnet-ef

RUN dotnet restore "MyBrokenPage.Dal.Design.csproj"
COPY src/MyBrokenPage.Dal.Design/ .

WORKDIR /app/src/MyBrokenPage.Dal
COPY src/MyBrokenPage.Dal/ .

WORKDIR "/app/src/MyBrokenPage.Dal.Design/."

ENV PATH $PATH:/root/.dotnet/tools
RUN dotnet-ef migrations add InitialMigrations

RUN chmod +x ./entrypoint.sh
CMD /bin/bash ./entrypoint.sh
