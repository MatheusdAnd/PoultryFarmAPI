using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PoultryDomain
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string nome { get; set; }

        [StringLength(11)]
        public string tCelular { get; set; }

        [StringLength(10)]
        public string tFixo { get; set; }

        [Required]
        [StringLength(11)]
        public string cpf { get; set; }
        public DateTime dtNascimento { get; set; }
        public ICollection<Endereco> Endereco { get; set; }
        public ICollection<Pedido> Pedido { get; set; }
    }
}