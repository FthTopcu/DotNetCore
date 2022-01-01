using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Linq;
using WebApi.DBOperations;
using WebApi.BookOperations.GetBooks;
using WebApi.BookOperations.CreateBook;
using static WebApi.BookOperations.CreateBook.CreateBookCommand;
using static WebApi.BookOperations.UpdateBook.UpdateBookQuery;
using WebApi.BookOperations.GetByIdBook;
using WebApi.BookOperations.UpdateBook;

namespace WebApi.Controllers
{
        [ApiController]
        [Route("[controller]s")]
        public class BookController : ControllerBase
        {
                private readonly BookStoreDbContext _context;

                public BookController(BookStoreDbContext context)
                {
                        _context = context;
                }

                [HttpGet]
                public IActionResult GetBooks()
                {
                        GetBooksQuery query = new GetBooksQuery(_context);
                        var result = query.Handle();
                        return Ok(result);
                }
                [HttpGet("{id}")]
                public IActionResult GetById(int id)
                {
                        GetByIdQuery query = new GetByIdQuery(_context);
                        try
                        {
                                var result = query.Handle(id);
                                return Ok(result);
                        }
                        catch (Exception ex)
                        {
                                return BadRequest(ex.Message);
                        }
                }
                // [HttpGet]
                // public Book Get([FromQuery]string id)
                // {
                //     var book = BookList.Where(book => book.Id == Convert.ToInt32(id)).SingleOrDefault();
                //     return book;
                // }

                //Post
                [HttpPost]
                public IActionResult AddBook([FromBody] CreateBookModel newBook)
                {
                        CreateBookCommand command = new CreateBookCommand(_context);
                        try
                        {
                                command.Model = newBook;
                                command.Handle();
                        }
                        catch (Exception ex)
                        {
                                return BadRequest(ex.Message);
                        }
                        return Ok();
                }

                //Put
                [HttpPut("{id}")]
                public IActionResult UpdateBook(int id, [FromBody] UpdateBooksModel updatedBook)
                {
                        UpdateBookQuery updateBookQuery = new UpdateBookQuery(_context);
                        try{
                                updateBookQuery.Model = updatedBook;
                                updateBookQuery.Handle(id);
                        }
                        catch (Exception ex)
                        {
                                return BadRequest(ex.Message);
                        }
                        return Ok();
                }

                [HttpDelete("{id}")]
                public IActionResult DeleteBook(int id)
                {
                        var book = _context.Books.SingleOrDefault(x => x.Id == id);
                        if (book is null)
                                return BadRequest();
                        _context.Books.Remove(book);
                        _context.SaveChanges();
                        return Ok();
                }
        }

}