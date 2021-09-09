using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PoultryApplication.DTOs
{
    public class PedidoDTO
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public decimal valorTotal { get; set; }

        [Required]
        public DateTime dtPedido { get; set; }

        public int ClienteId { get; set; }
        
        public ICollection<ItemPedidoDTO> ItemPedido { get; set; }
    }
}