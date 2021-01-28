using EasyTicket.MessagingBus;
using EasyTicket.Services.Payment.Services;
using EasyTicket.Services.Payment.Worker;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace EasyTicket.Services.Payment
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
            services.AddHostedService<PaymentMessageWorker>();
            services.AddHttpClient<IExternalGatewayPaymentService, ExternalGatewayPaymentService>(c =>
                c.BaseAddress = new Uri(Configuration["ApiConfigs:ExternalPaymentGateway:Uri"]));
            services.AddSingleton<IMessageBus>(x => new RabbitMQMessageBus(Configuration["RabbitMQ:Host"],
             int.Parse(Configuration["RabbitMQ:Port"]),
             Configuration["RabbitMQ:Username"],
             Configuration["RabbitMQ:Password"]));

            //Uncomment for AzureServiceBus
            //services.AddHostedService<ServiceBusListener>();
            //services.AddSingleton<IMessageBus, AzServiceBusMessageBus>();

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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
