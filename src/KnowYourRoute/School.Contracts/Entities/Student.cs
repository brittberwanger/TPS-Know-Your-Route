using KnowYourRoute.Common.Contracts.Entities;

namespace KnowYourRoute.School.Contracts.Entities
{
    public class Student
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }
    }
}
