using System;
using System.Linq;
using WebApi.DBOperations;

namespace WebApi.Application.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommand
    {
        public UpdateAuthorModel Model { get; set; }
        private readonly BookStoreDbContext _dbContext;
        public int AuthorId { get; set; }
        public UpdateAuthorCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Handle()
        {
            var author = _dbContext.Authors.SingleOrDefault(x => x.Id == AuthorId);
            if (author is null)
                throw new InvalidOperationException("Yazar Mevcut Değil");

            author.Name = Model.Name != default ? Model.Name : author.Name;
            author.Surname = Model.Surname != default ? Model.Surname : author.Surname;
            // book.PublishDate = Model.PublishDate != default ? Model.PublishDate : book.PublishDate;
            _dbContext.SaveChanges();
        }
        public class UpdateAuthorModel
        {
            public string Name { get; set; }
            public string Surname { get; set; }
            /////dışarıdan güncellenemesin
            // public DateTime BirthDate { get; set; }
        }
    }


}