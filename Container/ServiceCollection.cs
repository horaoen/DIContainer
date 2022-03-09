namespace Container;

public class ServiceCollection : List<ServiceDiscriptor>
{
    public void AddTransient<TService, TImplement>()
        where TService : class
        where TImplement : class
    {
        AddTransient(typeof(TService), typeof(TImplement));
    }
    public void AddTransient(Type serviceType, Type implementType)
    {
        var discriptor = new ServiceDiscriptor()
        {
            LifeTime = ServiceLife.Transient,
            ServiceType = serviceType,
            ImplementType = implementType,
        };
        AddIfNotContent(discriptor);
    }
    public void AddScoped<TServcie, TImplement>()
        where TServcie : class
        where TImplement : class
    {
        AddScoped(typeof(TServcie), typeof(TImplement));
    }
    private void AddScoped(Type TService, Type TImpement)  
    {
        var discriptor = new ServiceDiscriptor()
        {
            LifeTime = ServiceLife.Scoped,
            ServiceType = TService,
            ImplementType = TImpement
        };
        AddIfNotContent(discriptor);
    }
    public void AddSingleton<TServcie, TImplement>()
        where TServcie : class
        where TImplement : class
    {
        AddSingleton(typeof(TServcie), typeof(TImplement));
    }
    private void AddSingleton(Type TService, Type TImpement)  
    {
        var discriptor = new ServiceDiscriptor()
        {
            LifeTime = ServiceLife.Singleton,
            ServiceType = TService,
            ImplementType = TImpement
        };
        AddIfNotContent(discriptor);
    }
    private void AddIfNotContent(ServiceDiscriptor discriptor)
    {
        if (!this.Any(e => e.ServiceType == discriptor.ServiceType && e.ImplementType == e.ImplementType))
        {
            this.Add(discriptor);
        }
    }
}
