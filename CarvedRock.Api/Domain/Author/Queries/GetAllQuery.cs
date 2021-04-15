using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarvedRock.Api.Domain.Author.Queries
{
    public class GetAllQuery : IRequest<Task<List<GraphQl_solution.Database.Author>>>
    {

    }
}
