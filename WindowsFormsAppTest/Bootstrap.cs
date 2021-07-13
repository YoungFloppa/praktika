﻿using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Data;
using Repository;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsAppTest
{
    public class Bootstrap
    {
        public static WindsorContainer BuildContainer()
        {
            WindsorContainer container = new WindsorContainer();
            container.Register(Component.For<DbContext>().ImplementedBy<PracticeDbContext>());
            container.Register(Component.For<IUnitOfWork>().ImplementedBy < UnitOfWork>());
            container.Register(Classes.FromAssemblyNamed("Repository").
            BasedOn(typeof(IRepository<>)).WithService.Base().WithServiceDefaultInterfaces());
            container.Register(Classes.FromAssemblyNamed("Service").
            BasedOn(typeof(IService)).WithService.Base().WithServiceDefaultInterfaces());

            return container;
        }
    }
}
