using System.Text.Json.Serialization;

namespace MinimalAPIEmpresa.Models
{
    public class EmpleadoDepartamento
    {
        public int EmpleadoId { get; set; }
        [JsonIgnore]
        public Empleado? Empleado { get; set; }

        public int DepartamentoId { get; set; }
        public Departamento Departamento { get; set; }
    }
}
