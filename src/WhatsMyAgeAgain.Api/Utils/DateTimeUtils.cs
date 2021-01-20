using System;

namespace WhatsMyAgeAgain.Api.Utils
{
    public class DateTimeUtils
    {
        static readonly DateTime _currentDateTime = DateTime.Now;

        public static double GetTotalCompletedDaysSinceBirthdate(DateTime birthDate) => 
            Math.Floor(_currentDateTime.Subtract(birthDate).TotalDays);

        public static double GetTotalCompletedMonthsSinceBirthdate(DateTime birthDate)
        {
            return Math.Floor(_currentDateTime.Subtract(birthDate).TotalDays / 
                (DateConsts.AVERAGE_NUMBER_OF_DAYS_PER_YEAR / DateConsts.TOTAL_MONTHS_OF_YEAR));
        }

        public static double GetTotalCompletedYearsSinceBirthdate(DateTime birthDate) => 
            Math.Floor(_currentDateTime.Subtract(birthDate).TotalDays / DateConsts.AVERAGE_NUMBER_OF_DAYS_PER_YEAR);

        public static double GetTotalCompletedDaysSinceLastBirthday(DateTime birthDate)
        {
            var days = GetTotalCompletedDaysSinceBirthdate(birthDate);
            return Math.Floor(Math.Floor(days) % DateConsts.AVERAGE_NUMBER_OF_DAYS_PER_YEAR);
        }

        public static double GetTotalCompletedMonthsSinceLastBirthday(DateTime birthDate)
        {
            var months = GetTotalCompletedMonthsSinceBirthdate(birthDate);
            return Math.Floor(months) % DateConsts.TOTAL_MONTHS_OF_YEAR;
        }
    }
}
