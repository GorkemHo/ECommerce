using Autofac;
using AutoMapper;
using ECommerce.Application.AutoMapper;
using ECommerce.Application.Services.AppUserService;
using ECommerce.Application.Services.CategoryService;
using ECommerce.Application.Services.OrderService;
using ECommerce.Application.Services.ProductOrderService;
using ECommerce.Application.Services.ProductService;
using ECommerce.Domain.Repositories;
using ECommerce.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.IoC
{
    public class DependencyResolver : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AppUserRepo>().As<IAppUserRepo>().InstancePerLifetimeScope();
            builder.RegisterType<CategoryRepo>().As<ICategoryRepo>().InstancePerLifetimeScope();
            builder.RegisterType<OrderRepo>().As<IOrderRepo>().InstancePerLifetimeScope();
            builder.RegisterType<ProductOrderRepo>().As<IProductOrderRepo>().InstancePerLifetimeScope();
            builder.RegisterType<ProductRepo>().As<IProductRepo>().InstancePerLifetimeScope();

            builder.RegisterType<AppUserService>().As<IAppUserService>().InstancePerLifetimeScope();
            builder.RegisterType<CategoryService>().As<ICategoryService>().InstancePerLifetimeScope();
            builder.RegisterType<OrderService>().As<IOrderService>().InstancePerLifetimeScope();
            builder.RegisterType<ProductOrderService>().As<IProductOrderService>().InstancePerLifetimeScope();
            builder.RegisterType<ProductService>().As<IProductService>().InstancePerLifetimeScope();

            // Mapper'ı da Hep IMapper olarak çağırdık bu sebeple Burada Mapper class ı ile IMapper ı resolve ediyoruz.
            builder.Register(context => new MapperConfiguration(config =>
            {
                // Register Mapper Profile
                config.AddProfile<Mapping>();
            })).AsSelf().SingleInstance();

            builder.Register(c => {
                var context = c.Resolve<IComponentContext>();
                var config = context.Resolve<MapperConfiguration>();
                return config.CreateMapper(context.Resolve);

            })
                .As<IMapper>()
                .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
