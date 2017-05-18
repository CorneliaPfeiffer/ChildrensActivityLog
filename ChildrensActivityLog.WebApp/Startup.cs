using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ChildrensActivityLog.Data;

using Microsoft.EntityFrameworkCore;
using ChildrensActivityLog.Data.Repositories;

namespace ChildrensActivityLog.WebApp
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            //services.AddEntityFrameworkSqlServer(IChildrensAcitivityLogRepository);
                //.AddEntityFrameworkSqlServer..AddDbContext<DatabaseContext>();
            services.AddMvc();
           
            //services.AddScoped<ChildrensActivityLogContext>(_ => new ChildrensActivityLogContext(Configuration.GetConnectionString("DefaultConnection")));

            //var connection = @"Server=(localdb)\mssqllocaldb;Database=ChildrensActivityLog;Trusted_Connection=True;";
            //services.AddDbContext<ChildrensActivityLogContext>(options => options.UseSqlServer(connection));

            //services.AddScoped<IChildrensAcitivityLogRepository, ChildrensAcitivityLogRepository>();
            services.AddSingleton<IChildrensAcitivityLogRepository, ChildrensAcitivityLogRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Domain.Child, Models.ChildOnlyDto>();
                cfg.CreateMap<Domain.Child, Models.ChildDto>();
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
