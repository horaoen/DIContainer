using Container;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TestApi.Services;

namespace TestApi.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    static Container.ServiceCollection services = new();
    static Container.ServiceProvider? provider;

    public WeatherForecastController()
    {
        services.AddScoped<IUser, User>();
        services.AddSingleton<IRole, Role>();
        if (provider == null)
        {
            provider = services.BuildProvider();
        }
    }
    [HttpGet(Name = "GetWeatherForecast")]
    public void Get()
    {
        var providerScoped = provider.CreateScoped();
        var user = providerScoped.GetService(typeof(IUser));
        var role = providerScoped.GetService(typeof(IRole));
        var u = providerScoped.GetService(typeof(IUser));
    }
}
