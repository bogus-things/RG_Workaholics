using BepInEx.Configuration;
using BepInEx.IL2CPP;
using System.Collections.Generic;

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
        private const string SECTION_SHOP = "Shop";
        private const string SECTION_INN = "Hot Spring Inn";

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

        private static ConfigEntry<bool> _shopkeeperEnabled;
        internal static bool ShopkeeperEnabled { get { return _shopkeeperEnabled.Value; } }

        private static ConfigEntry<bool> _shopCustomerEnabled;
        internal static bool ShopCustomerEnabled { get { return _shopCustomerEnabled.Value; } }

        private static ConfigEntry<bool> _bumEnabled;
        internal static bool BumEnabled { get { return _bumEnabled.Value; } }

        private static ConfigEntry<bool> _leaderEnabled;
        internal static bool LeaderEnabled { get { return _leaderEnabled.Value; } }

        private static ConfigEntry<bool> _guest1Enabled;
        internal static bool Guest1Enabled { get { return _guest1Enabled.Value; } }

        private static ConfigEntry<bool> _guest2Enabled;
        internal static bool Guest2Enabled { get { return _guest2Enabled.Value; } }

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

            _shopkeeperEnabled = plugin.Config.Bind(SECTION_SHOP, "Shopkeeper", true, "Enable/disable overriding specific character's schedule");
            _shopCustomerEnabled = plugin.Config.Bind(SECTION_SHOP, "Customer", true, "Enable/disable overriding specific character's schedule");
            _bumEnabled = plugin.Config.Bind(SECTION_SHOP, "Bum", true, "Enable/disable overriding specific character's schedule");

            _leaderEnabled = plugin.Config.Bind(SECTION_INN, "Shopkeeper", true, "Enable/disable overriding specific character's schedule");
            _guest1Enabled = plugin.Config.Bind(SECTION_INN, "Guest 1", true, "Enable/disable overriding specific character's schedule");
            _guest2Enabled = plugin.Config.Bind(SECTION_INN, "Guest 2", true, "Enable/disable overriding specific character's schedule");
        }

        internal static Dictionary<string, bool> GetEnableStatus()
        {
            Dictionary<string, bool> status = new Dictionary<string, bool>();

            status.Add("ill_rg_Default_male00", BossEnabled);
            status.Add("ill_rg_Default_male01", ColleagueEnabled);
            status.Add("ill_rg_Default_male02", OfficeJanitorEnabled);

            status.Add("ill_rg_Default_male03", DoctorEnabled);
            status.Add("ill_rg_Default_male04", OutpatientEnabled);
            status.Add("ill_rg_Default_male05", InpatientEnabled);

            status.Add("ill_rg_Default_male06", TeacherEnabled);
            status.Add("ill_rg_Default_male07", StudentEnabled);
            status.Add("ill_rg_Default_male08", SemiJanitorEnabled);

            status.Add("ill_rg_Default_male09", ClubManagerEnabled);
            status.Add("ill_rg_Default_male10", OwnerEnabled);
            status.Add("ill_rg_Default_male11", FanEnabled);

            status.Add("ill_rg_Default_male12", DealerEnabled);
            status.Add("ill_rg_Default_male13", CasinoManagerEnabled);
            status.Add("ill_rg_Default_male14", CustomerEnabled);

            status.Add("ill_rg_Default_male15", FamilyEnabled);

            status.Add("ill_rg_Default_male16", ShopkeeperEnabled);
            status.Add("ill_rg_Default_male17", ShopCustomerEnabled);
            status.Add("ill_rg_Default_male18", BumEnabled);

            status.Add("ill_rg_Default_male19", LeaderEnabled);
            status.Add("ill_rg_Default_male20", Guest1Enabled);
            status.Add("ill_rg_Default_male21", Guest2Enabled);

            return status;
        }
    }
}
