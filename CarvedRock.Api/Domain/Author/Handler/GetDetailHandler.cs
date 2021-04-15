using CarvedRock.Api.Domain.Queries;
using GraphQl_solution.Infrastructure.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarvedRock.Api.Domain.Author.Handler
{
    public class GetDetailHandler : RequestHandler<GetDetailQuery, Task<GraphQl_solution.Database.Author>>
    {
        private readonly IAuthorService _authorService;

        public GetDetailHandler(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        protected override Task<GraphQl_solution.Database.Author> Handle(GetDetailQuery request)
        {
            return _authorService.GetDetail(request.AuthorId);
        }

        //protected override GraphQl_solution.Database.Author Hander(Query request)
        //{
        //    return _authorService.GetDetail(request.AuthorId);
        //}
    }
}
