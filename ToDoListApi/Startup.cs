using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ToDoListApi.Models;
using Microsoft.EntityFrameworkCore;
using ToDoListApi.Context;
using ToDoListApi.Repository;
using ToDoListApi.Data_Manager;
using Newtonsoft.Json.Serialization;
namespace ToDoListApi
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
            services.AddControllers().AddNewtonsoftJson(options =>
            {
                // Use the default property (Pascal) casing
                var resolver = options.SerializerSettings.ContractResolver;
                if (resolver != null)
                    (resolver as DefaultContractResolver).NamingStrategy = null;
            });

            services.AddDbContext<TodoListContext>(options=>
            options.UseSqlServer(Configuration.GetConnectionString("Devcon")));
            services.AddScoped<IDataRepository<TodoList>, TodoListTaskManager>();
            services.AddScoped<IDataRepository<TaskList>,TaskListDataManager>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
