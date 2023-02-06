using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Application.Services.Repositories
{
    public class BasketRepository : EfRepositoryBase<Basket, ProjectDbContext>, IBasketRepository
    {
        public BasketRepository(ProjectDbContext context) : base(context)
        {
        }
    }
}
