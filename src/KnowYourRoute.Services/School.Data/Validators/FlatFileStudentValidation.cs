using System;
using System.Collections.Generic;
using System.IO;
using KnowYourRoute.School.Data.Serializers;
using System.Linq;
using System.Text.RegularExpressions;
using KnowYourRoute.Common.Contracts.Enumerations;
using KnowYourRoute.School.Contracts.Validators;
using KnowYourRoute.School.Data.Errors;

namespace KnowYourRoute.School.Data.Validators
{
    public class FlatFileStudentValidation : StudentValidation
    {
        public IList<StudentDataError> StudentDataErrors { get; }

        public FlatFileStudentValidation()
        {
            StudentDataErrors = new List<StudentDataError>();
        }

        // TODO: Use this to determine if need to skip first record for column headers? Or actually check values?
        public bool StudentDataIsValid( string[] studentData )
        {
            if ( studentData.Length != 11 )
            {
                StudentDataErrors.Add( new StudentDataError( studentData, "Data is expected to contain 11 fields" ) );
                return false;
            }
            return true;
        }

        public bool BellTimeIsValid( string[] studentData )
        {
            StudentDataIsValid( studentData );

            var bellTimeData = studentData[ StudentFileContents.BELL_TIME_INDEX ].Split( '-' );

            if ( bellTimeIsInvalid( bellTimeData ) )
            {
                StudentDataErrors.Add( new StudentDataError( studentData, $"Invalid bell time: {studentData[ StudentFileContents.BELL_TIME_INDEX ]}. Must be in hmm-hmm format" ) );
                return false;
            }
            return true;
        }

        private bool bellTimeIsInvalid( string[] bellTimeData )
        {
            return bellTimeData.Length != 2
                   || bellTimeData.Any( bt => bt.Length <= 2 || bt.Length > 4 )
                   || bellTimeData.Any( bt => !bt.All( char.IsNumber ) );
        }


        public bool PhysicalAddressIsValid( string[] studentData )
        {
            StudentDataIsValid( studentData );

            StateCode stateCode;
            if ( !Enum.TryParse( studentData[ StudentFileContents.STATE_INDEX ], out stateCode ) )
            {
                StudentDataErrors.Add( new StudentDataError( studentData, $"Invalid state code: {studentData[ StudentFileContents.STATE_INDEX ]}. Must be a valid 2-character state code" ) );
                return false;
            }

            if ( stateCode != StateCode.OK )
            {
                StudentDataErrors.Add( new StudentDataError( studentData, "Must have an Oklahoma address" ) );
                return false;
            }

            return true;
        }

        public bool EmailAddressIsValid( string[] studentData )
        {
            var regex = new Regex( @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?" );

            if ( !regex.IsMatch( studentData[ StudentFileContents.EMAIL_ADDRESS_INDEX ] ) )
            {
                StudentDataErrors.Add( new StudentDataError( studentData, $"Invalid email address: {studentData[ StudentFileContents.EMAIL_ADDRESS_INDEX ]}" ) );
                return false;
            }
            return true;
        }
    }
}
