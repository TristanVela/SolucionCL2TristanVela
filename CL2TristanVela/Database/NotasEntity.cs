using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CL2TristanVela.Database
{
    public class NotasEntity
    {
        [Key]
        public int Codigo { get; set; }

        [ForeignKey("IdAlumno")]
        public AlumnosEntity Alumno { get; set; }
        public string NombreCurso { get; set; }
        public int Nota { get; set; }
    }
}
