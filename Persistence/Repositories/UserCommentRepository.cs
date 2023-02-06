using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Application.Services.Repositories
{
    public class UserCommentRepository : EfRepositoryBase<UserComment, ProjectDbContext>, IUserCommentRepository
    {
        public UserCommentRepository(ProjectDbContext context) : base(context)
        {
        }
    }
}
