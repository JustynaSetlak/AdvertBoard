using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdvertBoard.BusinessLogic.IdentityConfig;
using AdvertBoard.BusinessLogic.Services;
using AdvertBoard.Controllers;
using AdvertBoard.DbAccess;
using AdvertBoard.DbAccess.Models;
using Autofac;
using Autofac.Integration.Mvc;
using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace AdvertBoard.Configuration
{
    public class DependencyConfig
    {
        public static void ConfigureDependencyInjection()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            RegisterRepositories(builder);
            RegisterServices(builder);
            RegisterMapper(builder);

            builder.RegisterType<AdvertBoardContext>().AsSelf().InstancePerRequest();
            builder.RegisterType<AuthService>().AsSelf().InstancePerRequest();
            builder.RegisterType<ApplicationUserManager>().AsSelf().InstancePerRequest();
            builder.RegisterType<ApplicationSignInManager>().AsSelf().InstancePerRequest();
            builder.RegisterType<ApplicationUserStore>().As<IUserStore<User>>().InstancePerRequest();
            builder.Register<IAuthenticationManager>(c => HttpContext.Current.GetOwinContext().Authentication)
                .InstancePerRequest();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        private static void RegisterMapper(ContainerBuilder builder)
        {
            var mapper = AutoMapperConfig.AutoMapperConfig.Initialize().CreateMapper();
            builder.RegisterInstance<IMapper>(mapper);
        }

        private static void RegisterRepositories(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces();
        }

        private static void RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces();
        }
    }
}