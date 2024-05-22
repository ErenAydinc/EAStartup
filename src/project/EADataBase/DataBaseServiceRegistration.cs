using EADomain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EADataBase
{
    public static class DataBaseServiceRegistration
    {
        public static IServiceCollection AddDataBaseServices(this IServiceCollection services,IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(opt => opt.UseMySql(connectionString,ServerVersion.AutoDetect(connectionString)));
            return services;
        }
    }
}
