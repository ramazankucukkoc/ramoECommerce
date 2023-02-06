using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Application.Services.Repositories
{
    public class OrderDetailRepository : EfRepositoryBase<OrderDetail, ProjectDbContext>, IOrderDetailRepository
    {
        public OrderDetailRepository(ProjectDbContext context) : base(context)
        {
        }
    }
}
