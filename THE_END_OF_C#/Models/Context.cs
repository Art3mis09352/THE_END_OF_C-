using Microsoft.EntityFrameworkCore;

namespace THE_END_OF_C_.Models
{
    public class Context : DbContext
    {
        public DbSet<TGROUP> TGroup { get; set; }
        public DbSet<TRELATION> TRelation { get; set; }
        public DbSet<TPROPERTY> TPROPERTY { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
    }
}
