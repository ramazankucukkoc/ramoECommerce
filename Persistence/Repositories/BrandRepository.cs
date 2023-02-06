using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Application.Services.Repositories
{
    public class BrandRepository : EfRepositoryBase<Brand, ProjectDbContext> ,IBrandRepository
    {
        public BrandRepository(ProjectDbContext context) : base(context)
        {
        }
    }
}
