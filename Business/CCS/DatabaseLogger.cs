namespace Business.CCS
{
    public class DatabaseLogger : ILogger
    {
        public void log()
        {
            Console.WriteLine("Logged to the database");
        }
    }
}
