namespace FitnessApp
{
    public class Running : Activity
    {
        private double distance;

        public Running(int minutes, double distance) : base(minutes)
        {
            this.distance = distance;
        }

        public override double GetDistance()
        {
            return distance;
        }

        public override double GetSpeed()
        {
            return (distance / minutes) * 60;
        }

        public override double GetPace()
        {
            return (double)minutes / distance;
        }
    }
}
