# Leaf Mobile

Leaf Mobile � uma aplica��o de gerenciamento de entregas, parte do sistema de gest�o distribu�do Leaf, desenvolvido com foco em produtividade, efici�ncia e usabilidade. Esta aplica��o � projetada especificamente para dispositivos m�veis, destinada a facilitar o trabalho dos entregadores, permitindo o acompanhamento, consulta e baixa de pedidos de forma eficiente e pr�tica.

## �ndice

- [Tecnologias Utilizadas](#tecnologias-utilizadas)
- [Funcionalidades](#funcionalidades)
- [Arquitetura do Projeto](#arquitetura-do-projeto)
- [Uso](#uso)
- [Considera��es](#considera��es)
- [Licen�a](#licen�a)

## Tecnologias Utilizadas

- **.NET MAUI**: Framework utilizado para desenvolvimento cross-platform, permitindo a cria��o de aplicativos para iOS, Android e outros sistemas operacionais a partir de uma �nica base de c�digo. Entretanto escolhemos o foco total na aplica��o Android.
- **C#**: Linguagem principal do projeto, usada em conjunto com as melhores pr�ticas de programa��o.
- **MVVM (Model-View-ViewModel)**: Arquitetura adotada para separar l�gica de apresenta��o, dados e controle, facilitando a manuten��o e testabilidade.
- **ADO.NET**: Usado para conex�o com banco de dados SQL Server, permitindo a manipula��o de dados dos pedidos de forma direta e segura.
- **CommunityToolkit.Maui**: Biblioteca de componentes MAUI usada para aprimorar a interface do usu�rio, facilitar anima��es, exibir notifica��es (Toasts), entre outras funcionalidades.
- **Inje��o de Depend�ncia**: Utilizada para gerenciar depend�ncias de forma eficaz e garantir flexibilidade no c�digo.
- **Valida��es de Dados e Tratamento de Erros**: Aplicadas para garantir a seguran�a e integridade dos dados, al�m de melhorar a usabilidade.

## Funcionalidades

Leaf Mobile � focado nas opera��es de entrega, fornecendo ao entregador as ferramentas necess�rias para gerenciar os pedidos. Entre as principais funcionalidades, destacam-se:

- **Listagem de Pedidos**: O entregador pode visualizar todos os pedidos atribu�dos a ele, juntamente com os detalhes relevantes, como endere�o de entrega, cliente, n�mero do pedido e CEP.
- **Atualiza��o e Baixa de Pedidos**: Permite ao entregador atualizar o status do pedido para "baixado" ap�s a entrega, registrando o momento exato e o respons�vel pela atualiza��o.
- **Tratamento de Erros e Notifica��es**: Exibe mensagens de erro amig�veis e informativas em caso de falha na conex�o ou opera��o, garantindo uma experi�ncia de usu�rio robusta.
- **Refresh Pull-To-Refresh**: Permite ao usu�rio atualizar a lista de pedidos deslizando a tela para baixo, garantindo que sempre tenha a informa��o mais atualizada.
- **Modo Offline**: A aplica��o pode armazenar informa��es temporariamente para que, em caso de perda de conex�o, o entregador ainda possa acessar alguns dados.
- **Autentica��o de Usu�rio**: Controle de login para garantir que apenas usu�rios autorizados possam acessar a aplica��o.
  
## Arquitetura do Projeto

A arquitetura do Leaf Mobile foi planejada para garantir escalabilidade, facilidade de manuten��o e separa��o de responsabilidades. O projeto foi organizado seguindo o padr�o **MVVM** (Model-View-ViewModel), facilitando a liga��o entre a interface de usu�rio e os dados:

- **View**: Camada de interface do usu�rio, onde os componentes visuais (como telas e bot�es) s�o definidos. Todas as intera��es do usu�rio, como cliques e navega��o, s�o processadas nesta camada.
- **ViewModel**: Respons�vel por mediar as intera��es entre a `View` e o `Model`, gerenciando dados e comandos para interagir com a interface de forma reativa.
- **Model**: Representa as estruturas de dados principais, incluindo o pedido e seus itens, e define a l�gica de neg�cios.
- **Services (Servi�os)**: Cont�m l�gica de manipula��o de dados, incluindo conex�es com o banco de dados via ADO.NET e opera��es CRUD para sincronizar pedidos e dados de usu�rios.
  
### Estrutura Adicional

- **Inje��o de Depend�ncia**: As depend�ncias s�o gerenciadas e injetadas em tempo de execu��o, melhorando a modularidade e facilitando os testes.
- **Tratamento de Erros**: S�o aplicados tratamentos de erro espec�ficos para notificar o usu�rio de problemas na execu��o, principalmente para erros de conex�o.
- **Toast Notifications**: Mensagens pop-up utilizadas para informar o status de opera��es, como "Pedidos Atualizados" ou "Erro ao Atualizar Pedido", melhorando a usabilidade e o feedback imediato ao usu�rio.

## Conhecimentos e Conceitos Aplicados

Durante o desenvolvimento do Leaf Mobile, foram aplicados e aperfei�oados diversos conceitos e pr�ticas, como:

1. **MVVM em .NET MAUI**: A ado��o de MVVM com .NET MAUI permitiu o desenvolvimento modular, facilitando a reutiliza��o de componentes e a testabilidade do c�digo.
2. **Conex�o com SQL Server via ADO.NET**: Conhecimentos de ADO.NET foram aplicados para estabelecer uma conex�o direta e segura com o banco de dados, realizando opera��es de CRUD (Create, Read, Update, Delete) de forma eficiente.
3. **Inje��o de Depend�ncia**: Compreens�o e implementa��o da inje��o de depend�ncia para gerenciar servi�os como `PedidoServices`, `UsuarioServices` e `ProdutoServices`, melhorando a flexibilidade do c�digo.
4. **Tratamento e Manipula��o de Erros**: Utiliza��o de blocos de `try-catch` e feedback ao usu�rio para garantir que o aplicativo continue a funcionar de forma previs�vel mesmo em casos de erro.
5. **Anima��es e Usabilidade**: Uso da `CommunityToolkit.Maui` para aprimorar a experi�ncia do usu�rio, adicionando anima��es de feedback visual e toasts informativos.
6. **Design Responsivo e Interface Intuitiva**: Projeto da interface de usu�rio otimizado para dispositivos m�veis, proporcionando uma experi�ncia de navega��o intuitiva.

### Pr�-requisitos

- .NET SDK 6.0 ou superior.
- Visual Studio 2022 com suporte para .NET MAUI.
- SQL Server para o banco de dados.

## Uso

1. **Login**: O usu�rio deve fazer login com suas credenciais para acessar a aplica��o.
2. **Visualiza��o de Pedidos**: A tela inicial exibe a lista de pedidos designados ao entregador.
3. **Atualiza��o e Baixa de Pedido**: Ao clicar no pedido, o entregador pode visualizar os detalhes e, ao concluir a entrega, marcar o pedido como "baixado".
4. **Refresh da Lista de Pedidos**: Para garantir que os pedidos estejam atualizados, o usu�rio pode deslizar a tela para baixo para recarregar a lista.


## Considera��es

Leaf Mobile foi desenvolvido como uma solu��o pr�tica para o gerenciamento de entregas, fazendo parte de um sistema maior de gest�o distribu�da. Esta aplica��o � destinada a fins acad�micos e de aprendizado, com o objetivo de consolidar conhecimentos em desenvolvimento mobile, arquitetura MVVM e intera��o com bancos de dados.

---

Leaf Mobile � uma pe�a essencial do sistema Leaf, projetado para simular um ambiente de trabalho real e permitir a pr�tica de conceitos avan�ados em desenvolvimento mobile, integra��o com backend e pr�ticas modernas de arquitetura em software.