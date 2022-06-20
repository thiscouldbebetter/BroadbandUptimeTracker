using System.Net.NetworkInformation;
using System.Timers;

namespace NetworkConnectivityLogger
{
	public class Tracker
	{
		private readonly int secondsPerPing;
		private readonly string hostNameToPing;
		private readonly Logger logger;

		public Tracker(int secondsPerPing, string hostNameToPing, Logger logger)
		{
			this.secondsPerPing = secondsPerPing;
			this.hostNameToPing = hostNameToPing;
			this.logger = logger;
		}
		public void Run()
		{
			WriteToLog("Tracking begins.");

			WriteToLog("Will ping " + hostNameToPing + " every " + secondsPerPing + " seconds,");
			WriteToLog("writing results to the file at " + logger.LogFilePath + ".");

			var timer = new System.Timers.Timer();
			const int millisecondsPerSecond = 1000;
			timer.Interval = secondsPerPing * millisecondsPerSecond;
			timer.Elapsed += new ElapsedEventHandler(TimerElapsed);
			timer.Start();

			WriteToLog("Tracker is running.");
			WriteToLog("Press the Enter key to quit.");

			// Run it at startup to avoid waiting a whole cycle for results.
			TimerElapsed(null, null);

			Console.ReadLine();

			WriteToLog("Tracking stopped at " + DateTime.UtcNow.ToString("o"));
		}

		public void TimerElapsed(object? target, ElapsedEventArgs? args)
		{
			var message = "Pinging " + hostNameToPing + "...";
			WriteToLog(message);
			var ping = new Ping();
			bool wasPingSuccessful;
			try
			{
				var reply = ping.Send(hostNameToPing);
				wasPingSuccessful = (reply.Status == IPStatus.Success);
			}
			catch (Exception)
			{
				wasPingSuccessful = false;
			}
			message = "...ping " + (wasPingSuccessful ? "successful." : "FAILED!");
			WriteToLog(message);
		}

		public void WriteToLog(string message)
		{
			logger.Log(message);
		}

	}
}
