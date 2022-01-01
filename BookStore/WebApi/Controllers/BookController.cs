using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Linq;
using WebApi.DBOperations;
using WebApi.BookOperations.GetBooks;
using WebApi.BookOperations.CreateBook;
using static WebApi.BookOperations.CreateBook.CreateBookCommand;
using static WebApi.BookOperations.UpdateBook.UpdateBookCommand;
using WebApi.BookOperations.GetBookDetail;
using WebApi.BookOperations.UpdateBook;
using WebApi.BookOperations.DeleteBook;
using AutoMapper;

namespace WebApi.Controllers
{
        [ApiController]
        [Route("[controller]s")]
        public class BookController : ControllerBase
        {
                private readonly BookStoreDbContext _context;
                private readonly IMapper _mapper;

                public BookController(BookStoreDbContext context,IMapper mapper)
                {
                        _context = context;
                        _mapper = mapper;

                }

                [HttpGet]
                public IActionResult GetBooks()
                {
                        GetBooksQuery query = new GetBooksQuery(_context,_mapper);
                        var result = query.Handle();
                        return Ok(result);
                }
                [HttpGet("{id}")]
                public IActionResult GetById(int id)
                {
                        BookDetailViewModel result;
                        try
                        {
                                GetBookDetailQuery query = new GetBookDetailQuery(_context,_mapper);
                                query.BookId = id;
                                result = query.Handle();
                        }
                        catch (Exception ex)
                        {
                                return BadRequest(ex.Message);
                        }
                        return Ok(result);
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
                        CreateBookCommand command = new CreateBookCommand(_context,_mapper);
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
                public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel updatedBook)
                {
                        try
                        { 
                                UpdateBookCommand command = new UpdateBookCommand(_context);
                                command.BookId = id;
                                command.Model = updatedBook;
                                command.Handle();
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
                        try
                        { 
                                DeleteBookCommand command = new DeleteBookCommand(_context);
                                command.BookId = id;
                                command.Handle();
                        }
                        catch (Exception ex)
                        {
                                return BadRequest(ex.Message);
                        }
                        return Ok();
                }
        }

}