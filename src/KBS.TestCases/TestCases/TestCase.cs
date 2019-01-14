using System;
using System.Threading.Tasks;
using KBS.Configuration;
using KBS.MessageBus;
using KBS.MessageBus.Configurator;
using KBS.Topics;
using MassTransit;

namespace KBS.TestCases.TestCases
{
    /// <summary>
    /// Abstract test case with a method that is used to run the benchmark
    /// </summary>
    public abstract class TestCase : IMessageBusEndpointConfigurator
    {
        /// <summary>
        /// Class that is used to track messages that are being sent
        /// </summary>
        private readonly MessageCaptureContext _messageCaptureContext;

        /// <summary>
        /// Abstract class with a Benchmark method that is used to call a callback on given test parameters
        /// </summary>
        /// <param name="messageCaptureContext">
        /// </param>
        protected TestCase(MessageCaptureContext messageCaptureContext)
        {
            _messageCaptureContext = messageCaptureContext;
        }

        /// <summary>
        /// Method used to create a message object for given index
        /// </summary>
        /// <param name="index">
        /// </param>
        /// <param name="filler">
        /// </param>
        protected abstract IMessageDiagnostics CreateMessage(int index, byte[] filler);

        /// <summary>
        /// Method to run the test benchmark
        /// </summary>
        /// <param name="busControl">
        /// The bus for the test case to use
        /// </param>
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
        private IMessageDiagnostics[] GenerateMessages()
        {
            var messages = new IMessageDiagnostics[BenchmarkConfiguration.MessageCount];
            var filler = new byte[BenchmarkConfiguration.FillerSize];

            for (var i = 0; i < BenchmarkConfiguration.MessageCount; i++)
                messages[i] = CreateMessage(i, filler);

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
        protected async Task SendMessages(Action<object> callback)
        {
            // Force this method to run asynchronously
            await Task.Yield();

            // Generate messages beforehand to make sure that calculations that can impact the
            // benchmark don't affect the results
            // TODO: Find a solution that won't hog the memory with benchmarks that send millions of messages
            var messages = GenerateMessages();

            // Save start time of benchmark
            var startTime = DateTime.UtcNow;

            // Track event on benchmark start
            Console.WriteLine($"Start sending messages {startTime}");

            // Create clients array
            var clients = new Task[BenchmarkConfiguration.ClientCount];

            // Amount of message that each client will send
            var messagesForEachClient = BenchmarkConfiguration.MessageCount / BenchmarkConfiguration.ClientCount;

            for (var i = 0; i < BenchmarkConfiguration.ClientCount; i++)
            {
                var startIndex = messagesForEachClient * i;
                var endIndex = startIndex + messagesForEachClient;

                // Create a new client
                clients[i] = Task.Run(() =>
                {
                    for (var j = startIndex; j < endIndex; j++)
                    {
                        // Send message
                        callback(messages[j]);

                        // Handle sent message in message capture context
                        _messageCaptureContext.HandleMessageSend(messages[j]);
                    }
                });
            }

            // Wait until all clients have sent their messages
            await Task.WhenAll(clients);

            // Track event on benchmark end
            Console.WriteLine($"Done sending messages {DateTime.UtcNow - startTime}");
        }
    }
}
