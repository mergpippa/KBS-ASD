namespace KBS.Infrastructure.Data
{
    public enum TestEnvironmentState
    {
        Initial = 1 << 0,

        CreatingResourceGroup = 1 << 1,
        CreatedResourceGroup = 1 << 2,

        CreatingMessageBroker = 1 << 3,
        CreatedMessageBroker = 1 << 4,

        CreatingAppServiceApp = 1 << 5,
        CreatedAppServiceApp = 1 << 6,

        CreatingAppServiceWebJob = 1 << 7,
        CreatedAppServiceWebJob = 1 << 8,

        DeployingApplicationToWebJob = 1 << 9,
        DeployedApplicationToWebJob = 1 << 10,

        TriggeringWebJob = 1 << 11,
        TriggeredWebJob = 1 << 12,

        RemovingResourceGroup = 1 << 13,
        RemovedResourceGroup = 1 << 14,
    }
}
