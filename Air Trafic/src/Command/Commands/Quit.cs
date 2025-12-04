namespace Air_Traffic.Command.Commands
{
    public class Quit : ICommand
    {
        public string Execute()
        {
            return "Exiting the Air Traffic Control System. Goodbye!";
        }

        public bool Exit()
        {
            return true;
        }

    }
}
