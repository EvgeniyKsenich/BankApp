using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using BA.Database.DataContext;
using AutoMapper;
using BA.Database.Сommon.Repositories;
using BA.Database.UnitOfWork;
using BA.Database.Enteties;

namespace BA.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(connection));

            var _mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new Modeles.Mapper());
            });
            services.AddSingleton<IMapper>(sp => _mapperConfiguration.CreateMapper());

            services.AddTransient<IUnitOfWork<User, Account, Transaction>, UnitOfWork>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
