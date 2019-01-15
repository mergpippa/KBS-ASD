namespace KBS.Data.Enum
{
    public enum TelemetryEventType
    {
        PrePublish = 1,

        PostPublish = 2,

        PublishFault = 3,

        PreReceive = 4,

        PostConsume = 5,

        PostReceive = 6,

        ReceiveFault = 7,

        ConsumeFault = 8,

        PreSend = 9,

        PostSend = 10,

        SendFault = 11,
    }
}
