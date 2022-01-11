using System;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.Application.BookOperations.Queries.GetBookDetail
{
        public class GetBookDetailQuery
        {
                private readonly BookStoreDbContext _dbContext;
                private readonly IMapper _mapper;
                public int BookId { get; set; }
                public GetBookDetailQuery(BookStoreDbContext dbContext, IMapper mapper)
                {
                        _dbContext = dbContext;
                        _mapper = mapper;
                }
                public BookDetailViewModel Handle()
                {
                        var Book = _dbContext.Books.Include(x => x.Genre).Include(y => y.Author).Where(book => book.Id == BookId).SingleOrDefault();
                        if (Book is null)
                                throw new InvalidOperationException("Kitap Mevcut Değil");
                        BookDetailViewModel vm = _mapper.Map<BookDetailViewModel>(Book);
                        return vm;
                }
        }
        public class BookDetailViewModel
        {
                public string Title { get; set; }
                public string Author{get;set;}
                public string Genre { get; set; }
                public int PageCount { get; set; }
                public string PublishDate { get; set; }
        }

}