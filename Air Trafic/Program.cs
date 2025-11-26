using Air_Trafic.src;
using System.Security.Cryptography.X509Certificates;

namespace Air_Trafic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Airplane> airplanes = new List<Airplane>()
            {
                new Airplane(1, FlightType.NORMAL, AirplaneOperation.LANDING),
                new Airplane(2, FlightType.EMERGENCY, AirplaneOperation.TAKEOFF),
                new Airplane(3, FlightType.NORMAL, AirplaneOperation.LANDING),
                new Airplane(4, FlightType.NORMAL, AirplaneOperation.TAKEOFF),
                new Airplane(5, FlightType.GOVERNMENTAL, AirplaneOperation.LANDING),
                new Airplane(6, FlightType.EMERGENCY, AirplaneOperation.TAKEOFF),
                new Airplane(7, FlightType.NORMAL, AirplaneOperation.LANDING),
                new Airplane(8, FlightType.NORMAL, AirplaneOperation.TAKEOFF),
                new Airplane(9, FlightType.NORMAL, AirplaneOperation.LANDING),
                new Airplane(10, FlightType.NORMAL, AirplaneOperation.TAKEOFF)
            };

            AirTrafficControlTower controlTower = new AirTrafficControlTower(airplanes);

            controlTower.Run();



        }

    }
}
