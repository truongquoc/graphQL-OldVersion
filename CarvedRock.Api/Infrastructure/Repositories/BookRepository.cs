using GraphQl_solution.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarvedRock.Api.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {

        private readonly AppDbContext _context;
        public BookRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Book>> GetAll() => await Task.FromResult(
            await _context.Books.ToListAsync()
            );

        public async Task<List<Book>> GetAllBookByAuthorId(int authorId)
        {
            return await Task.FromResult(_context.Books.Where(e => e.AuthorId == authorId).ToList());
        }

        public async Task<List<Book>> GetAllBookByAuthorIds(List<int> authorIds)
        {
            return await Task.FromResult(_context.Books.Where(e => authorIds.Contains(e.AuthorId)).ToList());
        }

        public async Task<Book> GetDetail(int id) => await Task.FromResult(
            _context.Books.Include(a => a.Author).FirstOrDefault(i => i.Id == id));
    }
}
