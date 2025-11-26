namespace Air_Trafic.src
{
    public class AirTrafficControlTower
    {
        public AirplanePriorityQueue AirplanesToProcess { get; private set; }
        public List<Runway> Runways { get; private set; }

        private readonly object _lockObj = new object();

        public AirTrafficControlTower(List<Airplane> airplanes)
        {
            AirplanesToProcess = new AirplanePriorityQueue();
            Runways = new List<Runway>() {
                new Runway("Northern runway (1)", ReportFromRunway),
                new Runway("Southern runway (2)", ReportFromRunway),
                new Runway("Eastern runway (3)", ReportFromRunway),
                new Runway("Western runway (4)", ReportFromRunway)
            };

            foreach (var airplane in airplanes)
            {
                AcceptAirplane(airplane);
            }
        }

        public void AcceptAirplane(Airplane airplaneToAdd)
        {
            AirplanesToProcess.Enqueue(airplaneToAdd);
        }

        public void ReportFromRunway(string report)
        {
            Console.WriteLine(report);
        }

        public Airplane GetAirplaneToProcess()
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

        public void Run()
        {
            while (AirplanesToProcess.Count > 0)
            {
                foreach (Runway runway in Runways)
                {
                    if (runway.AssignedAirplane == null)
                    {
                        Airplane airplaneToProcess = GetAirplaneToProcess();
                        if (airplaneToProcess != null)
                        {
                            runway.AssignAircraft(airplaneToProcess);
                        }
                    }
                }



            }
        }
    }

    
}
