using System;
using MassTransit;

namespace KBS.MessageBus.Transports
{
    internal interface ITransport
    {
        IBusControl GetBusControl(Action<IBusFactoryConfigurator> baseBusFactoryConfigurator);
    }
}
