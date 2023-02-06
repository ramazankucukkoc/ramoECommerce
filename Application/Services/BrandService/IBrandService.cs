using Domain.Entities;

namespace Application.Services.BrandService
{
    public interface IBrandService
    {
        Task<Brand> GetById(int id);

    }
}
