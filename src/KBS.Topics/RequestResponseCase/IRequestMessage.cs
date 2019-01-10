namespace KBS.Topics.RequestResponseCase
{
    /// <summary>
    /// A request will contain the same properties as a response for this test case
    /// </summary>
    public interface IRequestMessage : IResponseMessage, IMessageDiagnostics
    {
    }
}
