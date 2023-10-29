using System;
using System.ComponentModel.DataAnnotations;

namespace CL2TristanVela.Database
{
    public class AlumnosEntity
    {
        [Key ]
        public int IdAlumno { get; set; }
        public string NombreAlumno { get; set; }
        public string ApellidoAlumno { get; set; }
        public int DNI { get; set; }
        public DateTime FechaNamiento { get; set; }
    }
}
