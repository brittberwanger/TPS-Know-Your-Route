using KnowYourRoute.Common.Contracts.Enumerations;
using System;

namespace KnowYourRoute.Common.Contracts.Entities
{
    public class Address
    {
        public string StreetAddress1 { get; set; }
        public string StreetAddress2 { get; set; }
        public string City { get; set; }
        public StateCode StateCode { get; set; }
        public string PostalCode { get; set; }

        public bool IsValid => isValid();

        private bool isValid()
        {
            return !string.IsNullOrWhiteSpace( StreetAddress1 )
                && !string.IsNullOrWhiteSpace( City )
                && StateCode != StateCode.Unspecified
                && !string.IsNullOrWhiteSpace( PostalCode );
        }
    }
}
