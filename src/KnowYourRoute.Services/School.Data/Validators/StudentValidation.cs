using System;
using System.IO;
using KnowYourRoute.School.Data.Serializers;
using System.Linq;
using KnowYourRoute.Common.Contracts.Enumerations;

namespace KnowYourRoute.School.Data.Validators
{
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
                throw new InvalidDataException();
        }

        public void ValidateBellTime()
        {
            ValidateStudentData();

            var bellTimeData = _studentData[ FlatFileStudentSerializer.BELL_TIME_INDEX ].Split( '-' );
            if ( bellTimeData.Length != 2 || bellTimeData.Any( bt => bt.Length <= 2 ) || bellTimeData.Any( bt => !bt.All( char.IsNumber ) ))
                throw new InvalidDataException( $"{_studentData[ FlatFileStudentSerializer.ID_INDEX ]} ({_studentData[ FlatFileStudentSerializer.LAST_NAME_INDEX]}, {_studentData[ FlatFileStudentSerializer.FIRST_NAME_INDEX ]} has an invalid bell time: {_studentData[ FlatFileStudentSerializer.BELL_TIME_INDEX ]}. Must be in hmm-hmm format" );
        }


        public void ValidateAddress()
        {
            ValidateStudentData();

            StateCode stateCode;
            if ( !Enum.TryParse( _studentData[ FlatFileStudentSerializer.STATE_INDEX ], out stateCode ) )
                throw new InvalidDataException( $"{_studentData[ FlatFileStudentSerializer.ID_INDEX ]} ({_studentData[ FlatFileStudentSerializer.LAST_NAME_INDEX ]}, {_studentData[ FlatFileStudentSerializer.FIRST_NAME_INDEX ]} has an invalid state code: {_studentData[ FlatFileStudentSerializer.BELL_TIME_INDEX ]}. Must be a valid 2-character state code" );
            
            if ( stateCode != StateCode.OK )
                throw new InvalidDataException( $"{_studentData[ FlatFileStudentSerializer.ID_INDEX ]} ({_studentData[ FlatFileStudentSerializer.LAST_NAME_INDEX ]}, {_studentData[ FlatFileStudentSerializer.FIRST_NAME_INDEX ]} must have an Oklahoma address" );
        }
    }
}
