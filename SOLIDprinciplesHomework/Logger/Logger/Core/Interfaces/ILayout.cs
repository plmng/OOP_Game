namespace Logger.Core.Interfaces
{
    using Core;

    public interface ILayout
    {
        string GetFormatedMessage(LoggerMessage msg);
    }
}
