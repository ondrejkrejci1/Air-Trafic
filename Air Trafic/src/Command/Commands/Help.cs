namespace Air_Traffic.Command.Commands
{
    public class Help : ICommand
    {
        public string Execute()
        {
            return "airplanesInSystem, addAirplane, quit";
        }

        public bool Exit()
        {
            return false;
        }

    }
}
