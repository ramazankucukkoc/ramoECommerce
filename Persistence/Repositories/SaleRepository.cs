using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Application.Services.Repositories
{
    public class SaleRepository : EfRepositoryBase<Sale, ProjectDbContext>, ISaleRepository
    {
        public SaleRepository(ProjectDbContext context) : base(context)
        {
        }
    }
}
