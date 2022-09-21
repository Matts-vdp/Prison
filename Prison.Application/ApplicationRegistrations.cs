using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Prison.Contracts.Commands;

namespace Prison.Application;

public static class ApplicationRegistrations
{
    public static void RegisterApplication(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetAssembly(typeof(ApplicationRegistrations)));

        AssemblyScanner.FindValidatorsInAssemblyContaining<CommandBase<IValidator>>()
            .ForEach(x =>
            {
                services.Add(ServiceDescriptor.Transient(x.InterfaceType, x.ValidatorType));
                services.Add(ServiceDescriptor.Transient(x.ValidatorType, x.ValidatorType));
            });
    }
}