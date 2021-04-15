using CarvedRock.Api.Infrastructure.Services;
using GraphQl_solution.Infrastructure.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarvedRock.Api.Domain
{
    public class GetAllAuthorHandler : RequestHandler<GetAllAuthorRequest, Task<List<GraphQl_solution.Database.Author>>>
    {
        private readonly IAuthorService _authorService;
        public GetAllAuthorHandler(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        protected override Task<List<GraphQl_solution.Database.Author>> Handle(GetAllAuthorRequest request)
        {
            return _authorService.GetAll();
        }

    }

    public class GetDetailAuthorHandler : RequestHandler<GetDetailAuthorRequest, Task<GraphQl_solution.Database.Author>>
    {
        private readonly IAuthorService _authorService;
        public GetDetailAuthorHandler(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        protected override async Task<GraphQl_solution.Database.Author> Handle(GetDetailAuthorRequest request)
        {
            return await _authorService.GetDetail(request.AuthorId);
        }
    }

    public class GetAllBooksByAuthorHandler : RequestHandler<GetAllBookByAuthorRequest, Task<List<GraphQl_solution.Database.Book>>>
    {
        private readonly IBookService _bookService;
        public GetAllBooksByAuthorHandler(IBookService bookService)
        {
            _bookService = bookService;
        }

        protected override async Task<List<GraphQl_solution.Database.Book>> Handle(GetAllBookByAuthorRequest request)
        {
            return await _bookService.GetBooksByAuthorId(request.AuthorId);
        }

    }

}
