using BepInEx.Configuration;
using BepInEx.IL2CPP;
using Il2CppSystem.Collections.Generic;

namespace RGWorkaholics
{
    class Config
    {
        private const string SECTION_GENERAL = "General";
        private const string SECTION_OFFICE = "Office";
        private const string SECTION_CLINIC = "Clinic";
        private const string SECTION_SEMINAR = "Seminar";
        private const string SECTION_CLUB = "Club";
        private const string SECTION_CASINO = "Casino";
        private const string SECTION_NEET = "Living Room";


        private static ConfigEntry<bool> _enabled;
        internal static bool Enabled { get { return _enabled.Value; } }

        private static ConfigEntry<bool> _bossEnabled;
        internal static bool BossEnabled { get { return _bossEnabled.Value; } }

        private static ConfigEntry<bool> _colleagueEnabled;
        internal static bool ColleagueEnabled { get { return _colleagueEnabled.Value; } }

        private static ConfigEntry<bool> _officeJanitorEnabled;
        internal static bool OfficeJanitorEnabled { get { return _officeJanitorEnabled.Value; } }

        private static ConfigEntry<bool> _doctorEnabled;
        internal static bool DoctorEnabled { get { return _doctorEnabled.Value; } }

        private static ConfigEntry<bool> _outpatientEnabled;
        internal static bool OutpatientEnabled { get { return _outpatientEnabled.Value; } }

        private static ConfigEntry<bool> _inpatientEnabled;
        internal static bool InpatientEnabled { get { return _inpatientEnabled.Value; } }

        private static ConfigEntry<bool> _teacherEnabled;
        internal static bool TeacherEnabled { get { return _teacherEnabled.Value; } }

        private static ConfigEntry<bool> _studentEnabled;
        internal static bool StudentEnabled { get { return _studentEnabled.Value; } }

        private static ConfigEntry<bool> _semiJanitorEnabled;
        internal static bool SemiJanitorEnabled { get { return _semiJanitorEnabled.Value; } }

        private static ConfigEntry<bool> _clubManagerEnabled;
        internal static bool ClubManagerEnabled { get { return _clubManagerEnabled.Value; } }

        private static ConfigEntry<bool> _ownerEnabled;
        internal static bool OwnerEnabled { get { return _ownerEnabled.Value; } }

        private static ConfigEntry<bool> _fanEnabled;
        internal static bool FanEnabled { get { return _fanEnabled.Value; } }

        private static ConfigEntry<bool> _dealerEnabled;
        internal static bool DealerEnabled { get { return _dealerEnabled.Value; } }

        private static ConfigEntry<bool> _casinoManagerEnabled;
        internal static bool CasinoManagerEnabled { get { return _casinoManagerEnabled.Value; } }

        private static ConfigEntry<bool> _customerEnabled;
        internal static bool CustomerEnabled { get { return _customerEnabled.Value; } }

        private static ConfigEntry<bool> _familyEnabled;
        internal static bool FamilyEnabled { get { return _familyEnabled.Value; } }

        internal static void Init(BasePlugin plugin)
        {
            _enabled = plugin.Config.Bind(SECTION_GENERAL, "Enabled", true, "If enabled, all male characters will be present at their jobs after a time change (they can still choose to go home later, though)");

            _bossEnabled = plugin.Config.Bind(SECTION_OFFICE, "Boss", true, "Enable/disable overriding specific character's schedule");
            _colleagueEnabled = plugin.Config.Bind(SECTION_OFFICE, "Colleague", true, "Enable/disable overriding specific character's schedule");
            _officeJanitorEnabled = plugin.Config.Bind(SECTION_OFFICE, "Janitor", true, "Enable/disable overriding specific character's schedule");

            _doctorEnabled = plugin.Config.Bind(SECTION_CLINIC, "Doctor", true, "Enable/disable overriding specific character's schedule");
            _outpatientEnabled = plugin.Config.Bind(SECTION_CLINIC, "Outpatient", true, "Enable/disable overriding specific character's schedule");
            _inpatientEnabled = plugin.Config.Bind(SECTION_CLINIC, "Inpatient", true, "Enable/disable overriding specific character's schedule");

            _teacherEnabled = plugin.Config.Bind(SECTION_SEMINAR, "Teacher", true, "Enable/disable overriding specific character's schedule");
            _studentEnabled = plugin.Config.Bind(SECTION_SEMINAR, "Student", true, "Enable/disable overriding specific character's schedule");
            _semiJanitorEnabled = plugin.Config.Bind(SECTION_SEMINAR, "Janitor", true, "Enable/disable overriding specific character's schedule");

            _clubManagerEnabled = plugin.Config.Bind(SECTION_CLUB, "Manager", true, "Enable/disable overriding specific character's schedule");
            _ownerEnabled = plugin.Config.Bind(SECTION_CLUB, "Owner", true, "Enable/disable overriding specific character's schedule");
            _fanEnabled = plugin.Config.Bind(SECTION_CLUB, "Fan", true, "Enable/disable overriding specific character's schedule");

            _dealerEnabled = plugin.Config.Bind(SECTION_CASINO, "Dealer", true, "Enable/disable overriding specific character's schedule");
            _casinoManagerEnabled = plugin.Config.Bind(SECTION_CASINO, "Manager", true, "Enable/disable overriding specific character's schedule");
            _customerEnabled = plugin.Config.Bind(SECTION_CASINO, "Customer", true, "Enable/disable overriding specific character's schedule");

            _familyEnabled = plugin.Config.Bind(SECTION_NEET, "Family", true, "Enable/disable overriding specific character's schedule");
        }

        internal static Dictionary<string, bool> GetEnableStatus()
        {
            Dictionary<string, bool> status = new Dictionary<string, bool>();

            status.Add("上司", BossEnabled);
            status.Add("同僚", ColleagueEnabled);
            status.Add("清掃員", OfficeJanitorEnabled);

            status.Add("医師", DoctorEnabled);
            status.Add("通院患者", OutpatientEnabled);
            status.Add("入院患者", InpatientEnabled);

            status.Add("講師", TeacherEnabled);
            status.Add("学生", StudentEnabled);
            status.Add("用務員", SemiJanitorEnabled);

            status.Add("マネージャー", ClubManagerEnabled);
            status.Add("オーナー", OwnerEnabled);
            status.Add("ファン", FanEnabled);

            status.Add("ディーラー", DealerEnabled);
            status.Add("支配人", CasinoManagerEnabled);
            status.Add("客", CustomerEnabled);

            status.Add("家族", FamilyEnabled);

            return status;
        }
    }
}
