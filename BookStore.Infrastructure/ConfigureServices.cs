using BookStore.Domain.Repository;
using BookStore.Infrastructure.Data;
using BookStore.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices
            (this IServiceCollection services, IConfiguration configuration)

        {
            services.AddDbContext<BookDbContext>(options =>
                options.UseSqlite(configuration.GetConnectionString("BookDbContext") ??
                    throw new InvalidOperationException("Connection string 'BookDbContext not found '"))
            );

            services.AddTransient<IBookRepository, BookRepository>();
            return services;

        }
    }
}
