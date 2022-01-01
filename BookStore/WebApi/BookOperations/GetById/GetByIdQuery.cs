using System;
using System.Linq;
using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.BookOperations.GetByIdBook
{
        public class GetByIdQuery
        {
                private readonly BookStoreDbContext _dbContext;
                public GetByIdQuery(BookStoreDbContext dbContext)
                {
                        _dbContext = dbContext;
                }
                public BooksViewModel Handle(int id)
                {
                        var Book = _dbContext.Books.Where(book => book.Id == id).SingleOrDefault();
                        if (Book is null)
                                throw new InvalidOperationException("Kitap Mevcut Değil");
                        BooksViewModel vm = new BooksViewModel();
                        vm.Title = Book.Title;
                        vm.Genre = ((GenreEnum)Book.GenreId).ToString();
                        vm.PublishDate = Book.PublishDate.Date.ToString("dd/MM/yyyy");
                        vm.PageCount = Book.PageCount;
                        return vm;
                }

        }
        public class BooksViewModel
        {
                public string Title { get; set; }
                public string Genre { get; set; }
                public int PageCount { get; set; }
                public string PublishDate { get; set; }
        }

}