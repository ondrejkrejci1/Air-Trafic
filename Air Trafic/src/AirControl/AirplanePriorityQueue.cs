using Air_Traffic.Aircraft;

namespace Air_Traffic.AirControl
{
    public class AirplanePriorityQueue
    {
        public List<Airplane> Airplanes { get; private set; }

        private readonly object _lockObj = new object();

        public AirplanePriorityQueue()
        {
            Airplanes = new List<Airplane>();
        }


        public void Enqueue(Airplane airplaneToEnqueue)
        {
            if (Airplanes.Count == 0)
            {
                Airplanes.Add(airplaneToEnqueue);
                return;
            }

            int newPriority = GetPriority(airplaneToEnqueue.FlightType);

            for (int i = 0; i < Airplanes.Count; i++)
            {
                int currentPriority = GetPriority(Airplanes[i].FlightType);

                if (newPriority < currentPriority)
                {
                    Airplanes.Insert(i, airplaneToEnqueue);
                    return;
                }
            }

            Airplanes.Add(airplaneToEnqueue);

        }

        public Airplane Dequeue()
        {
            lock (_lockObj)
            {
                Airplane airplaneToDequeue = Airplanes[0];
                Airplanes.RemoveAt(0);
                return airplaneToDequeue;
            }
        }

        public int Count
        {
            get { return Airplanes.Count; }
        }

        public List<Airplane> ToList()
        {
            return new List<Airplane>(Airplanes);
        }

        private static int GetPriority(FlightType flightType)
        {
            switch (flightType)
            {
                case FlightType.EMERGENCY:
                    return 1;
                case FlightType.GOVERNMENTAL:
                    return 2;
                case FlightType.NORMAL:
                    return 3;
                default:
                    return int.MaxValue;
            }
        }




    }
}
