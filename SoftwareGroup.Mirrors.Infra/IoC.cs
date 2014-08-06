using Autofac;
using Autofac.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareGroup.Mirrors.Infra
{
    /// <summary>
    /// Dependency Injection Helper
    /// </summary>
    public class IoC
    {
        static object padLock = new object();
        static IContainer _container = null;

        private static IContainer Container
        {
            get
            {
                if (_container == null)
                {
                    lock (padLock)
                    {
                        if (_container == null)
                        {
                            ContainerBuilder builder = new ContainerBuilder();
                            builder.RegisterModule(new ConfigurationSettingsReader("autofac"));
                            _container = builder.Build();
                        }
                    }
                }
                return _container;
            }
        }

        /// <summary>
        /// Resolves an interface to a concrete type.
        /// </summary>
        /// <typeparam name="T">Interface Type</typeparam>
        /// <returns>Configured concrete class instance</returns>
        public static T Resolve<T>()
        {
            return Container.Resolve<T>();
        }

        /// <summary>
        /// Resolves an interface to a concrete type with parameters
        /// </summary>
        /// <typeparam name="T">Interface Type</typeparam>
        /// <param name="parameters">Parameters to the constructor</param>
        /// <returns>Configured concrete class instance</returns>
        public static T Resolve<T>(IDictionary<string, object> parameters)
        {
            List<Autofac.NamedParameter> paramList = new List<NamedParameter>();
            if (parameters != null)
            {
                foreach (var item in parameters.Keys)
                {
                    paramList.Add(new NamedParameter(item, parameters[item]));
                }
            }
            return Container.Resolve<T>(paramList);
        }
    }
}
