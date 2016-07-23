using System;

namespace KnowYourRoute.Common.Contracts.Exceptions
{
    public class KnowYourRouteException : Exception
    {
        public KnowYourRouteException( string message ) : base( message ) { }

        public KnowYourRouteException( string message, Exception innerException ) : base( message, innerException ) { }
    }
}
