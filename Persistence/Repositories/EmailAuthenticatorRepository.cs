using Core.Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Application.Services.Repositories
{
    public class EmailAuthenticatorRepository : EfRepositoryBase<EmailAuthenticator, ProjectDbContext>,
                                            IEmailAuthenticatorRepository
    {
        public EmailAuthenticatorRepository(ProjectDbContext context) : base(context)
        {
        }
    }
}
