# Festas Infantis

## Projeto

Desenvolvido durante o curso Fullstack da [Academia do Programador](https://www.academiadoprogramador.net) 2024

---
## Descrição

Rafaela possui um negócio de festas infantis. Ela precisa controlar os aluguéis e para isso ela precisa de uma aplicação que permita cadastrar clientes, temas, itens de festa e aluguéis.

## Funcionalidades

1. O cadastro do **Cliente** consiste de:
	- nome
	- telefone
	- cpf
	- aluguéis*

	1.1. Deve ser possível calcular um **desconto** para novos aluguéis a partir de alguéis concluidos.
	
 	1.2. Deverá ser possível visualizar os aluguéis relacionados a um cliente através de um botão na tela principal.

2. O cadastro do **Tema** consiste de:
	- nome
	- valor (total)
	- itens
	- aluguéis*

	2.1. Deve ser possível incluir vários itens em um tema, somando o valor total com base no valor de cada item.

3. O cadastro do **Item** consiste de:
	- descrição
	- valor
	- tema

	3.1. Não deve ser possível utilizar o mesmo item em temas diferentes.

4. O cadastro do **Aluguel** consiste de:
	- cliente
	- tema
	- porcentagem de entrada
	- porcentagem de desconto
	- data do pagamento (caso conclúido)
	- status
	- festa

	4.1. A porcentagem de entrada é obrigatória e deverá ser selecionada entre os valores 40% e 50%.
	

    4.2. O cadastro da **Festa** será realizado durante o aluguel e consiste de:
		- endereço
		- data
		- hora de início
		- hora de término
    
    4.3. Deverá ser possivel filtrar a tabela de aluguéis entre aluguéis pendentes e concluídos. 
	
    4.4. Deverá ser possível concluir um aluguel através de um botão na tela principal.

5. O **Controle de Desconto** consiste de:
	- porcentagem de desconto por aluguel
	- porcentagem máxima de desconto

	5.1. Para cada aluguel realizado por um cliente (a partir do primeiro), deverá ser calculado um valor de desconto.
	5.2. O valor deverá ser calculado pela fórmula: (quantidade de aluguéis do cliente * porcentagem de desconto).
	5.3. As porcentagens deverão ser configuradas à partir de um botão da tela principal.
---

## Requisitos

- .NET SDK (recomendado .NET 8.0 ou superior) para compilação e execução do projeto.
---
## Como Usar

#### Clone o Repositório
```
git clone https://github.com/academia-do-programador/festas-infantis-2024.git
```

#### Navegue até a pasta raiz da solução
```
cd festas-infantis-2024
```

#### Restaure as dependências
```
dotnet restore
```

#### Navegue até a pasta do projeto
```
cd FestasInfantis.WinApp
```

#### Execute o projeto
```
dotnet run
```
