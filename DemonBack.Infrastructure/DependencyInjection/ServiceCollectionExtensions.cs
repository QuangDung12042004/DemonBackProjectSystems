using DemonBack.Application.AnimePaths;
using DemonBack.Infrastructure.Data;
using DemonBack.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemonBack.Infrastructure.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql(connectionString, npgsql =>
                {
                    // migrations sẽ nằm ở Infrastructure
                    npgsql.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName);
                    
                });
            });
            services.AddScoped<IAnimePathRepository, AnimePathRepository>();
            return services;
        }
    }
}   
