using BookStore.Aggregates.Store;
using BookStore.Data.Store;
using BookStore.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace BookStore.Repositories
{
    public class StoreRepository : EfCoreRepository<BookStoreDbContext, BookStore.Aggregates.Store.Store, StoreId>, IStoreRepository
    {
        public StoreRepository(IDbContextProvider<BookStoreDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task AddStore(Aggregates.Store.Store store)
        {
            await DbContext.Stores.AddAsync(store);
        }

        public async Task<List<Aggregates.Store.Store>> GetStores()
        {
            try
            {

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
