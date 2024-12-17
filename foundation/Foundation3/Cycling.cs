namespace FitnessApp
{
    public class Cycling : Activity
    {
        private double speed;

        public Cycling(int minutes, double speed) : base(minutes)
        {
            this.speed = speed;
        }

        public override double GetDistance()
        {
            return (speed * minutes) / 60;
        }

        public override double GetSpeed()
        {
            return speed;
        }

        public override double GetPace()
        {
            return 60 / speed;
        }
    }
}
