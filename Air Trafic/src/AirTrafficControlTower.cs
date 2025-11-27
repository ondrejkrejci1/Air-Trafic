namespace Air_Trafic.src
{
    public class AirTrafficControlTower
    {
        public AirplanePriorityQueue AirplanesToProcess { get; private set; }
        public List<Runway> Runways { get; private set; }

        private readonly object _lockObj = new object();

        private readonly Thread controllTowerThread;
        private bool isRunning = true;

        public AirTrafficControlTower()
        {
            AirplanesToProcess = new AirplanePriorityQueue();
            Runways = new List<Runway>() {
                new Runway("Northern runway (1)", ReportFromRunway),
                new Runway("Southern runway (2)", ReportFromRunway),
                new Runway("Eastern runway (3)", ReportFromRunway),
                new Runway("Western runway (4)", ReportFromRunway)
            };

            controllTowerThread = new Thread(Run)
            {
                IsBackground = true
            };
            controllTowerThread.Start();
        }

        public void AcceptAirplane(Airplane airplaneToAdd)
        {
            AirplanesToProcess.Enqueue(airplaneToAdd);
        }

        public void ReportFromRunway(string report)
        {
            Console.WriteLine($"\n----- {report} -----");
        }

        public Airplane? GetAirplaneToProcess()
        {
            if (AirplanesToProcess.Count > 0)
            {
                lock (_lockObj)
                {
                    return AirplanesToProcess.Dequeue();
                }

            }
            return null;
        }

        public void StopAllRunways()
        {
            foreach (var runway in Runways)
            {
                runway.Stop();
            }
        }

        public List<Airplane> GetAllAirplanesToProcess()
        {
            return AirplanesToProcess.ToList();
        }

        public void Run()
        {
            while (isRunning)
            {
                foreach (Runway runway in Runways)
                {
                    if (runway.AssignedAirplane == null)
                    {
                        Airplane? airplaneToProcess = GetAirplaneToProcess();
                        if (airplaneToProcess != null)
                        {
                            runway.AssignAircraft(airplaneToProcess);
                        }
                    }
                }
            }
        }

        public void Stop()
        {
            isRunning = false;
        }
    }    
}
