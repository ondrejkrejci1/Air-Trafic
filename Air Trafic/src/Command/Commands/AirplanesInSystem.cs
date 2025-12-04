using Air_Traffic.Aircraft;

namespace Air_Traffic.Command.Commands
{
    public class AirplanesInSystem : ICommand
    {
        private readonly MyConsole console;

        public AirplanesInSystem(MyConsole console)
        {
            this.console = console;
        }

        public string Execute()
        {
            List<Airplane> airplanes = console.GetAllAirplanesToProcess();
            string airplanesToString = string.Join("\n", airplanes.Select(a => a.ToString()));
            return $"Listing all airplanes in the system...\n {airplanesToString}";
        }

        public bool Exit()
        {
            return false;
        }
    }
}
