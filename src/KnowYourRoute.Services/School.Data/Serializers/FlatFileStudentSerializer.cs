using System;
using KnowYourRoute.School.Contracts.Entities;
using System.Collections.Generic;
using System.Linq;
using KnowYourRoute.Common.Contracts.Entities;
using KnowYourRoute.Common.Contracts.Enumerations;
using KnowYourRoute.School.Contracts.Validators;

namespace KnowYourRoute.School.Data.Serializers
{
    public class FlatFileStudentSerializer
    {
        private StudentValidation _studentValidation;

        // TODO: For testing! Take out!
        public List<string> NullHighSchools = new List<string>();

        public FlatFileStudentSerializer( StudentValidation studentValidation )
        {
            _studentValidation = studentValidation;
        }

        public IEnumerable<Student> ToStudents( IEnumerable<string[]> data, Func<string, HighSchool> highSchoolFactory )
        {
            return data.Where( dataIsValid ).Select( s => toStudent( s, highSchoolFactory ) );
        }

        // TODO: Do validation here on the incoming data?
        private Student toStudent( string[] data, Func<string, HighSchool> highSchoolFactory )
        {
            return new Student
            {
                ID = data[ StudentFileContents.ID_INDEX ],
                HighSchool = highSchoolFactory( data[ StudentFileContents.HIGH_SCHOOL_INDEX ] ),
                HighSchoolName = data[ StudentFileContents.HIGH_SCHOOL_INDEX ],
                LastName = data[ StudentFileContents.LAST_NAME_INDEX ],
                FirstName = data[ StudentFileContents.FIRST_NAME_INDEX ],
                Address = constructAddress( data ),
                // TODO: Handle bad data
                GradeLevel = data[ StudentFileContents.GRADE_LEVEL_INDEX ],
                EmailAddress = data[ StudentFileContents.EMAIL_ADDRESS_INDEX ]
            };
        }

        private bool dataIsValid( string[] data )
        {
            return _studentValidation.StudentDataIsValid( data )
                   && _studentValidation.BellTimeIsValid( data )
                   && _studentValidation.PhysicalAddressIsValid( data )
                   && _studentValidation.EmailAddressIsValid( data );
        }

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
