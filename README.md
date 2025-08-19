
# 🏙️ Rest API - Cidades

Este projeto é uma API REST simples para gerenciar informações sobre cidades, incluindo seu nome, estado, país e população. Os dados das cidades são armazenados em um arquivo JSON.

## 📁 Estrutura do Projeto

O projeto é composto pelos seguintes arquivos principais:

- CidadesController.cs: Controlador ASP.NET Core que define os endpoints da API para operações CRUD em cidades.
- Cidade.cs: Modelo de dados que representa uma cidade, com propriedades para Id, Nome, IdEstado, IdPais e Populacao.
- CidadesRepository.cs: Classe responsável por gerenciar o armazenamento e a recuperação dos dados das cidades em um arquivo JSON.
- cidades.json: Arquivo JSON onde os dados das cidades são persistidos.
- Arquivos de UI (.cshtml, .css, .js): Arquivos relacionados à interface do usuário (páginas Razor) para a aplicação web, embora o foco principal seja a API.
- launchSettings.json: Configurações de inicialização para o projeto, incluindo URLs e variáveis de ambiente.
## 🎯 Funcionalidades da API

A API oferece os seguintes endpoints para interagir com os dados das cidades:

1. Obter Cidades

```https
 Endpoint: GET /paises/{idPais}/estados/{idEstado}/cidades
```

Descrição: Retorna uma lista de cidades filtradas por país e estado. Opcionalmente, pode-se filtrar por nome da cidade e população mínima.

#### Parâmetros de Rota:
- idPais (int, obrigatório): O ID do país.
- idEstado (int, obrigatório): O ID do estado.
#### Parâmetros de Consulta (Query Parameters):
- fromPopulacao (int, opcional): Filtra cidades com população maior ou igual a este valor.
- nome (string, opcional): Filtra cidades pelo nome exato.
#### Respostas:
- 200 OK: Retorna uma lista de objetos Cidade.
- 404 Not Found: Se nenhuma cidade for encontrada com os critérios especificados.
2. Adicionar Cidade
```https
Endpoint: POST /paises/{idPais}/estados/{idEstado}/cidades
```
Descrição: Adiciona uma nova cidade ao repositório.

#### Parâmetros de Rota:
- idPais (int, obrigatório): O ID do país ao qual a cidade pertence.
- idEstado (int, obrigatório): O ID do estado ao qual a cidade pertence.
#### Corpo da Requisição (Request Body):
- Um objeto Cidade no formato JSON, contendo Id, Nome e Populacao. Os valores de IdEstado e IdPais serão sobrescritos pelos valores da rota.
#### Respostas:
- 201 Created: Se a cidade for criada com sucesso. O cabeçalho Location na resposta indicará a URI da nova cidade.


## 📦 Como Executar

1. Pré-requisitos:
- .NET SDK (versão compatível com o projeto, geralmente .NET 6 ou superior).
- Um editor de código como Visual Studio ou VS Code.

2. Clonar o repositório

```bash
  git clone https://github.com/3lder7/API_Rest.git
  cd API_Rest-master/API
```

3. Restaurar dependências

```bash
    dotnet restore
```

4. Executar o projeto

```bash
    dotnet run
```

- O projeto será iniciado e a API estará disponível nas URLs configuradas em launchSettings.json (por exemplo, http://localhost:5000).

## 🛠️ Exemplos de Uso (com cURL)

- Obter todas as cidades de um estado/país:

```bash
  GET "https://localhost:5255/paises/55/estados/11/cidades"
```
- Obter uma cidade específica por nome:

```bash
  GET "https://localhost:5255/paises/55/estados/11/cidades?nome=Santos"
```


## ❗Observações

- Os dados das cidades são persistidos em um arquivo JSON (cidades.json) no diretório especificado em CidadesRepository.cs. Certifique-se de que o caminho seja válido ou ajuste-o conforme necessário para o seu ambiente.
- A aplicação web (.cshtml files) é básica e serve principalmente como um ponto de entrada para a API.
- Este é um projeto de exemplo e o repositório de dados (CidadesRepository) é uma implementação simples em memória que salva em um arquivo JSON. Para aplicações de produção, um banco de dados real seria mais apropriado.

---
  Feito por **Elder Galvão** 🐈‍⬛
