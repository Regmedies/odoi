namespace SampleFunctionAppNew.Types
{
    public class TimeType
    {
        private readonly string _time;

        public TimeType(string time)
        {
            _time = time;
        }

        public static implicit operator string(TimeType t) => t?._time;

        public static explicit operator TimeType(string time) => new TimeType(time);
    }
}
