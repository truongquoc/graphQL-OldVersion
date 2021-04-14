using GraphQl_solution.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarvedRock.Api.Infrastructure.Services
{
    public interface IBookService
    {
        Task<List<Book>> GetAll();
        Task<Book> GetDetail(int id);
    }
}
