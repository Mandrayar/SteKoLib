using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace SteKoLib
{
    public sealed class PerformanceTimer
	{
		[DllImport("Kernel32.dll")]
        private static extern bool QueryPerformanceCounter(out long lpPerformanceCount);

        [DllImport("Kernel32.dll")]
        private static extern bool QueryPerformanceFrequency(out long lpFrequency);

		#region Member

		long startTime;
		long stopTime;
        long frequency;

		#endregion

		#region Construction

		public PerformanceTimer()
        {
            startTime = 0;
            stopTime  = 0;

			if (QueryPerformanceFrequency(out frequency) == false)
            {
                throw new Exception("high-performance counter not supported");
            }
		}

		#endregion

		#region Public Methods

		/// <summary>
		/// Start the timer
		/// </summary>
         public void Start()
        {
            // Lets do the waiting threads there work
            Thread.Sleep(0);
            QueryPerformanceCounter(out startTime);
        }

        /// <summary>
		/// Stop the timer
        /// </summary>
        public void Stop()
        {
            QueryPerformanceCounter(out stopTime);
		}

		public void Print(string name)
		{
			Console.WriteLine(string.Format("PerformanceTimer '{0}': {1} ms", name, Duration*1000.0));
		}

		#endregion

		#region Public Properties

		/// <summary>
		/// Returns the duration of the timer (in seconds)
		/// </summary>
        public double Duration
        {
            get
            {
				long current;
				QueryPerformanceCounter(out current);
				return (double)(current-startTime)/(double)frequency;
            }
		}

		#endregion
	}
}
