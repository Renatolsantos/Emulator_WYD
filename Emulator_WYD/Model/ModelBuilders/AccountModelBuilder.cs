using Emulator_WYD.Model.Database;
using Emulator_WYD.Model.ModelBuilders.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Emulator_WYD.Model.ModelBuilders
{
    public class AccountModelBuilder : IModelBuilder
    {
        public void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(account =>
            {
                account.HasKey(x => x.Id);
                account.HasIndex(x => x.Id);

                account.HasIndex(a => a.UserName)
                       .IsUnique();
            });
        }
    }
}
