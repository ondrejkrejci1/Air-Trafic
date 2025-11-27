using Air_Trafic.src.Commands;

namespace Air_Trafic.src
{
    public class MyConsole
    {
        private bool isRunning = true;
        private Dictionary<string, ICommand>? commands;
        private AirTrafficControlTower? controlTower;

        private int airplaneCounter = 0;

        private void Initialize()
        {
            controlTower = new AirTrafficControlTower();
            commands = new Dictionary<string, ICommand>
            {
                { "help", new Help() },
                { "quit", new Quit() },
                { "airplanesinsystem", new AirplanesInSystem(this) },
                { "addairplane", new AddAirplane(this) }
            };
        }

        private void Do()
        {
            Console.Write(">> ");
            string? commandInput = Console.ReadLine();
            commandInput = commandInput?.Trim();
            commandInput = commandInput?.ToLower();

            if (commands.ContainsKey(commandInput))
            {
                Console.WriteLine(commands[commandInput].Execute());
                isRunning = !commands[commandInput].Exit();
            }
            else
            {
                Console.WriteLine("Unknown command. Type 'help' for a list of commands.");
            }
        }

        public void Start()
        {
            Initialize();
            Console.WriteLine("Welcome to the Air Traffic Control System!");
            try
            {
                do
                {
                    Do();
                } while (isRunning);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            controlTower?.StopAllRunways();
            controlTower?.Stop();
        }

        public void AddAirplane(Airplane airplane)
        {
            if(airplane.ID == -1)
            {
                airplane.ID = ++airplaneCounter;
                controlTower?.AcceptAirplane(airplane);
            }
        }

        public List<Airplane> GetAllAirplanesToProcess()
        {
            return controlTower.GetAllAirplanesToProcess();
        }


    }
}
