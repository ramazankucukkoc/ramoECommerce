using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class InvoiceRepository : EfRepositoryBase<Invoice, ProjectDbContext>, IInvoiceRepository
    {
        public InvoiceRepository(ProjectDbContext context) : base(context)
        {
        }
    }
}
