using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace App_Cobranza.Models.ViewModels.Cliente
{
    public class BuscarVM
    {
        [Display(Name = "Nombre del Cliente")]
        public string busqueda { get; set; }

        [Display(Name = "ID del Cliente")]
        public string id { get; set; }

        public List<ClienteResultadoVM> Resultados { get; set; } = new List<ClienteResultadoVM>();
    }

    public class ClienteResultadoVM
    {
        public string id { get; set; } 
        public string nombre { get; set; }
        public string documento { get; set; }
    }
}