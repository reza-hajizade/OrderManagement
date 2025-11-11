using OrderManagement.Domain.Entities;

namespace OrderManagement.Application.Repositories
{
    public interface IOrderReadRepository
    {
        Task<OrderReadModel> GetOrderById(Guid id);
    }
}
