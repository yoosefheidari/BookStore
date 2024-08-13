using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace BookStore.Data.Store
{
    public interface IStoreRepository : IBasicRepository<BookStore.Aggregates.Store.Store, int>, IScopedDependency
    {
        Task<List<BookStore.Aggregates.Store.Store>> GetStores();
        Task AddStore(BookStore.Aggregates.Store.Store store);
    }
}
