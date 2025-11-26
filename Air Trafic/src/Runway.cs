using System;
using System.Collections.Concurrent;
using System.Threading;

namespace Air_Trafic.src
{
    public class Runway
    {
        private readonly Thread runwayThread;
        private volatile bool running = true;
        public Airplane? AssignedAirplane { get; private set; }
        private Action<string> reportCallback;

        public string Name { get; private set; }

        public Runway(string name, Action<string> reportCallback)
        {
            Name = name;
            this.reportCallback = reportCallback;
            runwayThread = new Thread(ProcessAirplane)
            {
                IsBackground = true
            };
            runwayThread.Start();
        }

        public void AssignAircraft(Airplane Airplane)
        {
            AssignedAirplane = Airplane;
        }

        private void ProcessAirplane()
        {
            while (running)
            {
                if (AssignedAirplane != null)
                {
                    // Simulace zpracování letadla
                    string report = $"{Name}: {AssignedAirplane} is in process.";
                    reportCallback?.Invoke(report);
                    Thread.Sleep(10000);
                    report = $"{Name}: {AssignedAirplane} has exited the runway.";
                    reportCallback?.Invoke(report);

                    AssignedAirplane = null;
                }
                Thread.Sleep(100);
            }
        }

        public void Stop()
        {
            running = false;            
        }
    }
}
