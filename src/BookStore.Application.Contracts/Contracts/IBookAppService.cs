using Abp.Application.Services.Dto;
using BookStore.Dtos;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace BookStore.Contracts
{
    public interface IBookAppService : IApplicationService
    {
        Task AddBook(AddBookInputDto bookInfo);
        Task<PagedResultDto<BookOutputDto>> GetBooks(PagedResultRequestDto requestDto);

    }
}
