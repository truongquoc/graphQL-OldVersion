using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarvedRock.Api.Domain
{
    public class GetAllAuthorRequest : IRequest<Task<List<GraphQl_solution.Database.Author>>>
    {

    }

    public class GetDetailAuthorRequest : IRequest<Task<GraphQl_solution.Database.Author>>
    {
        public int AuthorId { get; set; }

        public GetDetailAuthorRequest(int authorId)
        {
            AuthorId = authorId;
        }
    }

    public class GetAllBookByAuthorRequest : IRequest<Task<List<GraphQl_solution.Database.Book>>>
    {
        public int AuthorId { get; set; }
        public GetAllBookByAuthorRequest(int authorId)
        {
            AuthorId = authorId;
        }
    }

}
