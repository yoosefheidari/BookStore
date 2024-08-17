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
using Volo.Abp.Uow;

namespace BookStore.Repositories
{
    public class BookRepository : EfCoreRepository<BookStoreDbContext, Aggregates.Book.Book, BookId>, IBookRepository
    {
        private readonly ICurrentTenant _currentTenant;
        private readonly IUnitOfWork _unitOfWork;
        public BookRepository(IDbContextProvider<BookStoreDbContext> dbContextProvider, ICurrentTenant currentTenant, IUnitOfWork unitOfWork) : base(dbContextProvider)
        {
            _currentTenant = currentTenant;
            _currentTenant.Change(new Guid("14FCFBF0-A85C-46EC-8940-5F587AAEC761"));
            _unitOfWork = unitOfWork;
        }

        public async Task AddBook(Aggregates.Book.Book book)
        {
            var t = await DbContext.Books.AddAsync(book);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<List<Aggregates.Book.Book>> GetBooks()
        {

            try
            {
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
