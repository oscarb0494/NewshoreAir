using Autofac;
using AutoMapper;
using Business.DisponibilityBusiness;
using Business.Mapper;
using Domain.Contracts;
using Domain.Models;
using Domain.Models.Third;
using Services.IWebServices;
using Services.WebServices;

namespace NewshoreAPI.IOC
{
    public class AutofacBusinessModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<WebService>().As<IWebService>().SingleInstance();
            builder.RegisterType<DisponibilityBusiness>().As<IDisponibilityBusiness>().SingleInstance();
            builder.RegisterType<FlightResponse_Journey<List<Flight>,List<FlightResponse>>>().As<IMap<List<Flight>,List<FlightResponse>>>().SingleInstance();
            builder.RegisterType<Flight_Transport<Transport,FlightResponse>>().As<IMap<Transport,FlightResponse>>().SingleInstance();

            builder.Register(context => new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<List<FlightResponse>, List<Flight>>();
                //etc...
            })).AsSelf().SingleInstance();

            builder.Register(c =>
            {
                //This resolves a new context that can be used later.
                var context = c.Resolve<IComponentContext>();
                var config = context.Resolve<MapperConfiguration>();
                return config.CreateMapper(context.Resolve);
            })
            .As<IMapper>()
            .InstancePerLifetimeScope();
        }

    }
}
