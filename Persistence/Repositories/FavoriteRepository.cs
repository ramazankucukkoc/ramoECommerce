using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class FavoriteRepository : EfRepositoryBase<Favorite, ProjectDbContext>, IFavoriteRepository
    {
        public FavoriteRepository(ProjectDbContext context) : base(context)
        {
        }
    }
}
