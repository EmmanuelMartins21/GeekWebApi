# GeekWebApi

A GeekWebApi é uma API que oferece diversos métodos GET para acessar informações sobre Filmes, Livros e Séries Geek. Essa API está sendo desenvolvida para fornecer dados detalhados e relevantes sobre os títulos mais populares e amados pelos fãs da cultura Geek.

## Endpoints

A seguir, estão listados os endpoints disponíveis na API, juntamente com as informações que eles fornecem:

### 1. Filmes

#### Endpoint: `/filmes`

Este endpoint retorna uma lista de Filmes Geek, contendo detalhes sobre cada um, como título, gênero, diretor, elenco, sinopse e outras informações relevantes.

#### Exemplo de resposta:

```json
{
  "filmes": [
    {
      "nome": "The Batman",
      "empresa": "Warner Bros. Pictures",
      "dataLancamento": "2022-03-04T00:00:00",
      "duracaoMinutos": 149
    },
   
  ]
}
```

### 2. Livros

#### Endpoint: `/livros`

Este endpoint retorna uma lista de Livros Geek, incluindo detalhes como título, autor, editora, sinopse e outras informações relevantes.

#### Exemplo de resposta:

```json
{
  "livros": [
    {
      "nome": "string",
      "genero": "string",
      "editora": "string",
      "dataLancamento": "2023-07-22T15:58:55.739Z",
      "paginas": 0
    }
   
  ]
}
```

### 3. Séries

#### Endpoint: `/series`

Este endpoint retorna uma lista de Séries Geek, contendo informações como título, gênero, criador, elenco e sinopse.

#### Exemplo de resposta:

```json
{
  "series": [
    {
       "nome": "string",
       "empresa": "string",
       "genero": "string",
       "dataLancamento": "2023-07-22T15:57:28.147Z",
       "duracaoMinutos": 0
    }
  ]
}
```

## Como usar a API

Para utilizar a GeekWebApi, basta fazer uma requisição GET para o endpoint desejado. A resposta será retornada em formato JSON, contendo os dados requisitados sobre Filmes, Livros ou Séries Geek.

### Exemplo de requisição utilizando cURL:

```bash
curl -X GET https://geekwebapi.com/filmes
```

## Considerações Finais

A GeekWebApi foi criada com o objetivo de fornecer informações relevantes sobre Filmes, Livros e Séries Geek para entusiastas da cultura nerd. É importante mencionar que esta API é apenas para fins educacionais e não possui nenhum vínculo oficial com as obras mencionadas.

Esperamos que você aproveite o uso da GeekWebApi e que ela contribua para o seu conhecimento e diversão no mundo Geek! Caso tenha alguma sugestão ou encontre algum problema, sinta-se à vontade para abrir um problema no repositório oficial no GitHub.

Divirta-se explorando o universo Geek através da GeekWebApi! 🚀

