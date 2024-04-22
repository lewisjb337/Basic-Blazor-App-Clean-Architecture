using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DEMO.Application.IoC;

public static class Register
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
    }
}