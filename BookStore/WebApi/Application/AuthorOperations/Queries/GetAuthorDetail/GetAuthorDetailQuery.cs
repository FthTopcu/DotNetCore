using System;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.Application.AuthorOperations.Queries.GetAuthorDetail
{
    public class GetAuthorDetailQuery
    {
        private readonly IBookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public int AuthorId { get; set; }
        public GetAuthorDetailQuery(IBookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public AuthorDetailViewModel Handle()
        {
            var Author = _dbContext.Authors.Where(author => author.Id == AuthorId).SingleOrDefault();
            if (Author is null)
                throw new InvalidOperationException("Yazar Mevcut Değil");
            AuthorDetailViewModel vm = _mapper.Map<AuthorDetailViewModel>(Author);
            return vm;
        }
    }
    public class AuthorDetailViewModel
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string BirthDate { get; set; }
    }

}