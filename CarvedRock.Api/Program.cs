using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GraphQl_solution.Database;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CarvedRock.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IWebHost host = CreateWebHostBuilder(args).Build();

            using (IServiceScope scope = host.Services.CreateScope())
            {
                AppDbContext context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                var authorDbEntry = context.Authors.Add(
                  new Author
                  {
                      Name = "First Author",
                  }
                );


                context.Books.AddRange(
                  new Book
                  {
                      Name = "First Book",
                      Published = true,
                      AuthorId = authorDbEntry.Entity.Id,
                      Genre = "Mystery"
                  },
                  new Book
                  {
                      Name = "Second Book",
                      Published = true,
                      AuthorId = authorDbEntry.Entity.Id,
                      Genre = "Crime"
                  }
                );
                context.SaveChanges();
            }
            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
