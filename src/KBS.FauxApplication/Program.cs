using System;
using System.Collections.Generic;
using KBS.FauxApplication.WebshopCase;
using KBS.MessageBus;
using KBS.MessageBus.Configuration;
using KBS.MessageBus.Model;
using KBS.Messages.WebshopCase;

namespace KBS.FauxApplication
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var buyer = new Buyer();
            var webshop = new Webshop();
            var bank = new Bank();

            // The BusControl needs the webshop objects
            var consumers = new List<MassTransit.IConsumer> { buyer, webshop, bank };

            var busControl = new BusControl(new MessageBusConfigurator()
            {
                ReceiveEndpoints = new List<ReceiveEndpoint>() {
                    new ReceiveEndpoint() { QueueName = "webshop_queue", Consumers = consumers } }
            });

            busControl.Publish<ICatalogueRequest>(new { });

            Console.WriteLine("Waiting...");
            Console.ReadLine();

            busControl.Stop();
        }
    }
}
