using OrderManagement.Domain.Entities;

namespace OrderManagement.Application.Repositories
{
    public interface IOrderReadRepository
    {
        Task<OrderReadModel> GetOrderById(int id);
    }
}
