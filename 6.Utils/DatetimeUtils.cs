using System;
using System.Collections.Generic;
using System.Text;

namespace Utils
{
    public class DatetimeUtils
    {
        private static char _datetimeSeparator = 'T';
        private static char _timeSeparator = ':';
        private static char _dateSeparator = '-';

        public static DateTime GetDateTime(String datetime)
        {
            String[] datetimeSplitted = datetime.Split(_datetimeSeparator);

            if (datetimeSplitted.Length < 2)
            {
                throw new FormatException();
            }

            String date = datetimeSplitted[0];
            String time = datetimeSplitted[1];

            String[] dateSplitted = date.Split(_dateSeparator);

            if (dateSplitted.Length < 3)
            {
                throw new FormatException();
            }

            String[] timeSplitted = time.Split(_timeSeparator);

            if (timeSplitted.Length < 2)
            {
                throw new FormatException();
            }

            int day = int.Parse(dateSplitted[0]);
            int month = int.Parse(dateSplitted[1]);
            int year = int.Parse(dateSplitted[2]);

            int hour = int.Parse(timeSplitted[0]);
            int minutes = int.Parse(timeSplitted[1]);
            int seconds = 0;

            DateTime formattedDateTime = new DateTime(year, month, day, hour, minutes, seconds);

            return formattedDateTime;
        }
    }
}
