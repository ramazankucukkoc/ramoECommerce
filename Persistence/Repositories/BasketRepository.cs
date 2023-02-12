using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class BasketRepository : EfRepositoryBase<Basket, ProjectDbContext>, IBasketRepository
    {
        public BasketRepository(ProjectDbContext context) : base(context)
        {
        }
    }
}
