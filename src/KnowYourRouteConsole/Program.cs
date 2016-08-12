using Microsoft.Extensions.Configuration;
using System.IO;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using Autofac;
using Autofac.Core;
using KnowYourRouteConsole.Configuration;
using KnowYourRoute.Common.Contracts.Entities;
using KnowYourRoute.Common.Contracts.Enumerations;
using KnowYourRoute.Directions.Contracts.Common.Configuration;
using KnowYourRoute.Directions.Contracts.Common.UriBuilders;
using KnowYourRoute.Directions.Contracts.Maps.Interfaces;
using KnowYourRoute.Directions.Contracts.Routes.Entities;
using KnowYourRoute.Directions.Contracts.Routes.Interfaces;
using KnowYourRoute.Directions.Service.Common.UriBuilders;
using KnowYourRoute.Directions.Service.Maps.Services;
using KnowYourRoute.Directions.Service.Routes.Enumerations;
using KnowYourRoute.Directions.Service.Routes.Services;
using KnowYourRoute.School.Contracts.Entities;
using KnowYourRoute.School.Contracts.Interfaces;
using KnowYourRoute.School.Contracts.Validators;
using KnowYourRoute.School.Data.Repositories;
using KnowYourRoute.School.Data.Serializers;
using KnowYourRoute.School.Data.Validators;
using KnowYourRouteConsole.DirectionsResponses;
using KnowYourRouteConsole.Mappers;
using KnowYourRouteConsole.StaticMaps;
using Npgsql;
using Dapper;
using KnowYourRouteConsole.Containers;

namespace KnowYourRouteConsole
{
    public class Program
    {
        // NOTE: 105 students w/o valid high schools 
            //TULSA LEARNING ACADEMY: 75
            //TULSA TECH CAREER ACADEMY: 28
            //DAVID L.MOSS: 2
        // NOTE: 241 students without valid home addresses for generating routes
        // TODO: Replace address w/ high school name in instructions? Or will Google Place ID give me this?
        public static void Main( string[] args )
        {
            var configuration = buildConfiguration();
            var container = buildContainer( configuration );

            var studentRepository = container.Resolve<StudentRepository>();
            var studentDirectionsResponseRepository = container.Resolve<StudentDirectionsResponseRepository>();

            var students = studentRepository.GetAllStudents();
            var studentsWithHighSchools = studentRepository.GetAllStudents().Where( s => s.HighSchool != null );
            var files = Directory.GetFiles( configuration[ "DirectionsOutputDirectory" ] );
            var filesWithoutRoutes = studentDirectionsResponseRepository.GetStudentDirectionsResponses().Where( d => d.DirectionsResponse.Routes == null || !d.DirectionsResponse.Routes.Any() );

            Console.WriteLine( $"Total Students: {students.Count()}" );
            Console.WriteLine( $"Students w/o HS: {students.Count() - studentsWithHighSchools.Count()}" );
            Console.WriteLine( $"Total Files: {files.Count()}" );
            Console.WriteLine( $"Files Without Routes: {filesWithoutRoutes.Count()}" );
        }
        
        private static IConfigurationRoot buildConfiguration()
        {
            var configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.SetBasePath( Directory.GetCurrentDirectory() + "\\Configuration\\Files" );
            configurationBuilder.AddJsonFile( "googlemaps.configuration.json" );
            configurationBuilder.AddJsonFile( "KnowYourRoute.configuration.json" );
            return configurationBuilder.Build();
        }

        private static IContainer buildContainer( IConfigurationRoot configuration )
        {
            return ContainerSetup.Build( configuration )
                .WithJsonHighSchoolRepository()
                .WithPostgresStudentRepository()
                .WithStudentDirectionsResponseClasses()
                .WithStudentStaticMapClasses()
                .WithMappers()
                .Build();
        }

        private static void generateAndSaveDirectionsAndMapsForStudents( IEnumerable<Student> students, IContainer container )
        {
            var studentDirectionsRequestMapper = container.Resolve<StudentDirectionsRequestMapper>();
            var directionsService = container.Resolve<DirectionsService>();
            var studentDirectionsResponseWriter = container.Resolve<StudentDirectionsResponseWriter>();
            var directionsStaticMapMapper = container.Resolve<DirectionsStaticMapRequestMapper>();
            var staticMapService = container.Resolve<StaticMapService>();
            var studentStaticMapWriter = container.Resolve<StudentStaticMapWriter>();

            var studentsWithDirectionRequests = students.Select( s => new { Student = s, DirectionsRequest = studentDirectionsRequestMapper.ToDirectionsRequest( s ) } );
            var studentsWithDirections =
                studentsWithDirectionRequests.Select(
                    s =>
                        new 
                        {
                            s.Student,
                            s.DirectionsRequest,
                            DirectionsResponse = directionsService.GetDirections( s.DirectionsRequest ).Result
                        } );

            studentsWithDirections.ToList().ForEach( s => studentDirectionsResponseWriter.WriteToFile( s.Student, s.DirectionsResponse ) );

            var studentWithDirectionsAndMapRequests =
                studentsWithDirections.AsParallel()
                    .Where( s => s.DirectionsResponse.Routes.Any() )
                    .Select(
                        s =>
                            new
                            {
                                s.Student,
                                s.DirectionsRequest,
                                s.DirectionsResponse,
                                StaticMapRequest = directionsStaticMapMapper.ToStaticMapRequest( s.DirectionsRequest, s.DirectionsResponse )
                            } );

            var studentsWithDirectionsAndMaps =
                studentWithDirectionsAndMapRequests.AsParallel().Select(
                    s =>
                        new
                        {
                            s.Student,
                            s.DirectionsRequest,
                            s.DirectionsResponse,
                            s.StaticMapRequest,
                            StaticMap = staticMapService.GetStaticMap( s.StaticMapRequest ).Result
                        } );

            studentsWithDirectionsAndMaps.AsParallel().ToList().ForEach( s => studentStaticMapWriter.WriteToFile( s.Student, s.StaticMap ) );
        }
    }
}

