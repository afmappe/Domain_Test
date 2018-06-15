using Cars.Library.Infrastructure.Data.Interfaces;

namespace Cars.Library.Domain.Cars.Repositories
{
    public interface ICarRepository :
        IAsyncRepository<CarInfo>
    {
    }
}