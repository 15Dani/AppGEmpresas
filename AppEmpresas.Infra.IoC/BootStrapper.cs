using AppEmpresas.Application.AppServices;
using AppEmpresas.Application.IAppServices;
using AppEmpresas.Domain.Interfaces.IRepositories;
using AppEmpresas.Domain.IUoW;
using AppEmpresas.Domain.Services;
using AppEmpresas.Infra.Data.Context;
using AppEmpresas.Infra.Data.Repositories;
using AppEmpresas.Infra.Data.UoW;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace AppEmpresas.Infra.IoC
{
    public class BootStrapper
    {
        public static void RegisterDbContext(IConfiguration configuration, IServiceCollection service)
        {

            service.AddDbContext<UserContext>(options => options.UseLazyLoadingProxies().UseMySql(configuration.GetConnectionString("Appempresa")), ServiceLifetime.Scoped);

        }

        public static void Register(IServiceCollection services)
        {
            //AppService
            services.AddScoped<IUserAppService, UserAppServices>();
            

            //Domain
            services.AddScoped<IUserService, UserServicecs>();
            

            //Infra Data
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUnityOfWork, UnityOrWork>();
            services.AddScoped<UserContext>();
        }

        public static void RegisterMappings(IServiceCollection services, IMapper mapper)
        {
            services.AddSingleton(mapper);
        }

    }
}

    

    


    

