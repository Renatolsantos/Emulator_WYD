using Emulator_WYD.Data.Context;
using Emulator_WYD.Data.Repository.Interfaces;
using Emulator_WYD.Logger;
using Emulator_WYD.Model.Database;
using Emulator_WYD.Startup;
using Microsoft.EntityFrameworkCore;

namespace Emulator_WYD.Data.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly SQLDbContext _sqlContext;

        public AccountRepository()
        {
            _sqlContext = new SQLDbContext(new DbContextOptions<SQLDbContext>());
        }

        /// <summary>
        /// Create a <see cref="Account"/> entity in the database.
        /// </summary>
        /// <param name="account">The entity</param>
        /// <returns>The created entity id.</returns>
        public int Create(Account account)
        {
            try
            {
                account.CreatedBy = 1;
                account.UpdatedBy = 1;
                account.CreatedIn = Game.Time;
                account.UpdatedIn = Game.Time;

                var entity = _sqlContext.Accounts.Add(account);
                _ = _sqlContext.SaveChanges();

                return entity.Entity.Id;
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return 0;
            }
        }

        /// <summary>
        /// Get the <see cref="Account"/> by user name.
        /// </summary>
        /// <param name="userName">The user name.</param>
        /// <returns>The <see cref="Account"/> entity or null if not found.</returns>
        public Account? GetByUserName(string userName)
        {
            try
            {
                return _sqlContext.Accounts.SingleOrDefault(a => a.UserName.Equals(userName));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return null;
            }
        }
    }
}
