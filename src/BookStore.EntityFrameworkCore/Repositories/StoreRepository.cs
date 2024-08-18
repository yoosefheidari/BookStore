using BookStore.Aggregates.Store;
using BookStore.Data.Store;
using BookStore.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Uow;

namespace BookStore.Repositories
{
    public class StoreRepository : EfCoreRepository<BookStoreDbContext, BookStore.Aggregates.Store.Store, StoreId>, IStoreRepository
    {
        private readonly ICurrentTenant _currentTenant;
        private readonly IUnitOfWork _unitOfWork;
        public StoreRepository(IDbContextProvider<BookStoreDbContext> dbContextProvider, ICurrentTenant currentTenant, IUnitOfWork unitOfWork) : base(dbContextProvider)
        {
            _currentTenant = currentTenant;
            _currentTenant.Change(new Guid("14FCFBF0-A85C-46EC-8940-5F587AAEC761"));
            _unitOfWork = unitOfWork;
        }

        public async Task AddStore(Aggregates.Store.Store store)
        {
            await DbContext.Stores.AddAsync(store);
            await _unitOfWork.SaveChangesAsync();
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
