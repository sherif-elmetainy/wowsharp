using System.Linq;
using WOWSharp.Warcraft;
using Xunit;

namespace WOWSharp.Test.Warcraft
{
    public class CharacterTests
    {
        /// <summary>
        /// Test character professions
        /// </summary>
        [Fact]
        public void TestCharacterProfessions()
        {
            var client = TestHelper.CreateDefaultWarcraftClient();
            var character = client.GetCharacterAsync(TestConstants.TestRealmName, TestConstants.TestCharacterName, CharacterFields.Professions).Result;

            Assert.NotNull(character.Professions);
            Assert.Null(character.Achievements);
            Assert.Null(character.Items);
            Assert.Null(character.Guild);
            Assert.Null(character.Progression);
            Assert.Null(character.Appearance);
            Assert.Null(character.Pvp);
            Assert.Null(character.Stats);

            Assert.NotNull(character.Professions.PrimaryProfessions);
            Assert.Equal(2, character.Professions.PrimaryProfessions.Count);
            Assert.Contains(character.Professions.PrimaryProfessions, p => p.Id == TestConstants.TestProfession1);
            Assert.Contains(character.Professions.PrimaryProfessions, p => p.Id == TestConstants.TestProfession2);
            foreach (var profession in character.Professions.PrimaryProfessions)
            {
                Assert.NotNull(profession.Name);
                Assert.True(profession.Rank >= 525);
                Assert.True(profession.Maximum >= 525);
                Assert.NotNull(profession.Recipes);
                Assert.True(profession.Recipes.Count > 0);
                Assert.NotNull(profession.Icon);
                Assert.NotNull(profession.ToString());
            }
            Assert.NotNull(character.Professions.ToString());

            Assert.NotNull(character.Professions.SecondaryProfessions);
            Assert.Equal(4, character.Professions.SecondaryProfessions.Count);

            foreach (var profession in character.Professions.SecondaryProfessions)
            {
                Assert.NotNull(profession.Name);
                Assert.True(profession.Rank >= 525);
                Assert.True(profession.Maximum >= 525);
                if (profession.Id == Skill.Cooking || profession.Id == Skill.FirstAid)
                {
                    Assert.NotNull(profession.Recipes);
                    Assert.True(profession.Recipes.Count > 0);
                }
                Assert.NotNull(profession.Icon);
            }
        }

        /// <summary>
        /// Test achievements
        /// </summary>
        [Fact]
        public void TestCharacterAchievements()
        {
            var client = TestHelper.CreateDefaultWarcraftClient();
            var character = client.GetCharacterAsync(TestConstants.TestRealmName, TestConstants.TestCharacterName,
                                                CharacterFields.Achievements).Result;
            Assert.Null(character.Professions);
            Assert.NotNull(character.Achievements);
            Assert.Null(character.Items);
            Assert.Null(character.Titles);
            Assert.Null(character.Mounts);
            Assert.Null(character.PetSlots);
            Assert.Null(character.Pets);
            Assert.Null(character.HunterPets);
            Assert.Null(character.Guild);
            Assert.Null(character.Progression);
            Assert.Null(character.Appearance);
            Assert.Null(character.Pvp);
            Assert.Null(character.CompletedQuestIds);
            Assert.Null(character.Reputations);
            Assert.Null(character.Stats);
            Assert.Null(character.Talents);

            Assert.NotNull(character.Achievements.AchievementsCompleted);
            Assert.NotEqual(character.Achievements.AchievementsCompleted.Count, 0);
            Assert.NotNull(character.Achievements.Criteria);
            Assert.NotNull(character.Achievements.AchievementsCompletedDates);
            Assert.NotNull(character.Achievements.CriteriaCreatedDates);
            Assert.NotNull(character.Achievements.CriteriaDates);
            Assert.NotNull(character.Achievements.CriteriaQuantity);

            var a = new Achievements();
            Assert.Null(a.AchievementsCompletedDates);
            Assert.Null(a.CriteriaCreatedDates);
            Assert.Null(a.CriteriaDates);
        }

        /// <summary>
        /// Test companions
        /// </summary>
        [Fact]
        public void TestCharacterCompanions()
        {
            var client = TestHelper.CreateDefaultWarcraftClient();
            var character = client.GetCharacterAsync(TestConstants.TestRealmName, TestConstants.TestCharacterName, CharacterFields.Pets).Result;
            Assert.NotNull(character.Pets);
            Assert.NotNull(character.Pets.Collected);
            Assert.NotEqual(character.Pets.CollectedCount, 0);
            Assert.NotEqual(character.Pets.NotCollectedCount, 0);
            Assert.Equal(character.Pets.CollectedCount, character.Pets.Collected.Count);
        }

        /// <summary>
        /// Test mounts
        /// </summary>
        [Fact]
        public void TestCharacterMounts()
        {
            var client = TestHelper.CreateDefaultWarcraftClient();
            var character = client.GetCharacterAsync(TestConstants.TestRealmName, TestConstants.TestCharacterName,
                                                CharacterFields.Mounts).Result;
            Assert.NotNull(character.Mounts);
            Assert.NotNull(character.Mounts.Collected);
            Assert.NotEqual(0, character.Mounts.Collected.Count);
            Assert.NotEqual(0, character.Mounts.NotCollectedCount);
            Assert.NotEqual(0, character.Mounts.CollectedCount);
            Assert.Equal(character.Mounts.CollectedCount, character.Mounts.Collected.Count);
        }

        /// <summary>
        /// Test stats
        /// </summary>
        [Fact]
        public void TestCharacterStats()
        {
            var client = TestHelper.CreateDefaultWarcraftClient();
            var character = client.GetCharacterAsync(TestConstants.TestRealmName, TestConstants.TestCharacterName,
                                                CharacterFields.Stats).Result;
            Assert.NotNull(character.Stats);
            Assert.True(character.Stats.Stamina > 0);
            Assert.True(character.Stats.Agility > 0);
            Assert.True(character.Stats.Armor > 0);
            Assert.True(character.Stats.Intellect > 0);
            Assert.True(character.Stats.Spirit > 0);
            Assert.True(character.Stats.Strength > 0);
        }

        /// <summary>
        /// Test reputation
        /// </summary>
        [Fact]
        public void TestCharacterReputation()
        {
            var client = TestHelper.CreateDefaultWarcraftClient();
            var character = client.GetCharacterAsync(TestConstants.TestRealmName, TestConstants.TestCharacterName,
                                                CharacterFields.Reputation).Result;
            Assert.NotNull(character.Reputations);
            Assert.True(character.Reputations.Count > 0);

            Assert.True(character.Reputations.Any(o => o.Standing == Standing.Exalted));
            Assert.False(character.Reputations.Any(o => o.Maximum == 0));
            Assert.False(character.Reputations.Any(o => o.Id == 0));
            Assert.False(character.Reputations.Any(o => string.IsNullOrEmpty(o.Name)));
            Assert.True(character.Reputations.Any(o => o.Value > 0));
            Assert.NotNull(character.Reputations[0].ToString());
        }

        /// <summary>
        /// Test titles
        /// </summary>
        [Fact]
        public void TestCharacterTitles()
        {
            var client = TestHelper.CreateDefaultWarcraftClient();
            var character = client.GetCharacterAsync(TestConstants.TestRealmName, TestConstants.TestCharacterName,
                                                CharacterFields.Titles).Result;
            Assert.NotNull(character.Titles);
            Assert.True(character.Titles.Count > 0);

            Assert.True(character.Titles.Any(o => o.IsSelected));
            Assert.False(character.Titles.Any(o => o.Id == 0));
            Assert.False(character.Titles.Any(o => string.IsNullOrEmpty(o.Name)));
            Assert.NotNull(character.Titles[0].ToString());
        }

        /// <summary>
        /// Test spec
        /// </summary>
        [Fact]
        public void TestCharacterSpec()
        {
            var client = TestHelper.CreateDefaultWarcraftClient();
            var character = client.GetCharacterAsync(TestConstants.TestRealmName, TestConstants.TestCharacterName,
                                                CharacterFields.Talents).Result;
            Assert.NotNull(character.Talents);
            Assert.True(character.Talents.Any(t => t.IsSelected));
            foreach (var ct in character.Talents)
            {
                Assert.NotNull(ct.CalculatorGlyphs);
                Assert.NotNull(ct.CalculatorSpecialization);
                Assert.NotNull(ct.CalculatorTalent);
                Assert.NotNull(ct.Glyphs);
                Assert.NotNull(ct.Build);
                Assert.NotNull(ct.Build.Count > 0);
                Assert.True(ct.Build.Any(t => t.Column > 0));
                Assert.True(ct.Build.Any(t => t.Tier > 0));
                Assert.NotNull(ct.Build[0].Spell);
                Assert.True(ct.Build.Any(t => t.Spell.CastTime != null));
                Assert.NotNull(ct.Build[0].Spell.Description);
                Assert.NotNull(ct.Build[0].Spell.Icon);
                Assert.NotNull(ct.Build[0].Spell.Name);
                Assert.NotNull(ct.Build[0].Spell.ToString());
                //Assert.True(ct.Build.Any(t => t.Spell.Range != null));
                //Assert.NotNull(ct.Build[0].Spell.Subtext);
                Assert.True(ct.Build[0].Spell.Id > 0);
                Assert.NotNull(ct.ToString());
                Assert.NotNull(ct.Specialization);
                Assert.NotNull(ct.Specialization.Name);
                Assert.NotEqual(CharacterRoles.None, ct.Specialization.Role);
                Assert.NotNull(ct.Specialization.Order > 0);
                Assert.NotNull(ct.Specialization.BackgroundImage);
                Assert.NotNull(ct.Specialization.Description);
                Assert.NotNull(ct.Specialization.Icon);
                Assert.NotNull(ct.Specialization.ToString());
                Assert.NotNull(ct.Glyphs);
                Assert.NotNull(ct.Glyphs.MajorGlyphs);
                Assert.NotNull(ct.Glyphs.MinorGlyphs);
                Assert.True(ct.Glyphs.MajorGlyphs.Count > 0);
                Assert.True(ct.Glyphs.MinorGlyphs.Count > 0);
                Assert.NotNull(ct.Glyphs.MajorGlyphs[0].Name);
                Assert.NotNull(ct.Glyphs.MajorGlyphs[0].Icon);
                Assert.True(ct.Glyphs.MajorGlyphs[0].GlyphId > 0);
                Assert.True(ct.Glyphs.MajorGlyphs[0].ItemId > 0);
                Assert.Equal(ct.Glyphs.MajorGlyphs[0].Name, ct.Glyphs.MajorGlyphs[0].ToString());
            }
        }

        /// <summary>
        /// Test progression
        /// </summary>
        [Fact]
        public void TestCharacterProgression()
        {
            var client = TestHelper.CreateDefaultWarcraftClient();
            var character = client.GetCharacterAsync(TestConstants.TestRealmName, TestConstants.TestCharacterName,
                                                CharacterFields.Progression).Result;
            Assert.NotNull(character.Progression);
            Assert.NotNull(character.Progression.Raids);
            Assert.NotEqual(0, character.Progression.Raids.Count);

            foreach (var raid in character.Progression.Raids)
            {
                Assert.NotNull(raid);
                Assert.True(raid.Id > 0);
                Assert.NotNull(raid.Name);
                Assert.NotNull(raid.Bosses);
                Assert.NotEqual(0, raid.Bosses.Count);

                foreach (var boss in raid.Bosses)
                {
                    Assert.NotNull(boss);
                    Assert.NotNull(boss.Name);
                    // The assert is removed because some fights have no Id like Gunship Battle or Will of the Emperor
                    //Assert.True(boss.Id > 0);
                    if (boss.Name.Contains("Halfus"))
                    {
                        Assert.True(boss.NormalKills > 0);
                        Assert.True(boss.HeroicKills > 0);
                    }
                    if (boss.Name.Contains("Elegon"))
                    {
                        Assert.True(boss.NormalKills > 1);
                        Assert.True(boss.LfrKills > 1);
                        Assert.True(boss.HeroicKills >= 1);
                        Assert.True(boss.HeroicFirstKill.HasValue);
                        Assert.True(boss.NormalFirstKill.HasValue);
                        Assert.True(boss.LfrFirstKill.HasValue);
                    }
                    if (boss.Name.Contains("Garrosh Hellscream"))
                    {
                        Assert.True(boss.FlexKills.HasValue);
                    }
                }
            }
        }

        /// <summary>
        /// Test guild
        /// </summary>
        [Fact]
        public void TestCharacterGuild()
        {
            var client = TestHelper.CreateDefaultWarcraftClient();
            var character = client.GetCharacterAsync(TestConstants.TestRealmName, TestConstants.TestCharacterName,
                                                CharacterFields.Guild).Result;
            Assert.Null(character.Professions);
            Assert.Null(character.Achievements);
            Assert.Null(character.Items);

            Assert.Null(character.Items);
            Assert.Null(character.Titles);
            Assert.Null(character.Mounts);
            Assert.Null(character.CompletedQuestIds);
            Assert.Null(character.Reputations);
            Assert.Null(character.Stats);
            Assert.Null(character.Talents);

            Assert.NotNull(character.Guild);
            Assert.Null(character.Progression);
            Assert.Null(character.Appearance);
            Assert.Null(character.Pvp);
            Assert.Null(character.Stats);

            Assert.True(character.Guild.AchievementPoints > 0);
            Assert.Equal(TestConstants.TestGuildName, character.Guild.Name, true);
            Assert.Equal(TestConstants.TestRealmName, character.Guild.Realm, true);
            Assert.NotNull(character.Guild.Emblem);
            Assert.NotNull(character.Guild.Emblem.BackgroundColor);
            Assert.NotNull(character.Guild.Emblem.BorderColor);
            Assert.NotNull(character.Guild.Emblem.IconColor);
            Assert.True(character.Guild.Emblem.Icon >= 0);
            Assert.True(character.Guild.Emblem.Border >= 0);

            Assert.NotNull(character.Guild.ToString());
        }

        /// <summary>
        ///   Tests get character
        /// </summary>
        [Fact]
        public void TestCharacterAllFields()
        {
            var client = TestHelper.CreateDefaultWarcraftClient();
            var character = client.GetCharacterAsync(TestConstants.TestRealmName, TestConstants.TestCharacterName, CharacterFields.All).Result;
            Assert.NotNull(character);
            Assert.NotNull(character.Professions);
            Assert.NotNull(character.Achievements);
            Assert.NotNull(character.Items);
            Assert.NotNull(character.Titles);
            Assert.NotNull(character.Mounts);
            Assert.NotNull(character.Pets);
            Assert.NotNull(character.PetSlots);
            Assert.NotNull(character.Guild);
            Assert.NotNull(character.Progression);
            Assert.NotNull(character.Appearance);
            Assert.NotNull(character.Pvp);
            Assert.NotNull(character.CompletedQuestIds);
            Assert.NotNull(character.Reputations);
            Assert.NotNull(character.Stats);
            Assert.NotNull(character.Talents);
            Assert.NotNull(character.Statistics);

            Assert.Equal(TestConstants.TestClass, character.Class);
            Assert.True(character.Level >= 85);
            Assert.Equal(TestConstants.TestRace, character.Race);
            Assert.True(character.AchievementPoints > 0);
            Assert.Equal(TestConstants.TestGender, character.Gender);

            Assert.Equal(TestConstants.TestRealmName, character.Realm, true);
            Assert.Equal(TestConstants.TestCharacterName, character.Name, true);
        }

        /// <summary>
        ///   Tests get character
        /// </summary>
        [Fact]
        public void TestCharacterNoFields()
        {
            var client = TestHelper.CreateDefaultWarcraftClient();
            var character = client.GetCharacterAsync(TestConstants.TestRealmName, TestConstants.TestCharacterName, CharacterFields.None).Result;
            Assert.NotNull(character);
            Assert.Null(character.Professions);
            Assert.Null(character.Achievements);
            Assert.Null(character.Items);
            Assert.Null(character.Guild);
            Assert.Null(character.Progression);
            Assert.Null(character.Appearance);
            Assert.Null(character.Pvp);
            Assert.Null(character.Stats);

            Assert.Equal(TestConstants.TestClass, character.Class);
            Assert.True(character.Level >= 85);
            Assert.Equal(TestConstants.TestRace, character.Race);
            Assert.True(character.AchievementPoints > 0);
            Assert.Equal(TestConstants.TestGender, character.Gender);

            Assert.Equal(TestConstants.TestRealmName, character.Realm, true);
            Assert.Equal(TestConstants.TestCharacterName, character.Name, true);
        }

        /// <summary>
        ///  Tests character statistics
        /// </summary>
        [Fact]
        public void TestCharacterStatistics()
        {
            var client = TestHelper.CreateDefaultWarcraftClient();
            var character = client.GetCharacterAsync(TestConstants.TestRealmName, TestConstants.TestCharacterName,
                                                CharacterFields.Statistics).Result;
            Assert.NotNull(character);
            Assert.NotNull(character.Statistics);
            Assert.True(character.Statistics.Id > 0);
            Assert.False(string.IsNullOrWhiteSpace(character.Statistics.Name));
            Assert.NotNull(character.Statistics.Subcategories);

            var category = character.Statistics.Subcategories[0];

            Assert.NotNull(category);
            Assert.DoesNotContain(category.Statistics, s => s == null);
            Assert.DoesNotContain(category.Statistics, s => s.IsMoney);
            Assert.DoesNotContain(category.Statistics, s => string.IsNullOrEmpty(s.Name));
            Assert.DoesNotContain(category.Statistics, s => s.Quantity <= 0);
            Assert.DoesNotContain(category.Statistics, s => s.Id <= 0);
            Assert.DoesNotContain(category.Statistics, s => s.LastUpdatedTime.Year < 2000);
        }

        /// <summary>
        ///   Test char appearance
        /// </summary>
        [Fact]
        public void TestCharacterAppearance()
        {
            var client = TestHelper.CreateDefaultWarcraftClient();
            var character = client.GetCharacterAsync(TestConstants.TestRealmName, TestConstants.TestCharacterName,
                                                CharacterFields.Appearance).Result;
            Assert.NotNull(character);
            Assert.NotNull(character.Appearance);
            //Assert.True(character.Appearance.FaceVariation > 0);
            //Assert.True(character.Appearance.FeatureVariation > 0);
            //Assert.True(character.Appearance.HairVariation > 0);
            //Assert.True(character.Appearance.ShowCloak);
            //Assert.True(character.Appearance.ShowHelm);
            //Assert.True(character.Appearance.SkinColor > 0);
        }

        /// <summary>
        ///   Test char gear
        /// </summary>
        [Fact]
        public void TestCharacterGear()
        {
            var client = TestHelper.CreateDefaultWarcraftClient();
            var character = client.GetCharacterAsync(TestConstants.TestRealmName, TestConstants.TestCharacterName,
                                                CharacterFields.Items).Result;
            Assert.NotNull(character);
            Assert.NotNull(character.Items);
            Assert.NotNull(character.Items.ToString());

            Assert.Same(character.Items.Head, character.Items[EquipmentSlot.Head]);
            Assert.Same(character.Items.Neck, character.Items[EquipmentSlot.Neck]);
            Assert.Same(character.Items.Shoulder, character.Items[EquipmentSlot.Shoulder]);
            Assert.Same(character.Items.Back, character.Items[EquipmentSlot.Back]);
            Assert.Same(character.Items.Chest, character.Items[EquipmentSlot.Chest]);
            Assert.Same(character.Items.Tabard, character.Items[EquipmentSlot.Tabard]);
            Assert.Same(character.Items.Shirt, character.Items[EquipmentSlot.Shirt]);
            Assert.Same(character.Items.Wrist, character.Items[EquipmentSlot.Wrist]);
            Assert.Same(character.Items.Hands, character.Items[EquipmentSlot.Hands]);
            Assert.Same(character.Items.Waist, character.Items[EquipmentSlot.Waist]);
            Assert.Same(character.Items.Legs, character.Items[EquipmentSlot.Legs]);
            Assert.Same(character.Items.Feet, character.Items[EquipmentSlot.Feet]);
            Assert.Same(character.Items.Finger1, character.Items[EquipmentSlot.Finger1]);
            Assert.Same(character.Items.Finger2, character.Items[EquipmentSlot.Finger2]);
            Assert.Same(character.Items.Trinket1, character.Items[EquipmentSlot.Trinket1]);
            Assert.Same(character.Items.Trinket2, character.Items[EquipmentSlot.Trinket2]);
            Assert.Same(character.Items.Offhand, character.Items[EquipmentSlot.Offhand]);
            Assert.Same(character.Items.MainHand, character.Items[EquipmentSlot.MainHand]);

            var item = character.Items.AllItems.First();
            Assert.NotNull(item);
            Assert.NotNull(item.Name);
            Assert.True(item.ItemId > 0);
            Assert.NotNull(item.Icon);
            Assert.Equal(item.Name, item.ToString());

            item = character.Items.Chest;
            Assert.NotNull(item.Parameters);
            Assert.True(item.Parameters.Enchant != null && item.Parameters.Enchant.Value > 0);
            Assert.True(item.Parameters.Gem0 != null && item.Parameters.Gem0.Value > 0);
            //Assert.True(item.Parameters.Gem1.HasValue);
            //Assert.True(item.Parameters.Gem1.Value > 0);
            //Assert.True(item.Parameters.Gem2.HasValue);
            //Assert.True(item.Parameters.Gem2.Value > 0);
            //Assert.False(item.Parameters.Gem3.HasValue);
            Assert.True((int)item.Quality >= (int)ItemQuality.Rare);
            //Assert.NotNull(item.Parameters.SetItems);
            //Assert.True(item.Parameters.SetItems.Count > 0);
            //Assert.True(item.Parameters.TransmogrifyItemId.HasValue);
            //Assert.True(item.Parameters.TransmogrifyItemId.Value > 0);
            Assert.False(item.Parameters.Tinker.HasValue);

            var ritem = character.Items.AllItems.Any(i => i.Parameters.Reforge.HasValue);
            Assert.True(ritem);
        }

        /// <summary>
        ///   test hunter pets
        /// </summary>
        [Fact]
        public void TestCharacterHunterPets()
        {
            var client = TestHelper.CreateDefaultWarcraftClient();
            var character = client.GetCharacterAsync(TestConstants.TestRealmName, TestConstants.TestHunter,
                                                CharacterFields.HunterPets).Result;
            Assert.NotNull(character.HunterPets);
            Assert.NotEmpty(character.HunterPets);
            Assert.NotNull(character.HunterPets[0].CalculatorSpecialization);
            Assert.NotNull(character.HunterPets[0].Name);
            Assert.True(character.HunterPets[0].CreatureId > 0);
            Assert.True(character.HunterPets.Any(p => p.Slot > 0));

            var pet = character.HunterPets.FirstOrDefault(p => p.Specialization != null && p.Specialization.Order > 0);

            Assert.NotNull(pet);
            if (pet != null)
            {
                Assert.NotNull(pet.Specialization.BackgroundImage);
                Assert.NotNull(pet.Specialization.Description);
                Assert.NotNull(pet.Specialization.Icon);
                Assert.NotNull(pet.Specialization.Name);
                Assert.True(pet.Specialization.Order > 0);
                Assert.NotNull(pet.Specialization.Role);
            }
            //Assert.True(character.HunterPets.Any(p => p.IsSelected));
        }

        /// <summary>
        ///   test character progression
        /// </summary>
        [Fact]
        public void TestCharacterProgression2()
        {
            var client = TestHelper.CreateDefaultWarcraftClient();
            var character = client.GetCharacterAsync(TestConstants.TestRealmName, TestConstants.TestCharacterName,
                                                CharacterFields.Progression).Result;
            Assert.NotNull(character);
            Assert.NotNull(character.Progression);
            Assert.NotNull(character.Progression.Raids);
            Assert.True(character.Progression.Raids.Count > 0);

            var instance =
                character.Progression.Raids.FirstOrDefault(r => r.HeroicProgress == CharacterInstanceStatus.Completed);
            Assert.NotNull(instance);
            if (instance != null)
            {
                Assert.NotNull(instance.Name);
                Assert.True(instance.Id > 0);
                Assert.NotNull(instance.Bosses);
                Assert.True(instance.Bosses.Count > 0);
                Assert.NotNull(instance.Bosses[0]);
                Assert.NotNull(instance.Bosses[0].Name);
                Assert.NotNull(instance.Bosses[0].Id > 0);
                Assert.NotEqual(0, instance.Bosses[0].HeroicKills);
                Assert.NotEqual(1, instance.Bosses[0].NormalKills);

                Assert.Equal(CharacterInstanceStatus.Completed, instance.NormalProgress);
                Assert.NotNull(instance.ToString());
                Assert.NotNull(instance.Bosses[0].ToString());
            }
        }

        /// <summary>
        ///   test character feeds
        /// </summary>
        [Fact]
        public void TestCharacterFeeds()
        {
            var client = TestHelper.CreateDefaultWarcraftClient();
            var character = client.GetCharacterAsync(TestConstants.TestRealmName, TestConstants.TestCharacterName,
                                                CharacterFields.Feed).Result;
            Assert.NotNull(character);
            Assert.NotNull(character.Feed);
            Assert.True(character.Feed.All(f => f != null));
            Assert.True(character.Feed.All(f => f.Achievement != null || f.FeedItemType != FeedItemType.Achievement));
            Assert.True(character.Feed.All(f => f.ItemId > 0 || f.FeedItemType != FeedItemType.Loot));
            Assert.True(character.Feed.All(f => f.Criteria != null || f.FeedItemType != FeedItemType.Criteria));
        }
    }
}
