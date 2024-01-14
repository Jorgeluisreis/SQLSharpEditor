
# SQLSharpEditor - Editor SQL feito em C#

O propósito deste projeto é basicamente usar mecânicas de interação com o Banco de dados, mais precisamente o SQL Server. Contribuições serão bem vindas para a melhoria do projeto e seus afins.

## Observações

O modelo de banco de dados está configurado para a seguinte questão:

º Estrutura de tabela contendo: Id, Nome e Idade, sendo:
Id: Chave primária e do tipo Int
Nome: tipo text
Idade: tipo int

## Introdução

**Login**

A primeira tela é o login do sistema, nada sincronizado com a internet ou algo do gênero, basta digitar em Username e Password seja **sql** em ambos os campos, diferente disso irá dar erro no login.
<p align="center">
  <img src="https://uploaddeimagens.com.br/images/004/711/804/original/imagem_2024-01-14_165704243.png?1705262229" alt="Estrutura do Banco de Dados">
</p>


**Leitor INI**

Após o login sucedido, ele irá abrir uma caixa de interação para você selecionar o arquivo INi que estárá os dados do banco de dados para fazer o login no mesmo, sendo eles:

**NOMEBASE: Nome do banco de dados** e **LOCALBASE: Endereço do banco de dados**.

Ambos devem estar na estrutura abaixo:

![Estrutura do INI](https://uploaddeimagens.com.br/images/004/711/795/original/imagem_2024-01-14_164531127.png?1705261540)

Caso seja seja selecionado um INI sem essa estrutura ou um arquivo que não será .INI, dará erro.

## Editor

A tela do editor você terá um campo de Query parecido com do SQL Server, onde você será a marcação de palavras reservadas do mesmo e terá um botão no canto superior direito indicando que já pode executar o query.

![Tela do Editor](https://uploaddeimagens.com.br/images/004/711/798/original/imagem_2024-01-14_165339884.png?1705262025)




