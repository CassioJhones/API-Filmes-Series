 # 📚 Configuração do Projeto

### Pré-requisitos
 - **Docker:** Para rodar o MySQL em um container Docker. Instale o Docker Desktop caso ainda não tenha. [DOWNLOAD](https://www.docker.com/products/docker-desktop/)
 - **.NET SDK:** Para rodar o projeto e gerenciar as migrations. Instale o .NET SDK.

### 🐳 Rodando o MySQL no Docker
Para evitar a necessidade de instalar o MySQL localmente, configure o banco de dados em um container Docker.

No Docker Desktop, crie um novo container MySQL com as seguintes configurações:

![image](https://github.com/user-attachments/assets/b0100009-a43e-4502-bc0c-ee24b25df42d)

Ou usar o comando abaixo no terminal para criar o container MySQL diretamente:
```node
docker run --name mysql-filme -e MYSQL_ROOT_PASSWORD=root -e MYSQL_DATABASE=filme -p 3306:3306 -d mysql:8.0
```

### 🗄️ Configurando o Entity Framework
o Entity Framework Core é usado para gerenciar o banco de dados e as migrations. Com o MySQL rodando no Docker, siga estes passos para configurar o banco de dados no projeto.
Execute o comando para aplicar a migration e criar as tabelas necessárias no banco de dados filme no container Docker MySQL.
```node
dotnet ef database update
```

### 🧪 Testando a API
Com o MySQL rodando no Docker e o banco de dados configurado, você pode iniciar a API e fazer chamadas GET, POST, PUT, etc., para interagir com as tabelas.

Rode a aplicação com o comando:
```node
dotnet run
```

Use um cliente como Postman ou curl para testar os endpoints.

### 🚀 Comandos Resumidos para Configuração
Iniciar o MySQL no Docker:
```node
docker run --name mysql-filme -e MYSQL_ROOT_PASSWORD=root -e MYSQL_DATABASE=filme -p 3306:3306 -d mysql:8.0
```
Aplicar as migrations ao banco de dados:
```node
dotnet ef database update
```
Rodar a aplicação:
```node
dotnet run
```
### 💡 Observações
Esse projeto está configurado para usar o MySQL no Docker para facilitar o desenvolvimento local.
Tambem é possivel conectar-se ao MySQL rodando em localhost:3306 com o usuário root e senha root.
