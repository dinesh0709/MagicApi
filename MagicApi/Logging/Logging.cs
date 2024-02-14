namespace MagicApi.Logging
{
    public class Logging : ILogging
    {
        public void Log(string message, string Type)
        {
            if (Type == "error")
            {
                Console.WriteLine("error - " + message);
            }
            else
            {
                Console.WriteLine(message);
            }
        }
    }
}
