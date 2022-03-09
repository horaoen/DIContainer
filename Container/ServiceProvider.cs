using System.Collections.Concurrent;

namespace Container;

public class ServiceProvider
{
    public ConcurrentDictionary<Type, ServiceDiscriptor> Dictionary { get; set; }
    public ServiceProvider(ServiceCollection servcies)
    {
        Dictionary = new();
        ResizeService(servcies);
    }

    public void ResizeService(ServiceCollection services)
    {
        foreach (var service in services)
        {
            Dictionary.TryAdd(service.ServiceType, service);
        }
    }

    public object GetService(Type serviceType, ServiceProviderScoped scopedProvider)
    {
        var hasValue = Dictionary.TryGetValue(serviceType, out ServiceDiscriptor discriptor);
        if (hasValue)
        {
            switch (discriptor.LifeTime)
            {
                default:
                case ServiceLife.Transient:
                    {
                        return Activator.CreateInstance(discriptor.ImplementType);
                    }
                case ServiceLife.Singleton:
                    {
                        if (discriptor.ImplementInstance == null)
                        {
                            discriptor.ImplementInstance = Activator.CreateInstance(discriptor.ImplementType);
                        }
                        return discriptor.ImplementType;
                    }
                case ServiceLife.Scoped:
                    {
                        if (scopedProvider.ScopedService.TryGetValue(serviceType, out object instance))
                        {
                            if (instance == null)
                            {
                                instance = Activator.CreateInstance(discriptor.ImplementType);
                                scopedProvider.ScopedService[serviceType] = instance;
                            }
                        }
                        return instance;
                    }
            }
        }
        else
        {
            return null;
        }
    }
}
