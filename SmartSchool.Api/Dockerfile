# Use a imagem base do .NET Core 3.1
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Use a imagem do SDK para build
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src

# Copiar o arquivo de projeto e restaurar dependências
COPY ["SmartSchool.Api/SmartSchool.Api.csproj", "SmartSchool.Api/"]
RUN dotnet restore "SmartSchool.Api/SmartSchool.Api.csproj"

# Copiar todo o código fonte
COPY . .
WORKDIR "/src/SmartSchool.Api"

# Build da aplicação
RUN dotnet build "SmartSchool.Api.csproj" -c Release -o /app/build

# Publish da aplicação
FROM build AS publish
RUN dotnet publish "SmartSchool.Api.csproj" -c Release -o /app/publish

# Imagem final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Criar diretório para o banco SQLite
RUN mkdir -p /app/data

# Definir variáveis de ambiente
ENV ASPNETCORE_ENVIRONMENT=Production
ENV ASPNETCORE_URLS=http://+:80

ENTRYPOINT ["dotnet", "SmartSchool.Api.dll"]



