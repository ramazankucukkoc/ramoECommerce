using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Application.Services.Repositories
{
    public class FavoriteRepository : EfRepositoryBase<Favorite, ProjectDbContext>, IFavoriteRepository
    {
        public FavoriteRepository(ProjectDbContext context) : base(context)
        {
        }
    }
}
