using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Application.Services.Repositories
{
    public class CityRepository : EfRepositoryBase<City, ProjectDbContext>, ICityRepository
    {
        public CityRepository(ProjectDbContext context) : base(context)
        {
        }
    }
}
