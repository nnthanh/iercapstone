using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace IERSystem.BusinessLogic.Utils
{
    public static class DateTimeUtils
    {

        public static DateTime MinSqlTime = DateTime.Parse(SqlDateTime.MinValue.ToString());

        /// <summary>
        /// Replaces any date before 01.01.1753 with a Nullable of 
        /// DateTime with a value of null.
        /// </summary>
        /// <param name="date">Date to check</param>
        /// <returns>Input date if valid in the DB, or Null if date is 
        /// too early to be DB compatible.</returns>
        public static DateTime ToMinSqlTimeIfTooEarlyForDb(this DateTime date) {
            return (date >= (DateTime)SqlDateTime.MinValue) ? date : MinSqlTime;
        }
        
    }
}