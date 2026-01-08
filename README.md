# LiteMessenger – MSN Messenger Web Reimaginado

LiteMessenger é um projeto backend e frontend desenvolvido em .NET Core (versão 10), com o propósito de recriar de forma reimaginada o antigo MSN Messenger dos anos 2000, totalmente funcional via web.

O objetivo do projeto é construir um sistema de chat em tempo real com interatividade rica usando tecnologias modernas como WebSockets e WebAPI, permitindo conversas instantâneas, persistência de usuário, presença online e expansão para funcionalidades sociais.

O projeto ainda está em desenvolvimento — muitas funcionalidades básicas ainda estão pendentes de implementação.

## Funcionalidades Atuais
* API backend construída com ASP.NET Core
* Suporte inicial para mensagens/WebSockets
* Estrutura modular com separação de camadas (Domain, Application, API e WebUI)
* Frontend web (possivelmente em SPA usando TypeScript/HTML/CSS)
* Exemplos de endpoints REST para operações básicas

Observação: O projeto está em fase inicial e muitas features ainda faltam, como autenticação completa, persistência de mensagens, gerenciamento de salas e presença em tempo real.

## Arquitetura do projeto
```
LiteMessenger.Api            // Host API e endpoints REST/WebSockets
LiteMessenger.Application    // Lógica de aplicação (casos de uso)
LiteMessenger.Domain         // Entidades de domínio
LiteMessenger.WebUI          // Interface web (frontend)
LiteMessenger.slnx           // Solução principal .NET
package.json                 // scripts para automações de desenvolvimento (possivelmente será trocado para um Makefile)
.gitignore
```

A estrutura segue padrões de organização em camadas, mantendo o domínio e lógica de aplicação separados da infraestrutura e da interface de usuário.

## Tecnologias utilizadas
* .NET / ASP.NET Core 10
* C#
* Web API (REST)
* WebSockets (para interatividade em tempo real)
* Frontend Web (TypeScript / HTML / CSS - via WebUI)
* Modularização em camadas (Domain, Application, API, UI)
* Potencial para expansão com Docker, autenticação, persistência, etc.

## Como executar o projeto
### 1. Clone o projeto
```bash
git clone https://github.com/vitormcampos/litemessenger.git
cd litemessenger
```

### 2. Backend (.NET)
Na raiz da solução:
```bash
dotnet run --project LiteMessenger.Api
```
A API deve iniciar em uma porta configurada (ex: https://localhost:5001).

### 3. Frontend (WebUI)
```bash
cd LiteMessenger.WebUI
npm install
ng serve
```

## Objetivos do projeto
* Recriar o espírito do MSN Messenger de forma moderna e web
* Aprender e aplicar conceitos de tempo real com WebSockets no .NET
* Criar uma base extensível para chats e interações sociais
* Explorar arquitetura em camadas com .NET Core
* Servir como projeto de estudo e base para futuras funcionalidades
