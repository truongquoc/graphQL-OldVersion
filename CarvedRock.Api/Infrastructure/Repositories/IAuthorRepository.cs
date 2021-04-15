using GraphQl_solution.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQl_solution.Infrastructure
{
    public interface IAuthorRepository
    {
        Task<List<Author>> GetAll();
        Task<Author> GetDetail(int id);
        Task<List<Book>> GetBooksByAuthor(int id);
    }
}
