namespace KnowYourRoute.Common.Contracts.Entities
{
    public struct Coordinates
    {
        public decimal LongitudeX { get; set; }
        public decimal LatitudeY { get; set; }

        public bool IsValid => LongitudeX != default( decimal ) && LatitudeY != default( decimal );
    }
}
