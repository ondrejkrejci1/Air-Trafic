namespace Air_Traffic.Command.Commands
{
    public interface ICommand
    {
        public string Execute();

        public bool Exit();

    }
}
