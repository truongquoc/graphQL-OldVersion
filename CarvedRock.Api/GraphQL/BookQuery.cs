using CarvedRock.Api.Infrastructure.Services;
using GraphQL.Types;
using GraphQl_solution.GraphQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarvedRock.Api.GraphQL
{
    public class BookQuery : ObjectGraphType
    {
        public BookQuery(IBookService bookService)
        {
            Field<BookType>(
                "Book",
                arguments: new QueryArguments(
                   new QueryArgument<IdGraphType> { Name = "id", Description = "The Id of the Books." }
                    ),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    return bookService.GetDetail(id);
                }
                );
            Field<ListGraphType<BookType>>(
                "Books",
                resolve: context =>
                {
                    return bookService.GetAll();
                }
                );
        }
    }
}
