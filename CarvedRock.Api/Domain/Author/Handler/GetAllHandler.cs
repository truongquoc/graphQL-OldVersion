using CarvedRock.Api.Domain.Author.Queries;
using CarvedRock.Api.Domain.Queries;
using GraphQl_solution.Infrastructure.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarvedRock.Api.Domain.Author.Handler
{
    public class GetAllHandler : RequestHandler<GetAllQuery , Task<List<GraphQl_solution.Database.Author>>>
    {
        private readonly IAuthorService _authorService;
        public GetAllHandler(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        protected override Task<List<GraphQl_solution.Database.Author>> Handle(GetAllQuery request)
        {
            return _authorService.GetAll();
        }

    }
}
