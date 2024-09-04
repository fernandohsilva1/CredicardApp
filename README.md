# Sistema de Transações de Cartão de Crédito
Este projeto é um pequeno sistema de transações de cartão de crédito que permite ao usuário criar, capturar e cancelar transações através de uma interface. A aplicação interage com o Gateway de pagamentos Cielo utilizando o sandbox disponibilizado gratuitamente.

## Tecnologias Utilizadas
- C#
- ASP.NET Core
- Blazor (Server-side)
- REST API
- Gateway de Pagamentos Cielo

## Funcionalidades
- Criação de Transações: O usuário pode criar uma transação de cartão de crédito informando os dados necessários (número do cartão, bandeira, valor, CVC, etc.).
- Captura de Transações: O usuário pode capturar uma transação previamente criada.
- Cancelamento de Transações: O usuário pode cancelar uma transação existente, total ou parcialmente.
- Validação de Cartões: A aplicação valida os dados do cartão de crédito (número, bandeira e CVC) antes de criar uma transação. Apenas cartões das bandeiras Visa e Mastercard são aceitos.
  
## Requisitos
- .NET SDK 6.0 ou superior
- Visual Studio Code ou Visual Studio
- Conta de sandbox na Cielo.

## Regras de Negócio
- Cartões Aceitos: Visa e Mastercard.
- Visa: Número do cartão deve começar com 4, ter 13 ou 16 dígitos e CVC com 3 dígitos.
- Mastercard: Número do cartão deve começar com 5, ter 16 dígitos e CVC com 3 dígitos.

## Configuração do Projeto
- git clone https://github.com/fernandohsilva1/CredicardApp.git

## Configuração da API da Cielo
- Acesse o site da Cielo e crie uma conta no sandbox.
- Substitua os valores de MerchantId e MerchantKey no arquivo CieloService.cs pelos dados fornecidos pela Cielo.

##  Executando a Aplicação
- Certifique-se de que você possui o .NET SDK instalado.
- No diretório raiz do projeto, execute: dotnet build e dotnet run, o diretório abrirá em https://localhost:7242/

## Endpoints da API
1. Criar Transação: POST /api/Transaction/create
2. Capturar Transação: PUT /api/Transaction/capture/{transactionId}
3. Cancelar Transação: PUT /api/Transaction/cancel/{transactionId}

## Executando o Frontend
- O frontend é construído usando Blazor Server-side.
- Para rodar o frontend, execute o comando dotnet run no terminal do diretório raiz.
