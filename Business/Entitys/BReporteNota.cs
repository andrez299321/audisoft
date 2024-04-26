using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Entitys
{
    public class BReporteNota
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string? Profesor { get; set; }
        public string? Estudiante { get; set; }
        public double? Valor { get; set; }
    }
}
