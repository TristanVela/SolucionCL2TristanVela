using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CL2TristanVela.Database.AlumnosContext
{
    public class AlumnosContext :  DbContext
    {
        public DbSet<AlumnosEntity> Alumnos { get; set; }
        public DbSet<NotasEntity> Notas { get; set; }

        public AlumnosContext(DbContextOptions<AlumnosContext> option ) : base (option)
        {

        }

    }
}
