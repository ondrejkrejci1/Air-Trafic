namespace Air_Trafic.src.Commands
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
