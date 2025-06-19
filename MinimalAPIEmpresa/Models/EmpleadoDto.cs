namespace MinimalAPIEmpresa.Models
{
    public class EmpleadoDto
    {
        public string Nombre { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string Puesto { get; set; }
        public double Sueldo { get; set; }
        public int CiudadId { get; set; }
        public List<int> DepartamentoIds { get; set; }
    }
}
