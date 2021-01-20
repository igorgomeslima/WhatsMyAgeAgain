Esse projeto foi criado para resolver o desafio proposto nesse [repositorio](https://github.com/rodrigodos/IngenicoLAR "repositorio").


## Tecnologias

* ASP.NET Core 5
* OpenAPI

## Descrição da Implementação
Foi desenvolvida uma WebApi que possui **2 métodos***. Ambos recebem como parametro uma data(data de nascimento) para que seja realizado o calculo de idade conforme solicitado no desafio.

### Observações

***Eu decidi criar 2 métodos para a realização do cálculo, pois nao pude compreender o formato final(output) esperado, ou seja, tive uma dupla interpretação :).** 

> "...O exercício é gerar uma solução onde seja informado a data de nascimento, e a resposta seja a idade em anos, meses e dias."

Dito isso, seguem interpretações:

### Primeira
- O usuário informa uma data de nascimento;
- O sistema deverá retornar aquela data **representada/equivalente** em anos, dias e anos;

Exemplo:

**Input Payload**

    {
        "birthDate": "30/12/1992"
    }

**Output Payload**

    {
      "result": {
        "ageInDays": 10247,
        "ageInMonths": 336,
        "ageInYears": 28
      }
    }

### Segunda
- O usuário informa uma data de nascimento;
- O sistema deverá retornar "**uma descrição detalhada**" sobre os anos, meses e dias passados até o momento.

Exemplo:

**Input Payload**

    {
        "birthDate": "30/12/1992"
    }

**Output Payload**

    {
      "result": "Uma pessoa que nasceu em '30/12/1992' hoje tem 28 anos, 0 meses e 20 dias."
    }
	
	
## Como testar a solução?

### TL;DR
Caso já conheça como funciona o Swagger, ignore as demais etapas. 😀✔


1. O projeto Web Api ja esta definido como projeto principal da solução, desta forma, você só precisa clonar esse repositório e rodar o projeto na sua IDE .NET favorita(que suporte as tecnologias descritas no início deste documento).

3. O projeto esta utilizando "Swashbuckle" para gerar uma documentação nos padroes OpenAPI e para que seja oferecida uma UI interativa utilizando Swagger(atualmente essa definição é um padrão em projetos .NET 5).

5. Após a execução da solução, selecione o método que deseja testar, clique no respectivo botao **[Try it out]**, informe uma *data* para o payload presente no campo **"Request body"** e em seguida acione o botao **[Execute]**. A resposta do "request" aparecerá logo abaixo, no campo **"Response body"**.

![](https://i.imgur.com/IyLE3Z7.gif)
