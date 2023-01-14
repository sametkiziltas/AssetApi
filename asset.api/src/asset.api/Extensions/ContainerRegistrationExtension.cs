using System.Reflection;
using asset.api.ActionFilters;
using asset.api.Repositories;
using asset.api.Services;
using asset.api.Services.Asset;
using asset.api.Services.User;
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
        services.AddScoped<IUserService, UserService>();
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

    private static void AddMvcConfiguration(this IServiceCollection services, IWebHostEnvironment environment)
    {
        services.AddLogging();

        services.AddControllers(opt =>
        {
            opt.Filters.Add<CheckUserIdIsExistActionFilter>();
        });

        // services.AddAutoMapper(cfg =>
        // {
        //     cfg.AddProfile<GeneralMapping>();
        // });

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(opt =>
        {
            opt.SwaggerDoc(name: "v1",
                new OpenApiInfo { Title = $"Asset API - {environment.EnvironmentName}", Version = "v1" });
            var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            opt.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
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