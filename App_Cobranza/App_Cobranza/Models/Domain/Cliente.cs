using System.Collections.Generic;

namespace App_Cobranza.Models.Domain
{
    public class Cliente
    {
        public string id { get; set; }
        public string nombre { get; set; }
        public string documento { get; set; }
        public List<Producto> productos { get; set; } = new List<Producto>();
    }

    public class Producto
    {
        public string id { get; set; }
        public string nombre { get; set; }
        public decimal precioTotal { get; set; }
        public decimal? cantidadabonar { get; set; }
        public string plazodiferido { get; set; }
        public int pagoscompletados { get; set; }
        public decimal cantidadrestante { get; set; }
    }
}