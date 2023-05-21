# CommerceCashFlow

A solução CommerceCashFlow foi projetada para fornecer uma plataforma para os comerciantes gerenciarem seu fluxo de caixa diário por meio de entradas de débito e crédito. Também inclui recursos para geração de relatórios consolidados de balanço diário.
Este projeto foi criado como teste com prazo de entrega de ate 3 dias.

## Arquitetura da Solucao Implementada

A solução segue uma arquitetura em camadas, aderindo aos princípios SOLID e padrão CQRS. É composto pelas seguintes camadas:

- **Camada de Apresentação**: Inclui os controladores responsáveis ​​por tratar as requisições HTTP e entregar as respostas aos clientes.

- **Camada de Aplicação**: Implementa a lógica de negócios e orquestra as interações entre as camadas de apresentação e domínio. Ele inclui manipuladores de comando e consulta para lidar com solicitações e processar operações de negócios.

- **Camada de domínio**: contém as principais entidades de negócios e a lógica de domínio. Ele define entidades como `Merchant`, `Transaction` e `Report`.

- **Camada de infraestrutura**: fornece implementações para dependências externas, como acesso a dados, armazenamento em cache e manipulação de eventos. Inclui repositórios para persistência de dados e serviços para gerenciamento de cache.

- **Camada de Persistência**: Lida com armazenamento e recuperação de dados. Ele utiliza o SQL Server para armazenamento persistente de entidades.

- **Cache Layer**: Utiliza Redis como um mecanismo de cache para melhorar o desempenho armazenando dados acessados ​​com frequência.

- **Event Bus**: Fornece um mecanismo de publicação-assinatura para comunicação orientada a eventos entre diferentes componentes do sistema.

## Tecnologias Utilizadas

- **.NET Framework 6**: A solução é desenvolvida no .NET Framework 6, oferecendo uma base robusta e escalável para o desenvolvimento de aplicativos corporativos.

- **C#**: A principal linguagem de programação usada para implementar a lógica de negócios e os componentes da solução.

- **ASP.NET Core**: usado para criar os pontos de extremidade da API RESTful e manipular solicitações HTTP.

- **Entity Framework Core**: Fornece um ORM para interagir com o banco de dados SQL Server e gerenciar a persistência de dados.

- **Redis**: Usado como um cache na memória para melhorar o desempenho armazenando dados acessados ​​com frequência.

- **Mediatr**: Pattern que facilita a comunicação entre os componentes ao introduzir um objeto mediador que atua como um hub central, promovendo um baixo acoplamento e simplificando a interação entre eles.

## Princípios de design
A solução CommerceCashFlow adere aos princípios SOLID para melhorar a capacidade de manutenção, extensibilidade e testabilidade do código:

- Single Responsibility Principle (SRP): Cada classe tem uma responsabilidade única, promovendo alta coesão e baixo acoplamento.
- Open/Closed Principle (OCP): O sistema é aberto para extensão, mas fechado para modificação, permitindo que novos recursos sejam adicionados sem modificar o código existente.
- Liskov Substitution Principle (LSP): As classes derivadas podem ser substituídas por suas classes base, garantindo a interoperabilidade e preservando o comportamento.
- Interface Segregation Principle (ISP): Classes dependem apenas das interfaces de que necessitam, evitando dependências desnecessárias.
- Dependency Inversion Principle (DIP): Módulos de alto nível dependem de abstrações, não de implementações concretas, facilitando a flexibilidade e desacoplamento.

## Patterns e Tecnologias
A solução CommerceCashFlow incorpora os seguintes padrões e tecnologias:

- CQRS (Command Query Responsibility Segregation): Separa as operações de escrita (comandos) das operações de leitura (consultas), permitindo melhor escalabilidade, performance e manutenibilidade.
- Padrão de repositório: fornece uma interface consistente e abstrata para acesso e persistência de dados.
- Cache Redis: implementa o cache usando Redis para melhorar o desempenho e reduzir a carga no banco de dados.
- Docker: Utiliza o Docker para conteinerizar o aplicativo e suas dependências, permitindo fácil implantação e escalabilidade.

## Pré-requisitos
Antes de executar a solução CommerceCashFlow, certifique-se de ter os seguintes pré-requisitos instalados:
- Docker: [Install Docker](https://docs.docker.com/get-docker/)
- .NET Core SDK 6 or higher: [Install .NET Core SDK](https://dotnet.microsoft.com/download)

## Executando o Aplicativo
Para executar o aplicativo CommerceCashFlow, siga estas etapas:
1. Clonar o repository:

   ```bash
   git clone https://github.com/paulocampez/CommerceCashFlow.git
   ```

2. Navegue até o diretório raiz do projeto:

   ```bash
   cd CommerceCashFlow
   ```

3. Compile:

   ```bash
   dotnet build
   ```

4. Inicie o aplicativo usando o Docker Compose:

   ```bash
   docker-compose up --build
   ```

Este comando criará as imagens do Docker e iniciará os contêineres para SQL Server, Redis e o aplicativo CommerceCashFlow.

5. Depois que os contêineres estiverem funcionando, você poderá acessar os endpoints da API em `http://localhost:5000`.

## Caso de Uso

Título: Processar Fluxo de Caixa Diário e Gerar Relatório Consolidado

Atores:

- *Merchant*: O usuário que gerencia o fluxo de caixa diário e gera relatórios.
Descrição:

- O Merchant inicia o processamento do fluxo de caixa diário e o processo de geração de relatórios.
- O sistema apresenta ao Merchant opções para entrada de transações de débito e crédito.
- O Merchant seleciona a opção adequada para adicionar uma transação de débito ou crédito.
- O sistema solicita ao Merchant os detalhes da transação, como valor e tipo (débito ou crédito).
- O Merchant insere os detalhes da transação e confirma.
- O sistema valida os dados da transação e os armazena no banco de dados SQL.
- O sistema também armazena a transação no cache Redis para recuperação rápida.
- O Merchant repete as etapas para adicionar transações adicionais conforme necessário.
Assim que o Merchant terminar de adicionar transações, ele poderá solicitar um relatório diário consolidado.
- O sistema recupera os dados da transação do banco de dados SQL e do cache Redis.
- O sistema calcula os saldos consolidados do dia com base nas transações.
- O sistema gera um relatório com os saldos consolidados e apresenta ao Merchant.
- O comerciante analisa o relatório e prossegue com outras ações, se necessário.

*Fluxo Alternativo* :

- Se ocorrer um erro durante o processamento da transação ou geração do relatório, o sistema exibe uma mensagem de erro para o Merchant e permite que ele tente novamente ou entre em contato com o suporte para obter assistência.

*Pré-condições* :
- O banco de dados SQL e o cache Redis estão configurados e acessíveis corretamente.
- O sistema está instalado e funcionando, e todos os serviços necessários estão operacionais.

*Pós-condições* :
- As transações diárias de fluxo de caixa são registradas e armazenadas no banco de dados SQL.
- O relatório diário com saldos consolidados é gerado e apresentado ao Merchant.
- O comerciante tem uma visão geral do fluxo de caixa diário e pode tomar decisões informadas com base no relatório.

*Este caso de uso descreve o fluxo principal de como um Merchant interage com o sistema para gerenciar o fluxo de caixa diário por meio de transações de débito e crédito e gerar relatórios diários consolidados.*


## Conclusão

A solução CommerceCashFlow utiliza tecnologias modernas e segue uma arquitetura bem estruturada para fornecer aos comerciantes recursos eficientes de gerenciamento de fluxo de caixa e geração de relatórios. Incorporando princípios SOLID, padrão CQRS e utilizando tecnologias como .NET Framework 6, Redis e SQL Server, a solução oferece escalabilidade, capacidade de manutenção e desempenho para atender às necessidades das empresas no gerenciamento de suas operações diárias de fluxo de caixa.
