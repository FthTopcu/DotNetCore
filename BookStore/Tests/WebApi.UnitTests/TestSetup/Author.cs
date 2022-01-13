using System;
using WebApi.DBOperations;
using WebApi.Entities;

namespace TestSetup
{
    public static class Authors
    {
        public static void AddAuthors(this BookStoreDbContext context)
        {
            context.Authors.AddRange(
            new Author { Name = "Eric",Surname = "Ries",BirthDate = new DateTime(1978, 09, 22)},
            new Author { Name = "Charlotte Perkins",Surname = "Gilman",BirthDate = new DateTime(1860, 08, 03)},
            new Author { Name = "Frank",Surname = "Herbert",BirthDate = new DateTime(1920, 10, 08) }
            );
            
        }
    }
}