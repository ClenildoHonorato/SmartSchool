# SmartSchool API - Docker (MySQL)

Este projeto esta configurado para rodar com Docker usando MySQL.

## Arquivos Docker

- `SmartSchool.Api/Dockerfile`
- `docker-compose.yml`
- `docker-compose.override.yml`
- `.dockerignore`

## Como subir

```bash
docker compose up --build
```

Em segundo plano:

```bash
docker compose up -d --build
```

Parar e remover containers:

```bash
docker compose down
```

Parar e remover tambem o volume do MySQL:

```bash
docker compose down -v
```

## Servicos

- API: `http://localhost:5000`
- Swagger: `http://localhost:5000/swagger`
- MySQL: `localhost:3306`

## Variaveis principais

- `ASPNETCORE_ENVIRONMENT=Development`
- `ConnectionStrings__default=Server=mysql;Port=3306;Database=smartschool;User=root;Password=root`
- `MYSQL_ROOT_PASSWORD=root`
- `MYSQL_DATABASE=smartschool`

## Persistencia

O banco MySQL fica persistido no volume Docker `mysql_data`.
