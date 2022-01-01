using System;
using System.Linq;
using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.BookOperations.GetBookDetail
{
        public class GetBookDetailQuery
        {
                private readonly BookStoreDbContext _dbContext;
                public int BookId { get; set; }
                public GetBookDetailQuery(BookStoreDbContext dbContext)
                {
                        _dbContext = dbContext;
                }
                public BooksDetailViewModel Handle()
                {
                        var Book = _dbContext.Books.Where(book => book.Id == BookId).SingleOrDefault();
                        if (Book is null)
                                throw new InvalidOperationException("Kitap Mevcut Değil");
                        BooksDetailViewModel vm = new BooksDetailViewModel();
                        vm.Title = Book.Title;
                        vm.Genre = ((GenreEnum)Book.GenreId).ToString();
                        vm.PublishDate = Book.PublishDate.Date.ToString("dd/MM/yyyy");
                        vm.PageCount = Book.PageCount;
                        return vm;
                }
        }
        public class BooksDetailViewModel
        {
                public string Title { get; set; }
                public string Genre { get; set; }
                public int PageCount { get; set; }
                public string PublishDate { get; set; }
        }

}