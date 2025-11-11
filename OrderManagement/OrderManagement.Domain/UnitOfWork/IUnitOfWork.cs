namespace OrderManagement.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork
    {
        
        Task<int> SaveChangeAsync(CancellationToken cancellationToken);
        
    }
}
