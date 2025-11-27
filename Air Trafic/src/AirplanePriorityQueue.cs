namespace Air_Trafic.src
{
    public class AirplanePriorityQueue
    {
        public List<Airplane> Airplanes { get; private set; }

        public AirplanePriorityQueue()
        {
            Airplanes = new List<Airplane>();
        }


        public void Enqueue(Airplane airplaneToEnqueue)
        {
            if(Airplanes.Count == 0)
            {
                Airplanes.Add(airplaneToEnqueue);
                return;
            }

            foreach (Airplane airplane in Airplanes) 
            {
                if (GetPriority(airplane.FlightType) > GetPriority(airplaneToEnqueue.FlightType))
                {
                    Airplanes.Insert(Airplanes.IndexOf(airplane), airplaneToEnqueue);
                } else
                {
                    Airplanes.Add(airplaneToEnqueue);
                }
                return;
            }

        }

        public Airplane Dequeue()
        {
            Airplane airplaneToDequeue = Airplanes[0];
            Airplanes.RemoveAt(0);
            return airplaneToDequeue;
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
