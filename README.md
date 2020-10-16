# NBA Stats API

API desenvolvida para o processo seletivo da Ploomes. Trata-se de uma simples API de cadastro de Times e Jogadores da NBA ou qualquer outra liga relacionada ao basquete. 

Recursos disponíveis para acesso via API:
* [**Players**](#reference/Players)
* [**WhoIsTheKing**](#reference/Whoistheking)
* [**TopPlayers**](#reference/Toplayers)
* [**Teams**](#reference/Teams)

## Métodos
Requisições para a API devem seguir os padrões:
| Método | Descrição |
|---|---|
| `GET` | Retorna informações de um ou mais registros. |
| `POST` | Utilizado para criar um novo registro. |
| `PUT` | Atualiza dados de um registro ou altera sua situação. |
| `DELETE` | Remove um registro do sistema. |

## Respostas

| Código | Descrição |
|---|---|
| `200` | Requisição executada com sucesso (success).|
| `201` | Registro criado com sucesso (success).|
| `204` | Requisição executada com sucesso sem dados a retornar (success).|
| `401` | Dados de acesso inválidos.|
| `404` | Registro pesquisado não encontrado (Not found).|
| `500` | Erro interno do servidor, verificar os dados enviados para a API|

# Autenticação

Os métodos PUT, POST e DELETE sempre necessitam que seja passado em sua URL o paramêtro key juntamente com seu valor, trata-se de uma medida de segurança implementada pelo 
desenvolvedor desse projeto. Caso não possua uma chave de API, entre em contato via [LinkedIn](https://www.linkedin.com/in/carlos-franco-118046172/) ou envie um email para:
carloshof12@gmail.com


# Recursos

Caso utilize o Insomnia como ferramenta auxiliar, você pode baixar o script com todos as chamadas clicando aqui.


# Players [/Players]

Aqui estão presente os jogadores e suas estatísticas.

### Listar todos os jogadores [GET]
+ Rota: https://nbastatistics20201013222633.azurewebsites.net/api/players

+ Request (application/json)


+ Response 200 (application/json)

  `
{
  {
    "id": 1,
    "name": "Junir James",
    "points": 233,
    "rebounds": 232,
    "assists": 3232,
    "team": {
      "id": 1,
      "name": "Portland",
      "championships": 5
    },
   "teamId": 1
   },
   {
    "id": 2,
    "name": "Roberto James",
    "points": 20,
    "rebounds": 32,
    "assists": 32,
    "team": {
      "id": 1,
      "name": "Portland",
      "championships": 5
    },
   "teamId": 1
   }
}
  `

### Recuperar jogador especifico [GET/{id}]
+ Rota: https://nbastatistics20201013222633.azurewebsites.net/api/players/{id}

+ Request (application/json)


+ Response 200 (application/json)

  `
{
  "id": 1,
  "name": "Junir James",
  "points": 233,
  "rebounds": 232,
  "assists": 3232,
  "team": {
    "id": 1,
    "name": "Portland",
    "championships": 5
  },
  "teamId": 1
}

  `
  
### Criar novo jogador [POST]
+ Rota: https://nbastatistics20201013222633.azurewebsites.net/api/players?key=api_key

+ Query (application/json)
           + key: api_key  (required)

+ Request (application/json)

+ Attributes (object)
    + name: nome do jogador (string,optional) 
    + points: pontos do jogador (int, optional)
    + rebounds: rebotes do jogador (int, optional)
    + assists: assistências do jogador (int, optional)
    + teamId: Id do time do jogador (int, required)


+ Response 201 (application/json)

  `
{
  "name": "Junir James",
  "points": 233,
  "rebounds": 232,
  "assists": 3232,
  "team": {
    "id": 1,
    "name": "Portland",
    "championships": 5
  },
  "teamId": 1
}
  `

### Deletar jogador [DELETE/{id}]
+ Rota: https://nbastatistics20201013222633.azurewebsites.net/api/players/{id}?key=api_key

+ Query (application/json)
           +  key: api_key  (required)

+ Request (application/json)

+ Response 200 (application/json)

  `
{
  "id": 2,
  "name": "Rodrigo Bryant",
  "points": 23,
  "rebounds": 20,
  "assists": 3,
  "team": null,
  "teamId": 1
}
  `

### Alterar jogador [PUT/{id}]
+ Rota: https://nbastatistics20201013222633.azurewebsites.net/api/players/{id}?key=api_key

+ Query (application/json)
            + key: api_key (required)

+ Request (application/json)

+ Attributes (object)
    + name: nome do jogador (string,optional) 
    + points: pontos do jogador (int, optional)
    + rebounds: rebotes do jogador (int, optional)
    + assists: assistências do jogador (int, optional)
    + teamId: Id do time do jogador (int, required)


+ Response 204 (application/json)


# Who is The King? [/whoistheking]

Endpoint bonus que retorna o Rei (valor mockado)

### Quem é o Rei [GET]
+ Rota: https://nbastatistics20201013222633.azurewebsites.net/api/whoistheking

+ Request (application/json)


+ Response 200 (application/json)

  `
{
  "id": 23,
  "name": "Lebron James",
  "points": 34241,
  "rebounds": 10542,
  "assists": 9346,
  "team": {
    "id": 24,
    "name": "Los Angeles Lakers",
    "championships": 10
  },
  "teamId": 0
}

  `
  
# Top Players [/topplayers]
### Endpoint que possibilita a recuperação dos melhores jogadores cadastrados, possivel utilizar filtros [GET]
+ Rota: https://nbastatistics20201013222633.azurewebsites.net/api/topplayers?limit=1&order=ASC&Skill=Rebound

+ Request (application/json)

+ Query (application/json)
           + limit: número inteiro que retorna o número de resultados desejado (por default retorna 10)
           + order: valores aceitos ASC ou DESC (decrescente ou crescente, por default retorna decrescente)
           + skill: habilidade que deseja ranquear, valores possiveis são POINTS,REBOUNDS ou ASSISTS ( por default retorna Points)

+ Response 200 (application/json)
 
 `
[
  {
    "id": 1,
    "name": "Junir James",
    "points": 233,
    "rebounds": 232,
    "assists": 3232,
    "team": null,
    "teamId": 1
  }
]
  `

# Teams [/Teams]

Aqui estão presentes os times e suas estatísticas.

### Listar todos os Times [GET]
+ Rota: https://nbastatistics20201013222633.azurewebsites.net/api/teams

+ Request (application/json)


+ Response 200 (application/json)

`
          {
            {
              "id": 1,
              "name": "Portland",
              "championships": 5
            },
            {
              "id": 2,
              "name": "Lakers",
              "championships": 10
            }
          }
  `

### Recuperar time especifico [GET/{id}]
+ Rota: https://nbastatistics20201013222633.azurewebsites.net/api/teams/{id}

+ Request (application/json)


+ Response 200 (application/json)

  `
{
  "id": 1,
  "name": "Portland",
  "championships": 5
}
  `

### Criar novo Time [POST]
+ Rota: https://nbastatistics20201013222633.azurewebsites.net/api/team?key=api_key

+ Query (application/json)
            key: api_key  (required)

+ Request (application/json)

+ Attributes (object)
    + name: nome do time (string,optional) 
    + championships: numero de titulos do time (int, optional)


+ Response 201 (application/json)

  `
{
  "id": 3,
  "name": "Lakers",
  "championships": 10
}
  `

### Deletar Time [DELETE/{id}]
+ Rota: https://nbastatistics20201013222633.azurewebsites.net/api/teams/{id}?key=api_key

+ Query (application/json)
            key: api_key  (required)

+ Request (application/json)

+ Response 200 (application/json)

`
{
  "id": 3,
  "name": "Lakers",
  "championships": 10
}
  `


### Alterar Time [PUT/{id}]
+ Rota: https://nbastatistics20201013222633.azurewebsites.net/api/teams/{id}?key=api_key

+ Query (application/json)
            key: api_key (required)

+ Request (application/json)

+ Attributes (object)
     + name: nome do time (string,optional) 
     + championships: numero de titulos do time (int, optional)


+ Response 204 (application/json)
