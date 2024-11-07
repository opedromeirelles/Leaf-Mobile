# Leaf Mobile

**Leaf Mobile** é uma aplicação de gerenciamento de entregas, parte do sistema de gestão distribuído **Leaf**, desenvolvido com foco em produtividade, eficiência e usabilidade. Esta aplicação é projetada especificamente para dispositivos móveis, destinada a facilitar o trabalho dos entregadores, permitindo o acompanhamento, consulta e baixa de pedidos de forma eficiente e prática.

## Índice

- [Tecnologias Utilizadas](#tecnologias-utilizadas)
- [Funcionalidades](#funcionalidades)
- [Arquitetura do Projeto](#arquitetura-do-projeto)
- [Conhecimentos e Conceitos Aplicados](#conhecimentos-e-conceitos-aplicados)
- [Considerações](#considerações)

## Tecnologias Utilizadas

- **.NET MAUI**: Framework utilizado para desenvolvimento cross-platform, permitindo a criação de aplicativos para iOS, Android e outros sistemas operacionais a partir de uma única base de código. O foco principal desta aplicação é em dispositivos Android.
- **C#**: Linguagem principal do projeto, usada em conjunto com as melhores práticas de programação.
- **MVVM (Model-View-ViewModel)**: Arquitetura adotada para separar lógica de apresentação, dados e controle, facilitando a manutenção e testabilidade.
- **ADO.NET**: Utilizado para conexão com banco de dados SQL Server, permitindo a manipulação de dados dos pedidos de forma direta e segura.
- **CommunityToolkit.Maui**: Biblioteca que aprimora a interface do usuário, permitindo animações, notificações (Toasts) e outros elementos interativos.
- **Injeção de Dependência**: Utilizada para gerenciar dependências de forma eficaz e garantir flexibilidade no código.
- **Validações de Dados e Tratamento de Erros**: Implementadas para garantir a segurança e integridade dos dados, além de melhorar a usabilidade.

## Funcionalidades

**Leaf Mobile** é focado nas operações de entrega, fornecendo ao entregador as ferramentas necessárias para gerenciar os pedidos. Entre as principais funcionalidades, destacam-se:

- **Listagem de Pedidos**: O entregador pode visualizar todos os pedidos atribuídos a ele, juntamente com detalhes importantes como endereço de entrega e informações do cliente.
- **Atualização e Baixa de Pedidos**: Permite ao entregador atualizar o status de um pedido para "baixado" após a entrega, registrando a conclusão.
- **Notificações e Tratamento de Erros**: Exibe mensagens de erro amigáveis e informativas em caso de falha, garantindo uma experiência de usuário robusta.
- **Pull-To-Refresh**: Atualiza a lista de pedidos ao deslizar a tela para baixo.
- **Modo Offline**: Armazena informações temporariamente para permitir o acesso aos dados mesmo sem conexão.
- **Autenticação de Usuário**: Controle de acesso para garantir a segurança e privacidade das informações.

## Arquitetura do Projeto

A arquitetura do **Leaf Mobile** foi planejada para garantir escalabilidade, facilidade de manutenção e separação de responsabilidades. O padrão **MVVM** (Model-View-ViewModel) foi adotado para garantir a organização entre a interface de usuário e a lógica de negócios:

- **View**: Camada que contém os elementos de interface e define as interações do usuário.
- **ViewModel**: Media as interações entre a View e o Model, gerenciando dados e comandos de forma reativa.
- **Model**: Estruturas de dados e lógica de negócios.
- **Services (Serviços)**: Contém a lógica de manipulação de dados e conexão com o banco de dados via ADO.NET.

### Estrutura Adicional

- **Injeção de Dependência**: Implementada para gerenciar serviços de forma modular e facilitada.
- **Tratamento de Erros**: Aplicado para notificar o usuário sobre problemas e manter a continuidade das operações.
- **Toast Notifications**: Utilizadas para informar rapidamente o status de operações, como atualizações de pedidos.

## Conhecimentos e Conceitos Aplicados

- **MVVM em .NET MAUI**: Desenvolvimento modular com reuso de componentes e facilitação na testabilidade.
- **Conexão com SQL Server via ADO.NET**: Operações de CRUD eficientes e seguras.
- **Injeção de Dependência**: Implementação para modularidade e facilidade de teste.
- **Tratamento de Erros**: Blocos `try-catch` com mensagens informativas para o usuário.
- **Animações e Usabilidade**: Uso de `CommunityToolkit.Maui` para feedback visual e mensagens rápidas.

## Considerações

**Leaf Mobile** é uma parte fundamental do sistema **Leaf**, focada na logística de entrega e otimizada para dispositivos móveis. Este projeto foi desenvolvido com fins acadêmicos e de aprendizado, permitindo a aplicação prática de conceitos de desenvolvimento mobile, arquitetura **MVVM** e interação com bancos de dados.

---

Veja outras partes que complementam este projeto:

- [Leaf Web - Gerenciamento de cadastros e lançamentos de compras](https://github.com/opedromeirelles/Leaf-Web)
- [Leaf Desktop - Gerenciamento de vendas e produção de produtos](https://github.com/opedromeirelles/Leaf-WinForms)
