using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using KBS.MessageBus;
using KBS.MessageBus.Configurator;
using KBS.TestCases.Configuration;
using MassTransit;
using MassTransit.Internals.Extensions;

namespace KBS.TestCases.TestCases
{
    /// <summary>
    /// Abstract test case with a method that is used to run the benchmark
    /// </summary>
    public abstract class TestCase : IMessageBusEndpointConfigurator
    {
        private readonly TestCaseConfiguration _testCaseConfiguration;

        /// <summary>
        /// Abstract class with a Benchmark method that is used to call a callback on given test parameters
        /// </summary>
        /// <param name="testCaseConfiguration">
        /// </param>
        protected TestCase(TestCaseConfiguration testCaseConfiguration)
        {
            _testCaseConfiguration = testCaseConfiguration;
        }

        /// <summary>
        /// Method used to create a message object for given index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        protected abstract object CreateMessage(int index);
        
        /// /// <summary>
        /// Method to run the test benchmark
        /// </summary>
        /// <param name="busControl">The bus for the test case to use</param>
        /// <returns></returns>
        public abstract Task Run(BusControl busControl);
        
        /// <summary>
        /// Method used to configure the available endpoints for a test case
        /// </summary>
        /// <param name="busFactoryConfigurator">
        /// </param>
        public abstract void ConfigureEndpoints(IBusFactoryConfigurator busFactoryConfigurator);

        /// <summary>
        /// Method used to generated messages that will be sent during the benchmark
        /// </summary>
        /// <returns>
        /// </returns>
        private object[] GenerateMessages()
        {
            var messages = new object[_testCaseConfiguration.MessagesCount];

            for (var i = 0; i < _testCaseConfiguration.MessagesCount; i++)
                messages[i] = CreateMessage(i);

            return messages;
        }

        /// <summary>
        /// Method used to benchmark a service bus. This method calls a function that should send a
        /// message to the message bus. The frequency and amount of messages that are sent should be
        /// configured in the TestCaseConfiguration
        /// </summary>
        /// <param name="callback">
        /// </param>
        /// <returns>
        /// </returns>
        protected async Task Benchmark(Action<object> callback)
        {
            // Force this method to run asynchronously
            await Task.Yield();

            // Generate messages beforehand to make sure that calculations that can impact the
            // benchmark don't affect the results
            var messages = GenerateMessages();

            var startTime = DateTime.Now;

            // Track event on benchmark start TelemetryClient.TrackEvent( "benchmark_start", new
            // Dictionary<string, string> { { "startTime", startTime.ToString() } } );
            
            var clients = new Task[_testCaseConfiguration.Clients];
            
            // Amount of message that each client will send
            var messagesForEachClient = _testCaseConfiguration.MessagesCount / _testCaseConfiguration.Clients;

            for (var i = 0; i < _testCaseConfiguration.Clients; i++)
            {
                var startIndex = messagesForEachClient * i;
                var endIndex = startIndex + messagesForEachClient;
                
                // Create a new client
                clients[i] = Task.Run(() =>
                {
                    for (var j = startIndex; j < endIndex; j++)
                        callback(messages[j]);
                });
            }

            // Wait until all clients have sent their messages
            await Task.WhenAll(clients);

            // Track event on benchmark end TelemetryClient.TrackEvent( "benchmark_end", new
            // Dictionary<string, string> { { "endTime", (DateTime.Now - startTime).ToString() } } );

            Console.WriteLine($"Benchmark completed in: {DateTime.Now - startTime}");
        }
    }
}
