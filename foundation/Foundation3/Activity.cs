using System;

namespace FitnessApp
{
    public abstract class Activity
    {
        protected DateTime date;
        protected int minutes;

        public Activity(int minutes)
        {
            this.date = DateTime.Now;
            this.minutes = minutes;
        }

        public abstract double GetDistance();
        public abstract double GetSpeed();
        public abstract double GetPace();

        public virtual string GetSummary()
        {
            return $"{date.ToString("dd MMM yyyy")} - {this.GetType().Name} ({minutes} min): Distance {GetDistance():0.00} miles, Speed: {GetSpeed():0.00} mph, Pace: {GetPace():0.00} min per mile";
        }
    }
}
