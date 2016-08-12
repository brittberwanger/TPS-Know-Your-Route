using System;
using KnowYourRoute.School.Contracts.Interfaces;
using KnowYourRoute.School.Contracts.Entities;
using KnowYourRoute.Common.Contracts.Entities;
using KnowYourRoute.Common.Contracts.Enumerations;
using System.Collections.Generic;
using System.Linq;
using KnowYourRoute.School.Contracts.Enumerations;
using KnowYourRoute.School.Data.Constants;

namespace KnowYourRoute.School.Data.Repositories
{
    public class HardCodedSchoolRepository : HighSchoolRepository
    {
        private static readonly IEnumerable<HighSchool> _highSchools;

        static HardCodedSchoolRepository()
        {
            _highSchools = new List<HighSchool>
            {
                _traice,
                _bookerTWashington,
                _central,
                _danielWebster,
                _eastCentral,
                _mcLain,
                _memorial,
                _nathanHale,
                _thomasEdison,
                _willRogers,
                _phoenixRising,
                _streetSchool,
                _tulsaMet,
                _margaretHudson
            };
        }

        public IEnumerable<HighSchool> GetAllHighSchools()
        {
            return _highSchools;
        }
        
        public HighSchool GetHighSchoolByName( string name )
        {
            return _highSchools.FirstOrDefault( hs => hs.Name.Equals( name, StringComparison.OrdinalIgnoreCase ) );
        }

        // TODO: GooglePlaceId
        private static readonly Address _traiceAddress = new Address { StreetAddress1 = "2740 E 41st St N", City = "Tulsa", StateCode = StateCode.OK, PostalCode = "74110" };
        private static readonly Coordinates _traiceCoordinates = new Coordinates { Longitude = -95.949905m, Latitude = 36.212454m };
        private static readonly BellTimes _traiceBellTimes = new BellTimes { SchoolStart = new Time { Hour = 9, Minute = 15, Meridiem = Meridiem.AM }, SchoolEnd = new Time { Hour = 4, Minute = 20, Meridiem = Meridiem.PM } };
        private static readonly HighSchool _traice = new HighSchool { Name = SchoolNames.TRAICE_NAME, Coordinates = _traiceCoordinates, Address = _traiceAddress, BellTimes = _traiceBellTimes };

        private static readonly Address _bookerTWashingtonAddress = new Address { StreetAddress1 = "1514 E Zion St", City = "Tulsa", StateCode = StateCode.OK, PostalCode = "74106" };
        private static readonly Coordinates _bookerTWashingtonCoordinates = new Coordinates { Longitude = 95.9700144m, Latitude = 36.1876506m };
        private static readonly BellTimes _bookerTWashingtonBellTimes = new BellTimes { SchoolStart = new Time { Hour = 8, Minute = 30, Meridiem = Meridiem.AM }, SchoolEnd = new Time { Hour = 3, Minute = 35, Meridiem = Meridiem.PM } };
        private static readonly HighSchool _bookerTWashington = new HighSchool { Name = SchoolNames.BOOKER_T_WASHINGTON_NAME, GooglePlaceID = "ChIJNRQcThDstocRPDebu5YemR0", Coordinates = _bookerTWashingtonCoordinates, Address = _bookerTWashingtonAddress, BellTimes = _bookerTWashingtonBellTimes };

        private static readonly Address _centralAddress = new Address { StreetAddress1 = "3101 W Edison", City = "Tulsa", StateCode = StateCode.OK, PostalCode = "74127" };
        private static readonly Coordinates _centralCoordinates = new Coordinates {Longitude = -96.0271166m, Latitude = 36.162906m };
        private static readonly BellTimes _centralBellTimes = new BellTimes { SchoolStart = new Time { Hour = 8, Minute = 30, Meridiem = Meridiem.AM }, SchoolEnd = new Time { Hour = 3, Minute = 35, Meridiem = Meridiem.PM } };
        private static readonly HighSchool _central = new HighSchool{ Name = SchoolNames.CENTRAL_NAME, GooglePlaceID = "ChIJFXDCHlPqtocRR2QwpmCeyUk", Coordinates = _centralCoordinates, Address = _centralAddress, BellTimes = _centralBellTimes };

        private static readonly Address _danielWebsterAddress = new Address { StreetAddress1 = "1919 W 40th St", City = "Tulsa", StateCode = StateCode.OK, PostalCode = "74107" };
        private static readonly Coordinates _danielWebsterCoordinates = new Coordinates { Longitude = -96.0141712m, Latitude = 36.1059567m };
        private static readonly BellTimes _danielWebsterBellTimes = new BellTimes { SchoolStart = new Time { Hour = 8, Minute = 30, Meridiem = Meridiem.AM }, SchoolEnd = new Time { Hour = 3, Minute = 35, Meridiem = Meridiem.PM } };
        private static readonly HighSchool _danielWebster = new HighSchool { Name = SchoolNames.DANIEL_WEBSTER_NAME, GooglePlaceID = "ChIJ83vlPM6UtocRQmbSF4ZXIL4", Coordinates = _danielWebsterCoordinates, Address = _danielWebsterAddress, BellTimes = _danielWebsterBellTimes };

        private static readonly Address _eastCentralAddress = new Address { StreetAddress1 = "12150 E 11th St", City = "Tulsa", StateCode = StateCode.OK, PostalCode = "74128" };
        private static readonly Coordinates _eastCentralCoordinates = new Coordinates { Longitude = -95.8408342m, Latitude = 36.1468751m };
        private static readonly BellTimes _eastCentralBellTimes = new BellTimes { SchoolStart = new Time { Hour = 8, Minute = 30, Meridiem = Meridiem.AM }, SchoolEnd = new Time { Hour = 3, Minute = 35, Meridiem = Meridiem.PM } };
        private static readonly HighSchool _eastCentral = new HighSchool { Name = SchoolNames.EAST_CENTRAL_NAME, GooglePlaceID = "ChIJLTX5HxTztocROcRbOmA2mUw", Coordinates = _eastCentralCoordinates, Address = _eastCentralAddress, BellTimes = _eastCentralBellTimes };

        private static readonly Address _mcLainAddress = new Address { StreetAddress1 = "4929 N Peoria Ave", City = "Tulsa", StateCode = StateCode.OK, PostalCode = "74126" };
        private static readonly Coordinates _mcLainCoordinates = new Coordinates { Longitude = -95.9732124m, Latitude = 36.2249116m };
        private static readonly BellTimes _mcLainBellTimes = new BellTimes { SchoolStart = new Time { Hour = 8, Minute = 30, Meridiem = Meridiem.AM }, SchoolEnd = new Time { Hour = 3, Minute = 35, Meridiem = Meridiem.PM } };
        private static readonly HighSchool _mcLain = new HighSchool { Name = SchoolNames.MCLAIN_NAME, GooglePlaceID = "ChIJzbeGU8jutocR6SB2lA5s1sU", Coordinates = _mcLainCoordinates, Address = _mcLainAddress, BellTimes = _mcLainBellTimes };

        private static readonly Address _memorialAddress = new Address { StreetAddress1 = "5840 S Hudson", City = "Tulsa", StateCode = StateCode.OK, PostalCode = "74135" };
        private static readonly Coordinates _memorialCoordinates = new Coordinates { Longitude = -95.9146927m, Latitude = 36.0788739m };
        private static readonly BellTimes _memorialBellTimes = new BellTimes { SchoolStart = new Time { Hour = 8, Minute = 30, Meridiem = Meridiem.AM }, SchoolEnd = new Time { Hour = 3, Minute = 35, Meridiem = Meridiem.PM } };
        private static readonly HighSchool _memorial = new HighSchool { Name = SchoolNames.MEMORIAL_NAME, GooglePlaceID = "ChIJodOp44uStocRgFNXiNhacOY", Coordinates = _memorialCoordinates, Address = _memorialAddress, BellTimes = _memorialBellTimes };

        private static readonly Address _nathanHaleAddress = new Address { StreetAddress1 = "6960 E 21st St", City = "Tulsa", StateCode = StateCode.OK, PostalCode = "74129" };
        private static readonly Coordinates _nathanHaleCoordinates = new Coordinates { Longitude = -95.8970628m, Latitude = 36.1324199m };
        private static readonly BellTimes _nathanHaleBellTimes = new BellTimes { SchoolStart = new Time { Hour = 8, Minute = 30, Meridiem = Meridiem.AM }, SchoolEnd = new Time { Hour = 3, Minute = 35, Meridiem = Meridiem.PM } };
        private static readonly HighSchool _nathanHale = new HighSchool { Name = SchoolNames.NATHAN_HALE_NAME, GooglePlaceID = "ChIJoQgADqfytocRPfIYSturbhE",Coordinates = _nathanHaleCoordinates, Address = _nathanHaleAddress, BellTimes = _nathanHaleBellTimes };

        private static readonly Address _thomasEdisonAddress = new Address { StreetAddress1 = "2906 E 41st St", City = "Tulsa", StateCode = StateCode.OK, PostalCode = "74105" };
        private static readonly Coordinates _thomasEdisonCoordinates = new Coordinates { Longitude = -95.945766m, Latitude = 36.1042799m };
        private static readonly BellTimes _thomasEdisonBellTimes = new BellTimes { SchoolStart = new Time { Hour = 8, Minute = 30, Meridiem = Meridiem.AM }, SchoolEnd = new Time { Hour = 3, Minute = 35, Meridiem = Meridiem.PM } };
        private static readonly HighSchool _thomasEdison = new HighSchool { Name = SchoolNames.THOMAS_EDISON_NAME, GooglePlaceID = "EiQyOTA2IEUgNDFzdCBTdCwgVHVsc2EsIE9LIDc0MTA1LCBVU0E", Address = _thomasEdisonAddress, Coordinates = _thomasEdisonCoordinates, BellTimes = _thomasEdisonBellTimes };

        private static readonly Address _willRogersAddress = new Address { StreetAddress1 = "3909 E 5th Pl", City = "Tulsa", StateCode = StateCode.OK, PostalCode = "74112" };
        private static readonly Coordinates _willRogersCoordinates = new Coordinates { Longitude = -95.933252m, Latitude = 36.153701m };
        private static readonly BellTimes _willRogersBellTimes = new BellTimes { SchoolStart = new Time { Hour = 8, Minute = 30, Meridiem = Meridiem.AM }, SchoolEnd = new Time { Hour = 3, Minute = 35, Meridiem = Meridiem.PM } };
        private static readonly HighSchool _willRogers = new HighSchool { Name = SchoolNames.WILL_ROGERS_NAME, GooglePlaceID = "ChIJXaeQLQTttocRHOGsQzFi7fo", Coordinates = _willRogersCoordinates, Address = _willRogersAddress, BellTimes = _willRogersBellTimes };

        // TODO: Bell Times!!
        private static readonly Address _phoenixRisingAddress = new Address { StreetAddress1 = "315 South Gilcrease Museum Rd", City = "Tulsa", StateCode = StateCode.OK, PostalCode = "74127" };
        private static readonly Coordinates _phoenixRisingCoordinates = new Coordinates { Longitude = -96.019233m, Latitude = 36.153526m };
        private static readonly BellTimes _phoenixRisingBellTimes = new BellTimes { SchoolStart = new Time { Hour = 8, Minute = 30, Meridiem = Meridiem.AM }, SchoolEnd = new Time { Hour = 3, Minute = 35, Meridiem = Meridiem.PM } };
        private static readonly HighSchool _phoenixRising = new HighSchool { Name = SchoolNames.PHOENIX_RISING_NAME, Coordinates = _phoenixRisingCoordinates, Address = _phoenixRisingAddress, BellTimes = _phoenixRisingBellTimes };

        private static readonly Address _streetSchoolAddress = new Address{ StreetAddress1 = "1135 S Yale Avenue", City = "Tulsa", StateCode = StateCode.OK, PostalCode = "74112" };
        private static readonly Coordinates _streetSchoolCoordinates = new Coordinates { Longitude = -95.922221m, Latitude = 36.146506m };
        private static readonly BellTimes _streetSchoolBellTimes = new BellTimes { SchoolStart = new Time { Hour = 8, Minute = 30, Meridiem = Meridiem.AM }, SchoolEnd = new Time { Hour = 2, Minute = 5, Meridiem = Meridiem.PM } };
        private static readonly HighSchool _streetSchool = new HighSchool { Name = SchoolNames.STREET_SCHOOL_NAME, Coordinates = _streetSchoolCoordinates, Address = _streetSchoolAddress, BellTimes = _streetSchoolBellTimes };

        private static readonly Address _tulsaMetAddress = new Address { StreetAddress1 = "6201 East Virgin Street", City = "Tulsa", StateCode = StateCode.OK, PostalCode = "74115" };
        private static readonly Coordinates _tulsaMetCoordinates = new Coordinates { Longitude = -95.907768m, Latitude = 36.184739m };
        private static readonly BellTimes _tulsaMetBellTimes = new BellTimes { SchoolStart = new Time { Hour = 9, Minute = 15, Meridiem = Meridiem.AM }, SchoolEnd = new Time { Hour = 4, Minute = 20, Meridiem = Meridiem.PM } };
        private static readonly HighSchool _tulsaMet = new HighSchool { Name = SchoolNames.TULSA_MET_HIGH_SCHOOL_NAME, Coordinates = _tulsaMetCoordinates, Address = _tulsaMetAddress, BellTimes = _tulsaMetBellTimes };

        private static readonly Address _margaretHudsonAddress = new Address { StreetAddress1 = "1136 South Allegheny Avenue", City = "Tulsa", StateCode = StateCode.OK, PostalCode = "74112" };
        private static readonly Coordinates _margaretHudsonCoordinates = new Coordinates { Longitude = -95.921895m, Latitude = 36.146876m };
        private static readonly BellTimes _margaretHudsonBellTimes = new BellTimes { SchoolStart = new Time { Hour = 9, Minute = 10, Meridiem = Meridiem.AM }, SchoolEnd = new Time { Hour = 3, Minute = 0, Meridiem = Meridiem.PM } };
        private static readonly HighSchool _margaretHudson = new HighSchool { Name = SchoolNames.MARGARET_HUDSON_NAME, Coordinates = _margaretHudsonCoordinates, Address = _margaretHudsonAddress, BellTimes = _margaretHudsonBellTimes};
    }
}
