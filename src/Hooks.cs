using BepInEx.Logging;
using HarmonyLib;
using Il2CppSystem.Collections.Generic;
using Illusion.Collections.Generic.Optimized;
using Manager;
using RG.Scripts;
using RG.User;

namespace RGWorkaholics
{
    class Hooks
    {
        private static ManualLogSource Log = RGWorkaholicsPlugin.Log;

        [HarmonyPrefix]
        [HarmonyPatch(typeof(Game), nameof(Game.PushForwardCycle))]
        private static void pushForwardCyclePre()
        {
            if (Config.Enabled)
            {
                Int32KeyDictionary<MapShiftData> assignments = Game.ActionCache._dicShiftAssignment;
                Cycle cycle = Game.UserFile.Cycle;
                foreach (KeyValuePair<int, MapShiftData> entry in assignments)
                {
                    MapShiftData data = entry.value;
                    foreach (ActorShiftData actorData in data._list)
                    {
                        actorData._shifts[Util.getNextCycleIndex(cycle)] = true;
                    }
                }
            }
        }
    }
}
