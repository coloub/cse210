namespace FitnessApp
{
    public class Swimming : Activity
    {
        private int laps;

        public Swimming(int minutes, int laps) : base(minutes)
        {
            this.laps = laps;
        }

        public override double GetDistance()
        {
            return (laps * 50) / 1000.0;
        }

        public override double GetSpeed()
        {
            return (GetDistance() / minutes) * 60;
        }

        public override double GetPace()
        {
            return (double)minutes / GetDistance();
        }

        public override string GetSummary()
        {
            return $"{date.ToString("dd MMM yyyy")} - Swimming ({minutes} min): Distance {GetDistance():0.00} km, Speed: {GetSpeed():0.00} kph, Pace: {GetPace():0.00} min per km";
        }
    }
}
