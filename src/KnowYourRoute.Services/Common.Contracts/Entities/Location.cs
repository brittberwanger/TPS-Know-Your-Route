namespace KnowYourRoute.Common.Contracts.Entities
{
    public class Location
    {
        public Address Address { get; set; }
        public Coordinates Coordinates { get; set; }
        public string PlaceId { get; set; }
    }
}