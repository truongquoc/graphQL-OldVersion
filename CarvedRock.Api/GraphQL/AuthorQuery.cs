using CarvedRock.Api.Domain.Queries;
using GraphQL;
using GraphQL.Types;
using GraphQl_solution.Database;
using GraphQl_solution.Infrastructure.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQl_solution.GraphQL
{

    public class Statistic
    {
        public List<int> authorIds { get; set; }
    }
    public class AuthorQuery : ObjectGraphType<Author>
    {

        public AuthorQuery(IMediator mediator)
        {
            Field<AuthorType>(
                "Author",
                arguments: new QueryArguments(
                   new QueryArgument<IdGraphType> { Name = "id", Description = "The Id of the Author." }
                    ),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    //return authorService.GetDetail(id);
                    return mediator.Send(new GetDetailQuery(id));
                }
                );
            //Field<ListGraphType<AuthorType>>(
            //    "Authors",
            //    resolve: context =>
            //    {
            //        return authorService.GetAll();
            //    }
            //    );
            //Field<ListGraphType<BookType>>(
            //    "Books",
            //    arguments: new QueryArguments(new
            //    QueryArgument<IdGraphType>
            //    { Name = "id" }),
            //    resolve: context =>
            //    {
            //        var id = context.GetArgument<int>("id");
            //        return authorService.GetBookByAuthor(id);
            //    }
            //    );
        }
    }
}
