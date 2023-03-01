namespace VehicleTravelApp
{
    public class Statistics
    {
        public float Max { get; private set; }

        public float Min { get; private set; }

        public float Sum { get; private set; }

        public float Count { get; private set; }

        public float Average
        {
            get
            {
                return this.Sum / this.Count;
            }
        }

        public string AverageComent
        {
            get
            {
                switch (this.Sum)
                {
                    case var average when average >= 1000:
                        return "You probably have too much money for gas";
                    case var average when average >= 501:
                        return "And that's some distance";
                    case var average when average >= 101:
                        return "Driving economically means more money and time";
                    case var average when average >= 21:
                        return "Driving short distances causes problems with the exhaust system";
                    case var average when average >= 1:
                        return "You haven't gone too far";
                    default:
                        return "I guess you haven't gone anywhere";
                }
            }
        }

        public Statistics()
        {
            this.Max = float.MinValue;
            this.Min = float.MaxValue;
            this.Sum = 0;
            this.Count = 0;
        }

        public void AddTrip(float trip)
        {
            this.Count++;
            this.Sum += trip;
            this.Min = Math.Min(trip, this.Min);
            this.Max = Math.Max(trip, this.Max);
        }
    }

}
