using Emulator_WYD.Model.Database;
using Emulator_WYD.Model.ModelBuilders;
using Microsoft.EntityFrameworkCore;

namespace Emulator_WYD.Data.Context
{
    public class EFDbContext : DbContext
    {
        public EFDbContext(DbContextOptions<EFDbContext> options) : base(options)
        {
        }

        protected EFDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new AccountModelBuilder().OnModelCreating(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }
    }
}
