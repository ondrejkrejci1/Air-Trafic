namespace Air_Traffic.Passengers
{
    public class Passenger
    {
        public string Name { get; private set; }

        public bool SeatbeltFastened { get; private set; }

        public List<PassengerIssue> Issues { get; private set; }

        public Passenger(string name)
        {
            Name = name;
            SeatbeltFastened = false;
            Issues = new List<PassengerIssue>();
        }

        public void FastenSeatbelt()
        {
            Random rnd = new Random();
            if (rnd.Next(100) < 95)
            {
                SeatbeltFastened = true;
            }
            else
            {
                Issues.Add(PassengerIssue.BROKEN_SEATBELT);
            }
        }



    }
}
