using Cars.Library.Infrastructure.Data.Interfaces;
using System.Threading.Tasks;

namespace Cars.Library.Domain.Cars.Repositories
{
    public interface ICarRepository :
        IAsyncRepository<CarInfo>
    {
        Task<CarInfo> Get(string license);
    }
}