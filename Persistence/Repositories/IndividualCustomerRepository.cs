using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Application.Services.Repositories
{
    public class IndividualCustomerRepository : EfRepositoryBase<IndividualCustomer, ProjectDbContext>, IIndividualCustomerRepository
    {
        public IndividualCustomerRepository(ProjectDbContext context) : base(context)
        {
        }
    }
}
