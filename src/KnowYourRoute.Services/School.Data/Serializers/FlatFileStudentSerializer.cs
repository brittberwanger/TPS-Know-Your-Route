using System;
using KnowYourRoute.School.Contracts.Entities;
using System.Collections.Generic;
using System.Linq;
using KnowYourRoute.Common.Contracts.Entities;
using KnowYourRoute.Common.Contracts.Enumerations;

namespace KnowYourRoute.School.Data.Serializers
{
    public class FlatFileStudentSerializer
    {
        private readonly BellTimesSerializer _bellTimesSerializer;

        public FlatFileStudentSerializer( BellTimesSerializer bellTimesSerializer )
        {
            _bellTimesSerializer = bellTimesSerializer;
        }

        public IEnumerable<Student> ToStudents( IEnumerable<string[]> data, Func<string, HighSchool> highSchoolFactory )
        {
            return data.Select( s => ToStudent( s, highSchoolFactory ) );
        }

        // TODO: Do validation here on the incoming data?
        public Student ToStudent( string[] data, Func<string, HighSchool> highSchoolFactory )
        {
            return new Student
            {
                ID = data[ StudentFileContents.ID_INDEX ],
                BellTimes = constructBellTime( data[ StudentFileContents.BELL_TIME_INDEX ] ),
                HighSchool = highSchoolFactory( data[ StudentFileContents.HIGH_SCHOOL_INDEX ] ),
                LastName = data[ StudentFileContents.LAST_NAME_INDEX ],
                FirstName = data[ StudentFileContents.FIRST_NAME_INDEX ],
                Address = constructAddress( data ),
                // TODO: Handle bad data
                GradeLevel = data[ StudentFileContents.GRADE_LEVEL_INDEX ]
            };
        }

        private BellTimes constructBellTime( string data )
        {
            return _bellTimesSerializer.ToBellTimes( data );
        }

        // TODO: Handle Address 2
        private Address constructAddress( string[] data )
        {
            return new Address
            {
                StreetAddress1 = data[ StudentFileContents.STREET_INDEX ],
                City = data[ StudentFileContents.CITY_INDEX ],
                // TODO: Handle bad data
                StateCode = (StateCode)Enum.Parse( typeof( StateCode ), data[ StudentFileContents.STATE_INDEX ] ),
                PostalCode = data[ StudentFileContents.POSTAL_CODE_INDEX ]
            };
        }
    }
}
