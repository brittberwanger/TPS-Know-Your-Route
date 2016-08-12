using System;
using System.Collections.Generic;
using KnowYourRoute.School.Contracts.Entities;
using KnowYourRoute.School.Contracts.Interfaces;
using KnowYourRoute.School.Data.Serializers;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using KnowYourRoute.School.Contracts.Validators;
using KnowYourRoute.School.Data.Validators;

namespace KnowYourRoute.School.Data.Repositories
{
    public class FlatFileStudentRepository : StudentRepository
    {
        private string _filepath;
        private HighSchoolRepository _highSchoolRepository;
        private FlatFileStudentSerializer _serializer;
        private IEnumerable<Student> _students;

        public FlatFileStudentRepository( string filepath, HighSchoolRepository highSchoolRepository, FlatFileStudentSerializer serailzer )
        {
            _filepath = filepath;
            _highSchoolRepository = highSchoolRepository;
            _serializer = serailzer;
            constructStudentEntities();
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _students;
        }

        public Student GetStudentByID( string id )
        {
            return _students.FirstOrDefault( s => s.ID == id );
        }

        private void constructStudentEntities()
        {
            var studentData = File.ReadAllLines( _filepath );
            // ONE POSSIBILITY: var parser = new TextFieldParser( csv )
            // TODO: split student data, skip first line if not serializable
            var tokenizedStudentData = studentData.Select( splitCsvWithCommasInData ).Skip( 1 );
            _students = _serializer.ToStudents( tokenizedStudentData, _highSchoolRepository.GetHighSchoolByName );
        }   


        private string[] splitCsvWithCommasInData( string input )
        {
            var csvRegex = new Regex( "(?:^|,)(\"(?:[^\"]+|\"\")*\"|[^,]*)", RegexOptions.Compiled );
            var stringList = new List<string>();

            foreach ( Match match in csvRegex.Matches( input ) )
                stringList.Add( match.Value.TrimStart( ',' ) );

            return stringList.ToArray();
        }
    }
}
