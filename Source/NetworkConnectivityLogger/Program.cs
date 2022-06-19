namespace NetworkConnectivityLogger
{
    internal class Program
	{
		static void Main(string[] args)
		{
			var logger = new Logger("NetworkConnectivityLogger.log");

			logger.Log("NetworkConnectivityLogger");
			logger.Log("======================");

			string secondsPerPingAsString;
			var secondsPerPingDefault = 30;
			if (args.Length < 1)
			{
				logger.Log("No argument for secondsPerPing, using default: " + secondsPerPingDefault + ".");
				secondsPerPingAsString = secondsPerPingDefault.ToString();
			}
			else
			{
				secondsPerPingAsString = args[0];
			}

			if (int.TryParse(secondsPerPingAsString, out var secondsPerPing) == false)
			{
				var message =
					"Error parsing argument 'secondsPerPing': " + secondsPerPingAsString
					+ ".  Using default: " + secondsPerPingDefault + ".";
				logger.Log(message);
				secondsPerPing = secondsPerPingDefault;
			}

			string hostToPing;
			var hostToPingDefault = "google.com";
			if (args.Length < 2)
			{
				logger.Log("No argument for hostToPing, using default: " + hostToPingDefault + ".");
				hostToPing = hostToPingDefault;
			}
			else
			{
				hostToPing = args[1];
			}

			var tracker = new Tracker(secondsPerPing, hostToPing, logger);
			tracker.Run();
		}
	}
}