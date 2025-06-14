namespace App_Cobranza.Models.ViewModels.Cliente
{
    public class PerfilVM
    {
        public string idcliente { get; set; }
        public string nombrecliente { get; set; }
        public List<ProductoVM> productos { get; set; } = new List<ProductoVM>();
    }

    public class ProductoVM
    {
        public string id { get; set; }
        public string nombre { get; set; }
        public decimal preciototal { get; set; }
        public decimal cantidadabonar { get; set; }
        public string plazodiferido { get; set; }
        public int pagoscompletados { get; set; }
        public decimal cantidadrestante { get; set; }
    }
}