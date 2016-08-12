using System.Data.Common;
using Autofac;
using Autofac.Core;
using KnowYourRoute.Directions.Contracts.Common.Configuration;
using KnowYourRoute.Directions.Contracts.Common.UriBuilders;
using KnowYourRoute.Directions.Contracts.Maps.Interfaces;
using KnowYourRoute.Directions.Contracts.Routes.Interfaces;
using KnowYourRoute.Directions.Service.Common.UriBuilders;
using KnowYourRoute.Directions.Service.Maps.Services;
using KnowYourRoute.Directions.Service.Routes.Services;
using KnowYourRoute.School.Contracts.Interfaces;
using KnowYourRoute.School.Contracts.Validators;
using KnowYourRoute.School.Data.Repositories;
using KnowYourRoute.School.Data.Serializers;
using KnowYourRoute.School.Data.Validators;
using KnowYourRouteConsole.Configuration;
using KnowYourRouteConsole.DirectionsResponses;
using KnowYourRouteConsole.Mappers;
using KnowYourRouteConsole.StaticMaps;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace KnowYourRouteConsole.Containers
{
    public static class ContainerSetup
    {
        public static FluentContainerSetup Build( IConfigurationRoot configuration )
        {
            return new FluentContainerSetup( configuration );
        }
    }

    public class FluentContainerSetup
    {
        private ContainerBuilder _containerBuilder;

        private IConfigurationRoot _configuration;

        public FluentContainerSetup( IConfigurationRoot configuration )
        {
            _containerBuilder = new ContainerBuilder();
            _configuration = configuration;
        }

        private FluentContainerSetup( ContainerBuilder containerBuilder, IConfigurationRoot configuration )
        {
            _containerBuilder = containerBuilder;
            _configuration = configuration;
        }

        public FluentContainerSetup WithHardCodedHighSchoolRepository()
        {
            _containerBuilder.RegisterType<HardCodedSchoolRepository>()
                .Named<HighSchoolRepository>( "HardCodedSchoolRepository" );

            return new FluentContainerSetup( _containerBuilder, _configuration );
        }

        public FluentContainerSetup WithJsonHighSchoolRepository()
        {
            _containerBuilder.RegisterType<JsonSchoolRepository>()
                .As<HighSchoolRepository>()
                .WithParameter( "filepath", _configuration[ "HighSchoolJsonFilePath" ] );

            return new FluentContainerSetup( _containerBuilder, _configuration );
        }

        public FluentContainerSetup WithFlatFileStudentRepository()
        {
            _containerBuilder.RegisterType<FlatFileStudentValidation>().As<StudentValidation>();

            _containerBuilder.RegisterType<FlatFileStudentSerializer>();

            _containerBuilder.RegisterType<FlatFileStudentRepository>()
                .As<StudentRepository>()
                .WithParameter( "filepath", _configuration[ "StudentDataFilepath" ] );

            return new FluentContainerSetup( _containerBuilder, _configuration );
        }

        public FluentContainerSetup WithPostgresStudentRepository()
        {
            _containerBuilder.RegisterType<NpgsqlConnection>()
                .As<DbConnection>()
                .WithParameter( "connectionString", _configuration[ "PostgresSchoolDataCS" ] );

            _containerBuilder.RegisterType<PostgresStudentRepository>().As<StudentRepository>();

            return new FluentContainerSetup( _containerBuilder, _configuration );
        }

        public FluentContainerSetup WithDirectionsServices()
        {
            _containerBuilder.Register( c => new GoogleMapsApiOptions { ApiKey = _configuration[ "GoogleApiKey" ] } )
                .As<ApiOptions>();

            _containerBuilder.RegisterType<GoogleUriParameterBuilder>().As<UriParameterBuilder>();

            _containerBuilder.RegisterType<GoogleDirectionsService>().As<DirectionsService>();

            _containerBuilder.RegisterType<GoogleStaticMapService>().As<StaticMapService>();

            return new FluentContainerSetup( _containerBuilder, _configuration );
        }

        public FluentContainerSetup WithMappers()
        {
            _containerBuilder.RegisterType<StudentDirectionsRequestMapper>();

            _containerBuilder.RegisterType<DirectionsStaticMapRequestMapper>();

            return new FluentContainerSetup( _containerBuilder, _configuration );
        }

        public FluentContainerSetup WithStudentDirectionsResponseClasses()
        {
            _containerBuilder.RegisterType<StudentDirectionsResponseWriter>()
                .WithParameter( "directionsResponseDirectory", _configuration[ "DirectionsOutputDirectory" ] );

            _containerBuilder.RegisterType<StudentDirectionsResponseRepository>()
                .WithParameter( "directionsResponseDirectory", _configuration[ "DirectionsOutputDirectory" ] );

            return new FluentContainerSetup( _containerBuilder, _configuration );
        }

        public FluentContainerSetup WithStudentStaticMapClasses()
        {
            _containerBuilder.RegisterType<StudentStaticMapWriter>()
                .WithParameter( "staticMapDirectory", _configuration[ "StaticMapsOutputDirectory" ] );

            _containerBuilder.RegisterType<StudentStaticMapRepository>()
                .WithParameter( "staticMapDirectory", _configuration[ "StaticMapsOutputDirectory" ] );

            return new FluentContainerSetup( _containerBuilder, _configuration );
        }

        public IContainer Build()
        {
            return _containerBuilder.Build();
        }
    }
}
