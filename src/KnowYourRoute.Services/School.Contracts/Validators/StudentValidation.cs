namespace KnowYourRoute.School.Contracts.Validators
{
    public interface StudentValidation
    {
        bool StudentDataIsValid( string[] studentData );

        bool BellTimeIsValid( string[] studentData );

        bool PhysicalAddressIsValid( string[] studentData );

        bool EmailAddressIsValid( string[] studentData );
    }
}