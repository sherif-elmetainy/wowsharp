// Copyright (C) 2011 by Sherif Elmetainy (Grendiser@Kazzak-EU)
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

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace WOWSharp.Warcraft
{
    /// <summary>
    ///   Represents character's current stats
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class CharacterStats
    {
        /// <summary>
        ///   Gets or sets character's max health points
        /// </summary>
        [JsonProperty(PropertyName="health", Required = Required.Always)]
        public int Health
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the character's power type
        /// </summary>
        [JsonProperty(PropertyName="powerType", Required = Required.Always)]
        [JsonConverter(typeof(StringEnumConverter))]
        public PowerType PowerType
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the character's max power
        /// </summary>
        [JsonProperty(PropertyName="power", Required = Required.Always)]
        public int Power
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the character's strength
        /// </summary>
        [JsonProperty(PropertyName="str", Required = Required.Always)]
        public int Strength
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the character's agility
        /// </summary>
        [JsonProperty(PropertyName="agi", Required = Required.Always)]
        public int Agility
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the character's stamina
        /// </summary>
        [JsonProperty(PropertyName="sta", Required = Required.Always)]
        public int Stamina
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the character's intellect
        /// </summary>
        [JsonProperty(PropertyName="int", Required = Required.Always)]
        public int Intellect
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the character's spirit
        /// </summary>
        [JsonProperty(PropertyName="spr", Required = Required.Always)]
        public int Spirit
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the character's melee attack power
        /// </summary>
        [JsonProperty(PropertyName="attackPower", Required = Required.Always)]
        public int MeleeAttackPower
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the character's ranged attack power
        /// </summary>
        [JsonProperty(PropertyName="rangedAttackPower", Required = Required.Always)]
        public int RangedAttackPower
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the character's mastery
        /// </summary>
        [JsonProperty(PropertyName="mastery")]
        public double Mastery
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the character's mastery rating
        /// </summary>
        [JsonProperty(PropertyName="masteryRating")]
        public int MasteryRating
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the character's melee crit chance
        /// </summary>
        [JsonProperty(PropertyName="crit", Required = Required.Always)]
        public double MeleeCritChance
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the character's melee crit rating
        /// </summary>
        [JsonProperty(PropertyName="critRating", Required = Required.Always)]
        public int CritRating
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the character's hit rating
        /// </summary>
        [JsonProperty(PropertyName="hitRating", Required = Required.Always)]
        public int HitRating
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the character's hit percentage
        /// </summary>
        [JsonProperty(PropertyName="hitPercent", Required = Required.Always)]
        public double HitPercent
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the character's haste rating
        /// </summary>
        [JsonProperty(PropertyName="hasteRating", Required = Required.Always)]
        public int HasteRating
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the character's melee haste percentage from haste rating
        /// </summary>
        [JsonProperty(PropertyName="hasteRatingPercent", Required = Required.Always)]
        public double HasteRatingPercent
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the character's total melee haste percentage
        /// </summary>
        [JsonProperty(PropertyName="haste", Required = Required.Always)]
        public double HastePercent
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the character's expertise rating
        /// </summary>
        [JsonProperty(PropertyName="expertiseRating", Required = Required.Always)]
        public int ExpertiseRating
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the character's spell power
        /// </summary>
        [JsonProperty(PropertyName="spellPower", Required = Required.Always)]
        public int SpellPower
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the character's spell penetration
        /// </summary>
        [JsonProperty(PropertyName="spellPen", Required = Required.Always)]
        public int SpellPenetration
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the character's spell crit chance
        /// </summary>
        [JsonProperty(PropertyName="spellCrit", Required = Required.Always)]
        public double SpellCritChance
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the character's spell crit rating
        /// </summary>
        [JsonProperty(PropertyName="spellCritRating", Required = Required.Always)]
        public int SpellCritRating
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the character's spell hit percentage
        /// </summary>
        [JsonProperty(PropertyName="spellHitPercent", Required = Required.Always)]
        public double SpellHitPercent
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the character's spell hit rating
        /// </summary>
        [JsonProperty(PropertyName="spellHitRating", Required = Required.Always)]
        public int SpellHitRating
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the character's spell haste rating
        /// </summary>
        [JsonProperty(PropertyName="spellHasteRating", Required = Required.Always)]
        public int SpellHasteRating
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the character's spell haste percentage from haste rating
        /// </summary>
        [JsonProperty(PropertyName="spellHasteRatingPercent", Required = Required.Always)]
        public double SpellHasteRatingPercent
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the character's total spell haste 
        /// </summary>
        [JsonProperty(PropertyName="spellHaste", Required = Required.Always)]
        public double SpellHastePercent
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the character mana regeneration out of combat
        /// </summary>
        [JsonProperty(PropertyName="mana5", Required = Required.Always)]
        public double ManaPer5
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the character's mana regeneration in combat
        /// </summary>
        [JsonProperty(PropertyName="mana5Combat", Required = Required.Always)]
        public double ManaPer5Combat
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the character's armor
        /// </summary>
        [JsonProperty(PropertyName="armor", Required = Required.Always)]
        public int Armor
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the character's dodge chance
        /// </summary>
        [JsonProperty(PropertyName="dodge", Required = Required.Always)]
        public double DodgeChance
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the character's dodge rating
        /// </summary>
        [JsonProperty(PropertyName="dodgeRating", Required = Required.Always)]
        public int DodgeRating
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the character's parry chance
        /// </summary>
        [JsonProperty(PropertyName="parry", Required = Required.Always)]
        public double ParryChance
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the character's parry rating
        /// </summary>
        [JsonProperty(PropertyName="parryRating", Required = Required.Always)]
        public int ParryRating
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the character's block chance
        /// </summary>
        [JsonProperty(PropertyName="block", Required = Required.Always)]
        public double BlockChance
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the character's block rating
        /// </summary>
        [JsonProperty(PropertyName="blockRating", Required = Required.Always)]
        public int BlockRating
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the character's pvp resilence
        /// </summary>
        [JsonProperty(PropertyName="pvpResilience", Required = Required.Always)]
        public double PvpResilience
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the character's pvp resilence rating
        /// </summary>
        [JsonProperty(PropertyName="pvpResilienceRating", Required = Required.Always)]
        public int PvpResilienceRating
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the character's pvp resilence bonus
        /// </summary>
        [JsonProperty(PropertyName="pvpResilienceBonus", Required = Required.Always)]
        public double PvpResilienceBonus
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the character's minimum main hand melee weapon damage
        /// </summary>
        [JsonProperty(PropertyName="mainHandDmgMin", Required = Required.Always)]
        public double MainHandDamageMin
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the character's maximum main hand melee weapon damage
        /// </summary>
        [JsonProperty(PropertyName="mainHandDmgMax", Required = Required.Always)]
        public double MainHandDamageMax
        {
            get;
            set;
        }

        /// <summary>
        ///   Get or sets the character's main hand weapon speed
        /// </summary>
        [JsonProperty(PropertyName="mainHandSpeed", Required = Required.Always)]
        public double MainHandSpeed
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the character's main hand weapon damage per second
        /// </summary>
        [JsonProperty(PropertyName="mainHandDps", Required = Required.Always)]
        public double MainHandDps
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the character's main hand weapon expertise
        /// </summary>
        [JsonProperty(PropertyName="mainHandExpertise", Required = Required.Always)]
        public double MainHandExpertise
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the character's minimum off hand weapon damage
        /// </summary>
        [JsonProperty(PropertyName="offHandDmgMin", Required = Required.Always)]
        public double OffhandDamageMin
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the character's maximum off hand weapon damage
        /// </summary>
        [JsonProperty(PropertyName="offHandDmgMax", Required = Required.Always)]
        public double OffhandDamageMax
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the character's off hand weapon speed
        /// </summary>
        [JsonProperty(PropertyName="offHandSpeed", Required = Required.Always)]
        public double OffhandSpeed
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the character's off hand weapon damage per second
        /// </summary>
        [JsonProperty(PropertyName="offHandDps", Required = Required.Always)]
        public double OffhandDps
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the character's off hand weapon expertise
        /// </summary>
        [JsonProperty(PropertyName="offHandExpertise", Required = Required.Always)]
        public double OffhandExpertise
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the character's minimum ranged weapon damage
        /// </summary>
        [JsonProperty(PropertyName="rangedDmgMin", Required = Required.Always)]
        public double RangedDamageMin
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the character's maximum ranged weapon damage
        /// </summary>
        [JsonProperty(PropertyName="rangedDmgMax", Required = Required.Always)]
        public double RangedDamageMax
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the character's ranged weason speed
        /// </summary>
        [JsonProperty(PropertyName="rangedSpeed", Required = Required.Always)]
        public double RangedSpeed
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the character's ranged haste percentage from haste rating
        /// </summary>
        [JsonProperty(PropertyName="rangedHasteRatingPercent", Required = Required.Always)]
        public double RangedHasteRatingPercent
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the character's total ranged haste percentage
        /// </summary>
        [JsonProperty(PropertyName="rangedHaste", Required = Required.Always)]
        public double RangedHastePercent
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the character's ranged haste percentage
        /// </summary>
        [JsonProperty(PropertyName="rangedHasteRating", Required = Required.Always)]
        public int RangedHasteRating
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the character's ranged weapon damage per second
        /// </summary>
        [JsonProperty(PropertyName="rangedDps", Required = Required.Always)]
        public double RangedDps
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the character's ranged expertise
        /// </summary>
        [JsonProperty(PropertyName="rangedExpertise", Required = Required.Always)]
        public double RangedExpertise
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the character's ranged crit chance
        /// </summary>
        [JsonProperty(PropertyName="rangedCrit", Required = Required.Always)]
        public double RangedCritChance
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the character's ranged crit rating
        /// </summary>
        [JsonProperty(PropertyName="rangedCritRating", Required = Required.Always)]
        public int RangedCritRating
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the character's ranged hit rating
        /// </summary>
        [JsonProperty(PropertyName="rangedHitRating", Required = Required.Always)]
        public int RangedHitRating
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the character's hit percentage
        /// </summary>
        [JsonProperty(PropertyName="rangedHitPercent", Required = Required.Always)]
        public double RangedHitPercent
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the character's pvp power
        /// </summary>
        [JsonProperty(PropertyName="pvpPower", Required = Required.Always)]
        public double PvpPower
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the character's pvp power damage bonus
        /// </summary>
        [JsonProperty(PropertyName="pvpPowerDamage", Required = Required.Always)]
        public double PvpPowerDamage
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the character's pvp healing bonus
        /// </summary>
        [JsonProperty(PropertyName="pvpPowerHealing", Required = Required.Always)]
        public double PvpPowerHealing
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets or sets the character's pvp power rating
        /// </summary>
        [JsonProperty(PropertyName="pvpPowerRating", Required = Required.Always)]
        public int PvpPowerRating
        {
            get;
            set;
        }
    }
}