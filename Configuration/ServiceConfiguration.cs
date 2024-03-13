using DataAccess.Connection;
using DataAccess.Factory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services.ModelServices;
using Services.ModelServices.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configuration;

public static class ServiceConfiguration
{
    public static IServiceCollection AddServiceConfiguration(this IServiceCollection services, IConfiguration config)
    {
        services.AddTransient<IAccountService, AccountService>();

        services.AddTransient<ITransportService, TransportService>();

        services.AddTransient<ILocationService, LocationService>();

        services.AddTransient<IGateService, GateService>(); 

        return services;
    }
}