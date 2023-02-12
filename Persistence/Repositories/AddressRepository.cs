using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class AddressRepository : EfRepositoryBase<Address, ProjectDbContext>, IAddressRepository
    {
        public AddressRepository(ProjectDbContext context) : base(context)
        {
        }
    }
}
