using KnowYourRoute.Directions.Service.Routes.Enumerations;
using System;
using KnowYourRoute.Directions.Contracts.Exceptions;
using KnowYourRoute.Directions.Contracts.Routes.Entities;
using KnowYourRoute.Directions.Contracts.Routes.Interfaces;
using KnowYourRoute.Directions.Contracts.Validation;

namespace KnowYourRoute.Directions.Service.Routes.Validation
{
    public class GoogleDirectionsRequestValidation : DirectionsRequestValidation
    {
        private readonly DirectionsRequest _directionsRequest;

        public GoogleDirectionsRequestValidation( DirectionsRequest directionsRequest )
        {
            _directionsRequest = directionsRequest;
        }

        public void ValidateDirectionsRequest()
        {
            if ( _directionsRequest == null )
                throw new InvalidRequestException( string.Format( ExceptionMessages.XCannotBeNull, nameof( _directionsRequest ) ) );
        }

        public void ValidateArrivalTime()
        {
            ValidateDirectionsRequest();

            // TODO: How do we want to validate What does Google do if neither departure/arrival time are specified?
            if ( _directionsRequest.ArrivalTime == default ( DateTime ) )
            {
                var invalidPropertyPath = $"{nameof( _directionsRequest )}.{nameof( _directionsRequest.ArrivalTime )}";
                throw new InvalidPropertyException( string.Format( ExceptionMessages.MustSpecifyAValidX, invalidPropertyPath ) );
            }
        }

        public void ValidateDepartureTime()
        {
            ValidateDirectionsRequest();

            // TODO: How do we want to validate What does Google do if neither departure/arrival time are specified?
            if ( _directionsRequest.DepartureTime == default ( DateTime ) )
            {
                var invalidPropertyPath = $"{nameof( _directionsRequest )}.{ nameof( _directionsRequest.DepartureTime )}";
                throw new InvalidPropertyException( string.Format( ExceptionMessages.MustSpecifyAValidX, invalidPropertyPath ) );
            }
                
        }

        public void ValidateDestinationLocation()
        {
            // TODO: Have to validate each individually, we only care if NONE are valid
            throw new NotImplementedException();
        }

        public void ValidateOriginLocation()
        {
            throw new NotImplementedException();
        }

        public void ValidateTransitRoutingPreferences()
        {
            ValidateDirectionsRequest();

            // TODO: What will this print if not a valid value?
            // TODO: Enumerate and list valid values
            if ( !Enum.IsDefined( typeof( TransitRoutingPreference ), _directionsRequest.TransitRoutingPreference ) )
            {
                var invalidPropertyPath = $"{nameof( _directionsRequest )}.{nameof( _directionsRequest.TransitRoutingPreference )}";
                var invalidPropertyValue = $"{_directionsRequest.TransitRoutingPreference}";
                var invalidType = $"{nameof( _directionsRequest.TransitRoutingPreference )}";

                throw new InvalidPropertyException( string.Format( ExceptionMessages.XEqualsYIsNotAValidZ, invalidPropertyPath, invalidPropertyValue, invalidType ) );
            }
        }

        public void ValidateTravelMode()
        {
            ValidateDirectionsRequest();

            // TODO: What will this print if not a valid value?
            // TODO: Enumerate and list valid values
            if ( !Enum.IsDefined( typeof( TravelMode ), _directionsRequest.TravelMode ) )
                throw new InvalidPropertyException( $"{nameof( _directionsRequest )}.{nameof( _directionsRequest.TravelMode )} = {_directionsRequest.TravelMode } is not a valid travel mode" );
        }
    }
}
