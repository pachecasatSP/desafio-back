# Bem-vindo ao Projeto desafio-back

## Olá!

Meu nome é Adolfo, tenho 42 anos e estou muito empolgado em participar deste processo seletivo. Tenho uma vasta experiência em desenvolvimento de software e estou sempre em busca de novos desafios e oportunidades para aprender e crescer. Este projeto é um reflexo do meu compromisso com boas práticas de desenvolvimento e design de software.

## Sobre o Projeto

Este projeto de teste foi desenvolvido para demonstrar meu conhecimento e habilidades em várias áreas importantes do desenvolvimento de software, incluindo:

- **Docker e Docker Compose**: Utilização de múltiplos containers para facilitar o desenvolvimento e o teste da aplicação.
- **Design Patterns**: A implementação de padrões de design.
- **DRY** - Encapsular de processos repetitivos.
- **DDD** - O projeto está dividido nas camadas Api, Domain, Infrastructure
	- A Api contém toda a lógica de aplicação (Command Handlers, Responses, Requests e as Rotas de api)
	- O Domínio expõe todo o contexto de domínio do projeto, bem com as abstrações e definições para os componentes que o irâo consumir.
	- A infraestruta fornece todos os serviços que fazem interface com o mundo externo à aplicação, neste caso específico, temos:
		* Acesso a banco de dados - separado em 2 contextos (RentalManagementContext e AuditContext)
			- RentalManagementContext é o contexto principal do domínio da aplicação
			- Audit é o contexto que armazena os eventos disparados dentro da aplicação
		* Comunicação com a mensageria
			Aqui estão os consumers e producers dos eventos disparados
		* Comunicação com o serviço de armazenamento
			Neste caso, estou utilizando o Azure BlobStorage através do Azurite.

### Alguns dos Design Patterns Utilizados

1. **Mediator Pattern**:
   - **MediatR**: Utilizado para desacoplar o código de manipulação de comandos e consultas da lógica de negócios, promovendo uma comunicação mais clara e eficiente entre os componentes.

2. **Repository Pattern**:
   - Implementado para abstrair o acesso a dados e promover a separação de preocupações entre a lógica de negócios e a persistência de dados.

3. **Specification Pattern**:
   - Utilizado para encapsular regras de negócios e critérios de seleção complexos de maneira reutilizável e compreensível.

### Configuração do Docker Compose

O projeto utiliza Docker Compose para orquestrar a execução de múltiplos containers. 
O arquivo `docker-compose.yml` encontra-se na pasta raiz do projeto e inclui as seguintes imagens:

- **api**: A aplicação principal.
- **rabbitmq**: Servidor de mensagens para comunicação assíncrona.
- **postgres**: Banco de dados relacional para armazenamento persistente.
- **azurite**: Emulador de armazenamento Azure para desenvolvimento local.

#### Instruções para Execução

Para iniciar a aplicação, siga estes passos:

1. Certifique-se de que o Docker e o Docker Compose estão instalados na sua máquina.
2. Navegue até o diretório raiz do projeto onde o arquivo `docker-compose.yml` está localizado.
3. Execute um dos comandos abaixo para iniciar todos os containers:

1a. Execução:	
   ```bash
   docker-compose up --build
   
Execuçôes subsequentes
```bash
   docker-compose up
