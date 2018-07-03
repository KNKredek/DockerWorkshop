using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crayons.Api.Domain;
using Crayons.Api.Domain.Models;
using Crayons.Api.Domain.Repositories;
using Crayons.Api.Domain.Repositories.Interfaces;
using Crayons.Api.Services;
using Crayons.Api.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Crayons.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuraion = configuration;
        }

        public IConfiguration Configuraion { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContext<LibraryDbContext>(dbOptions =>
                dbOptions.UseSqlServer(Configuraion.GetConnectionString("default"))
            );
            services.AddScoped<IRepository<Book>,BookRepository>();
            services.AddScoped<IBookService,BookService>();
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
