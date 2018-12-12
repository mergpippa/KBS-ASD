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
            Buyer buyer = null;
            Webshop webshop = null;
            Bank bank = null;

            var consumers = new List<MassTransit.IConsumer> { buyer, webshop, bank };
            var busControl = new BusControl(new MessageBusConfigurator()
            {
                ReceiveEndpoints = new List<ReceiveEndpoint>() {
                    new ReceiveEndpoint() { QueueName = "webshop_queue", Consumers = consumers } }
            });

            buyer = new Buyer(busControl);
            webshop = new Webshop(busControl);
            bank = new Bank(busControl);

            buyer.RequestItemList();
            Console.ReadKey();
        }
    }
}
