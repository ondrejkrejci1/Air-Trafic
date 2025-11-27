namespace Air_Trafic.src.Commands
{
    public class AddAirplane : ICommand
    {
        private readonly MyConsole console;
        public AddAirplane(MyConsole console)
        {
            this.console = console;
        }

        public string Execute()
        {
            Console.Write("Creating new airplane to system -\n\t" +
                "·Enter airplane flight type:\n\t·(1-NORMAL; 2-EMERGENCY; 3-GOVERNMENTAL)\n\t- ");
            
            string? flightTypeInput = Console.ReadLine();
            flightTypeInput = flightTypeInput.Trim();
            flightTypeInput = flightTypeInput.ToLower();

            FlightType flightType;

            switch (flightTypeInput)
            {
                case "1":
                    flightType = FlightType.NORMAL;
                    break;
                case "2":
                    flightType = FlightType.EMERGENCY;
                    break;
                case "3":
                    flightType = FlightType.GOVERNMENTAL;
                    break;
                case "normal":
                    flightType = FlightType.NORMAL;
                    break;
                case "emergency":
                    flightType = FlightType.EMERGENCY;
                    break;
                case "governmental":
                    flightType = FlightType.GOVERNMENTAL;
                    break;
                case "1-normal":
                    flightType = FlightType.NORMAL;
                    break;
                case "2-emergency":
                    flightType = FlightType.EMERGENCY;
                    break;
                case "3-governmental":
                    flightType = FlightType.GOVERNMENTAL;
                    break;
                default:
                    return "Invalid flight type. Airplane not added to the system.";
            }

            Console.Write("Enter flight operation airplane is about to do:\n\t·" +
                "(1-LANDING; 2-TAKEOFF)\n\t- ");

            string? flightOperationInput = Console.ReadLine();
            flightOperationInput = flightOperationInput.Trim();
            flightOperationInput = flightOperationInput.ToLower();

            FlightOperation flightOperation;

            switch (flightOperationInput)
            {
                case "1":
                    flightOperation = FlightOperation.LANDING;
                    break;
                case "2":
                    flightOperation = FlightOperation.TAKEOFF;
                    break;
                case "landing":
                    flightOperation = FlightOperation.LANDING;
                    break;
                case "takeoff":
                    flightOperation = FlightOperation.TAKEOFF;
                    break;
                case "1-landing":
                    flightOperation = FlightOperation.LANDING;
                    break;
                case "2-takeoff":
                    flightOperation = FlightOperation.TAKEOFF;
                    break;

                default:
                    return "Invalid flight operation. Airplane not added to the system.";
            }

            console.AddAirplane(new Airplane(-1, flightType, flightOperation));

            return "New airplane added to the system.";
        }

        public bool Exit()
        {
            return false;
        }
    }
}
