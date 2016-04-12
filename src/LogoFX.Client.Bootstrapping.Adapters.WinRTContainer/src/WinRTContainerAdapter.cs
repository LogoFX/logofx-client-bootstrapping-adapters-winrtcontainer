using System;
using System.Collections.Generic;
using Windows.UI.Xaml.Controls;
using Caliburn.Micro;
using LogoFX.Client.Bootstrapping.Adapters.Contracts;
using Solid.Practices.IoC;

namespace LogoFX.Client.Bootstrapping.Adapters.WinRTContainer
{
    /// <summary>
    /// Represents implementation of <see cref="IBootstrapperAdapter"/> using <see cref="WinRTContainer"/>
    /// </summary>
    /// <seealso cref="IIocContainer" />
    /// <seealso cref="IBootstrapperAdapter" />
    /// <seealso cref="INavigationAdapter" />
    public class WinRTContainerAdapter : IIocContainer, IBootstrapperAdapter, 
        IIocContainerAdapter<Caliburn.Micro.WinRTContainer>, INavigationAdapter
    {
        private readonly Caliburn.Micro.WinRTContainer _container;

        /// <summary>
        /// Initializes a new instance of the <see cref="WinRTContainerAdapter"/> class.
        /// </summary>
        public WinRTContainerAdapter()
            :this(new Caliburn.Micro.WinRTContainer())
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WinRTContainerAdapter"/> class.
        /// </summary>
        /// <param name="container">The container.</param>
        public WinRTContainerAdapter(Caliburn.Micro.WinRTContainer container)
        {
            _container = container;
        }

        /// <summary>
        /// Resolves an instance of required service by its type
        /// </summary>
        /// <param name="serviceType">Type of service</param><param name="key">Optional service key</param>
        /// <returns>
        /// Instance of service
        /// </returns>
        public object GetInstance(Type serviceType, string key)
        {
            return _container.GetInstance(serviceType, key);
        }

        /// <summary>
        /// Resolves all instances of required service by its type
        /// </summary>
        /// <param name="serviceType">Type of service</param>
        /// <returns>
        /// All instances of requested service
        /// </returns>
        public IEnumerable<object> GetAllInstances(Type serviceType)
        {
            return _container.GetAllInstances(serviceType);
        }

        /// <summary>
        /// Resolves instance's dependencies and injects them into the instance
        /// </summary>
        /// <param name="instance">Instance to get injected with dependencies</param>
        public void BuildUp(object instance)
        {
            _container.BuildUp(instance);
        }

        /// <summary>
        /// Registers dependency in a transient lifetime style
        /// </summary>
        /// <typeparam name="TService">Type of dependency declaration</typeparam><typeparam name="TImplementation">Type of dependency implementation</typeparam>
        public void RegisterTransient<TService, TImplementation>() where TImplementation : class, TService
        {
            _container.RegisterPerRequest(typeof(TService), null, typeof(TImplementation));
        }

        /// <summary>
        /// Registers dependency in a transient lifetime style
        /// </summary>
        /// <typeparam name="TService">Type of dependency</typeparam>
        public void RegisterTransient<TService>() where TService : class
        {
            _container.RegisterPerRequest(typeof(TService), null, typeof(TService));
        }

        /// <summary>
        /// Registers dependency in a transient lifetime style
        /// </summary>
        /// <param name="serviceType">Type of dependency declaration</param><param name="implementationType">Type of dependency implementation</param>
        public void RegisterTransient(Type serviceType, Type implementationType)
        {
            _container.RegisterPerRequest(serviceType, null, implementationType);
        }

        /// <summary>
        /// Registers dependency as a singleton
        /// </summary>
        /// <typeparam name="TService">Type of dependency declaration</typeparam><typeparam name="TImplementation">Type of dependency implementation</typeparam>
        public void RegisterSingleton<TService, TImplementation>() where TImplementation : class, TService
        {
            _container.RegisterSingleton(typeof(TService), null, typeof(TImplementation));
        }

        /// <summary>
        /// Registers dependency as a singleton
        /// </summary>
        /// <param name="serviceType">Type of dependency declaration</param><param name="implementationType">Type of dependency implementation</param>
        public void RegisterSingleton(Type serviceType, Type implementationType)
        {
            _container.RegisterSingleton(serviceType, null, implementationType);
        }

        /// <summary>
        /// Registers an instance of dependency
        /// </summary>
        /// <typeparam name="TService">Type of dependency</typeparam><param name="instance">Instance of dependency</param>
        public void RegisterInstance<TService>(TService instance) where TService : class
        {
            _container.RegisterInstance(typeof(TService), null, instance);
        }

        /// <summary>
        /// Registers an instance of dependency
        /// </summary>
        /// <param name="dependencyType">Type of dependency</param><param name="instance">Instance of dependency</param>
        public void RegisterInstance(Type dependencyType, object instance)
        {
            _container.RegisterInstance(dependencyType, null, instance);
        }

        /// <summary>
        /// Registers the dependency via the handler.
        /// </summary>
        /// <param name="dependencyType">Type of the dependency.</param><param name="handler">The handler.</param>
        public void RegisterHandler(Type dependencyType, Func<object> handler)
        {
            _container.RegisterHandler(dependencyType, null, container => handler());
        }

        /// <summary>
        /// Registers the dependency via the handler.
        /// </summary>
        /// <param name="handler">The handler.</param>
        public void RegisterHandler<TService>(Func<TService> handler) where TService : class
        {
            _container.RegisterHandler(typeof(TService), null, container => handler());
        }

        /// <summary>
        /// Registers the collection.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <param name="dependencyTypes">The dependency types.</param>        
        public void RegisterCollection<TService>(IEnumerable<Type> dependencyTypes) where TService : class
        {
            foreach (var type in dependencyTypes)
            {
                _container.RegisterSingleton(typeof(TService), null, type);
            }
        }

        /// <summary>
        /// Registers the collection of the dependencies.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <param name="dependencies">The dependencies.</param>
        public void RegisterCollection<TService>(IEnumerable<TService> dependencies) where TService : class
        {
            _container.RegisterInstance(typeof(IEnumerable<TService>), null, dependencies);
        }

        /// <summary>
        /// Registers the collection.
        /// </summary>
        /// <param name="dependencyType">Type of the dependency.</param>
        /// <param name="dependencyTypes">The dependency types.</param>        
        public void RegisterCollection(Type dependencyType, IEnumerable<Type> dependencyTypes)
        {
            foreach (var type in dependencyTypes)
            {
                _container.RegisterSingleton(dependencyType, null, type);
            }
        }

        /// <summary>
        /// Registers the collection of the dependencies.
        /// </summary>
        /// <param name="dependencyType">The dependency type.</param>
        /// <param name="dependencies">The dependencies.</param>
        public void RegisterCollection(Type dependencyType, IEnumerable<object> dependencies)
        {
            foreach (var dependency in dependencies)
            {
                _container.RegisterInstance(dependencyType, null, dependency);
            }            
        }

        /// <summary>
        /// Resolves an instance of service.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <returns/>
        public TService Resolve<TService>() where TService : class
        {
            return _container.GetInstance<TService>();
        }

        /// <summary>
        /// Resolves an instance of service according to the service type.
        /// </summary>
        /// <param name="serviceType">The type of the service.</param>
        /// <returns/>
        public object Resolve(Type serviceType)
        {
            return _container.GetInstance(serviceType, null);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <filterpriority>2</filterpriority>
        public void Dispose()
        {
            
        }
                
        /// <summary>
        /// Sets the specified frame as the root frame of the navigation.
        /// </summary>
        /// <param name="frame">The root frame</param>
        public void RegisterNavigationService(Frame frame)
        {
            _container.RegisterNavigationService(frame);
        }
    }
}
