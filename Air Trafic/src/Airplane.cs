namespace Air_Trafic.src
{

    public class Airplane
    {
        public int ID { get; set; }
        public FlightType FlightType { get; private set; }

        public FlightOperation Operation { get; set; }

        public Airplane(int id, FlightType flightType, FlightOperation operation)
        {
            ID = id;
            FlightType = flightType;
            Operation = operation;
        }

        public override string? ToString()
        {
            return $"Airplane - {ID}, ({FlightType} - {Operation})";
        }
    }
}
