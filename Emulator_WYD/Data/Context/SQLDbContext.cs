using Emulator_WYD.Helper;
using Microsoft.EntityFrameworkCore;

namespace Emulator_WYD.Data.Context
{
    public class SQLDbContext : EFDbContext
    {
        public SQLDbContext(DbContextOptions<SQLDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(AppSettingsHelper.GetConnectionString("SQLDbContext"));
                base.OnConfiguring(optionsBuilder);
            }
        }
    }
}
