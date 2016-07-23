using KnowYourRoute.School.Contracts.Interfaces;
using KnowYourRoute.School.Contracts.Entities;
using KnowYourRoute.Common.Contracts.Entities;
using KnowYourRoute.Common.Contracts.Enumerations;
using System;
using System.Collections.Generic;

namespace KnowYourRoute.School.Data.Repositories
{
    public class HardCodedSchoolRepository : HighSchoolRepository
    {

        private static HighSchool bookerTWashington = new HighSchool { Name = "Booker T Washington High School", GooglePlaceID = "ChIJNRQcThDstocRPDebu5YemR0", Coordinates = bookerTWashingtonCoordinates, Address = bookerTWashingtonAddress };
        private static Address bookerTWashingtonAddress = new Address { StreetAddress1 = "1514 E Zion St", City = "Tulsa", StateCode = StateCode.OK, PostalCode = "74106" };
        private static Coordinates bookerTWashingtonCoordinates = new Coordinates { Longitude = 95.9700144m, Latitude = 36.1876506m };

        private static HighSchool central = new HighSchool{ Name = "Central High School", GooglePlaceID = "ChIJFXDCHlPqtocRR2QwpmCeyUk", Coordinates = centralCoordinates, Address = centralAddress };
        private static Address centralAddress = new Address { StreetAddress1 = "3101 W Edison", City = "Tulsa", StateCode = StateCode.OK, PostalCode = "74127" };
        private static Coordinates centralCoordinates = new Coordinates {Longitude = -96.0271166m, Latitude = 36.162906m };

        private static HighSchool danielWebster = new HighSchool { Name = "Daniel Webster High School", GooglePlaceID = "ChIJ83vlPM6UtocRQmbSF4ZXIL4", Coordinates = danielWebsterCoordinates, Address = danielWebsterAddress };
        private static Address danielWebsterAddress = new Address { StreetAddress1 = "1919 W 40th St", City = "Tulsa", StateCode = StateCode.OK, PostalCode = "74107" };
        private static Coordinates danielWebsterCoordinates = new Coordinates { Longitude = -96.0141712m, Latitude = 36.1059567m };

        private static HighSchool eastCentral = new HighSchool { Name = "East Central High School", GooglePlaceID = "ChIJLTX5HxTztocROcRbOmA2mUw", Coordinates = eastCentralCoordinates, Address = eastCentralAddress };
        private static Address eastCentralAddress = new Address { StreetAddress1 = "12150 E 11th St", City = "Tulsa", StateCode = StateCode.OK, PostalCode = "74128" };
        private static Coordinates eastCentralCoordinates = new Coordinates { Longitude = -95.8408342m, Latitude = 36.1468751m };

        private static HighSchool mcClain = new HighSchool { Name = "McClain High School", GooglePlaceID = "ChIJzbeGU8jutocR6SB2lA5s1sU", Coordinates = mcClainCoordinates, Address = mcClainAddress };
        private static Address mcClainAddress = new Address { StreetAddress1 = "4929 N Peoria Ave", City = "Tulsa", StateCode = StateCode.OK, PostalCode = "74126" };
        private static Coordinates mcClainCoordinates = new Coordinates { Longitude = -95.9732124m, Latitude = 36.2249116m };

        private static HighSchool memorial = new HighSchool { Name = "Memorial High School", GooglePlaceID = "ChIJodOp44uStocRgFNXiNhacOY", Coordinates = memorialCoordinates, Address = memorialAddress };
        private static Address memorialAddress = new Address { StreetAddress1 = "5840 S Hudson", City = "Tulsa", StateCode = StateCode.OK, PostalCode = "74135" };
        private static Coordinates memorialCoordinates = new Coordinates { Longitude = -95.9146927m, Latitude = 36.0788739m };
        
        private static HighSchool nathanHale = new HighSchool { Name = "Nathan Hale High School", GooglePlaceID = "ChIJoQgADqfytocRPfIYSturbhE",Coordinates = nathanHaleCoordinates, Address = nathanHaleAddress };
        private static Address nathanHaleAddress = new Address { StreetAddress1 = "6960 E 21st St", City = "Tulsa", StateCode = StateCode.OK, PostalCode = "74129" };
        private static Coordinates nathanHaleCoordinates = new Coordinates { Longitude = -95.8970628m, Latitude = 36.1324199m };

        private static HighSchool thomasEdison = new HighSchool { Name = "Thomas Edison High School", GooglePlaceID = "EiQyOTA2IEUgNDFzdCBTdCwgVHVsc2EsIE9LIDc0MTA1LCBVU0E", Address = thomasEdisonAddress, Coordinates = thomasEdisonCoordinates };
        private static Address thomasEdisonAddress = new Address { StreetAddress1 = "2906 E 41st St", City = "Tulsa", StateCode = StateCode.OK, PostalCode = "74105" };
        private static Coordinates thomasEdisonCoordinates = new Coordinates { Longitude = -95.945766m, Latitude = 36.1042799m };
        
        private static HighSchool willRogers = new HighSchool { Name = "Will Rogers High School", GooglePlaceID = "ChIJXaeQLQTttocRHOGsQzFi7fo", Coordinates = willRogersCoordinates, Address = willRogersAddress };
        private static Address willRogersAddress = new Address { StreetAddress1 = "3909 E 5th Pl", City = "Tulsa", StateCode = StateCode.OK, PostalCode = "74112" };
        private static Coordinates willRogersCoordinates = new Coordinates { Longitude = -95.933252m, Latitude = 36.153701m, };

        public IEnumerable<HighSchool> GetAllHighSchools()
        {
            throw new NotImplementedException();
        }

        public HighSchool GetHighSchoolByName( string name )
        {
            throw new NotImplementedException();
        }
    }
}
