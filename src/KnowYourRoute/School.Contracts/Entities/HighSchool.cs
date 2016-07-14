using KnowYourRoute.Common.Contracts.Entities;

namespace KnowYourRoute.School.Contracts.Entities
{
    public class HighSchool
    {
        public string Name { get; set; }
        public string GooglePlaceID { get; set; }
        public Address Address { get; set; }
        public Coordinates Coordinates { get; set; }
    }
}
