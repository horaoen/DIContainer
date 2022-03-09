using System.Collections.Concurrent;

namespace Container;

public class ServiceProviderScoped
{
    public Dictionary<Type, object> ScopedService { get; set; }
    public ServiceProvider Root { get; set; }
    public ServiceProviderScoped(ServiceProvider root)
    {
        Root = root;
        ScopedService = new();
        ResizeService(Root.Dictionary);
    }
    
    private void ResizeService(ConcurrentDictionary<Type, ServiceDiscriptor> dictionary)
    {
        foreach (var item in dictionary)
        {
            ScopedService.TryAdd(item.Key, item.Value.ImplementInstance);
        }
    }
    public object GetService(Type serviceType)
    {
        return Root.GetService(serviceType, this);
    }
}
