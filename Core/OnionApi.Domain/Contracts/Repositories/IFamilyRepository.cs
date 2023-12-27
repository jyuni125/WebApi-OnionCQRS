using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApi.Domain.Contracts.Repositories
{
    public interface IFamilyRepository<T> : IBaseRepository<T>
    {
        public Task Create(T t);

        public Task Update(T t);

        public Task Delete(Guid id);

        public Task<IEnumerable<T>> GetLastName(string Lastname);
    }
}
