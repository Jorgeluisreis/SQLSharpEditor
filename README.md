
# SQLSharpEditor - Editor SQL feito em C#

O propósito deste projeto é basicamente usar mecânicas de interação com o Banco de dados, mais precisamente o SQL Server. Contribuições serão bem vindas para a melhoria do projeto e seus afins.

## Observações

O modelo de banco de dados está configurado para a seguinte questão:

Caso queira testar/usar este projeto, terá que criar uma tabela com as seguintes descrições abaixo:
Id: Chave primária e do tipo Int
Nome: tipo text
Idade: tipo int
<p align="center">
  <img src="https://uploaddeimagens.com.br/images/004/711/804/original/imagem_2024-01-14_165704243.png?1705262229" alt="Estrutura do Banco de Dados">
</p>
A idéia é que futuramente ele possa ser adaptado para qualquer estrutura de banco de dados, seja ele com chave ou sem chave, lendo diretamente os dados d0 banco de dados (Colunas e afins) e se adaptando ao mesmo.


## Introdução

**Login**

A primeira tela é o login do sistema, nada sincronizado com a internet ou algo do gênero, basta digitar em Username e Password seja **sql** em ambos os campos, diferente disso irá dar erro no login.

**Leitor INI**

Após o login sucedido, ele irá abrir uma caixa de interação para você selecionar o arquivo INi que estárá os dados do banco de dados para fazer o login no mesmo, sendo eles:

**NOMEBASE: Nome do banco de dados** e **LOCALBASE: Endereço do banco de dados**.

Ambos devem estar na estrutura abaixo:

![Estrutura do INI](https://uploaddeimagens.com.br/images/004/711/795/original/imagem_2024-01-14_164531127.png?1705261540)

Caso seja seja selecionado um INI sem essa estrutura ou um arquivo que não será .INI, dará erro.

## Editor

A tela do editor você terá um campo de Query parecido com do SQL Server, onde você será a marcação de palavras reservadas do mesmo e terá um botão no canto superior direito indicando que já pode executar o query.
<p align="center">
  <img src="https://uploaddeimagens.com.br/images/004/711/798/original/imagem_2024-01-14_165339884.png?1705262025" alt="Tela do Editor">
</p>
Caso você faça alguma alteração em alguma célula (precisa sair do modo edição da célula para salvar a edição), o botão de salvar (ícone de disquete preto) irá aparecer no canto superior direito da tela para estar atribuindo ao banco de dados.

## Metas
Como citado acima, a idéia é que com o tempo ele passe a ser usado em qualquer tipo de banco de dados SQL Server, não necessáriamente preso no modelo atual (Id, Nome e Idade), você está mais do que convidade para contrubuir com o projeto.



