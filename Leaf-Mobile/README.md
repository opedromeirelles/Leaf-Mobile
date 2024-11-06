# Leaf Mobile

Leaf Mobile é uma aplicação de gerenciamento de entregas, parte do sistema de gestão distribuído Leaf, desenvolvido com foco em produtividade, eficiência e usabilidade. Esta aplicação é projetada especificamente para dispositivos móveis, destinada a facilitar o trabalho dos entregadores, permitindo o acompanhamento, consulta e baixa de pedidos de forma eficiente e prática.

## Índice

- [Tecnologias Utilizadas](#tecnologias-utilizadas)
- [Funcionalidades](#funcionalidades)
- [Arquitetura do Projeto](#arquitetura-do-projeto)
- [Uso](#uso)
- [Considerações](#considerações)
- [Licença](#licença)

## Tecnologias Utilizadas

- **.NET MAUI**: Framework utilizado para desenvolvimento cross-platform, permitindo a criação de aplicativos para iOS, Android e outros sistemas operacionais a partir de uma única base de código. Entretanto escolhemos o foco total na aplicação Android.
- **C#**: Linguagem principal do projeto, usada em conjunto com as melhores práticas de programação.
- **MVVM (Model-View-ViewModel)**: Arquitetura adotada para separar lógica de apresentação, dados e controle, facilitando a manutenção e testabilidade.
- **ADO.NET**: Usado para conexão com banco de dados SQL Server, permitindo a manipulação de dados dos pedidos de forma direta e segura.
- **CommunityToolkit.Maui**: Biblioteca de componentes MAUI usada para aprimorar a interface do usuário, facilitar animações, exibir notificações (Toasts), entre outras funcionalidades.
- **Injeção de Dependência**: Utilizada para gerenciar dependências de forma eficaz e garantir flexibilidade no código.
- **Validações de Dados e Tratamento de Erros**: Aplicadas para garantir a segurança e integridade dos dados, além de melhorar a usabilidade.

## Funcionalidades

Leaf Mobile é focado nas operações de entrega, fornecendo ao entregador as ferramentas necessárias para gerenciar os pedidos. Entre as principais funcionalidades, destacam-se:

- **Listagem de Pedidos**: O entregador pode visualizar todos os pedidos atribuídos a ele, juntamente com os detalhes relevantes, como endereço de entrega, cliente, número do pedido e CEP.
- **Atualização e Baixa de Pedidos**: Permite ao entregador atualizar o status do pedido para "baixado" após a entrega, registrando o momento exato e o responsável pela atualização.
- **Tratamento de Erros e Notificações**: Exibe mensagens de erro amigáveis e informativas em caso de falha na conexão ou operação, garantindo uma experiência de usuário robusta.
- **Refresh Pull-To-Refresh**: Permite ao usuário atualizar a lista de pedidos deslizando a tela para baixo, garantindo que sempre tenha a informação mais atualizada.
- **Modo Offline**: A aplicação pode armazenar informações temporariamente para que, em caso de perda de conexão, o entregador ainda possa acessar alguns dados.
- **Autenticação de Usuário**: Controle de login para garantir que apenas usuários autorizados possam acessar a aplicação.
  
## Arquitetura do Projeto

A arquitetura do Leaf Mobile foi planejada para garantir escalabilidade, facilidade de manutenção e separação de responsabilidades. O projeto foi organizado seguindo o padrão **MVVM** (Model-View-ViewModel), facilitando a ligação entre a interface de usuário e os dados:

- **View**: Camada de interface do usuário, onde os componentes visuais (como telas e botões) são definidos. Todas as interações do usuário, como cliques e navegação, são processadas nesta camada.
- **ViewModel**: Responsável por mediar as interações entre a `View` e o `Model`, gerenciando dados e comandos para interagir com a interface de forma reativa.
- **Model**: Representa as estruturas de dados principais, incluindo o pedido e seus itens, e define a lógica de negócios.
- **Services (Serviços)**: Contém lógica de manipulação de dados, incluindo conexões com o banco de dados via ADO.NET e operações CRUD para sincronizar pedidos e dados de usuários.
  
### Estrutura Adicional

- **Injeção de Dependência**: As dependências são gerenciadas e injetadas em tempo de execução, melhorando a modularidade e facilitando os testes.
- **Tratamento de Erros**: São aplicados tratamentos de erro específicos para notificar o usuário de problemas na execução, principalmente para erros de conexão.
- **Toast Notifications**: Mensagens pop-up utilizadas para informar o status de operações, como "Pedidos Atualizados" ou "Erro ao Atualizar Pedido", melhorando a usabilidade e o feedback imediato ao usuário.

## Conhecimentos e Conceitos Aplicados

Durante o desenvolvimento do Leaf Mobile, foram aplicados e aperfeiçoados diversos conceitos e práticas, como:

1. **MVVM em .NET MAUI**: A adoção de MVVM com .NET MAUI permitiu o desenvolvimento modular, facilitando a reutilização de componentes e a testabilidade do código.
2. **Conexão com SQL Server via ADO.NET**: Conhecimentos de ADO.NET foram aplicados para estabelecer uma conexão direta e segura com o banco de dados, realizando operações de CRUD (Create, Read, Update, Delete) de forma eficiente.
3. **Injeção de Dependência**: Compreensão e implementação da injeção de dependência para gerenciar serviços como `PedidoServices`, `UsuarioServices` e `ProdutoServices`, melhorando a flexibilidade do código.
4. **Tratamento e Manipulação de Erros**: Utilização de blocos de `try-catch` e feedback ao usuário para garantir que o aplicativo continue a funcionar de forma previsível mesmo em casos de erro.
5. **Animações e Usabilidade**: Uso da `CommunityToolkit.Maui` para aprimorar a experiência do usuário, adicionando animações de feedback visual e toasts informativos.
6. **Design Responsivo e Interface Intuitiva**: Projeto da interface de usuário otimizado para dispositivos móveis, proporcionando uma experiência de navegação intuitiva.

### Pré-requisitos

- .NET SDK 6.0 ou superior.
- Visual Studio 2022 com suporte para .NET MAUI.
- SQL Server para o banco de dados.

## Uso

1. **Login**: O usuário deve fazer login com suas credenciais para acessar a aplicação.
2. **Visualização de Pedidos**: A tela inicial exibe a lista de pedidos designados ao entregador.
3. **Atualização e Baixa de Pedido**: Ao clicar no pedido, o entregador pode visualizar os detalhes e, ao concluir a entrega, marcar o pedido como "baixado".
4. **Refresh da Lista de Pedidos**: Para garantir que os pedidos estejam atualizados, o usuário pode deslizar a tela para baixo para recarregar a lista.


## Considerações

Leaf Mobile foi desenvolvido como uma solução prática para o gerenciamento de entregas, fazendo parte de um sistema maior de gestão distribuída. Esta aplicação é destinada a fins acadêmicos e de aprendizado, com o objetivo de consolidar conhecimentos em desenvolvimento mobile, arquitetura MVVM e interação com bancos de dados.

---

Leaf Mobile é uma peça essencial do sistema Leaf, projetado para simular um ambiente de trabalho real e permitir a prática de conceitos avançados em desenvolvimento mobile, integração com backend e práticas modernas de arquitetura em software.