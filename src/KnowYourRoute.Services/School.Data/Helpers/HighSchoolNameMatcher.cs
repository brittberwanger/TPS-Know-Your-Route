using System;
using KnowYourRoute.School.Contracts.Entities;
using System.Linq;
using KnowYourRoute.School.Data.Constants;

namespace KnowYourRoute.School.Data.Helpers
{
    // TODO: Make high school and name fields and pass in from constructor
    public class HighSchoolNameMatcher
    {
        private static readonly string[] _mcClainAliases = { "mcclain", "mclain" };
        private static readonly string[] _thomasEdisonAliases = { "thomas", "edison" };
        private static readonly string[] _nathanHaleAliases = { "nathan", "hale" };
        private static readonly string[] _danielWebsterAliases = { "daniel", "webster" };

        public bool NameMatches( HighSchool highSchool, string name )
        {
            return nameMatches( highSchool, name );
        }

        private bool nameMatches( HighSchool highSchool, string name )
        {
            var firstNameOfHighSchool = highSchool.Name.Split( ' ' ).First();

            if ( name.StartsWith( firstNameOfHighSchool, StringComparison.OrdinalIgnoreCase ) )
                return true;

            return isMcClain( highSchool, name ) || isEdison( highSchool, name ) || isNathanHale( highSchool, name ) || isDanielWebster( highSchool, name );
        }

        private bool isMcClain( HighSchool highSchool, string studentHighSchoolName )
        {
            return highSchool.Name == SchoolNames.MCCLAIN_NAME && _mcClainAliases.Any( alias => studentHighSchoolName.StartsWith( alias, StringComparison.OrdinalIgnoreCase ) );
        }

        private bool isEdison( HighSchool highSchool, string studentHighSchoolName )
        {
            return highSchool.Name == SchoolNames.THOMAS_EDISON_NAME && _thomasEdisonAliases.Any( alias => studentHighSchoolName.StartsWith( alias, StringComparison.OrdinalIgnoreCase ) );
        }

        private bool isNathanHale( HighSchool highSchool, string studentHighSchoolName )
        {
            return highSchool.Name == SchoolNames.NATHAN_HALE_NAME && _nathanHaleAliases.Any( alias => studentHighSchoolName.StartsWith( alias, StringComparison.OrdinalIgnoreCase ) );
        }

        private bool isDanielWebster( HighSchool highSchool, string studentHighSchoolName )
        {
            return highSchool.Name == SchoolNames.DANIEL_WEBSTER_NAME && _danielWebsterAliases.Any( alias => studentHighSchoolName.StartsWith( alias, StringComparison.OrdinalIgnoreCase ) );
        }
    }
}
