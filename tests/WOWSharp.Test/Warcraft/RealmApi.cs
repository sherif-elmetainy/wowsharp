#region LICENSE
// Copyright (C) 2015 by Sherif Elmetainy (Grendiser@Kazzak-EU)
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
#endregion

using System;
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
            task = client.GetRealmStatusAsync();
            RealmStatusResponse response2 = task.Result;
            Assert.Same(response, response2);
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
