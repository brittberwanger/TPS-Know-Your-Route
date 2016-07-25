using System;
using KnowYourRoute.Directions.Contracts.Exceptions;
using KnowYourRoute.Directions.Contracts.Maps.Entities;
using KnowYourRoute.Directions.Contracts.Maps.Interfaces;
using KnowYourRoute.Directions.Contracts.Validation;
using KnowYourRoute.Directions.Service.Maps.Enumerations;

namespace KnowYourRoute.Directions.Service.Maps.Validation
{
    public class GoogleStaticMapRequestValidation : StaticMapRequestValidation
    {
        // TODO: Better way to handle nameof( path )?
        // TODO: Reusable error message strings
        // TODO: Add config field for premium subscription and use here for determining maxes
        public const int IMAGE_SIZE_MIN_HEIGHT = 1;
        public const int IMAGE_SIZE_MAX_HEIGHT_FREE = 640;
        public const int IMAGE_SIZE_MAX_HEIGHT_PREMIUM = 1024;

        public const int IMAGE_SIZE_MIN_WIDTH = 1;
        public const int IMAGE_SIZE_MAX_WIDTH_FREE = 640;
        public const int IMAGE_SIZE_MAX_WIDTH_PREMIUM = 1024;

        public const int SCALE_MIN = 1;
        public const int SCALE_MAX_FREE = 2;
        public const int SCALE_MAX_PREMIUM = 4;

        // TODO: Test MAP_PATH_WEIGHT_MAX
        public const int MAP_PATH_WEIGHT_MIN = 1;
        public const int MAP_PATH_WEIGHT_MAX = 20;

        private readonly StaticMapRequest _staticMapRequest;

        public GoogleStaticMapRequestValidation( StaticMapRequest staticMapRequest )
        {
            _staticMapRequest = staticMapRequest;
        }


        public void ValidateStaticMapRequest()
        {
            if ( _staticMapRequest == null )
                throw new InvalidRequestException( $"{nameof( _staticMapRequest )} cannot be null" );
        }
        

        public void ValidateImageSize()
        {
            ValidateStaticMapRequest();

            //if ( _staticMapRequest.ImageSize == default( ImageSize ) )
            //    throw new InvalidPropertyException( $"Must specify a valid {nameof( _staticMapRequest )}.{nameof( _staticMapRequest.ImageSize )}" );

            if ( _staticMapRequest.ImageSize.Width < IMAGE_SIZE_MIN_WIDTH )
                throw new InvalidPropertyException( $"{nameof( _staticMapRequest )}.{nameof( _staticMapRequest.ImageSize )}.{nameof( _staticMapRequest.ImageSize.Width )} is less than minimum size {IMAGE_SIZE_MIN_WIDTH}" );

            if ( _staticMapRequest.ImageSize.Width > IMAGE_SIZE_MAX_WIDTH_FREE )
                throw new InvalidPropertyException( $"{nameof( _staticMapRequest )}.{nameof( _staticMapRequest.ImageSize )}.{nameof( _staticMapRequest.ImageSize.Width )} is greater than maximum size {IMAGE_SIZE_MAX_WIDTH_FREE}" );

            if ( _staticMapRequest.ImageSize.Height < IMAGE_SIZE_MIN_HEIGHT )
                throw new InvalidPropertyException( $"{nameof( _staticMapRequest )}.{nameof( _staticMapRequest.ImageSize )}.{nameof( _staticMapRequest.ImageSize.Height )} is less than minimum size {IMAGE_SIZE_MIN_HEIGHT}" );

            if ( _staticMapRequest.ImageSize.Height > IMAGE_SIZE_MAX_HEIGHT_FREE )
                throw new InvalidPropertyException( $"{nameof( _staticMapRequest )}.{nameof( _staticMapRequest.ImageSize )}.{nameof( _staticMapRequest.ImageSize.Height )} is greater than maximum size {IMAGE_SIZE_MAX_HEIGHT_FREE}" );
        }


        public void ValidateScale()
        {
            ValidateStaticMapRequest();

            if ( _staticMapRequest.Scale < SCALE_MIN )
                throw new InvalidPropertyException( $"{nameof( _staticMapRequest )}.{nameof( _staticMapRequest.Scale )} is less than minimum {SCALE_MIN}" );

            if ( _staticMapRequest.Scale > SCALE_MAX_FREE )
                throw new InvalidPropertyException( $"{nameof( _staticMapRequest )}.{nameof( _staticMapRequest.Scale )} is greater than maximum {SCALE_MAX_FREE}" );
        }


        public void ValidateImageFormat()
        {
            ValidateStaticMapRequest();

            // TODO: What will this print if not a valid value?
            // TODO: Enumerate and list valid values
            if ( !Enum.IsDefined( typeof( ImageFormat ), _staticMapRequest.ImageFormat ) )
                throw new InvalidPropertyException( $"{nameof( _staticMapRequest )}.{nameof( _staticMapRequest.ImageFormat )} = {_staticMapRequest.ImageFormat} is not a valid image format." );
        }


        public void ValidateMapPath()
        {
            ValidateStaticMapRequest();

            if ( _staticMapRequest.MapPath == null )
                throw new InvalidPropertyException( $"{nameof( _staticMapRequest )} requires a valid {nameof( _staticMapRequest.MapPath )}" );

            if ( _staticMapRequest.MapPath.Weight < MAP_PATH_WEIGHT_MIN )
                throw new InvalidPropertyException( $"{nameof( _staticMapRequest )}.{nameof( _staticMapRequest.MapPath )}.{nameof( _staticMapRequest.MapPath.Weight )} is less than minimum {MAP_PATH_WEIGHT_MIN}" );

            if ( _staticMapRequest.MapPath.Weight > MAP_PATH_WEIGHT_MAX )
                throw new InvalidPropertyException( $"{nameof( _staticMapRequest )}.{nameof( _staticMapRequest.MapPath )}.{nameof( _staticMapRequest.MapPath.Weight )} is greater than maximum {MAP_PATH_WEIGHT_MAX}" );

            // TODO: What will this print if not a valid value?
            // TODO: Enumerate and list valid values
            if ( !Enum.IsDefined( typeof( MapFeatureColor ), _staticMapRequest.MapPath.Color ) )
                throw new InvalidPropertyException( $"{nameof( _staticMapRequest )}.{nameof( _staticMapRequest.MapPath )}.{nameof( _staticMapRequest.MapPath.Color )} = {_staticMapRequest.MapPath.Color} is not a valid color" );
        }
    }
}
