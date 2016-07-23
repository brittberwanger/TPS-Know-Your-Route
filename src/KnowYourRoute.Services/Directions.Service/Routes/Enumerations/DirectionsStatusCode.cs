namespace KnowYourRoute.Directions.Service.Routes.Enumerations
{
    public enum DirectionsStatusCode
    {
        Unspecified = 0,
        OK = 1,
        Not_Found = 2,
        Zero_Results = 3,
        Max_Waypoints_Exceeded = 4,
        Invalid_Request = 5,
        Over_Query_Limit = 6,
        Request_Denied = 7,
        Unknown_Error = 8
    }
}
