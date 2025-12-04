using Air_Traffic.Passengers;

namespace Air_Traffic.Aircraft
{

    public class Airplane
    {
        public int ID { get; set; }
        public FlightType FlightType { get; private set; }
        public FlightOperation Operation { get; set; }
        public List<Passenger> Passengers { get; private set; }

        public Airplane(int id, FlightType flightType, FlightOperation operation)
        {
            ID = id;
            FlightType = flightType;
            Operation = operation;
            Passengers = new List<Passenger>();
        }

        public override string? ToString()
        {
            return $"Airplane - {ID}, ({FlightType} - {Operation})";
        }
    }
}
