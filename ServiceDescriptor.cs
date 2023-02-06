namespace Ioc
{
    public class ServiceDescriptor
    {
        public Type Type { get; }
        public object Implementation { get; internal set; }
        public Type ImplementationType { get; }
        public ServiceLifeTime ServiceLifeTime { get; }

        public ServiceDescriptor(object implementation, ServiceLifeTime serviceLifeTime)
        {
            this.Type = implementation.GetType();
            this.Implementation = implementation;
            this.ServiceLifeTime = serviceLifeTime;
        }
         public ServiceDescriptor(Type implementation, ServiceLifeTime serviceLifeTime)
        {
            this.Type = implementation;
            this.ServiceLifeTime = serviceLifeTime;
        }

        public ServiceDescriptor(Type implementation, Type implementationType, ServiceLifeTime serviceLifeTime)
        {
            this.Type = implementation;
            this.ImplementationType = implementationType;
            this.ServiceLifeTime = serviceLifeTime;
        }
    }
}