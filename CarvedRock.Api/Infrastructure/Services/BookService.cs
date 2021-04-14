using CarvedRock.Api.Infrastructure.Services;
using GraphQl_solution.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarvedRock.Api.Infrastructure.Repositories
{
    public class BookService : IBookService
    {

        private readonly IBookRepository _bookRepository;
        public BookService(IBookRepository repo)
        {
            _bookRepository = repo;
        }
        public async Task<List<Book>> GetAll()
        {
            return await _bookRepository.GetAll();
        }
        public Task<Book> GetDetail(int id)
        {
            return _bookRepository.GetDetail(id);
        }
    }
}
