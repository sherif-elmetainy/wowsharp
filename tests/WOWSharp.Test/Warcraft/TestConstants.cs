using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WOWSharp.Warcraft;

namespace WOWSharp.Test.Warcraft
{
    public class TestConstants
    {
        public const string TestRealmName = "Kazzak";
        public const string TestRegionName = "EU";
        public const string TestCharacterName = "Grendiser";
        public const string TestGuildName = "Immortalis";
        public const string TestHunter = "Karkoor";
        public const ClassKey TestClass = ClassKey.Druid;
        public const Race TestRace = Race.Troll;
        public const CharacterGender TestGender = CharacterGender.Male;
        public const Skill TestProfession1 = Skill.Alchemy;
        public const Skill TestProfession2 = Skill.Leatherworking;

        public const string TestAuctionHouseRealm = "Echsenkessel"; // Need to test witha  low pop realm
    }
}
