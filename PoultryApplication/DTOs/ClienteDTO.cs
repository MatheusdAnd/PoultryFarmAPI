using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PoultryApplication.DTOs
{
    public class ClienteDTO
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string nome { get; set; }

        [RegularExpression(@"^\d{11}$", ErrorMessage = "Telefone celular deve ter 11 dígitos numéricos")]
        public string tCelular { get; set; }

        [RegularExpression(@"^\d{10}$", ErrorMessage = "Telefone fixo deve ter 10 dígitos numéricos")]
        public string tFixo { get; set; }

        [Required]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "CPF deve ter 11 dígitos numéricos")]
        public string cpf { get; set; }
        public DateTime dtNascimento { get; set; }
    }
}