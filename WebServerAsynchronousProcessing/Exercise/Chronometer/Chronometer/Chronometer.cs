using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Chronometer
{
    public class Chronometer : IChronometer
    {
        private List<string> laps;
        private Stopwatch watch;
        private string totalElapsedTime;

        public Chronometer()
        {
            this.laps = new List<string>();
            this.watch = new Stopwatch();
        }

        public string GetTime => this.totalElapsedTime;

        public IList<string> Laps => this.laps.AsReadOnly();

        public string Lap()
        {
            var timeElapse = this.watch.Elapsed.ToString();
            this.laps.Add(timeElapse);

            return timeElapse;
        }

        public void Reset()
        {
            this.watch.Reset();
            this.totalElapsedTime = this.watch.Elapsed.ToString();
            this.laps.Clear();            
        }

        public void Start()
        {                     
            this.watch.Start();
        }

        public void Stop()
        {
            this.totalElapsedTime = this.watch.Elapsed.ToString();
            this.watch.Stop();
        }
    }
}
