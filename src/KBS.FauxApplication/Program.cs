using System;
using System.Collections.Generic;
using KBS.FauxApplication.WebshopCase;
using KBS.MessageBus;
using KBS.MessageBus.Configuration;
using KBS.MessageBus.Model;

namespace KBS.FauxApplication
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            // Webshop objects need a BusControl
            BusControl busControl = new BusControl();

            Buyer buyer = new Buyer(busControl);
            Webshop webshop = new Webshop(busControl);
            Bank bank = new Bank(busControl);

            // The BusControl needs the webshop objects
            var consumers = new List<MassTransit.IConsumer> { buyer, webshop, bank };
            busControl.Create(new MessageBusConfigurator()
            {
                ReceiveEndpoints = new List<ReceiveEndpoint>() {
                    new ReceiveEndpoint() { QueueName = "webshop_queue", Consumers = consumers } }
            });

            buyer.RequestItemList();
            Console.WriteLine("Waiting...");
            Console.ReadKey();
        }
    }
}
