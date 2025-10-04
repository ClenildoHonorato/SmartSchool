# SmartSchool API - Docker

Este projeto agora está configurado para rodar com Docker.

## Arquivos Docker criados:

- `SmartSchool.Api/Dockerfile` - Configuração da imagem Docker
- `docker-compose.yml` - Orquestração dos serviços
- `.dockerignore` - Arquivos ignorados no build
- `SmartSchool.Api/data/` - Diretório para persistência do SQLite

## Como usar:

### 1. Build e execução com Docker Compose (Recomendado):
```bash
# Build e execução
docker-compose up --build

# Execução em background
docker-compose up -d --build

# Parar os serviços
docker-compose down
```

### 2. Build e execução manual:
```bash
# Build da imagem
docker build -f SmartSchool.Api/Dockerfile -t smartschool-api .

# Executar o container
docker run -p 5000:80 -v ${PWD}/SmartSchool.Api/data:/app/data smartschool-api
```

### 3. Comandos úteis:
```bash
# Ver logs
docker-compose logs -f smartschool-api

# Rebuild sem cache
docker-compose build --no-cache

# Acessar o container
docker-compose exec smartschool-api bash
```

## Acesso à API:

- **API**: http://localhost:5000
- **Swagger**: http://localhost:5000/swagger

## Configurações:

- **Porta**: 5000 (host) -> 80 (container)
- **Banco de dados**: SQLite persistido em `SmartSchool.Api/data/`
- **Ambiente**: Development (configurável via variável de ambiente)

## Variáveis de ambiente disponíveis:

- `ASPNETCORE_ENVIRONMENT`: Development/Production
- `ConnectionStrings__default`: String de conexão do banco

## Estrutura dos volumes:

```
SmartSchool.Api/data/  ->  /app/data (container)
```

O banco SQLite será criado automaticamente no diretório `data` e persistirá entre as execuções do container.


