using Microsoft.EntityFrameworkCore;

namespace Emulator_WYD.Data.Context
{
    public class EFDbContext : DbContext
    {
        public EFDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
