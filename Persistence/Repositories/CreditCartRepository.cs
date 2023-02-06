using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Application.Services.Repositories
{
    public class CreditCartRepository : EfRepositoryBase<CreditCart, ProjectDbContext>, ICreditCartRepository
    {
        public CreditCartRepository(ProjectDbContext context) : base(context)
        {
        }
    }
}
