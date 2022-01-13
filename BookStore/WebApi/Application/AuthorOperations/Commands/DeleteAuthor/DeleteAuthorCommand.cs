using System;
using System.Linq;
using WebApi.DBOperations;

namespace WebApi.Application.AuthorOperations.Commands.DeleteAuthor
{
        public class DeleteAuthorCommand
        {
                private readonly IBookStoreDbContext _dbContext;
                public int AuthorId { get; set; }
                public DeleteAuthorCommand(IBookStoreDbContext dbContext)
                {
                        _dbContext = dbContext;
                }
                public void Handle()
                {
                        var author = _dbContext.Authors.SingleOrDefault(x => x.Id ==  AuthorId);
                        if (author is null)
                                throw new InvalidOperationException("Yazar Mevcut Değil");
                                
                        var isActiveBook = _dbContext.Books.SingleOrDefault(x => x.AuthorId == AuthorId);
                        if(isActiveBook is not null)
                                throw new InvalidOperationException("Yazarın Bir Kitabı mevcut");

                        _dbContext.Authors.Remove(author);
                        _dbContext.SaveChanges();

                }
        }


}
