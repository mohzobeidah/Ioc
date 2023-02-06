namespace Ioc
{
    public class DIServiceCollections
    {
        private readonly List<ServiceDescriptor> _serviceDescriptors = new();
        public void GenerateSingleton<T>()
        {
            _serviceDescriptors.Add(new ServiceDescriptor(typeof(T), ServiceLifeTime.Singleton));
        }

        public void GenerateSingleton<TSerivce>(TSerivce serivce)
        {
            _serviceDescriptors.Add(new ServiceDescriptor(serivce, ServiceLifeTime.Singleton));
        }
        public void GenerateTransient<TSerivce>(TSerivce serivce)
        {
            _serviceDescriptors.Add(new ServiceDescriptor(serivce, ServiceLifeTime.Transient));
        }
        public void GenerateTransient<T>()
        {
            _serviceDescriptors.Add(new ServiceDescriptor(typeof(T), ServiceLifeTime.Transient));
        }

        public DIConatiner GenerateContainer()
        {
            return new DIConatiner(_serviceDescriptors);
        }

        public void GenerateTransient<T1, T2>() where T2 : T1
        {
            _serviceDescriptors.Add(new ServiceDescriptor(typeof(T1), typeof(T2), ServiceLifeTime.Transient));
        }
        public void GenerateSingleton<T1, T2>() where T2 : T1
        {
            _serviceDescriptors.Add(new ServiceDescriptor(typeof(T1), typeof(T2), ServiceLifeTime.Singleton));
        }
    }
}