# API do Ganimedes

Esse projeto contém o core do backend do ganimedes, com a api
que contém os principais endpoints para cadastro de usuários,
login, recuperação e inserção de formulários por parte
dos alunos, recuperação de formulários por parte dos docentes
e membros da ccp, e recuperação e inserção do parecer emitido
pelos docentes e membros da ccp.

Existem três tipos de usuário no sistema:

* Aluno: com funcionalidades para recuperar e inserir seu formulário
semestral.

* Docente: com funcionalidades para visualizar formulários de seus orientandos e emitir um parecer.

* CCP: pode visualizar formulários de todos alunos no sistema que tiveram um
parecer emitido pelo seu orientador. Também consegue visualizar o parecer
do orientador, emitir um parecer, e visualizar pareceres que outros membros
da ccp possam ter dado.

## Especificações

Linguagem: C# </br>
Versão do .NET: 8.0 </br>

Este sistema se comunica com um microsserviço de autenticação em java, que se localiza no mesmo repositório em ../ganimedes_authentication_service. O microsserviço é responsável por fazer a validação interna do login, gerar tokens para logins bem sucedidos, e validar tokens. Todos enpoints consumíveis por usuários do sistema após autenticação necessitam de um token de autorização enviado no header da requisição. </br>

Além disso, é necessário subir o banco de dados e configurar as variáveis de ambiente em launchSettings.json para que o programa estabeleça conexão com o banco. Na pasta Sistema-Ganimedes.DB existe um Dockerfile que permite subir o banco em um contêiner. Por isso é recomendado ter o docker instalado em sua máquina.

## Execução do projeto

Para rodar o projeto, é necessário ter o .NET 8.0 ou superior instalado em seu máquina. Caso não tenha, acesse o link da microsoft para instalar e siga as instruções:

https://learn.microsoft.com/pt-br/dotnet/core/install/windows

O mínimo necessário é o runtime do .net.

Para rodar o projeto, clone o repositório em sua máquina com:

    git clone https://github.com/rafael2051/Sistema-Ganimedes.Back.git

Navegue até o projeto com a api do projeto:

    cd Sistema-Ganimedes.Back/ganimedes_backend

E execute o seguinte comando para iniciar a aplicação:

    dotnet run --project '.\Sistema-Ganimedes.API\'

A API subirá na porta 7260 com https. Além disso, é necessário subir o banco de dados. Recomendo utilizar o docker-compose.yaml na pasta Sistema-Ganimedes.DB. Navegue até a pasta com o arquivo docker-compose.yaml:

    cd Sistema-Ganimedes.DB

E execute o seguinte comando:

    docker-compose up --build -d

Caso não tenha o docker instalado na sua máquina, pode instalar acessando a página oficial do docker:

https://docs.docker.com/manuals/

Por fim, é necessário rodar o microsserviço de autenticação em java, localizado em
Sistema-Ganimedes.Back/ganimedes_authentication_service.

## ENDPOINTS

### CADASTRO DE USUÁRIOS

___

POST /registerUser </br>
Body:

    {
        "nUsp": "string",
        "nome": "string",
        "email": "string",
        "password": "string",
        "linkLattes": "string",
        "dtAtualizacaoLattes": "2024-12-18T02:55:38.372Z",
        "perfil": "ALUNO | DOCENTE | CCP"
    }
Descrição: utlizado para cadastrar todo usuário no sistema. </br>

Retorno: 200 para cadastro bem sucedido. 409 para tentativa de cadastro de usuário que já existe no banco. 400 para caso de envio de dados inválidos no json. E 500 em caso de erro interno.
___

POST /registerStudent </br>
Body:

    {
        "nUsp": "string",
        "curso": "string",
        "anoIngresso": 0,
        "exameProficiencia": "string",
        "exameQualificacao": "string",
        "prazoMaximoQualificacao": "2024-12-18T02:59:08.826Z",
        "prazoMaximoDepositoTese": "2024-12-18T02:59:08.826Z",
        "orientador": "string",
        "rg": "string",
        "dtNascimento": "2024-12-18T02:59:08.826Z",
        "nacionalidade": "string"
    }
Descrição: utilizado para cadastrar um usuário com perfil de aluno no sistema. </br>

Regras de negócio: deve ser chamado apenas depois de o /registerUser para o aluno ter retornado 200, indicando o cadastro do usuário no banco. nUsp deve conter o mesmo número USP do usuário regitrado, o usuário deve ter sido registrado como aluno, e o campo orientador deve ter o número USP de um usuário cadastrado como docente no sistema. </br>

Retorno: 201 para cadastro bem sucedido. 409 em tentativa de criação de aluno antes da criação do usuário ou em tentativa de criação de aluno que já está cadastrado no sistema. E 500 em caso de erro interno.
