using KnowYourRoute.Common.Contracts.Entities;

namespace KnowYourRoute.School.Contracts.Entities
{
    public class Student
    {
        public string ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }
        public HighSchool HighSchool { get; set; }
        public string GradeLevel { get; set; }
        // TODO: Move bell time to school level
        public BellTimes BellTimes { get; set; }
    }
}
    