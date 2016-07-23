using System;
using KnowYourRoute.Common.Contracts.Exceptions;

namespace KnowYourRoute.Directions.Contracts.Exceptions
{
    public class InvalidPropertyException : KnowYourRouteException
    {
        public InvalidPropertyException( string message ) : base( message ) { }

        public InvalidPropertyException( string message, Exception innerException ) : base( message, innerException ){ }
    }
}
