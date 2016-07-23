using System;

namespace KnowYourRoute.School.Contracts.Entities
{
    public class BellTimes
    {
        // TODO: Better way to represent bell times
        // TODO: Handle to 24HourTime
        public Time SchoolStart { get; set; }
        public Time SchoolEnd { get; set; }
    }
}