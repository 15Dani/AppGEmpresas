using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppEmpresas.Application.AutoMapper;
using AppEmpresas.Domain.Identity;
using AppEmpresas.Infra.Data.Context;
using AppEmpresas.Infra.IoC;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace Appempresas
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            //Registra o contexto do banco oioi
            BootStrapper.RegisterDbContext(Configuration, services);
            BootStrapper.Register(services);

            // mapemaneto
            var mapper = AutoMapperConfig.RegisterMappings();
            BootStrapper.RegisterMappings(services, mapper);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

            });

            //Configuração se Senha
            IdentityBuilder builder = services.AddIdentityCore<User>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 4;
            }
           );

            builder = new IdentityBuilder(builder.UserType, typeof(Role), builder.Services);
            builder.AddEntityFrameworkStores<UserContext>();
            builder.AddRoleManager<RoleManager<Role>>();
            builder.AddRoleValidator<RoleValidator<Role>>();
            builder.AddSignInManager<SignInManager<User>>();

            services
               .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                   .AddJwtBearer(options =>
                   {
                       var key = Encoding.UTF8.GetBytes(Configuration.GetSection("AppSettings:Token").Value);
                       var tokenValidationParameters = new TokenValidationParameters();

                       tokenValidationParameters.ValidateIssuerSigningKey = true;
                       tokenValidationParameters.IssuerSigningKey = new SymmetricSecurityKey(key);
                       tokenValidationParameters.ValidateIssuer = false;
                       tokenValidationParameters.ValidateAudience = false;
                       options.TokenValidationParameters = tokenValidationParameters;
                   }
                   );

            //Comentei essa parte para validar o CRUD da APIs,  fique a vontade.
            //services
            //    .AddMvc(options =>
            //    {
            //        var policy = new AuthorizationPolicyBuilder()
            //            .RequireAuthenticatedUser()
            //            .Build();

            //        options.Filters.Add(new AuthorizeFilter(policy));
            //    }
            //    )
            //    .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
            //    .AddJsonOptions(options =>
            //    {
            //        //Set date configurations
            //        options
            //            .SerializerSettings
            //            .DateTimeZoneHandling = DateTimeZoneHandling.Local;

            //        options
            //            .SerializerSettings
            //            .ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            //    }
            //    );


            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.InjectStylesheet("/swagger/ui/custom.css");
            });

        }
    }
}
