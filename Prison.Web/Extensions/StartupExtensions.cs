using Prison.Models.Entities;
using Prison.Repositories;
using Prison.Repositories.Base;

namespace Prison.Web.Extensions;

public static class StartupExtensions
{
    public static void RegisterDependencies(this IServiceCollection services)
    {
        services.AddTransient<IRepository<PrisonBuilding>,Repository<PrisonBuilding>>();
        services.AddTransient<IRepository<Cell>, Repository<Cell>>();
        services.AddTransient<IRepository<Prisoner>, Repository<Prisoner>>();
    }
}
