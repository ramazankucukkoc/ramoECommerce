using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Application.Services.Repositories
{
    public class PersonelRepository : EfRepositoryBase<Personel, ProjectDbContext>, IPersonelRepository
    {
        public PersonelRepository(ProjectDbContext context) : base(context)
        {
        }
    }
}
