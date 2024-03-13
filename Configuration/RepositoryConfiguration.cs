using DataAccess.Connection;
using DataAccess.Factory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configuration;

public static class RepositoryConfiguration
{
    public static IServiceCollection AddRepositoryConfiguration(this IServiceCollection services, IConfiguration config)
    {

        services.AddSingleton<ISqlDAccess>(new SqlDAccess(config.GetConnectionString("DataBase") ?? throw new ArgumentNullException("config")));

        services.AddSingleton<IFactory, Factory>();

        return services;
    }
}
