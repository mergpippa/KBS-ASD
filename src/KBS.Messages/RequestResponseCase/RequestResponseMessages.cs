namespace KBS.Messages.RequestResponseCase
{
    public interface IRequestMessage
    {
        int Count { get; }
    }

    public interface IResponseMessage
    {
        int Count { get; }
    }
}
