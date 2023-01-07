using asset.api.Repositories;
using asset.api.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace asset.api.Extensions;

public static class ContainerRegistrationExtension
{
    private static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IAssetRepository, AssetRepository>();
    }
    
    private static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IAssetService, AssetService>();
    }
    
    private static void AddDatabase(this IServiceCollection services)
    {
        
        services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("AssetDb"));

        // var serviceProvider = services.BuildServiceProvider();
        // var settingService = (ISettingService)serviceProvider.GetService(typeof(ISettingService));
        // var connectionString = settingService.GetValueAsync<string>(Constants.ConnectionStringKey).GetAwaiter().GetResult();
        // if (string.IsNullOrEmpty(connectionString))
        // {
        //     throw new Exception("Connection string is null. ");
        // }

        // services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString,p=> p.SetPostgresVersion(9,6)));
        
    }

    private static void AddMvcConfiguration(this IServiceCollection services,IWebHostEnvironment environment)
    {
        services.AddLogging();
        
        services.AddControllers();
        
        // services.AddAutoMapper(cfg =>
        // {
        //     cfg.AddProfile<GeneralMapping>();
        // });

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(opt =>
        {
            opt.SwaggerDoc(name: "v1", new OpenApiInfo { Title = $"Asset API - {environment.EnvironmentName}", Version = "v1" });
        });
    }
    
    public static void AddAllServices(this IServiceCollection services, IWebHostEnvironment environment)
    {
        services.AddMvcConfiguration(environment);
        services.AddRepositories();
        services.AddServices();
        services.AddDatabase();
    }
}
