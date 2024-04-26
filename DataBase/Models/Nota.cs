using System;
using System.Collections.Generic;

namespace DataBase.Models
{
    public partial class Nota
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int? IdProfesor { get; set; }
        public int? IdEstudiante { get; set; }
        public double? Valor { get; set; }

        public virtual Estudiante IdEstudianteNavigation { get; set; }
        public virtual Profesor IdProfesorNavigation { get; set; }
    }
}
