using System.IO;
using KnowYourRoute.School.Contracts.Entities;
using Newtonsoft.Json;

namespace KnowYourRouteConsole.StaticMaps
{
    public class StudentStaticMapWriter
    {
        private string _staticMapDirectory;

        public StudentStaticMapWriter( string staticMapDirectory )
        {
            _staticMapDirectory = staticMapDirectory;
        }

        public void WriteToFile( Student student, byte[] staticMap )
        {
            var staticMapDirectory = getStaticMapDirectory();
            var file = new FileInfo( $"{staticMapDirectory}{student.ID}.png" );
            var fileStream = getFileStreamForFile( file );

            fileStream.Write( staticMap, 0, staticMap.Length );
        }

        // TODO: Redundant from StudentDirectionsResponseWriter
        private string getStaticMapDirectory()
        {
            return _staticMapDirectory.EndsWith( "\\" )
                ? _staticMapDirectory
                : _staticMapDirectory + "\\";
        }

        // TODO: Redundant from StudentDirectionsResponseWriter
        private FileStream getFileStreamForFile( FileInfo file )
        {
            FileStream fileStream;
            if (!File.Exists( file.FullName ))
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
