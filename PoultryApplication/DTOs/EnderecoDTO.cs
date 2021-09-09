using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PoultryApplication.DTOs
{
    public class EnderecoDTO
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(45)]
        public string nome { get; set; }

        [Required]
        [RegularExpression(@"^\d{8}$", ErrorMessage = "CEP deve ter 8 dígitos numéricos")]
        public string cep { get; set; }

        [Required]
        [StringLength(2)]
        [RegularExpression(@"[A-Z][A-Z]", ErrorMessage = "Estado deve ter 2 dígitos (A-Z)")]
        public string estado { get; set; }

        [Required]
        [StringLength(90)]
        public string cidade { get; set; }

        [Required]
        [StringLength(90)]
        public string logradouro { get; set; }

        [Required]
        [StringLength(10)]
        public string numero { get; set; }

        public string complemento { get; set; }

        public string referencia { get; set; }

        [Required]
        public string bairro { get; set; }
        
        [Required]
        public int ClienteId { get; set; } 
    }
}