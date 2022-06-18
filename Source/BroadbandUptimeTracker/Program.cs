namespace BroadbandUptimeTracker
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var logger = new Logger("BroadbandUptimeTracker.log");

			logger.Log("BroadbandUptimeTracker");
			logger.Log("======================");

			string secondsPerPingAsString;
			var secondsPerPingDefault = (30).ToString();
			if (args.Length < 1)
			{
				logger.Log("No argument for secondsPerPing, using default: " + secondsPerPingDefault);
				secondsPerPingAsString = secondsPerPingDefault;
			}
			else
			{
				secondsPerPingAsString = args[0];
			}

			if (int.TryParse(secondsPerPingAsString, out var secondsPerPing) == false)
			{
				logger.Log("Error parsing argument 'secondsPerPing': " + secondsPerPingAsString);
			}

			string hostToPing;
			var hostToPingDefault = "google.com";
			if (args.Length < 2)
			{
				logger.Log("No argument for hostToPing, using default: " + hostToPingDefault);
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