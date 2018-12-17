using System;
using System.Threading.Tasks;
using KBS.FauxApplication.Model;
using KBS.FauxApplication.TestCases.Webshop.Consumers;
using KBS.MessageBus;
using KBS.Messages.WebshopCase;
using MassTransit;

namespace KBS.FauxApplication.TestCases.Webshop
{
    internal class WebshopTestCase : ITestCase
    {
        private readonly string _endpointQueueName = "webshop_queue";

        /// <summary>
        /// Method used to configure the available endpoints for a test case
        /// </summary>
        /// <param name="busFactoryConfigurator">
        /// </param>
        public void ConfigureEndpoints(IBusFactoryConfigurator busFactoryConfigurator)
        {
            busFactoryConfigurator.ReceiveEndpoint(
                _endpointQueueName,
                receiveEndpointConfigurator =>
                {
                    receiveEndpointConfigurator.Consumer<Buyer>();
                    receiveEndpointConfigurator.Consumer<Bank>();
                    receiveEndpointConfigurator.Consumer<Shop>();
                }
            );
        }

        public async Task Run(BusControl busControl, TestConfiguration testConfiguration)
        {
            if (!testConfiguration.UserInput)
            {
                busControl.Publish<ICatalogueRequest>(new { });
                await Task.Delay(testConfiguration.Duration);
            }
            else
            {
                var run = true;
                string[] command;
                Console.WriteLine("[quit], [list], [buy Apple 2]");
                do
                {
                    command = Console.ReadLine().Split(' ');

                    switch (command[0].ToLower())
                    {
                        case "quit":
                            run = false;
                            break;

                        case "list":
                            Console.WriteLine("\tBuyer: Requested catalogue...");
                            busControl.Publish<ICatalogueRequest>(new { });
                            break;

                        case "buy":
                            if (command.Length < 3) break;
                            int quantity;
                            if (!Int32.TryParse(command[2], out quantity)) break;
                            string item = command[1];
                            if (Shop.Items.ContainsKey(item))
                            {
                                int left = Shop.Items[item];
                                if (left >= quantity)
                                {
                                    var bankInfo = new { AccountID = 666u, Withdrawal = quantity * 2 };
                                    var order = new { ItemName = item, Quantity = quantity, Purchase = bankInfo };
                                    Console.WriteLine($"\tOrdering {order.Quantity} {order.ItemName}(s)");
                                    Console.WriteLine($"\tOrdered by account {bankInfo.AccountID}\n\t{bankInfo.Withdrawal} to withdraw");
                                    busControl.Publish<IOrder>(order);
                                }
                                else
                                    Console.WriteLine("\tThat's to much");
                            }
                            break;

                        default:
                            break;
                    }
                } while (run);
            }
        }
    }
}
