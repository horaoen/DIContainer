namespace Container;

public class ServiceDiscriptor
{
    public ServiceLife LifeTime { get; set; }
    public Type ServiceType { get; set; }
    public Type ImplementType { get; set; }
    public object ImplementInstance { get; set; }
    
} 
