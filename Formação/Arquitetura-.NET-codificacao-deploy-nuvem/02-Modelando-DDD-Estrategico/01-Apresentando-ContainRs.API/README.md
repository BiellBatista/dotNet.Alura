# Preparando o ambiente

## Criando o banco de dados a estrutura e dados iniciais do Identity
Abra o terminal, navegue para a pasta onde baixou o projeto e execute o comando abaixo:
```
dotnet ef database update --context IdentityDbContext --project .\src\_01_Apresentando_ContainRs.API\_01_Apresentando_ContainRs.API.csproj --startup-project .\src\_01_Apresentando_ContainRs.API\_01_Apresentando_ContainRs.API.csproj
```

## Criando o banco de dados a estrutura e dados iniciais de negócio
Abra o terminal, navegue para a pasta onde baixou o projeto e execute o comando abaixo:
```
dotnet ef database update --context AppDbContext --project .\src\_01_Apresentando_ContainRs.API\_01_Apresentando_ContainRs.API.csproj --startup-project .\src\_01_Apresentando_ContainRs.API\_01_Apresentando_ContainRs.API.csproj
```

## Rodando o projeto

O comando deverá criar o banco de dados e as tabelas necessárias para o funcionamento do projeto.