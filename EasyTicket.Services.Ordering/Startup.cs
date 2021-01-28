using AutoMapper;
using EasyTicket.MessagingBus;
using EasyTicket.Services.Ordering.DbContexts;
using EasyTicket.Services.Ordering.Extensions;
using EasyTicket.Services.Ordering.Messaging;
using EasyTicket.Services.Ordering.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
namespace EasyTicket.Services.Ordering
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
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddDbContext<OrderDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<IOrderRepository, OrderRepository>();

            //Specific DbContext for use from singleton AzServiceBusConsumer
            var optionsBuilder = new DbContextOptionsBuilder<OrderDbContext>();
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));

            services.AddSingleton(new OrderRepository(optionsBuilder.Options));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Ordering API", Version = "v1" });
            });

            //services.AddSingleton<IAzServiceBusConsumer, AzServiceBusConsumer>();

            services.AddSingleton<IMessageBus>(x => new RabbitMQMessageBus(Configuration["RabbitMQ:Host"],
                int.Parse(Configuration["RabbitMQ:Port"]),
                Configuration["RabbitMQ:Username"],
                Configuration["RabbitMQ:Password"]));

            services.AddSingleton<IRabbitMQConsumer, RabbitMQConsumer>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();


            app.UseRouting();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ordering API V1");

            });

            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseAzServiceBusConsumer();


        }
    }
}
