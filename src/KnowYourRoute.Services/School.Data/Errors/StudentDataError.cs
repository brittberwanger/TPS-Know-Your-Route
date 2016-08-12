using KnowYourRoute.School.Data.Serializers;

namespace KnowYourRoute.School.Data.Errors
{
    public class StudentDataError
    {
        private string[] _studentData;

        public string StudentID => _studentData[ StudentFileContents.ID_INDEX ];
        public string FirstName => _studentData[ StudentFileContents.FIRST_NAME_INDEX ];
        public string LastName => _studentData[ StudentFileContents.LAST_NAME_INDEX ];

        public string ErrorMessage;

        public StudentDataError( string[] studentData, string errorMessage )
        {
            _studentData = studentData;
            ErrorMessage = errorMessage;
        }
    }
}
