using AutoMapper;
using WebApi.Application.AuthorOperations.Queries.GetAuthors;
using WebApi.Application.AuthorOperations.Queries.GetAuthorDetail;
using WebApi.Application.BookOperations.Queries.GetBookDetail;
using WebApi.Application.BookOperations.Queries.GetBooks;
using WebApi.Application.GenreOperations.Queries.GetGenreDetail;
using WebApi.Application.GenreOperations.Queries.GetGenres;
using WebApi.Entities;
using static WebApi.Application.BookOperations.Commands.CreateBook.CreateBookCommand;
using static WebApi.Application.AuthorOperations.Commands.CreateAuthor.CreateAuthorCommand;

namespace WebApi.Common
{
        public class MappingProfile : Profile
        {
                public MappingProfile()
                {
                        CreateMap<CreateBookModel, Book>();
                        CreateMap<Book, BookDetailViewModel>().ForMember(destination => destination.Genre, opt => opt.MapFrom(src => src.Genre.Name)).ForMember(yazar => yazar.Author, opt => opt.MapFrom(src => src.Author.Name+" "+src.Author.Surname));
                        CreateMap<Book, BooksViewModel>().ForMember(destination => destination.Genre, opt => opt.MapFrom(src => src.Genre.Name)).ForMember(yazar => yazar.Author, opt => opt.MapFrom(src => src.Author.Name+" "+src.Author.Surname));
                        
                        CreateMap<Genre,GenresViewModel>();
                        CreateMap<Genre,GenreDetailViewModel>();
                        CreateMap<CreateAuthorModel,Author>();
                        CreateMap<Author,AuthorsViewModel>();
                        CreateMap<Author,AuthorDetailViewModel>();
                }
        }
}