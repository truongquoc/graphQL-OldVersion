using GraphQL;
using GraphQL.Types;
using GraphQl_solution.Database;
using GraphQl_solution.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQl_solution.GraphQL
{
    public class AuthorQuery : ObjectGraphType
    {
        public AuthorQuery(IAuthorService authorService)
        {
            Field<AuthorType>(
                "Author",
                arguments: new QueryArguments(
                   new QueryArgument<IdGraphType> { Name = "id", Description = "The Id of the Author." }
                    ),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    return authorService.GetDetail(id);
                }
                );
            Field<ListGraphType<AuthorType>>(
                "Authors",
                resolve: context =>
                {
                    return authorService.GetAll();
                }
                );
            Field<ListGraphType<BookType>>(
                "Books",
                arguments: new QueryArguments(new
                QueryArgument<IdGraphType>
                { Name = "id" }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    return authorService.GetBookByAuthor(id);
                }
                );
        }
    }
}
