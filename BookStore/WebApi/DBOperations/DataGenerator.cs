using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApi;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WepAbi.DBOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if (context.Books.Any())
                    return;

                context.Genres.AddRange(
                    new Genre
                    {
                        Name = "Personel Growth"

                    },
                    new Genre
                    {
                        Name = "Science Fiction"

                    },
                    new Genre
                    {
                        Name = "Romance"

                    }
                );
                context.Authors.AddRange(
                    new Author
                    {
                        Name = "Eric",
                        Surname = "Ries",
                        BirthDate = new DateTime(1978, 09, 22)

                    },
                    new Author
                    {
                        Name = "Charlotte Perkins",
                        Surname = "Gilman",
                        BirthDate = new DateTime(1860, 08, 03)

                    },
                    new Author
                    {
                        Name = "Frank",
                        Surname = "Herbert",
                        BirthDate = new DateTime(1920, 10, 08)
                    }
                );
                context.Books.AddRange(
                    new Book
                    {
                        // Id = 1,
                        Title = "Lean Startup",
                        AuthorId = 1,
                        GenreId = 1,
                        PageCount = 200,
                        PublishDate = new DateTime(2001, 06, 12)
                    },
                    new Book
                    {
                        //Id = 2,
                        Title = "Herland",
                        AuthorId = 2,
                        GenreId = 2,
                        PageCount = 250,
                        PublishDate = new DateTime(2010, 06, 12)
                    },
                    new Book
                    {
                        //Id = 3,
                        Title = "Dune",
                        AuthorId = 3,
                        GenreId = 2,
                        PageCount = 540,
                        PublishDate = new DateTime(2002, 05, 23)
                    }
                );
                context.SaveChanges();
            }
        }
    }
}