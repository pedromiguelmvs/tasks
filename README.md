<p align="center">
   <img src="https://i.imgur.com/wA3rXSd.png" width="200"/>
</p>

# Tarefas - Backend





[![Author](https://img.shields.io/badge/author-PedroMiguel-D54F44?style=flat-square)](https://github.com/pedromiguelmvs)


> CRUD de tarefas feito com C# (ASP.NET Core), Identity, Entity Framework, JWT Auth e mais.

<br />
<p align="center"><img src="https://i.imgur.com/h6fT2YJ.png"/></p>

---

# :pushpin: Indice

* [Considerações Iniciais](#paintbrush-considerações-iniciais)
* [Features](#rocket-features)
* [Rodando o projeto](#runner-rodando-o-projeto)

# :paintbrush: Considerações iniciais

Antes de começar, quero esclarecer que, por motivos de organização, este projeto foi dividido em duas partes: __frontend__ e __backend__. O frontend pode ser acessado [clicando aqui](https://github.com/pedromiguelmvs/tasks).

# :rocket: Features

Projeto feito com SQLServer, C#, ASP.NET Core e mais.

* 👤 Crie novas tarafes através de uma listagem que atualiza em tempo real.
* 🎟️ Tenha o controle de tarefas já concluídas usando o marcador de tasks!

# :runner: Rodando o projeto

Primeiro, você deve clonar o repositório do projeto:

```git clone https://github.com/pedromiguelmvs/tasks```

Após isso, entre na pasta do projeto:

```cd tasks```

Feito isso, instale as dependências do projeto. Estarei levando em conta que você já tem a CLI do __dotnet__ instalada.
Caso não tenha, você pode obtê-la [clicando aqui](https://learn.microsoft.com/pt-br/dotnet/core/install/linux).

```dotnet restore```

Para armazenar os dados localmente utilizei um container no docker (é necessário tê-lo instalado, [clique aqui](https://docs.docker.com/engine/install/ubuntu/) caso não tenha). Rode o seguinte comando:

```docker compose -f Api/Infra/docker-compose.yml up -d --build```

Nossa base de dados já está disponível! Por motivos de praticidade, todas as chaves necessárias já estão no `appsettings.json`, apesar de não ser o ideal em um caso real de uso.

Tudo certo! Rode o projeto:

```dotnet watch```

ou

```dotnet run```