using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Application.Services.Repositories
{
    public class ProductCommentRepository : EfRepositoryBase<ProductComment, ProjectDbContext>, IProductCommentRepository
    {
        public ProductCommentRepository(ProjectDbContext context) : base(context)
        {
        }
    }
}
