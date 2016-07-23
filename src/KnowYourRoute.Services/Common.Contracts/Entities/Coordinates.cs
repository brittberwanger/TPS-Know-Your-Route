namespace KnowYourRoute.Common.Contracts.Entities
{
    public struct Coordinates
    {
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
        public bool IsValid { get; set; }
    }
}
