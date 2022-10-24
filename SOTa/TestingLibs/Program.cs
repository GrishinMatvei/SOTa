TimeSpan[] startTimes = new TimeSpan[]
{
 TimeSpan.Parse("10:00"),
 TimeSpan.Parse("11:00"),
 TimeSpan.Parse("15:00"),
 TimeSpan.Parse("15:30"),
 TimeSpan.Parse("16:50")
};
int[] durations = new int[] { 60, 30, 10, 10, 40 };

TimeSpan beginWorkingTime = TimeSpan.Parse("8:00");
TimeSpan endWorkingTime = TimeSpan.Parse("18:00");
int consultationTime = 30;

string[] strs = SF2022UserLib.Calculations.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime);

foreach (string str in strs) Console.WriteLine(str);