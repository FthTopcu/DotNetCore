using AutoMapper;
using WebApi.BookOperations.GetBookDetail;
using WebApi.BookOperations.GetBooks;
using static WebApi.BookOperations.CreateBook.CreateBookCommand;

namespace WebApi.Common
{
        public class MappingProfile : Profile
        {
                public MappingProfile()
                {
                        CreateMap<CreateBookModel, Book>();
                        CreateMap<Book, BookDetailViewModel>().ForMember(destination => destination.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
                        CreateMap<Book, BooksViewModel>().ForMember(destination => destination.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
                }
        }
}