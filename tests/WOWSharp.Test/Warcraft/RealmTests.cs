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
    public class RealmTests
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
            Assert.Contains("0", new RealmStatusResponse().ToString());
            Assert.NotNull(response.ToString());
            Assert.NotNull(response.Realms);
            Assert.NotEmpty(response.Realms);
            Assert.Contains(response.Realms, r => r.IsPvp);
            Assert.Contains(response.Realms, r => r.IsRP);
            Assert.DoesNotContain(response.Realms, r => r.Locale == null);
            Assert.DoesNotContain(response.Realms, r => r.Name == null);
            Assert.DoesNotContain(response.Realms, r => r.Slug == null);
            Assert.DoesNotContain(response.Realms, r => r.BattleGroupName == null);
            Assert.Contains(response.Realms, r => r.Status);
            Assert.DoesNotContain(response.Realms, r => r.TimeZone == null);
            Assert.DoesNotContain(response.Realms, r => r.WinterGrasp == null);

            var tolBarad = response.Realms.Where(r => r.TolBarad != null
                                                      && r.Status).Select(r => r.TolBarad).FirstOrDefault();
            Assert.NotNull(tolBarad);
            if (tolBarad != null)
            {
                Assert.True(tolBarad.AreaId > 0);
                Assert.NotEqual(Faction.Neutral, tolBarad.ControllingFaction);
                Assert.Equal(DateTimeOffset.Now.Year,  tolBarad.NextBattleTime.Year);
                Assert.NotEqual(PvpZoneStatus.Unknown, tolBarad.Status);
            }
        }

        
    }
}
