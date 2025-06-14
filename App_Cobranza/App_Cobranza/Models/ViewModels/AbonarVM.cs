using System;
using System.ComponentModel.DataAnnotations;

namespace App_Cobranza.Models.ViewModels.Pago
{
    public class AbonarVM
    {
        public string idcliente { get; set; }
        public string idfactura { get; set; }
        public string nombre { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal monto { get; set; }

        public DateTime FechaPago { get; set; } = DateTime.Now;

        [Required]
        public string metodopago { get; set; }

        public string observaciones { get; set; }
    }
}