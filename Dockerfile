FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
RUN dotnet tool install -g Microsoft.Web.LibraryManager.Cli
ENV PATH $PATH:/root/.dotnet/tools

WORKDIR /app
COPY . .

WORKDIR /app/src/MyBrokenPage.UI
COPY ["src/MyBrokenPage.UI/MyBrokenPage.UI.csproj", "./"]
RUN dotnet restore "./MyBrokenPage.UI.csproj"

WORKDIR /app/src/MyBrokenPage.UI
RUN libman restore
RUN dotnet build "MyBrokenPage.UI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MyBrokenPage.UI.csproj" -c Release -o /app/publish

FROM base as final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyBrokenPage.UI.dll"]