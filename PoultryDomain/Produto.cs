using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PoultryDomain
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string nome { get; set; }

        [Required]
        public decimal valor { get; set; }

        [StringLength(255)]
        public string descricao { get; set; }

        [Required]
        [StringLength(2)]
        public string unidadeMedida { get; set; }

        [Required]
        [StringLength(50)]
        public string categoria { get; set; }

        public ICollection<ItemPedido> ItemPedido { get; set; }
    }
}