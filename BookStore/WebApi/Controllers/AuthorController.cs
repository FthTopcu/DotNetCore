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
using WebApi.Application.AuthorOperations.Commands.DeleteAuthor;
using static WebApi.Application.AuthorOperations.Commands.UpdateAuthor.UpdateAuthorCommand;
using WebApi.Application.AuthorOperations.Commands.UpdateAuthor;

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

        //Put
        [HttpPut("{id}")]
        public IActionResult UpdateAuthor(int id, [FromBody] UpdateAuthorModel updatedAuthor)
        {
                UpdateAuthorCommand command = new UpdateAuthorCommand(_context);
                command.AuthorId = id;
                command.Model = updatedAuthor;

                UpdateAuthorCommandValidator validator = new UpdateAuthorCommandValidator();
                validator.ValidateAndThrow(command);
                command.Handle();

                return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAuthor(int id)
        {
                DeleteAuthorCommand command = new DeleteAuthorCommand(_context);
                command.AuthorId = id;
                DeleteAuthorCommandValidator validator = new DeleteAuthorCommandValidator();
                validator.ValidateAndThrow(command);
                command.Handle();

                return Ok();
        }
    }
}