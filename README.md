# SISTEMA-GANIMEDES

Este projeto contém a API do sistema Ganimedes, um sistema desenvolvido por
alunos da USP para fazer a gestão das avaliações semestrais na p�s-gradua��o.

## ESPECIFICA��ES

	Linguagem de programa��o: C#
	Vers�o do .NET: 8.0

## ARQUITETURA

Este projeto segue um padr�o DDD, com quatro camadas:

* API
* Application
* Domain
* Infrastructure

A camada de API � o entry point da aplica��o e cont�m as rotas; <br>
A camada Application cont�m as regras de neg�cio; <br>
A camada Domain cont�m as entidades do sistema; <br>
A camada Infrastructure faz a comunica��o com o banco; <br>

# ENDPOINTS

## Formul�rios

### Recuperar formul�rios

`/getFormularios/NUSP/tipoUsuario?dataInicio=mm/yyyy&dataFim=mm/yyyy`

|	Par�metro	|	Tipo	|	OBS 						|
|		:---:	|	:---:	|	:---:						|
|		NUSP	|	int32	|	N�mero USP do usu�rio		|
|tipoUsuario|enum|ALUNO / ORIENTADOR / CCP|
|dataInicio|datatime|Opcional|
|dataFim|datetime|Opcional|



