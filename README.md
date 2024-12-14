# SISTEMA-GANIMEDES

Este projeto contém o backend do sistema Ganimedes, um sistema desenvolvido por
alunos da USP para fazer a gestão das avaliações semestrais na pós-graduação.

O backend do Ganimedes é composto por dois serviços:

* ganimedes_backend: uma api feita com .NET 8.0, que contém todos
os endpoints necessários para o cliente fazer cadastro de usuários,
login, editar dados de usuário, recuperar informações do formulário,
submeter um formulário, e caso seja um usuário docente ou membro da 
ccp, endpoints para visualizar os formuários vinculados a ele
e também para submeter um parecer sobre o desempenho dos alunos.

* ganimedes_authentication_service: um microsserviço escrito em java
responsável por autenticar usuários, gerar tokens e validar tokens.
Ele possui endpoints que apenas o backend do ganimedes enxerga.

## ESPECIFICAÇÕES

	Linguagem de programação do backend: C#
	Versão do .NET: 8.0
___

	Linguagem de progamação do serviço de autentição: Java
	Versão da SDK do Java: 17.0.3

Para saber mais detalhes de cada serviço, navegue para
ganimedes_backend ou ganimedes_authentication_service. Cada um contém um readme com
mais detalhes da arquitetura escolhida, como rodar o projeto, e documentação
sobre as rotas.



