using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Application.Services.Repositories
{
    public class InvoiceRepository : EfRepositoryBase<Invoice, ProjectDbContext>, IInvoiceRepository
    {
        public InvoiceRepository(ProjectDbContext context) : base(context)
        {
        }
    }
}
