namespace Ioc
{
    public class DIConatiner
    {
        private readonly List<ServiceDescriptor> _serviceDescriptors;
        public DIConatiner(List<ServiceDescriptor> serviceDescriptors)
        {
            this._serviceDescriptors = serviceDescriptors;
        }

        public object GetServices(Type serviceType)
        {
            var serviceDescriptor = _serviceDescriptors.SingleOrDefault(x => x.Type == serviceType);

            if (serviceDescriptor == null)
                throw new Exception($"NUll Serivce {serviceType}");

            if (serviceDescriptor.Implementation != null)
                return serviceDescriptor.Implementation;

            var actualType = serviceDescriptor.ImplementationType ?? serviceDescriptor.Type;
            if (actualType.IsAbstract || actualType.IsInterface)
                throw new Exception($"IsAbstract or  IsInterface  {serviceType}");
            var constactor = actualType.GetConstructors().FirstOrDefault();
            object[] paramters = null;
            if (constactor != null)
            {
                paramters = constactor.GetParameters()
                .Select(x => GetServices(x.ParameterType)).ToArray();
            }
            var implementation = Activator.CreateInstance(actualType, paramters);

            if (serviceDescriptor.ServiceLifeTime == ServiceLifeTime.Singleton)
                serviceDescriptor.Implementation = implementation;

            return implementation;
        }
        public T GetServices<T>()
        {
            return (T)GetServices(typeof(T));
        }
        public DIConatiner GenerateContainer<T>()
        {
            throw new NotImplementedException();
        }
    }
}