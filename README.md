# Poultry Farm API

## O que é?
A Poultry Farm API é uma API para gerenciamento de pedidos.

## O que faz?
Esta API é capaz de fazer operações CRUD de cliente, endereço, produto e pedido.

## Como usar?
Use as seguintes rotas para fazer as operações:

| Rota | HTTP | Descrição |
| --- | --- | --- |
| /api/cliente | Post | Incluir cliente |
| /api/cliente/{id} | Put | Atualizar cliente |
| /api/cliente/{id} | Delete | Excluir cliente |
| /api/cliente | Get | Consultar todos os clientes |
| /api/cliente/{id} | Get | Consultar cliente por id |
| /api/cliente/nome/{nome} | Get | Consultar cliente por nome |
| /api/cliente/cpf/{cpf} | Get | Consultar cliente por CPF |
| /api/endereco | Post | Incluir endereço |
| /api/endereco/{id} | Put | Atualizar endereço |
| /api/endereco/{id} | Delete | Excluir endereço |
| /api/endereco | Get | Consultar todos os endereços |
| /api/endereco/clienteid/{id} | Get | Consultar endereço pelo id do cliente |
| /api/endereco/enderecoid/{id} | Get | Consultar endereço pelo id do endereço |
| /api/produto | Post | Incluir produto |
| /api/produto/{id} | Put | Atualizar produto |
| /api/produto/{id} | Delete | Excluir produto |
| /api/produto | Get | Consultar todos os produtos |
| /api/produto/{id} | Get | Consultar produto por id |
| /api/produto/nome/{nome} | Get | Consultar produto por nome |
| /api/pedido | Post | Incluir pedido |
| /api/pedido | Get | Consultar todos os pedidos |
| /api/pedido/{id} | Get | Consultar pedido por id |
| /api/pedido/cliente/{id} | Get | Consultar pedido pelo id do cliente |
| /api/pedido/dtpedido/{dtpedido} | Get | Consultar pedido pelo id do endereço |

## Exemplos de objetos para inserção:

Cliente:
```
{
  "nome": "Ann",
  "tCelular": "99123456789",
  "cpf": "12345678900",
  "dtNascimento": "1999-12-16"
}
```
Endereço:
```
{
  "nome": "Casa",
  "cep": "12345678",
  "estado": "AA",
  "cidade": "Mineral Town",
  "logradouro": "Quadra 321 Rua 123",
  "numero": "25",
  "bairro": "Plaza",
  "clienteId": 1
}
```

Produto:
```
{
  "nome": "Milho para galinhas",
  "valor": 50,
  "descricao": "Alimenta uma galinha por um dia.",
  "unidadeMedida": "un",
  "categoria": "Ração",
}
```

Pedido:
```
{
  "valorTotal": 260,
  "dtPedido": "2021-09-09",
  "clienteId": 1
  "itemPedido": [
    {
      "quantidade":2,
      "valorUnitario": 50,
      "produtoId": 1
    },
   {
      "quantidade":2,
      "valorUnitario": 80,
      "produtoId": 2
    }
  ]
}
```
