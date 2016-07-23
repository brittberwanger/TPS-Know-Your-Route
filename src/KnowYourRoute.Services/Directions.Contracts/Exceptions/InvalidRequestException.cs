using System;
using KnowYourRoute.Common.Contracts.Exceptions;

namespace KnowYourRoute.Directions.Contracts.Exceptions
{
    public class InvalidRequestException : KnowYourRouteException
    {
        public InvalidRequestException( string message ) : base( message ) { }

        public InvalidRequestException( string message, Exception innerException ) : base( message, innerException ){ }
    }
}
