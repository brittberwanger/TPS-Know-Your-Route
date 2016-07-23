using KnowYourRoute.School.Contracts.Entities;
using System.Collections.Generic;

namespace KnowYourRoute.School.Contracts.Interfaces
{
    public interface HighSchoolRepository
    {
        IEnumerable<HighSchool> GetAllHighSchools();

        HighSchool GetHighSchoolByName( string name );
    }
}
