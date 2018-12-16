using KBS.MessageBus.Configurator;
using MassTransit;

namespace KBS.MessageBus.Transports
{
    internal interface ITransport
    {
        IBusControl GetBusControl(IMessageBusEndpointConfigurator endpointConfigurator);
    }
}
