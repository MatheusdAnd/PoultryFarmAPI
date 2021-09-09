using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PoultryDomain
{
    public class Pedido
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public decimal valorTotal { get; set; }

        [Required]
        public DateTime dtPedido { get; set; }

        public int ClienteId { get; set; }

        public Cliente Cliente { get; set; } 
        
        public ICollection<ItemPedido> ItemPedido { get; set; }
    }
}