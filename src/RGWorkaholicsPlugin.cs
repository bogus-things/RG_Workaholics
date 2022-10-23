using BepInEx;
using BepInEx.IL2CPP;
using BepInEx.Logging;
using HarmonyLib;

namespace RGWorkaholics
{
    [BepInPlugin(GUID, PluginName, Version)]
    public class RGWorkaholicsPlugin : BasePlugin
    {
        public const string PluginName = "RG Workaholics";
        public const string GUID = "com.bogus.RGWorkaholics";
        public const string Version = "0.1.0";

        internal static new ManualLogSource Log;

        public override void Load()
        {
            Log = base.Log;
            RGWorkaholics.Config.Init(this);
            Harmony.CreateAndPatchAll(typeof(Hooks), GUID);
        }
    }
}
