using BookStore.Aggregates.Book;
using BookStore.Aggregates.Store;
using BookStore.Contracts;
using BookStore.Data.Book;
using BookStore.Data.Store;
using BookStore.Dtos;
using BookStore.Localization;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;

namespace BookStore.Implementations
{
    [RemoteService(IsEnabled = false)]
    public class BookAppService : ApplicationService, IBookAppService, IScopedDependency
    {
        private readonly IBookRepository _bookRepository;
        private readonly IStoreRepository _storeRepository;

        public BookAppService(IBookRepository bookRepository, IStoreRepository storeRepository)
        {
            _bookRepository = bookRepository;
            LocalizationResource = typeof(BookStoreResource);
            _storeRepository = storeRepository;
        }

        public async Task AddBook(AddBookInputDto bookInfo)
        {
            throw new NotImplementedException();
            // await _bookAppService.AddBook(bookInfo);
        }

        public async Task AddComment(AddCommentInputDto commentInfo)
        {
            throw new NotImplementedException();

            //  await _bookAppService.AddComment(commentInfo);

        }

        public async Task AddDislike(LikeInputDto likeInfo)
        {
            throw new NotImplementedException();

            // await _bookAppService.AddDislike(likeInfo);

        }

        public async Task AddLike(LikeInputDto likeInfo)
        {
            throw new NotImplementedException();

            //   await _bookAppService.AddLike(likeInfo);

        }

        public async Task<List<CommentOutputDto>> GetComments()
        {
            throw new NotImplementedException();

            // return await _bookAppService.GetComments();

        }

        public async Task<List<BookOutputDto>> GetStoreBooks()
        {
            var outputBooks = new List<BookOutputDto>();
            var books = await _bookRepository.GetBooks();
            foreach (var item in books)
            {
                var result = ObjectMapper.Map<Book, BookOutputDto>(item);
                outputBooks.Add(result);
            }
            return outputBooks;
        }

        public async Task<List<StoreOutputDto>> GetStores()
        {
            var outputBooks = new List<StoreOutputDto>();
            var books = await _storeRepository.GetStores();
            foreach (var item in books)
            {
                var result = ObjectMapper.Map<Store, StoreOutputDto>(item);
                outputBooks.Add(result);
            }
            return outputBooks;

            // return await _bookAppService.GetStores();
        }
    }
}
