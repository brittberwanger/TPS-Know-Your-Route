using System.Collections.Generic;

namespace KnowYourRoute.Maps.Service.Entities
{
    public class Uri
    {
        private const string BASE_ADDRESS = @"https://maps.googleapis.com/maps/api/staticmap?";

        private IEnumerable<string> _parameters;

        public Uri( IEnumerable<string> parameters )
        {
            _parameters = parameters;
        }
    }
}
