
using Microsoft.EntityFrameworkCore;
using SimpleGameApi.Models.Domain.Contracts.Repositories;
using SimpleGameApi.Models.Domain.Contracts.Services;
using SimpleGameApi.Models.Infrastructure.Data.Contexts;
using SimpleGameApi.Models.Infrastructure.Data.Repositories;
using SimpleGameApi.Models.Services;

namespace SimpleGameApi.Models.Configuration;

public static class Startup
{
    public static void Configure(IConfiguration configuration, IServiceCollection services)
    {
        ConfigureDatabase(configuration, services);
        ConfigureDependencies(services);
    }

    private static void ConfigureDatabase(IConfiguration configuration, IServiceCollection services)
    {
        var connStr = configuration.GetConnectionString("JogosDB") ??
            throw new ArgumentNullException("Connection String não localizada");

        services.AddDbContext<JogoDbContext>(options => 
        options.UseSqlServer(connStr));
    }

    private static void ConfigureDependencies(IServiceCollection services)
    {
        ConfigureRepositories(services);
        ConfigureServices(services);

    }

    private static void ConfigureRepositories(IServiceCollection services)
    {
        // Incluir dependencias de repositorios

        services.AddScoped<IJogoRepository, JogoRepository>();
        services.AddScoped<IEstoqueRepository, EstoqueRepository>();
        services.AddScoped<IVendaRepository, VendaRepository>();
        services.AddScoped<IAluguelRepository, AluguelRepository>();
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        // Incluir dependencias de servicos

        services.AddScoped<IJogoService, JogoService>();
        services.AddScoped<IEstoqueService, EstoqueService>();
        services.AddScoped<IVendaService, VendaService>();
    }


}
