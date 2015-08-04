using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WOWSharp.Interfaces;
using WOWSharp.Warcraft;
using Xunit;

namespace WOWSharp.Test.Warcraft
{
    public class BattleGroup
    {
        /// <summary>
        ///   Tests get slug method
        /// </summary>
        [Fact]
        public void TestBattlegroupsAndSlugs()
        {
            var originalCulture = Thread.CurrentThread.CurrentCulture;
            foreach (var region in Region.AllRegions)
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo(region.SupportedLocales[0]);
                var client = TestHelper.CreateDefaultWarcraftClient();
                var allRealms = client.GetRealmStatusAsync().Result;
                foreach (var realm in allRealms.Realms)
                {
                    Assert.Equal(realm.Slug, WarcraftClient.GetRealmSlug(realm.Name));
                }
                var allBattlegroups = client.GetBattleGroupsAsync().Result;
                foreach (var battleGroup in allBattlegroups.BattleGroups)
                {
                    Assert.Equal(battleGroup.Slug, WarcraftClient.GetBattleGroupSlug(battleGroup.Name));
                }
            }
        }
    }
}
