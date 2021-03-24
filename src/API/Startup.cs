using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using BLL.Interfaces;
using DAL;
using DAL.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using ITaskRepository = DAL.Interfaces.ITaskRepository;

namespace API
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Environment = env;
        }
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

       

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var loggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });
            if (Environment.IsDevelopment())
            {
                services.AddDbContext<TodoContext>(
                    opt =>
                    {
                        opt.UseLoggerFactory(loggerFactory); //logs all sql queries.

                        opt.UseSqlite("Data Source= ToDoIt");
                    });
            }
            else
            {
                services.AddDbContext<TodoContext>
                (opt =>
                {
                    opt.UseLoggerFactory(loggerFactory); //logs all sql queries.

                    opt.UseSqlServer(Configuration.GetConnectionString("defaultConnection"));
                });
                //    services.AddDbContext<TodoContext>(b => b
                //        .UseSqlServer(Environment.GetEnvironmentVariable("DatabaseConnectionString"))
                //        .LogTo(Console.WriteLine)
                //}

                services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo {Title = "API", Version = "v1"}); });

                services.AddScoped<IAssigneeRepository, AssigneeRepository>();
                services.AddScoped<IAssigneeService, AssigneeService>();
                services.AddScoped<ITaskRepository, TaskRepository>();
                services.AddScoped<ITaskService, TaskService>();
                services.AddTransient<DataInit>();

                services.AddCors(options =>
                    options.AddDefaultPolicy(
                        builder => { builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); })
                );

                services.AddControllers();
                services.AddMvc().AddNewtonsoftJson();
                services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
                services.AddControllers().AddNewtonsoftJson(options =>
                {
                    // Use the default property (Pascal) casing
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    options.SerializerSettings.MaxDepth = 5;
                });

            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}