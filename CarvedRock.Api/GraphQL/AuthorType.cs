using CarvedRock.Api.Domain;
using CarvedRock.Api.Infrastructure.Services;
using GraphQL.Types;
using GraphQl_solution.Database;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQl_solution.GraphQL
{
    public class AuthorType : ObjectGraphType<Author>
    {
       public AuthorType(IMediator mediator)
        {
            Name = "Author";
            Field(x => x.Id, type: typeof(IdGraphType)).Description("The Id of the Author");
            Field(x => x.Name).Description("The name of the author");
            Field(name: "Books", type: typeof(ListGraphType<BookType>), resolve: context =>
             {
                return mediator.Send(new GetAllBookByAuthorRequest(context.Source.Id)).Result;
             }
            );
        }
    }
}
