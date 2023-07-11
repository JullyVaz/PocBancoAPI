using PocBancoAPI.Data.Context;

namespace PocBancoAPI.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appdbcontext;

        public UnitOfWork(AppDbContext appDbContext)
        {
            _appdbcontext = appDbContext;
        }

        public Task CommitAsync()
        {
            throw new NotImplementedException();
        }

        public Task RollBackAsync()
        {
            throw new NotImplementedException();
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}