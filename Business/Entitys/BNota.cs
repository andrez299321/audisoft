using System;
using System.Collections.Generic;

namespace Business.Entitys
{
    public class BNota
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int? IdProfesor { get; set; }
        public int? IdEstudiante { get; set; }
        public double? Valor { get; set; }

    }
}
