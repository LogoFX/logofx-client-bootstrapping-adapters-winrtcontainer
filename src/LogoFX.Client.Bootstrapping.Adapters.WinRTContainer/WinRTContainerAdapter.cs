using System;
using System.Collections.Generic;
using Windows.UI.Xaml.Controls;
using Caliburn.Micro;
using LogoFX.Client.Bootstrapping.Adapters.Contracts;
using Solid.Practices.IoC;

namespace LogoFX.Client.Bootstrapping.Adapters.WinRTContainer
{
    public class WinRTContainerAdapter : IIocContainer, IBootstrapperAdapter , IUniversalAdapter
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

        public void RegisterTransient<TService, TImplementation>() where TImplementation : class, TService
        {
            _container.RegisterPerRequest(typeof(TService), null, typeof(TImplementation));
        }

        public void RegisterTransient<TService>() where TService : class
        {
            _container.RegisterPerRequest(typeof(TService), null, typeof(TService));
        }

        public void RegisterTransient(Type serviceType, Type implementationType)
        {
            _container.RegisterPerRequest(serviceType, null, implementationType);
        }

        public void RegisterSingleton<TService, TImplementation>() where TImplementation : class, TService
        {
            _container.RegisterSingleton(typeof(TService), null, typeof(TImplementation));
        }

        public void RegisterSingleton(Type serviceType, Type implementationType)
        {
            _container.RegisterSingleton(serviceType, null, implementationType);
        }

        public void RegisterInstance<TService>(TService instance) where TService : class
        {
            _container.RegisterInstance(typeof(TService), null, instance);
        }

        public void RegisterInstance(Type dependencyType, object instance)
        {
            _container.RegisterInstance(dependencyType, null, instance);
        }

        public void RegisterHandler(Type dependencyType, Func<object> handler)
        {
            _container.RegisterHandler(dependencyType, null, container => handler());
        }

        public void RegisterHandler<TService>(Func<TService> handler) where TService : class
        {
            _container.RegisterHandler(typeof(TService), null, container => handler());
        }

        public TService Resolve<TService>() where TService : class
        {
            return _container.GetInstance<TService>();
        }

        public object Resolve(Type serviceType)
        {
            return _container.GetInstance(serviceType, null);
        }

        public void Dispose()
        {
            
        }

        public void RegisterWinRTServices()
        {
            _container.RegisterWinRTServices();
        }

        public void RegisterNavigationService(Frame frame)
        {
            _container.RegisterNavigationService(frame);
        }
    }
}
