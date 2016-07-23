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
        internal const int ID_INDEX = 0;
        internal const int BELL_TIME_INDEX = 1;
        internal const int HIGH_SCHOOL_INDEX = 2;
        internal const int LAST_NAME_INDEX = 3;
        internal const int FIRST_NAME_INDEX = 4;
        internal const int STREET_INDEX = 5;
        internal const int CITY_INDEX = 6;
        internal const int STATE_INDEX = 7;
        internal const int POSTAL_CODE_INDEX = 8;
        internal const int GRADE_LEVEL_INDEX = 9;

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
                ID = data[ ID_INDEX ],
                BellTimes = constructBellTime( data[ BELL_TIME_INDEX ] ),
                HighSchool = highSchoolFactory( data[ HIGH_SCHOOL_INDEX ] ),
                LastName = data[ LAST_NAME_INDEX ],
                FirstName = data[ FIRST_NAME_INDEX ],
                Address = constructAddress( data ),
                // TODO: Handle bad data
                GradeLevel = data[ GRADE_LEVEL_INDEX ]
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
                StreetAddress1 = data[ STREET_INDEX ],
                City = data[ CITY_INDEX ],
                // TODO: Handle bad data
                StateCode = (StateCode)Enum.Parse( typeof( StateCode ), data[ STATE_INDEX ] ),
                PostalCode = data[ POSTAL_CODE_INDEX ]
            };
        }
    }
}
