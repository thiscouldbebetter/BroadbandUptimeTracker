namespace BroadbandUptimeTracker
{
	public class Logger
	{
		public readonly string LogFilePath;

		public Logger(string logFilePath)
		{
			LogFilePath = logFilePath;
		}

		public void Log(string message)
		{
			var timestamp = DateTime.UtcNow.ToString("o");
			var messageWithTimestamp = timestamp + " - " + message;
			Console.WriteLine(messageWithTimestamp);
			File.AppendAllLines(LogFilePath, new string[] { messageWithTimestamp });
		}
	}
}
