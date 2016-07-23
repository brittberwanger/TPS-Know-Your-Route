namespace KnowYourRoute.Directions.Contracts.Validation
{
    public interface DirectionsRequestValidation
    {
        void ValidateDirectionsRequest();

        void ValidateArrivalTime();

        void ValidateDepartureTime();

        void ValidateOriginLocation();

        void ValidateDestinationLocation();

        void ValidateTransitRoutingPreferences();

        void ValidateTravelMode();
    }
}
