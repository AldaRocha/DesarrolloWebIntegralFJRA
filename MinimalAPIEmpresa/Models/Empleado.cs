﻿namespace MinimalAPIEmpresa.Models
{
    public class Empleado
    {
        public int EmpleadoId { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string Puesto { get; set; }
        public double Sueldo { get; set; }

        public int CiudadId { get; set; }
        public Ciudad Ciudad { get; set; }

        public ICollection<EmpleadoDepartamento> EmpleadoDepartamentos { get; set; }
    }
}
