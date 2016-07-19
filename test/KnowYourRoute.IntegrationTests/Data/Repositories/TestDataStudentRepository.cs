using KnowYourRoute.Common.Contracts.Entities;
using KnowYourRoute.Common.Contracts.Enumerations;
using KnowYourRoute.School.Contracts.Entities;
using KnowYourRoute.School.Contracts.Interfaces;
using System;
using System.Collections.Generic;

namespace KnowYourRoute.School.Data.Repositories
{
    public class TestDataStudentRepository : StudentRepository
    {
        public IEnumerable<Student> GetAllStudents()
        {
            throw new NotImplementedException();
        }

        public Student GetStudentByID( int id )
        {
            throw new NotImplementedException();
        }

        private static Address bookerTWashington1 = new Address { StreetAddress1 = "2000 N Columbia Ave", City = "Tulsa", StateCode = StateCode.OK, PostalCode = "74110" };
        private static Address bookerTWashington2 = new Address { StreetAddress1 = "1240 N Cheyenne Ave", City = "Tulsa", StateCode = StateCode.OK, PostalCode = "74106" };
        private static Address bookerTWashington3 = new Address { StreetAddress1 = "710 East 35th St N", City = "Tulsa", StateCode = StateCode.OK, PostalCode = "74106" };

        private static Address central1 = new Address { StreetAddress1 = "430 S 50th W Ave", City = "Tulsa", StateCode = StateCode.OK, PostalCode = "74127" };
        private static Address central2 = new Address { StreetAddress1 = "2530 W 38th St N", City = "Tulsa", StateCode = StateCode.OK, PostalCode = "74127" };
        private static Address central3 = new Address { StreetAddress1 = "1810 W Matthew Brady St", City = "Tulsa", StateCode = StateCode.OK, PostalCode = "74127" };

        private static Address danielWebster1 = new Address { StreetAddress1 = "2410 S Phoenix Ave", City = "Tulsa", StateCode = StateCode.OK, PostalCode = "74107" };
        private static Address danielWebster2 = new Address { StreetAddress1 = "4360 S St Louis Ave", City = "Tulsa", StateCode = StateCode.OK, PostalCode = "74105" };
        private static Address danielWebster3= new Address { StreetAddress1 = "3260 W 72nd St", City = "Tulsa", StateCode = StateCode.OK, PostalCode = "74132" };

        private static Address eastCentral1 = new Address { StreetAddress1 = "14610 E 12th St", City = "Tulsa", StateCode = StateCode.OK, PostalCode = "74108" };
        private static Address eastCentral2 = new Address { StreetAddress1 = "16300 E Newton St", City = "Tulsa", StateCode = StateCode.OK, PostalCode = "74116" };
        private static Address eastCentral3 = new Address { StreetAddress1 = "6530 E 5th Pl", City = "Tulsa", StateCode = StateCode.OK, PostalCode = "74112" };

        private static Address mcClain1 = new Address { StreetAddress1 = "300 West 46th Pl N", City = "Tulsa", StateCode = StateCode.OK, PostalCode = "74126" };
        private static Address mcClain2 = new Address { StreetAddress1 = "3520 East 32nd Pl N", City = "Tulsa", StateCode = StateCode.OK, PostalCode = "74115" };
        private static Address mcClain3 = new Address { StreetAddress1 = "2430 N Main St", City = "Tulsa", StateCode = StateCode.OK, PostalCode = "74106" };

        private static Address memorial1 = new Address { StreetAddress1 = "4600 East 57th Street", City = "Tulsa", StateCode = StateCode.OK, PostalCode = "74135" };
        private static Address memorial2 = new Address { StreetAddress1 = "7700 S 92nd E Ave", City = "Tulsa", StateCode = StateCode.OK, PostalCode = "74133" };
        private static Address memorial3 = new Address { StreetAddress1 = "8010 S Gary Ave", City = "Tulsa", StateCode = StateCode.OK, PostalCode = "74136" };

        private static Address nathanHale1 = new Address { StreetAddress1 = "6730 E 28th Pl", City = "Tulsa", StateCode = StateCode.OK, PostalCode = "74129" };
        private static Address nathanHale2 = new Address { StreetAddress1 = "2420 S Quebec Ave", City = "Tulsa", StateCode = StateCode.OK, PostalCode = "74114" };
        private static Address nathanHale3 = new Address { StreetAddress1 = "1200 S 76th E Ave", City = "Tulsa", StateCode = StateCode.OK, PostalCode = "74112" };

        private static Address thomasEdison1 = new Address { StreetAddress1 = "2650 E 58th St", City = "Tulsa", StateCode = StateCode.OK, PostalCode = "74105" };
        private static Address thomasEdison2 = new Address { StreetAddress1 = "1350 E 42nd Pl", City = "Tulsa", StateCode = StateCode.OK, PostalCode = "74105" };
        private static Address thomasEdison3 = new Address { StreetAddress1 = "1530 E 36th St", City = "Tulsa", StateCode = StateCode.OK, PostalCode = "74105" };

        private static Address willRogers1 = new Address { StreetAddress1 = "5320 E 5th Pl", City = "Tulsa", StateCode = StateCode.OK, PostalCode = "74112" };
        private static Address willRogers2 = new Address { StreetAddress1 = "125 Waverly Dr", City = "Tulsa", StateCode = StateCode.OK, PostalCode = "74104" };
        private static Address willRogers3 = new Address { StreetAddress1 = "710 N Marion Ave", City = "Tulsa", StateCode = StateCode.OK, PostalCode = "74115" };

        // TODO:Bus accross town, invalid data
        // TODO: Nearest bus stop way far away?
        // TODO: Slightly change addresses, remove spacing, and test accuracy
        // TODO: Add address 2 to some
    }
}
