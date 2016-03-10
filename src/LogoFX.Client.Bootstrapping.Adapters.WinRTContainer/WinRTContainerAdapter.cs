using System;
using System.Collections.Generic;
using LogoFX.Client.Bootstrapping.Adapters.Contracts;

namespace LogoFX.Client.Bootstrapping.Adapters.WinRTContainer
{
    public class WinRTContainerAdapter : IBootstrapperAdapter
    {
        private readonly Caliburn.Micro.WinRTContainer _container;

        public WinRTContainerAdapter()
            :this(new Caliburn.Micro.WinRTContainer())
        {
            
        }

        public WinRTContainerAdapter(Caliburn.Micro.WinRTContainer container)
        {
            _container = container;
        }

        public object GetInstance(Type serviceType, string key)
        {
            return _container.GetInstance(serviceType, key);
        }

        public IEnumerable<object> GetAllInstances(Type serviceType)
        {
            return _container.GetAllInstances(serviceType);
        }

        public void BuildUp(object instance)
        {
            _container.BuildUp(instance);
        }
    }
}
