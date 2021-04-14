using GraphQl_solution.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQl_solution.Infrastructure.Services
{
    public interface IAuthorService 
    {
        Task<Author> GetDetail(int id);
        Task<List<Author>> GetAll();
    }
}
