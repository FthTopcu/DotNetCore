using System;
using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.Application.BookOperations.Commands.CreateBook;
using WebApi.DBOperations;
using WebApi.Entities;
using Xunit;
using static WebApi.Application.BookOperations.Commands.CreateBook.CreateBookCommand;

namespace Application.BookOperations.Commands.CreateCommand
{
    public class CreateBookCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateBookCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }
        [Fact]
        public void WhenAlreadyExistBookTitleIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            //arrange (Hazırlık)
            var book = new Book() { Title = "WhenAlreadyExistBookTitleIsGiven_InvalidOperationException_ShouldBeReturn", PageCount = 100, PublishDate = new System.DateTime(1990, 01, 10), AuthorId = 2, GenreId = 1 };
            _context.Books.Add(book);
            _context.SaveChanges();

            CreateBookCommand command =  new CreateBookCommand(_context,_mapper);
            command.Model = new CreateBookModel(){Title = book.Title}; 
            
            //act & assert (Çalıştırma & doğrulama)
            FluentActions 
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap Zaten Mevcut.");


        }
    }
}