using Microsoft.EntityFrameworkCore;

namespace ApiForENGLISH.Models
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options): base(options)
        {
            
        }

        public DbSet<Quetion> Quetions { get; set; }
        public DbSet<Participant> Participants { get; set; }
    }
}
