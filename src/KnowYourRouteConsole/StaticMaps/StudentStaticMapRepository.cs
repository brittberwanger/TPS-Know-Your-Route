using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace KnowYourRouteConsole.StaticMaps
{
    // TODO: Redundancies from StudentDirectionsResponseRepository
    public class StudentStaticMapRepository
    {
        private DateTime _lastAccessDateTime;

        private string _staticMapDirectory;

        private IList<StudentStaticMap> _studentStaticMaps;

        public StudentStaticMapRepository( string staticMapDirectory )
        {
            _staticMapDirectory = staticMapDirectory;
            loadStudentStaticMaps();
        }

        public StudentStaticMap GetStudentStaticMapForStudentId( string studentId )
        {
            refreshCollectionIfChanged();
            return _studentStaticMaps.FirstOrDefault( s => s.StudentId == studentId );
        }

        public IEnumerable<StudentStaticMap> GetStudentStaticMaps()
        {
            refreshCollectionIfChanged();
            return _studentStaticMaps;
        }

        private void loadStudentStaticMaps()
        {
            var files = Directory.GetFiles( _staticMapDirectory ).Select( f => new FileInfo( f ) );
            _studentStaticMaps = new List<StudentStaticMap>();

            foreach (var file in files.Where( isValidStudentStaticMapFile ))
            {
                _studentStaticMaps.Add( new StudentStaticMap
                {
                    StudentId = new string( file.Name.Take( file.Name.Length - 5 ).ToArray() ),
                    StaticMap = File.ReadAllBytes( file.FullName )
                } );
            }

            _lastAccessDateTime = DateTime.Now;
        }

        private bool isValidStudentStaticMapFile( FileInfo file )
        {
            return file.Name.Take( file.Name.Length - 5 ).All( char.IsDigit ) && file.Extension == ".json";
        }

        private void refreshCollectionIfChanged()
        {
            if ( Directory.GetLastWriteTime( _staticMapDirectory ) > _lastAccessDateTime )
                loadStudentStaticMaps();
        }
    }
}
