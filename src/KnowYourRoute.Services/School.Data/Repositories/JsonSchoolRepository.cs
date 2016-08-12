using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using KnowYourRoute.School.Contracts.Entities;
using KnowYourRoute.School.Contracts.Interfaces;
using Newtonsoft.Json;

namespace KnowYourRoute.School.Data.Repositories
{
    public class JsonSchoolRepository : HighSchoolRepository
    {
        private string _filepath;

        private IEnumerable<HighSchool> _highSchools;

        public JsonSchoolRepository( string filepath )
        {
            _filepath = filepath;
            loadHighSchools();
        }

        // TODO: Make sure file exists and is valid
        private void loadHighSchools()
        {
            var json = File.ReadAllText( _filepath );
            _highSchools = JsonConvert.DeserializeObject<IEnumerable<HighSchool>>( json );
        }


        public IEnumerable<HighSchool> GetAllHighSchools()
        {
            return _highSchools;
        }

        public HighSchool GetHighSchoolByName( string name )
        {
            return _highSchools.FirstOrDefault( hs => hs.Name.Equals( name, StringComparison.OrdinalIgnoreCase ) );
        }
    }
}
