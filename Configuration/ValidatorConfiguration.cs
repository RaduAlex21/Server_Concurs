using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services.ModelServices.Contracts;
using Services.ModelServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validators;
using DTO;

namespace Configuration;

public static class ValidatorConfiguration
{
    public static IServiceCollection AddValidatorConfiguration(this IServiceCollection services, IConfiguration config)
    {
        services.AddTransient<IValidator<AccountDTO>, AccountValidator>();

        services.AddTransient<IValidator<TransportDTO>, TransportValidator>();

        services.AddTransient<IValidator<LocationDTO>, LocationValidator>();

        services.AddTransient<IValidator<GateDTO>, GateValidator>(); 

        return services;
    }
}
