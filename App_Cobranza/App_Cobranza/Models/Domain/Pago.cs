using System;

namespace App_Cobranza.Models.Domain
{
    public class Pago
    {
        public string idtransaccion { get; set; }
        public DateTime fecha { get; set; } = DateTime.Now;
        public decimal monto { get; set; }
        public string metodopago { get; set; }
        public string estado { get; set; } = "Completado";
        public string facturarelacionada { get; set; }
        public string clienteid { get; set; } // Relación con cliente
    }
}