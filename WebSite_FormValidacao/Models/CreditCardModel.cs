using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ValidateCreditCard.Models
{
    public class CreditCardModel
    {
        [Required(ErrorMessage = "O Nro de Cartão deve ser informado.!")]
        [StringLength(20, MinimumLength = 5)]
        public string Nro {get; set;}
        public string Resposta { get; set; }
    }
}