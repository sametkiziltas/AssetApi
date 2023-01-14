namespace asset.api.Extensions;
public static class RegisterHttpExtensions
{
    public static void AddHttpClientServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHttpClient("UserApi", c => { c.BaseAddress = new Uri(configuration["UserApi:EndPoint"]); });
    }
}