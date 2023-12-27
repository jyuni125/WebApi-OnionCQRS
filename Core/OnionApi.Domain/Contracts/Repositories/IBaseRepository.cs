using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApi.Domain.Contracts.Repositories
{
    public interface IBaseRepository<T>
    {
        Task<T> GetOne(Guid id);

        Task<IEnumerable<T>> GetAll();
    }
}
