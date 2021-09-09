using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PoultryApplication.DTOs
{
    public class ItemPedidoDTO
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int quantidade { get; set; }

        [Required]
        public decimal valorUnitario { get; set; }

        public int ProdutoId { get; set; }
    }
}