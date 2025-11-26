using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Air_Trafic.src
{

    public class Airplane
    {
        public int ID { get; private set; }
        public FlightType FlightType { get; private set; }

        public AirplaneOperation Operation { get; set; }

        public Airplane(int id, FlightType flightType, AirplaneOperation operation)
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
