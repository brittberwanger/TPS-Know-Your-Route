using System;
using System.IO;
using NUnit.Framework;
using KnowYourRoute.School.Data.Validators;
using KnowYourRoute.School.Data.Serializers;

namespace KnowYourRoute.UnitTests.School.Data.Validators
{
    [TestFixture]
    public class StudentValidationTests
    {
        private const string STUDENT_ID = "123456";
        private const string FIRST_NAME = "Jane";
        private const string LAST_NAME = "Smith";

        [TestCase( 1 )]
        [TestCase( 9 )]
        [TestCase( 11 )]
        public void ValidateStudentData_ThrowsException_IfLengthNotEqualTo10( int arrayLength )
        {
            var expectedMessage = "_studentData is expected to contain 10 fields";

            var studentData = new string[ arrayLength ];
            var studentValidation = new FlatFileStudentValidation();
            
            var exception = Assert.Catch( () => studentValidation.StudentDataIsValid( studentData ) );

            validateException<InvalidDataException>( exception, expectedMessage );
        }


        [Test]
        public void ValidateStudentData_DoesNothing_IfLengthEquals10()
        {
            var studentData = new string[ 10 ];
            var studentValidation = new FlatFileStudentValidation();
            
            var testDelegate = new TestDelegate( () => studentValidation.StudentDataIsValid( studentData ) );

            Assert.DoesNotThrow( testDelegate );
        }

        
        [TestCase( "" )]
        [TestCase( "820330" )]
        [TestCase( "hmm-hmm" )]
        [TestCase( "820:330" )]
        [TestCase( "820-30" )]
        [TestCase( "820-00330" )]
        public void ValidateBellTime_ThrowsException_IfLengthNotEqualTo10( string bellTime )
        {
            var expectedMessage = $"Student 123456 (Smith, Jane) has an invalid bell time: {bellTime}. Must be in hmm-hmm format";

            var studentData = new string[ 10 ];
            addIdAndNameFieldsToArray( studentData );  
            studentData[ StudentFileContents.BELL_TIME_INDEX ] = bellTime;
            var studentValidation = new FlatFileStudentValidation();

            var exception = Assert.Catch( () => studentValidation.BellTimeIsValid( studentData ) );

            validateException<InvalidDataException>( exception, expectedMessage );           
        }


        [TestCase( "820-330" )]
        [TestCase( "0820-0330" )]
        public void ValidateBellTime_DoesNothing_IfBellTimeIsValid( string bellTime )
        {
            var studentData = new string[ 10 ];
            studentData[ StudentFileContents.BELL_TIME_INDEX ] = bellTime;
            var studentValidation = new FlatFileStudentValidation();

            var testDelegate = new TestDelegate( () => studentValidation.BellTimeIsValid( studentData ) );

            Assert.DoesNotThrow( testDelegate );
        }


        private void validateException<EType>( Exception exception, string expectedMessage )
        {
            Assert.IsNotNull( exception );
            Assert.IsInstanceOf<EType>( exception );
            Assert.That( expectedMessage, Is.EqualTo( exception.Message ) );
        }


        private void addIdAndNameFieldsToArray( string[] array )
        {
            array[ StudentFileContents.ID_INDEX ] = STUDENT_ID;
            array[ StudentFileContents.FIRST_NAME_INDEX ] = FIRST_NAME;
            array[ StudentFileContents.LAST_NAME_INDEX ] = LAST_NAME;
        }
    }    
}