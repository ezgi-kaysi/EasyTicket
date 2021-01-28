﻿using EasyTicket.Services.Ordering.Messaging;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EasyTicket.Services.Ordering.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        //public static IAzServiceBusConsumer ServiceBusConsumer { get; set; }

        public static IRabbitMQConsumer Consumer { get; set; }

        public static IApplicationBuilder UseAzServiceBusConsumer(this IApplicationBuilder app)
        {
            //Consumer = app.ApplicationServices.GetService<IAzServiceBusConsumer>();

            Consumer = app.ApplicationServices.GetService<IRabbitMQConsumer>();
            var life = app.ApplicationServices.GetService<IHostApplicationLifetime>();

            life.ApplicationStarted.Register(OnStarted);
            life.ApplicationStopping.Register(OnStopping);

            return app;
        }

        private static void OnStarted()
        {
            Consumer.Start();
        }

        private static void OnStopping()
        {
            Consumer.Stop();
        }
                
    }
}
