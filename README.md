# SISTEMA-GANIMEDES

Este projeto contém a API do sistema Ganimedes, um sistema desenvolvido por
alunos da USP para fazer a gestão das avaliações semestrais na pós-graduação.

## ESPECIFICAÇÕES

	Linguagem de programação: C#
	Versão do .NET: 8.0

## ARQUITETURA

Este projeto segue um padrão DDD, com quatro camadas:

* API
* Application
* Domain
* Infrastructure

A camada de API é o entry point da aplicação e contém as rotas; <br>
A camada Application contém as regras de negócio; <br>
A camada Domain contém as entidades do sistema; <br>
A camada Infrastructure faz a comunicação com o banco; <br>

# ENDPOINTS

## Formulários

### Recuperar formulários

`/getFormularios/NUSP/tipoUsuario?dataInicio=mm/yyyy&dataFim=mm/yyyy`

|	Parâmetro	|	Tipo	|	OBS 						|
|		:---:	|	:---:	|	:---:						|
|		NUSP	|	int32	|	Número USP do usuário		|
|tipoUsuario|enum|ALUNO / ORIENTADOR / CCP|
|dataInicio|datatime|Opcional|
|dataFim|datetime|Opcional|



