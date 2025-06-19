using System.Text.Json.Serialization;

namespace MinimalAPIEmpresa.Models
{
    public class Ciudad
    {
        public int CiudadId { get; set; }
        public string Nombre { get; set; }

        [JsonIgnore]
        public ICollection<Empleado>? Empleados { get; set; }
    }
}
