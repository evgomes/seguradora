# Seguradora

Aplicação de teste desenvolvida para listar, cadastrar, alterar, e excluir seguros residenciais, de vida e veiculares.

## Tecnologias Utilizadas

### Aplicação Back-end
- [ASP.NET Core 2.1](https://docs.microsoft.com/pt-br/aspnet/core/?view=aspnetcore-2.1);
- [Entity Framework Core 2.1](https://docs.microsoft.com/pt-br/ef/core/) (framework ORM para acesso a dados);
- [Entity Framework In-Memory Provider](https://docs.microsoft.com/pt-br/ef/core/miscellaneous/testing/in-memory) (para testes e para utilizar o Entity Framework em memória);
- [AutoMapper](https://automapper.org/) (mapeamento de recursos da API para modelos de domínio);

### Aplicação Cliente
- [Asp.Net Core 2.1 + SPA Template Angular](https://docs.microsoft.com/pt-br/aspnet/core/client-side/spa/angular?view=aspnetcore-2.1&tabs=visual-studio);
- [Bootstrap 4](https://getbootstrap.com/docs/4.0/getting-started/introduction/) (estilização das páginas);
- [Ng-Bootstrap](https://ng-bootstrap.github.io/#/home) (compatibilidade do Bootstrap com Angular);
- [Ngx-Toastr](https://www.npmjs.com/package/ngx-toastr) (notificações toast);
- [ngx-mask](https://www.npmjs.com/package/ngx-mask) (máscaras de CPF, CNPJ e de placas de veículos);
- [Rxjs](https://rxjs-dev.firebaseapp.com/) (utilização de observables);

## Requisitos para testar

Para testar a aplicação, é necessário ter os seguintes programas instalados na máquina:

- [.NET Core SDK](https://www.microsoft.com/net/download/dotnet-core/2.1) versão 2.1.5
- [Node.js](https://nodejs.org/en/download/) (última versão estável "LTS")
- [Angular CLI](https://cli.angular.io/)

### Como Testar

Primeiramente, faça o clone do repositório em uma pasta do computador:

```https://github.com/evgomes/seguradora.git```

Abra o terminal na pasta baixada, caso esteja utilizando Linux ou MacOS, ou o prompt de comando no caso de utilizar Windows.

Caso você esteja usando Linux ou MacOS, execute os seguintes comandos em sequência, um por vez:

```
cd src/Seguradora.Apresentacao.Web.Angular/ClientApp/
sudo npm install
cd ..
dotnet restore
export ASPNETCORE_ENVIRONMENT="Development"
source ~/.bash_profile
dotnet run
```

Caso você esteja utilizando Windows, execute os seguintes comandos em sequência, um por vez:

```
cd src/Seguradora.Apresentacao.Web.Angular/ClientApp/
npm install
cd ..
dotnet restore
set ASPNETCORE_ENVIRONMENT=Development
dotnet run
```
Caso tudo ocorra normalmente, a aplicação iniciará corretamente em modo de desenvolvimento. Caso ela inicie por engano em modo de produção, siga [esses passos](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/environments?view=aspnetcore-2.1) para alterar o ambiente e executar corretamente a aplicação.

Acesse o endereço ```localhost:5000``` para iniciar a aplicação. Caso ocorra erro de validação de HTTPS, adicione uma exceção ao browser para abrir a aplicação.

### Testes de Banco de Dados

Foi utilizado um provedor em memória para o banco de dados de forma a simplificar os testes da API. A aplicação possui suporte para MySQL ou outros provedores desejados.

Para testar com MySQL, altere o provider do contexto na classe ```Startup.cs``` (trecho está comentado), altere a string de conexão com o banco no arquivo ```appsettings.json``` e, no terminal ou prompt de comando, dentro da pasta do projeto cliente ```Seguradora.Apresentacao.Web.Angular```, execute a migration da base com o seguinte comando:

```dotnet ef database update --project ../Seguradora.Persistencia.EF/Seguradora.Persistencia.EF.csproj --startup-project Seguradora.Apresentacao.Web.Angular.csproj```

### Testes Unitários

Para executaros testes do projeto, abra o terminal ou prompt de comando no diretório do projeto ```Seguradora.Testes``` e execute os seguintes comandos:

```
dotnet restore
dotnet test
```

O resultado dos testes será exibido no terminal ou prompt.
