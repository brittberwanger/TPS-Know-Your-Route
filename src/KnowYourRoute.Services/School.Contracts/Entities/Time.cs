using KnowYourRoute.School.Contracts.Enumerations;

namespace KnowYourRoute.School.Contracts.Entities
{
    // TODO: How to deal with AM/PM
    public struct Time
    {
        public int Hour { get; set; }
        public int Minute { get; set; }
        public Meridiem Meridiem { get; set; }

        // TODO: Remove after testing
        public override string ToString()
        {
            return $"{Hour}:{Minute} {Meridiem}";
        }
    }
}
