using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using KnowYourRoute.Directions.Contracts.Routes.Entities;
using Newtonsoft.Json;

namespace KnowYourRouteConsole.DirectionsResponses
{
    // TODO: Redundancies from StudentStaticMapRepository
    public class StudentDirectionsResponseRepository
    {
        private DateTime _lastAccessDateTime;

        private string _directionsResponseDirectory;

        private IList<StudentDirectionsResponse> _studentDirectionsResponses;

        public StudentDirectionsResponseRepository( string directionsResponseDirectory )
        {
            _directionsResponseDirectory = directionsResponseDirectory;
            loadStudentDirectionsResponses();
        }

        public StudentDirectionsResponse GetStudentDirectionsResponseForStudentId( string studentId )
        {
            refreshCollectionIfChanged();
            return _studentDirectionsResponses.FirstOrDefault( s => s.StudentId == studentId );
        }

        public IEnumerable<StudentDirectionsResponse> GetStudentDirectionsResponses()
        {
            refreshCollectionIfChanged();
            return _studentDirectionsResponses;
        }

        private void loadStudentDirectionsResponses()
        {
            var files = Directory.GetFiles( _directionsResponseDirectory ).Select( f => new FileInfo( f ) );
            _studentDirectionsResponses = new List<StudentDirectionsResponse>();

            foreach (var file in files.Where( isValidStudentDirectionsResponseFile ))
            {
                _studentDirectionsResponses.Add( new StudentDirectionsResponse
                {
                    StudentId = new string( file.Name.Take( file.Name.Length - 5 ).ToArray() ),
                    DirectionsResponse = JsonConvert.DeserializeObject<DirectionsResponse>( File.ReadAllText( file.FullName ) )
                } );
            }

            _lastAccessDateTime = DateTime.Now;
        }

        private bool isValidStudentDirectionsResponseFile( FileInfo file )
        {
            return file.Name.Take( file.Name.Length - 5 ).All( char.IsDigit ) && file.Extension == ".json";
        }

        private void refreshCollectionIfChanged()
        {
            if (Directory.GetLastWriteTime( _directionsResponseDirectory ) > _lastAccessDateTime)
                loadStudentDirectionsResponses();
        }
    }
}
