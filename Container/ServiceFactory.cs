using System.ComponentModel;

namespace Container;

public static class ServiceFactory
{
    public static ServiceProvider BuildProvider(this ServiceCollection services)
    {
        return new ServiceProvider(services);
    }
    public static ServiceProviderScoped CreateScoped(this ServiceProvider provider)
    {
        return new ServiceProviderScoped(provider);
    }
}
