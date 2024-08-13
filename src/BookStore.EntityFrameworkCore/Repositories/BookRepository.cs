using BookStore.Aggregates.Book;
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
    public class BookRepository : EfCoreRepository<BookStoreDbContext, Aggregates.Book.Book, BookId>, IBookRepository
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
                _currentTenant.Change(new Guid("14FCFBF0-A85C-46EC-8940-5F587AAEC761"));
                var t = await DbContext.Books.ToListAsync();
                return t;
            }
            catch (Exception ex)
            {
                return new List<Book>();
            }
        }
    }
}
