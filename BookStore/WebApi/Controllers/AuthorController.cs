using Microsoft.AspNetCore.Mvc;
using WebApi.DBOperations;
using AutoMapper;
using FluentValidation;
using WebApi.Application.BookOperations.Queries.GetBooks;
using WebApi.Application.BookOperations.Queries.GetBookDetail;
using WebApi.Application.BookOperations.Commands.CreateBook;
using WebApi.Application.BookOperations.Commands.UpdateBook;
using WebApi.Application.BookOperations.Commands.DeleteBook;
using static WebApi.Application.BookOperations.Commands.CreateBook.CreateBookCommand;
using static WebApi.Application.BookOperations.Commands.UpdateBook.UpdateBookCommand;
using WebApi.Application.AuthorOperations.Queries.GetAuthors;
using WebApi.Application.AuthorOperations.Queries.GetAuthorDetail;
using static WebApi.Application.AuthorOperations.Commands.CreateAuthor.CreateAuthorCommand;
using WebApi.Application.AuthorOperations.Commands.CreateAuthor;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class AuthorController : ControllerBase
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public AuthorController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAuthors()
        {
            GetAuthorsQuery query = new GetAuthorsQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
                AuthorDetailViewModel result;

                GetAuthorDetailQuery query = new GetAuthorDetailQuery(_context, _mapper);
                query.AuthorId = id;
                GetAuthorDetailQueryValidator validator = new GetAuthorDetailQueryValidator();
                validator.ValidateAndThrow(query);
                result = query.Handle();

                return Ok(result);
        }
        // // [HttpGet]
        // // public Book Get([FromQuery]string id)
        // // {
        // //     var book = BookList.Where(book => book.Id == Convert.ToInt32(id)).SingleOrDefault();
        // //     return book;
        // // }

        //Post
        [HttpPost]
        public IActionResult AddAuthor([FromBody] CreateAuthorModel newAuthor)
        {
                CreateAuthorCommand command = new CreateAuthorCommand(_context, _mapper);
                command.Model = newAuthor;
                CreateAuthorCommandValidator validator = new CreateAuthorCommandValidator();
                validator.ValidateAndThrow(command);//valide et hatayı fırlat
                command.Handle();

                return Ok();
        }

        // //Put
        // [HttpPut("{id}")]
        // public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel updatedBook)
        // {
        //         UpdateBookCommand command = new UpdateBookCommand(_context);
        //         command.BookId = id;
        //         command.Model = updatedBook;

        //         UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
        //         validator.ValidateAndThrow(command);
        //         command.Handle();

        //         return Ok();
        // }

        // [HttpDelete("{id}")]
        // public IActionResult DeleteBook(int id)
        // {
        //         DeleteBookCommand command = new DeleteBookCommand(_context);
        //         command.BookId = id;
        //         DeleteBookCommandValidator validator = new DeleteBookCommandValidator();
        //         validator.ValidateAndThrow(command);
        //         command.Handle();

        //         return Ok();
        // }
    }
}