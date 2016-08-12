using System.IO;
using KnowYourRoute.Directions.Contracts.Routes.Entities;
using KnowYourRoute.School.Contracts.Entities;
using Newtonsoft.Json;

namespace KnowYourRouteConsole.DirectionsResponses
{
    public class StudentDirectionsResponseWriter
    {
        private string _directionsResponseDirectory;

        public StudentDirectionsResponseWriter( string directionsResponseDirectory )
        {
            _directionsResponseDirectory = directionsResponseDirectory;
        }

        public void WriteToFile( Student student, DirectionsResponse directionsResponse )
        {
            var directionsResponseDirectory = getDirectionsResponseDirectory();
            var file = new FileInfo( $"{directionsResponseDirectory}{student.ID}.json" );
            var fileStream = getFileStreamForFile( file );

            using ( var textWriter = new StreamWriter( fileStream ) )
            {
                textWriter.Write( JsonConvert.SerializeObject( directionsResponse, Formatting.Indented ) );
            }
        }

        // TODO: Redundant from StudentStaticMapWriter
        private string getDirectionsResponseDirectory()
        {
            return _directionsResponseDirectory.EndsWith( "\\" )
                ? _directionsResponseDirectory
                : _directionsResponseDirectory + "\\";
        }

        // TODO: Redundant from StudentStaticMapWriter
        private FileStream getFileStreamForFile( FileInfo file )
        {
            FileStream fileStream;
            if ( !File.Exists( file.FullName ) )
            {
                fileStream = File.Create( file.FullName );
            }
            else
            {
                fileStream = File.Open( file.FullName, FileMode.Truncate );
            }
            return fileStream;
        }
    }
}
