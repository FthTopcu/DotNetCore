using System.Collections.Generic;
using System;
using System.Linq;
using WebApi.Common;
using WebApi.DBOperations;
using AutoMapper;
using WebApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Application.AuthorOperations.Queries.GetAuthors
{
        public class GetAuthorsQuery
        {
                private readonly IBookStoreDbContext _dbContext;
                private readonly IMapper _mapper;
                public GetAuthorsQuery(IBookStoreDbContext dbContext, IMapper mapper)
                {
                        _dbContext = dbContext;
                        _mapper = mapper;
                }
                public List<AuthorsViewModel> Handle()
                {
                        var authorList = _dbContext.Authors.OrderBy(x => x.Id).ToList<Author>();
                        List<AuthorsViewModel> vm =  _mapper.Map<List<AuthorsViewModel>>(authorList);
                        return vm;
                }
        }
        public class AuthorsViewModel
        {
                public string Name { get; set; }
                public string Surname { get; set; }
                public string BirthDate { get; set; }
        }
}
