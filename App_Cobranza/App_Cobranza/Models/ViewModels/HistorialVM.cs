using System;

namespace App_Cobranza.Models.ViewModels.Pago
{
    public class HistorialVM
    {
        public string idtransaccion { get; set; }
        public DateTime fecha { get; set; }
        public decimal monto { get; set; }
        public string metodopago { get; set; }
        public string estado { get; set; }
        public string facturarelacionada { get; set; }
    }
}