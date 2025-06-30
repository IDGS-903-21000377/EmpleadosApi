using System.Text.Json.Serialization;

namespace EmpleadosApi.Models
{
    public class Empleado
    {
        public int Id { get; set; }
        public string Nombre { get; set; } 
        public string Correo { get; set; }

        [JsonPropertyName("tel")]

        public string tel { get; set; }

        public string FechaNacimiento { get; set; } 

        public string sexo { get; set; }    


    }
}
