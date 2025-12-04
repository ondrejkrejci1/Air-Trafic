using Air_Traffic.Aircraft;

namespace Air_Traffic.AirControl
{
    public class AirTrafficControlTower
    {
        public AirplanePriorityQueue AirplanesToProcess { get; private set; }
        public List<Runway> Runways { get; private set; }

        private readonly object _lockObj = new object();

        private bool isRunning = true;

        public AirTrafficControlTower()
        {
            AirplanesToProcess = new AirplanePriorityQueue();
            Runways = new List<Runway>() {
                new Runway("Northern runway (1)", ReportFromRunway, this),
                new Runway("Southern runway (2)", ReportFromRunway, this),
                new Runway("Eastern runway (3)", ReportFromRunway, this),
                new Runway("Western runway (4)", ReportFromRunway, this)
            };

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


        public void Stop()
        {
            isRunning = false;
        }
    }
}
