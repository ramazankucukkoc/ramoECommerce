using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Application.Services.Repositories
{
    public class AddressRepository : EfRepositoryBase<Address, ProjectDbContext>, IAddressRepository
    {
        public AddressRepository(ProjectDbContext context) : base(context)
        {
        }
    }
}
