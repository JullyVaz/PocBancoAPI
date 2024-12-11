# PocBancoAPI


Projeto Back-End feito em Asp.Net Core com base em arquitetura em camadas, seguindo boas práticas de programação pensando na manutenção do codigo.

Neste projeto temos as seguintes camadas:

-	Api
-	Service
-	Business
-	Repository

Durante uma requisição, é criada uma instância da controller, a controler irá receber uma injeção de dependência da service, a service irá receber uma injeção de dependência da business, a business por sua vez irá receber uma injeção da repository e finalmente a repository irá receber uma injeção da AppDbContex para fazer a conexão com o banco de dados.

Também temos a ajuda de alguns módulos secundários, como por exemplo o AutoMapper e o UnitOfWork, esses módulos existem para permitir mapeamento fácil entre as entidades e atomicidade de transação respectivamente. Além disso, contaremos com um módulo de testes, associado ao Framework Moq para injeção de dependência dentro dos testes.



