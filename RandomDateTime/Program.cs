using System;

namespace RandomDateTime
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                if (TryGetRandomDateTime(out var dateTime))
                {
                    Console.Write($"new DateTime({dateTime.Value.Year}, {dateTime.Value.Month}, {dateTime.Value.Day}, " +
                        $"{dateTime.Value.Hour}, {dateTime.Value.Minute}, {dateTime.Value.Second})");

                    Console.ReadKey();

                    Console.Clear();
                }
            }
        }

        private static bool TryGetRandomDateTime(out DateTime? dateTime)
        {
            var random = new Random();

            var currentYear = DateTime.Now.Year;

            var year = random.Next(currentYear - 30, currentYear);
            var month = random.Next(1, 12);
            var day = random.Next(1, 31);

            var hour = random.Next(0, 23);
            var minute = random.Next(0, 59);
            var second = random.Next(0, 59);

            try
            {
                dateTime = new DateTime(year, month, day, hour, minute, second);
            }
            catch (ArgumentOutOfRangeException)
            {
                dateTime = null;

                return false;
            }

            return true;
        }
    }
}
