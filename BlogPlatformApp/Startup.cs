using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogPlatformApp.Data;
using BlogPlatformApp.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using BlogPlatformApp.Models;

namespace BlogPlatformApp
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
            services.AddAutoMapper(typeof(Startup));

            services.AddDbContext<PostContext>(options =>
                   options.UseSqlServer(Configuration.GetConnectionString("PostContext")));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddScoped(typeof(IDataRepository<>), typeof(DataRepository<>));

            services.AddControllers();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<BlogPost, BlogPostViewModel>();
                });
            }

            app.UseCors("CorsPolicy");

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
