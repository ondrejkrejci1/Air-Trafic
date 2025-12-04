using Air_Traffic.Aircraft;

namespace Air_Traffic.AirControl
{
    public class Runway
    {
        private readonly Thread runwayThread;
        private bool isRunning = true;
        public Airplane? AssignedAirplane { get; private set; }
        private Action<string> reportCallback;

        public string Name { get; private set; }

        private AirTrafficControlTower controlTower;

        public Runway(string name, Action<string> reportCallback, AirTrafficControlTower controlTower)
        {
            Name = name;
            this.reportCallback = reportCallback;
            this.controlTower = controlTower;
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
            while (isRunning)
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
                else
                {
                    AssignedAirplane = controlTower.GetAirplaneToProcess();
                }
                Thread.Sleep(100);
            }
        }

        public void Stop()
        {
            isRunning = false;
        }
    }
}
