﻿using System;
using System.Collections.Generic;

namespace DataBase.Models
{
    public partial class Profesor
    {
        public Profesor()
        {
            Nota = new HashSet<Nota>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Nota> Nota { get; set; }
    }
}
