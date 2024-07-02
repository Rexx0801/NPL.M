using System;
using System.Globalization;

namespace NPL.M.A005.Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Nhập thời gian: ");
            string input = Console.ReadLine();

            DateTime dateTime;
            if (DateTime.TryParseExact(input, new string[]
            {
                "dd/MM/yyyy"
            }, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime))
            {
                int workingDays = CountWorkingDays(dateTime);
                Console.WriteLine(workingDays);
            }
            else
            {
                Console.WriteLine("Chuỗi không hợp lệ.");
            }
        }

        static DateTime GetLastDayOfMonth(DateTime date)
        {
            int daysInMonth = DateTime.DaysInMonth(date.Year, date.Month);
            return new DateTime(date.Year, date.Month, daysInMonth);
        }

        static int CountWorkingDays(DateTime date)
        {
            int workingDays = 0;
            int daysInMonth = DateTime.DaysInMonth(date.Year, date.Month);
            for (int day = 1; day <= daysInMonth; day++)
            {
                DateTime currentDay = new DateTime(date.Year, date.Month, day);
                if (currentDay.DayOfWeek != DayOfWeek.Saturday && currentDay.DayOfWeek != DayOfWeek.Sunday)
                {
                    workingDays++;
                }
            }
            return workingDays;
        }
    }
}
