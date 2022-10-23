using BepInEx.Logging;
using RG.User;

namespace RGWorkaholics
{
    class Util
    {
        private static ManualLogSource Log = RGWorkaholicsPlugin.Log;
        internal static int GetNextCycleIndex(Cycle cycle)
        {
            int dayOfWeek = (int)cycle.DayOfWeek; // 0-6 sun-sat
            int timezone = (int)cycle.TimeZone; // 0-1

            // shifts array is mon-sun, so need to do a shift left
            dayOfWeek -= 1;
            if (dayOfWeek < 0)
            {
                dayOfWeek = 6;
            }

            int nextIndex = (dayOfWeek * 2) + timezone + 1;

            return nextIndex == 14 ? 0 : nextIndex;
        }
    }
}
