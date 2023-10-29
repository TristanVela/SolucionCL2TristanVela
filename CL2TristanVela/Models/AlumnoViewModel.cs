using CL2TristanVela.Database;
using System;

namespace CL2TristanVela.Models
{
    public class AlumnoViewModel
    {
        public int IdAlumno { get; set; }
        public string NombreAlumno { get; set; }
        public string ApellidoAlumno { get; set; }
        public int DNI { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string NombreCurso { get; set; }
        public int Nota { get; set; } 
    }
}
