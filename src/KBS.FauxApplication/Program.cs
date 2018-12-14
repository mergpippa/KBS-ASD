using System;
using System.Collections.Generic;
using KBS.FauxApplication.WebshopCase;
using KBS.MessageBus;
using KBS.MessageBus.Configuration;
using KBS.MessageBus.Model;
using KBS.Messages.WebshopCase;
using MassTransit;

namespace KBS.FauxApplication
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            // The BusControl needs the webshop objects
            var consumers = new List<MassTransit.IConsumer> { new Buyer(), new Webshop(), new Bank() };

            var busControl = new BusControl(new MessageBusConfigurator(new List<ReceiveEndpoint>()
                    {
                        new ReceiveEndpoint("webshop_queue", consumers)
                    }));

            //busControl.Publish<ICatalogueRequest>(new { });

            #region Working in memory

            var buyer = new Buyer();
            var shop = new Webshop();
            var bank = new Bank();

            var bus = Bus.Factory.CreateUsingInMemory(cfg =>
            {
                cfg.ReceiveEndpoint("mem_queue", ep =>
                {
                    ep.Consumer(() => buyer);
                    ep.Consumer(() => shop);
                    ep.Consumer(() => bank);
                });
            });
            bus.Start();

            #endregion Working in memory

            bus.Publish<ICatalogueRequest>(new { });

            Console.WriteLine("Waiting...");
            Console.ReadLine();

            bus.Stop();
            busControl.Stop();
        }
    }
}
