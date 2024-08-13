using BookStore.Data.Store;
using BookStore.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.MultiTenancy;

namespace BookStore.Repositories
{
    public class StoreRepository : EfCoreRepository<BookStoreDbContext, BookStore.Aggregates.Store.Store, int>, IStoreRepository
    {
        private readonly ICurrentTenant _currentTenant;
        public StoreRepository(IDbContextProvider<BookStoreDbContext> dbContextProvider, ICurrentTenant currentTenant) : base(dbContextProvider)
        {
            _currentTenant = currentTenant;
        }

        public Task AddStore(Aggregates.Store.Store store)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Aggregates.Store.Store>> GetStores()
        {
            try
            {
                _currentTenant.Change(new Guid("14fcfbf0-a85c-46ec-8940-5f587aaec761"));
                var t = await DbContext.Stores.ToListAsync();
                return t;
            }
            catch (Exception ex)
            {
                return new List<Aggregates.Store.Store>();
            }
        }
    }
}
