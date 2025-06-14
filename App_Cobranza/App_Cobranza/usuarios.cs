namespace App_Cobranza.Models
{
    public class usuarios
    {
        public int id_usuario { get; set; }

        public string? primer_nombre { get; set; }
        public string? segundo_nombre { get; set; }

        public string? apellido_paterno { get; set; }
        public string? apellido_materno { get; set; }

        public string? usuario { get; set; }
        public string? contrasena { get; set; } // ⚠️ Solo si llegas a usarlo, no recomendable mostrarlo

        public string? tipo_usuario { get; set; } // ⚠️ Cuida bien este nombre, tiene un error en la base de datos
    }
}