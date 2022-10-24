namespace SF2022UserLib
{
    public static class Calculations
    {
        public static string[] AvailablePeriods(TimeSpan[] startTimes, int[] durations, TimeSpan beginWorkingTime, TimeSpan endWorkingTime, int consultationTime)
        {
            List<string> strings = new List<string>();
            for (TimeSpan i = beginWorkingTime; i <= endWorkingTime; i += TimeSpan.FromMinutes(consultationTime))
            {
                strings.Add(i.ToString());
            }

            return strings.ToArray();
        }

    }
}