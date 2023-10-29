using CL2TristanVela.Database;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CL2TristanVela.Models
{
    public class NotasModel
    {
        public int Codigo { get; set; }
        public AlumnosEntity Alumno { get; set; }
        public string NombreCurso { get; set; }
        public int Nota { get; set; }
    }
}
