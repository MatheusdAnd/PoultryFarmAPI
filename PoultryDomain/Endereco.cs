
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PoultryDomain
{
    public class Endereco
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string nome { get; set; }

        [Required]
        [StringLength(8)]
        public string cep { get; set; }

        [Required]
        [StringLength(2)]
        public string estado { get; set; }

        [Required]
        [StringLength(30)]
        public string cidade { get; set; }

        [Required]
        [StringLength(200)]        
        public string logradouro { get; set; }

        [Required]
        [StringLength(11)]
        public string numero { get; set; }

        [StringLength(200)]
        public string complemento { get; set; }

        [StringLength(200)]
        public string referencia { get; set; }

        [Required]
        [StringLength(30)]
        public string bairro { get; set; }

        public int ClienteId { get; set; }

        public Cliente Cliente { get; set; }  
    }
}