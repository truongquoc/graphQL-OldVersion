using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarvedRock.Api.Domain.Queries
{
    public class GetDetailQuery : IRequest<Task<GraphQl_solution.Database.Author>>
    {
        public int AuthorId { get; set; }

        public GetDetailQuery(int authorId)
        {
            AuthorId = authorId;
        }
    }
}
