using MedicoErp.Model.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MedicoErp.Configuration
{
    public static class AppContextInjection
    {
        public static IServiceCollection AddDbContextInjection(this IServiceCollection services, IConfiguration configuration)
        {
            try
            {
                services.AddDbContext<MedicoErpContext>(options => options.UseSqlServer(configuration.GetConnectionString("MedicoErpDbContext")));
                return services;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
