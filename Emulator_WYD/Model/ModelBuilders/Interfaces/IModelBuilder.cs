using Microsoft.EntityFrameworkCore;

namespace Emulator_WYD.Model.ModelBuilders.Interfaces
{
    public interface IModelBuilder
    {
        abstract void OnModelCreating(ModelBuilder modelBuilder);
    }
}
