using RG.User;

namespace RGWorkaholics
{
    class Util
    {
        internal static int getNextCycleIndex(Cycle cycle)
        {
            int dayOfWeek = (int)cycle.DayOfWeek;
            int timezone = (int)cycle.TimeZone;

            // DayOfWeek index starts with sunday = 1,
            // so need to do some shifts
            if (dayOfWeek == 7)
            {
                dayOfWeek = 0;
            }
            else
            {
                dayOfWeek = dayOfWeek - 1;
            }

            int index = (dayOfWeek * 2) + timezone;
            int nextIndex = index + 1;

            return nextIndex == 14 ? 0 : nextIndex;
        }
    }
}
