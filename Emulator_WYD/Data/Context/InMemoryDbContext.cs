using Microsoft.EntityFrameworkCore;

namespace Emulator_WYD.Data.Context
{
    public class InMemoryDbContext : EFDbContext
    {
        public InMemoryDbContext(DbContextOptions<InMemoryDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("Emulator_WYD");

            base.OnConfiguring(optionsBuilder);
        }
    }
}
