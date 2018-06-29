using Cars.Library.Infrastructure.Data.Interfaces;

namespace Cars.Library.Domain.Brands.Repositories
{
    public interface IBrandRepository
        : IAsyncRepository<BrandInfo>
    {
    }
}