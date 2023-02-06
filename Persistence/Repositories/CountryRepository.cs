using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Application.Services.Repositories
{
    public class CountryRepository : EfRepositoryBase<Country, ProjectDbContext>, ICountryRepository
    {
        public CountryRepository(ProjectDbContext context) : base(context)
        {
        }
    }
}
