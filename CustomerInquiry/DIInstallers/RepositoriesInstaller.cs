using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using CustomerInquiry.DataContexts;
using CustomerInquiry.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerInquiry.DIInstallers
{
    public class RepositoriesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<CustomerContext>().ImplementedBy<CustomerContext>().LifestyleTransient());
            container.Register(
                Component.For<ICustomerRepository>().ImplementedBy<CustomerRepository>().LifestyleTransient());
        }
    }
}