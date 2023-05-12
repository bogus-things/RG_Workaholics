using BepInEx.Logging;
using HarmonyLib;
using System.Collections.Generic;
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
        private static void PushForwardCyclePre()
        {
            if (Config.Enabled)
            {
                Int32KeyDictionary<MapShiftData> assignments = Game.ActionCache._dicShiftAssignment;
                Cycle cycle = Game.UserFile.Cycle;
                int nextIndex = Util.GetNextCycleIndex(cycle);
                Dictionary<string, bool> enableStatus = Config.GetEnableStatus();
                for (int i = 0; i < assignments.Count; i++)
                {
                    MapShiftData assignment = assignments[i];
                    for (int j = 0; j < assignment._list.Count; j++)
                    {
                        ActorShiftData actorData = assignment._list[j];
                        if (enableStatus.TryGetValue(actorData.File, out bool enabled) && enabled)
                        {
                            actorData._shifts[nextIndex] = true;
                        }
                    }
                }
            }
        }
    }
}
