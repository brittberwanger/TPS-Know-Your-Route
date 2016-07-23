
using System;
using KnowYourRoute.School.Contracts.Entities;
using KnowYourRoute.School.Contracts.Enumerations;

namespace KnowYourRoute.School.Data.Serializers
{
    public class BellTimesSerializer
    {
        public BellTimes ToBellTimes( string data )
        {
            var times = data.Split( '-' );
            return new BellTimes
            {
                SchoolStart = constructTime( times[ 0 ], Meridiem.AM ),
                SchoolEnd = constructTime( times[ 1 ], Meridiem.PM )
            };
            
        }

        private Time constructTime( string time, Meridiem meridiem )
        {
            // TODO: Handle if length < 2
            var minutesIndex = time.Length - 2;
            return new Time
            {
                // TODO: Handle bad data
                Hour = Convert.ToInt32( time.Substring( 0, minutesIndex ) ),
                Minute = Convert.ToInt32( time.Substring( minutesIndex ) ),
                Meridiem = meridiem
            };
        }
    }
}
