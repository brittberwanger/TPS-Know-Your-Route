using System;
using System.IO;
using KnowYourRoute.School.Data.Serializers;
using System.Linq;
using KnowYourRoute.Common.Contracts.Enumerations;

namespace KnowYourRoute.School.Data.Validators
{
    // TODO: Is student id always numeric?
    public class StudentValidation
    {
        private readonly string[] _studentData;


        public StudentValidation( string[] studentData )
        {
            _studentData = studentData;
        }   

        // TODO: Use this to determine if need to skip first record for column headers? Or actually check values?
        public void ValidateStudentData()
        {
            // TODO: Work on ACTUAL error message
            if ( _studentData.Length != 10 )
                throw new InvalidDataException( $"{nameof( _studentData )} is expected to contain 10 fields" );
        }

        public void ValidateBellTime()
        {
            ValidateStudentData();

            // TODO: Validaate bell time is less than 24:00 for both
            var bellTimeData = _studentData[ StudentFileContents.BELL_TIME_INDEX ].Split( '-' );
            if ( bellTimeData.Length != 2 || bellTimeData.Any( bt => bt.Length <= 2 || bt.Length > 4 ) || bellTimeData.Any( bt => !bt.All( char.IsNumber ) ))
                throw new InvalidDataException( $"Student {_studentData[ StudentFileContents.ID_INDEX ]} ({_studentData[ StudentFileContents.LAST_NAME_INDEX]}, {_studentData[ StudentFileContents.FIRST_NAME_INDEX ]}) has an invalid bell time: {_studentData[ StudentFileContents.BELL_TIME_INDEX ]}. Must be in hmm-hmm format" );
        }


        public void ValidateAddress()
        {
            ValidateStudentData();

            StateCode stateCode;
            if ( !Enum.TryParse( _studentData[ StudentFileContents.STATE_INDEX ], out stateCode ) )
                throw new InvalidDataException( $"Student {_studentData[ StudentFileContents.ID_INDEX ]} ({_studentData[ StudentFileContents.LAST_NAME_INDEX ]}, {_studentData[ StudentFileContents.FIRST_NAME_INDEX ]}) has an invalid state code: {_studentData[ StudentFileContents.BELL_TIME_INDEX ]}. Must be a valid 2-character state code" );
            
            if ( stateCode != StateCode.OK )
                throw new InvalidDataException( $"Student {_studentData[ StudentFileContents.ID_INDEX ]} ({_studentData[ StudentFileContents.LAST_NAME_INDEX ]}, {_studentData[ StudentFileContents.FIRST_NAME_INDEX ]}) must have an Oklahoma address" );
        }
    }
}
