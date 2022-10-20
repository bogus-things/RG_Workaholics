using BepInEx.Configuration;
using BepInEx.IL2CPP;

namespace RGWorkaholics
{
    class Config
    {
        private const string SECTION_GENERAL = "General";

        private static ConfigEntry<bool> _enabled;
        internal static bool Enabled { get { return _enabled.Value; } }

        internal static void Init(BasePlugin plugin)
        {
            _enabled = plugin.Config.Bind(SECTION_GENERAL, "Enabled", true, "If enabled, all male characters will be present at their jobs after a time change (they can still choose to go home later, though)");
        }
    }
}
