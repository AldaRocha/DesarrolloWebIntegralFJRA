using System.Text.Json.Serialization;

namespace MinimalAPIEmpresa.Models
{
    public class Departamento
    {
        public int DepartamentoId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        [JsonIgnore]
        public ICollection<EmpleadoDepartamento>? EmpleadoDepartamentos { get; set; }
    }
}
