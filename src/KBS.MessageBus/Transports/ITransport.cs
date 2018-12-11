using KBS.MessageBus.Configuration;
using MassTransit;

namespace KBS.MessageBus.Transports
{
    interface ITransport
    {
        IBusControl GetInstance(MessageBusConfigurator messageBusConfigurator);
    }
}
