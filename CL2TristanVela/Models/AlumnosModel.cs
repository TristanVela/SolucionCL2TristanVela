using System.ComponentModel.DataAnnotations;
using System;

namespace CL2TristanVela.Models
{
    public class AlumnosModel
    {
        public int IdAlumno { get; set; }
        public string NombreAlumno { get; set; }
        public string ApellidoAlumno { get; set; }
        public int DNI { get; set; }
        public DateTime FechaNamiento { get; set; }
    }
}
