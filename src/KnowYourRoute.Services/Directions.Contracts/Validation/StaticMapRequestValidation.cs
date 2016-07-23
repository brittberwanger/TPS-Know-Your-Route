namespace KnowYourRoute.Directions.Contracts.Validation
{
    public interface StaticMapRequestValidation
    {
        void ValidateStaticMapRequest();


        void ValidateImageSize();


        void ValidateScale();


        void ValidateImageFormat();


        void ValidateMapPath();
    }
}