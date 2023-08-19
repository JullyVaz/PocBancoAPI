namespace PocBancoAPI.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
        Task SaveChangesAsync();
        Task RollbackAscync();
        Task RollBackAsync();
    }
}
