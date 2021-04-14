using GraphQL.Types;
using GraphQl_solution.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQl_solution.GraphQL
{
    public class BookType : ObjectGraphType<Book>
    {
        public BookType()
        {
            Name = "Book";
            Field(x => x.Id, type: typeof(IdGraphType)).Description("The Id of the book");
            Field(x => x.Name).Description("The name of the book");
            Field(x => x.Genre).Description("Book genre");
            Field(x => x.Published).Description("If the book is published or not");
        }
    }
}
