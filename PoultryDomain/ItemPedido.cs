using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PoultryDomain
{
    public class ItemPedido
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int quantidade { get; set; }

        [Required]
        public decimal valorUnitario { get; set; }

        public int ProdutoId { get; set; }

        public Produto Produto { get; set; } 

        public int PedidoId { get; set; }

        public Pedido Pedido { get; set; } 
    }
}