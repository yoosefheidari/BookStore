using BookStore.Data.Book;
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
    public class BookRepository : EfCoreRepository<BookStoreDbContext, Aggregates.Book.Book, int>, IBookRepository
    {
        private readonly ICurrentTenant _currentTenant;
        public BookRepository(IDbContextProvider<BookStoreDbContext> dbContextProvider, ICurrentTenant currentTenant) : base(dbContextProvider)
        {
            _currentTenant = currentTenant;
        }

        public Task AddBook(Aggregates.Book.Book book)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Aggregates.Book.Book>> GetBooks()
        {
            try
            {
                // var book = new Aggregates.Book.Book(new BookId(5));

                _currentTenant.Change(new Guid("14fcfbf0-a85c-46ec-8940-5f587aaec761"));
                return await DbContext.Books.ToListAsync();
            }
            catch (Exception ex)
            {
                return new List<Aggregates.Book.Book>();
            }

        }
    }
}
