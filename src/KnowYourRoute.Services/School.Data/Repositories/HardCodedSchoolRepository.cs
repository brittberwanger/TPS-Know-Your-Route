using KnowYourRoute.School.Contracts.Interfaces;
using KnowYourRoute.School.Contracts.Entities;
using KnowYourRoute.Common.Contracts.Entities;
using KnowYourRoute.Common.Contracts.Enumerations;
using System.Collections.Generic;
using System.Linq;
using KnowYourRoute.School.Data.Constants;
using KnowYourRoute.School.Data.Helpers;

namespace KnowYourRoute.School.Data.Repositories
{
    public class HardCodedSchoolRepository : HighSchoolRepository
    {
        private static readonly IEnumerable<HighSchool> _highSchools;

        private readonly HighSchoolNameMatcher _nameMatcher;

        static HardCodedSchoolRepository()
        {
            _highSchools = new List<HighSchool>
            {
                _traice,
                _bookerTWashington,
                _central,
                _danielWebster,
                _eastCentral,
                _mcClain,
                _memorial,
                _nathanHale,
                _thomasEdison,
                _willRogers
            };
        }

        public HardCodedSchoolRepository( HighSchoolNameMatcher nameMatcher )
        {
            _nameMatcher = nameMatcher;
        }

        public IEnumerable<HighSchool> GetAllHighSchools()
        {
            return _highSchools;
        }
        
        public HighSchool GetHighSchoolByName( string name )
        {
            return _highSchools.FirstOrDefault( hs => _nameMatcher.NameMatches( hs, name ) );
        }

        // TODO: GooglePlaceId
        private static readonly Address _traiceAddress = new Address { StreetAddress1 = "2740 E 41st St N", City = "Tulsa", StateCode = StateCode.OK, PostalCode = "74110", IsValid = true };
        private static readonly Coordinates _traiceCoordinates = new Coordinates { Longitude = -95.949905m, Latitude = 36.212454m };
        private static readonly HighSchool _traice = new HighSchool { Name = SchoolNames.TRAICE_NAME, Coordinates = _traiceCoordinates, Address = _traiceAddress };

        private static readonly Address _bookerTWashingtonAddress = new Address { StreetAddress1 = "1514 E Zion St", City = "Tulsa", StateCode = StateCode.OK, PostalCode = "74106", IsValid = true };
        private static readonly Coordinates _bookerTWashingtonCoordinates = new Coordinates { Longitude = 95.9700144m, Latitude = 36.1876506m, IsValid = true };
        private static readonly HighSchool _bookerTWashington = new HighSchool { Name = SchoolNames.BOOKER_T_WASHINGTON_NAME, GooglePlaceID = "ChIJNRQcThDstocRPDebu5YemR0", Coordinates = _bookerTWashingtonCoordinates, Address = _bookerTWashingtonAddress };

        private static readonly Address _centralAddress = new Address { StreetAddress1 = "3101 W Edison", City = "Tulsa", StateCode = StateCode.OK, PostalCode = "74127", IsValid = true };
        private static readonly Coordinates _centralCoordinates = new Coordinates {Longitude = -96.0271166m, Latitude = 36.162906m, IsValid = true };
        private static readonly HighSchool _central = new HighSchool{ Name = SchoolNames.CENTRAL_NAME, GooglePlaceID = "ChIJFXDCHlPqtocRR2QwpmCeyUk", Coordinates = _centralCoordinates, Address = _centralAddress };

        private static readonly Address _danielWebsterAddress = new Address { StreetAddress1 = "1919 W 40th St", City = "Tulsa", StateCode = StateCode.OK, PostalCode = "74107", IsValid = true };
        private static readonly Coordinates _danielWebsterCoordinates = new Coordinates { Longitude = -96.0141712m, Latitude = 36.1059567m, IsValid = true };
        private static readonly HighSchool _danielWebster = new HighSchool { Name = SchoolNames.DANIEL_WEBSTER_NAME, GooglePlaceID = "ChIJ83vlPM6UtocRQmbSF4ZXIL4", Coordinates = _danielWebsterCoordinates, Address = _danielWebsterAddress };

        private static readonly Address _eastCentralAddress = new Address { StreetAddress1 = "12150 E 11th St", City = "Tulsa", StateCode = StateCode.OK, PostalCode = "74128", IsValid = true };
        private static readonly Coordinates _eastCentralCoordinates = new Coordinates { Longitude = -95.8408342m, Latitude = 36.1468751m, IsValid = true };
        private static readonly HighSchool _eastCentral = new HighSchool { Name = SchoolNames.EAST_CENTRAL_NAME, GooglePlaceID = "ChIJLTX5HxTztocROcRbOmA2mUw", Coordinates = _eastCentralCoordinates, Address = _eastCentralAddress };

        private static readonly Address _mcClainAddress = new Address { StreetAddress1 = "4929 N Peoria Ave", City = "Tulsa", StateCode = StateCode.OK, PostalCode = "74126", IsValid = true };
        private static readonly Coordinates _mcClainCoordinates = new Coordinates { Longitude = -95.9732124m, Latitude = 36.2249116m, IsValid = true };
        private static readonly HighSchool _mcClain = new HighSchool { Name = SchoolNames.MCCLAIN_NAME, GooglePlaceID = "ChIJzbeGU8jutocR6SB2lA5s1sU", Coordinates = _mcClainCoordinates, Address = _mcClainAddress };

        private static readonly Address _memorialAddress = new Address { StreetAddress1 = "5840 S Hudson", City = "Tulsa", StateCode = StateCode.OK, PostalCode = "74135", IsValid = true };
        private static readonly Coordinates _memorialCoordinates = new Coordinates { Longitude = -95.9146927m, Latitude = 36.0788739m, IsValid = true };
        private static readonly HighSchool _memorial = new HighSchool { Name = SchoolNames.MEMORIAL_NAME, GooglePlaceID = "ChIJodOp44uStocRgFNXiNhacOY", Coordinates = _memorialCoordinates, Address = _memorialAddress };

        private static readonly Address _nathanHaleAddress = new Address { StreetAddress1 = "6960 E 21st St", City = "Tulsa", StateCode = StateCode.OK, PostalCode = "74129", IsValid = true };
        private static readonly Coordinates _nathanHaleCoordinates = new Coordinates { Longitude = -95.8970628m, Latitude = 36.1324199m, IsValid = true };
        private static readonly HighSchool _nathanHale = new HighSchool { Name = SchoolNames.NATHAN_HALE_NAME, GooglePlaceID = "ChIJoQgADqfytocRPfIYSturbhE",Coordinates = _nathanHaleCoordinates, Address = _nathanHaleAddress };

        private static readonly Address _thomasEdisonAddress = new Address { StreetAddress1 = "2906 E 41st St", City = "Tulsa", StateCode = StateCode.OK, PostalCode = "74105", IsValid = true };
        private static readonly Coordinates _thomasEdisonCoordinates = new Coordinates { Longitude = -95.945766m, Latitude = 36.1042799m, IsValid = true };
        private static readonly HighSchool _thomasEdison = new HighSchool { Name = SchoolNames.THOMAS_EDISON_NAME, GooglePlaceID = "EiQyOTA2IEUgNDFzdCBTdCwgVHVsc2EsIE9LIDc0MTA1LCBVU0E", Address = _thomasEdisonAddress, Coordinates = _thomasEdisonCoordinates };

        private static readonly Address _willRogersAddress = new Address { StreetAddress1 = "3909 E 5th Pl", City = "Tulsa", StateCode = StateCode.OK, PostalCode = "74112", IsValid = true };
        private static readonly Coordinates _willRogersCoordinates = new Coordinates { Longitude = -95.933252m, Latitude = 36.153701m, IsValid = true };
        private static readonly HighSchool _willRogers = new HighSchool { Name = SchoolNames.WILL_ROGERS_NAME, GooglePlaceID = "ChIJXaeQLQTttocRHOGsQzFi7fo", Coordinates = _willRogersCoordinates, Address = _willRogersAddress };
    }
}
