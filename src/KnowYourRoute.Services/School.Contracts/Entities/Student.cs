using KnowYourRoute.Common.Contracts.Entities;

namespace KnowYourRoute.School.Contracts.Entities
{
    public class Student
    {

        public string ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        internal string HighSchoolName { get; set; }
        public HighSchool HighSchool { get; set; }
        public string GradeLevel { get; set; }
        public string EmailAddress { get; set; }
        public string GooglePlaceID { get; set; }
        public Coordinates Coordinates { get; set; }
        public Address Address { get; set; }
    }
}
    