﻿using System;
using System.Linq;
using WOWSharp.Warcraft;
using Xunit;

namespace WOWSharp.Test.Warcraft
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class RealmApi
    {
        [Fact]
        public void TestRealmsAsync()
        {
            var client = TestHelper.CreateDefaultWarcraftClient();
            var task = client.GetRealmStatusAsync();
            RealmStatusResponse response = task.Result;
            Assert.NotNull(response);
            Assert.True(new RealmStatusResponse().ToString().Contains('0'));
            Assert.NotNull(response.ToString());
            Assert.NotNull(response.Realms);
            Assert.NotEmpty(response.Realms);
            Assert.True(response.Realms.Any(r => r.IsPvp));
            Assert.True(response.Realms.Any(r => r.IsRP));
            Assert.True(response.Realms.All(r => r.Locale != null));
            Assert.True(response.Realms.All(r => r.Name != null));
            Assert.True(!response.Realms.Any(r => r.ToString() == null));
            Assert.True(response.Realms.All(r => r.Slug != null));
            Assert.True(response.Realms.All(r => r.BattleGroupName != null));
            Assert.True(response.Realms.Any(r => r.Status));
            Assert.True(response.Realms.All(r => r.TimeZone != null));
            Assert.True(response.Realms.Any(r => r.WinterGrasp != null));

            var tolBarad = response.Realms.Where(r => r.TolBarad != null
                                                      && r.Status).Select(r => r.TolBarad).FirstOrDefault();
            Assert.NotNull(tolBarad);
            Assert.True(tolBarad.AreaId > 0);
            Assert.True(tolBarad.ControllingFaction != Faction.Neutral);
            Assert.True(tolBarad.NextBattleTimeUtc.Year == DateTime.Now.Year);
            Assert.True(tolBarad.Status != PvpZoneStatus.Unknown);
        }
    }
}