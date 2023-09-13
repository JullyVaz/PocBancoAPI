namespace PocBancoAPI.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
        Task SaveChangesAsync();
        Task RollBackAsync();
    }
}
