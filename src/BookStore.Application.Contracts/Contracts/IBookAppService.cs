using BookStore.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;

namespace BookStore.Contracts
{
    public interface IBookAppService : IApplicationService, IScopedDependency
    {
        Task AddBook(AddBookInputDto bookInfo);
        Task<List<BookOutputDto>> GetBooks();

    }
}
