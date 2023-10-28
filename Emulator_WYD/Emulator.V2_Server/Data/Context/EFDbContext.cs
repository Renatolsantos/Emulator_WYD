using Microsoft.EntityFrameworkCore;

namespace Emulator.V2_Host.Data.Context
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
