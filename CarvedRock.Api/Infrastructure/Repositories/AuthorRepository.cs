using GraphQl_solution.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQl_solution.Infrastructure
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly AppDbContext _context;
        public AuthorRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Author>> GetAll() => await Task.FromResult(
            await _context.Authors.ToListAsync()
            );

        public async Task<List<Book>> GetBooksByAuthor(int id) => await Task.FromResult(
            await _context.Books.Where(i => i.AuthorId == id).ToListAsync());

        public async Task<Author> GetDetail(int id) => await Task.FromResult(
            _context.Authors.Include(a => a.Books).FirstOrDefault(i => i.Id == id));

        
    }
}
