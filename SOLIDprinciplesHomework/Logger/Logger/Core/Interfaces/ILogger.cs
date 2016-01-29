namespace Logger.Core
{
    public interface ILogger
    {
        void Error(string msg);
        
        void Info(string msg);
        
        void Warn(string msg);
        
        void Fatal(string msg);
        
        void Critical(string msg);

    }
}
