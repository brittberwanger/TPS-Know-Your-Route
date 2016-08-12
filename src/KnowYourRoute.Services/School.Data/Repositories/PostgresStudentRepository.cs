using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using KnowYourRoute.School.Contracts.Entities;
using KnowYourRoute.School.Contracts.Interfaces;
using Dapper;

namespace KnowYourRoute.School.Data.Repositories
{
    public class PostgresStudentRepository : StudentRepository
    {
        private readonly DbConnection _database;
        private readonly HighSchoolRepository _highSchoolRepository;

        private const string PARAMETERS = "student_number AS ID, first_name AS FirstName, school_name AS HighSchoolName, last_name AS LastName, " +
                                          "grade_level AS GradeLevel, email_address AS EmailAddress, google_place_id AS GooglePlaceID, " +
                                          "latitude_y AS Latitude, longitude_x AS Longitude, street AS StreetAddress1, city as City, " +
                                          "state AS StateCode, zip AS PostalCode";

        public PostgresStudentRepository( DbConnection database, HighSchoolRepository highSchoolRepository )
        {
            _database = database;
            _highSchoolRepository = highSchoolRepository;
        }

        public IEnumerable<Student> GetAllStudents()
        {
            var student = _database.Query<Student>( $"SELECT {PARAMETERS} FROM students" );
            student.ToList().ForEach( s => s.HighSchool = getHighSchoolForStudent( s ) );
            return student;
        }

        private HighSchool getHighSchoolForStudent( Student student )
        {
            return _highSchoolRepository.GetHighSchoolByName( student.HighSchoolName );
        }

        public Student GetStudentByID( string id )
        {
            var student = _database.Query<Student>( $"SELECT {PARAMETERS} FROM students WHERE student_number = @ID", new { ID = id } ).FirstOrDefault();
            student.HighSchool = getHighSchoolForStudent( student );
            return student;
        }
    }
}
