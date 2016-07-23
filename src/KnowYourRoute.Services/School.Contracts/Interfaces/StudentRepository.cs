using KnowYourRoute.School.Contracts.Entities;
using System.Collections.Generic;

namespace KnowYourRoute.School.Contracts.Interfaces
{
    public interface StudentRepository
    {
        IEnumerable<Student> GetAllStudents();

        Student GetStudentByID( string id );
    }
}
