using BookStore.Aggregates.Store;
using BookStore.Contracts;
using BookStore.Data.Store;
using BookStore.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.ChangeTracking;

namespace BookStore.Implementations
{
    [RemoteService(IsEnabled = false)]
    public class StoreAppService : ApplicationService, IStoreAppService
    {
        private readonly IStoreRepository _storeRepository;

        public StoreAppService(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }

        public async Task AddStore(AddStoreInputDto input)
        {
            var store = ObjectMapper.Map<AddStoreInputDto, Store>(input);
            store.SetCreationTime(DateTime.Now);
            await _storeRepository.AddStore(store);
        }

        [DisableEntityChangeTracking]
        public async Task<List<StoreOutputDto>> GetStores()
        {
            var stores = await _storeRepository.GetStores();
            return ObjectMapper.Map<List<Store>, List<StoreOutputDto>>(stores);
        }
    }
}
