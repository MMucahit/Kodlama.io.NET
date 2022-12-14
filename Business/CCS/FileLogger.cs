namespace Business.CCS
{
    public class FileLogger : ILogger
    {
        public void log()
        {
            Console.WriteLine("Logged to the file");
        }
    }
}
