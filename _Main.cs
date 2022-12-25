using BigDLL4221.Models;
using BigDLL4221.Utils;
using LOR_DiceSystem;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System;
using UnityEngine;
using LOR_XML;
using BigDLL4221.Enum;
using Sound;
using BigDLL4221.Buffs;

namespace AphoPassivePack
{
    public static class AphoPassivePack_Params
    {
        public static string PackageId = "AphoPassivePack";
        public static string Path;
        public static string CategoryName = "Attribution Archives";
    }
    public class AphoPassivePackInit : ModInitializer
    {
        public override void OnInitializeMod()
        {
            OnInitParameters();
            ArtUtil.GetArtWorks(new DirectoryInfo(AphoPassivePack_Params.Path + "/ArtWork"));
            ArtUtil.PreLoadBufIcons();
            CardUtil.ChangeCardItem(ItemXmlDataList.instance, AphoPassivePack_Params.PackageId);
            KeypageUtil.ChangeKeypageItem(BookXmlList.Instance, AphoPassivePack_Params.PackageId);
            PassiveUtil.ChangePassiveItem(AphoPassivePack_Params.PackageId);
            LocalizeUtil.AddGlobalLocalize(AphoPassivePack_Params.PackageId);
            LocalizeUtil.RemoveError();
            CardUtil.InitKeywordsList(new List<Assembly> { Assembly.GetExecutingAssembly() });
            ArtUtil.InitCustomEffects(new List<Assembly> { Assembly.GetExecutingAssembly() });
            CustomMapHandler.ModResources.CacheInit.InitCustomMapFiles(Assembly.GetExecutingAssembly());
        }
        private static void OnInitParameters()
        {
            ModParameters.PackageIds.Add(AphoPassivePack_Params.PackageId);
            AphoPassivePack_Params.Path = Path.GetDirectoryName(Uri.UnescapeDataString(new UriBuilder(Assembly.GetExecutingAssembly().CodeBase).Path));
            ModParameters.Path.Add(AphoPassivePack_Params.PackageId, AphoPassivePack_Params.Path);
            OnInitRewards();
            OnInitCards();
            OnInitCategories();
            OnInitKeypages();
            OnInitSprites();
            OnInitPassives();
        }
        private static void OnInitRewards()
        {
            ModParameters.StartUpRewardOptions.Add(new RewardOptions(keypages: new List<LorId>
            {
                    new LorId(AphoPassivePack_Params.PackageId, 10000001),
                    new LorId(AphoPassivePack_Params.PackageId, 10000002),
                    new LorId(AphoPassivePack_Params.PackageId, 10000003),
                    new LorId(AphoPassivePack_Params.PackageId, 10000004),
                    new LorId(AphoPassivePack_Params.PackageId, 10000005),
                    new LorId(AphoPassivePack_Params.PackageId, 10000006),
                    new LorId(AphoPassivePack_Params.PackageId, 10000007),
                    new LorId(AphoPassivePack_Params.PackageId, 10000008),
                    new LorId(AphoPassivePack_Params.PackageId, 10000009),
                    new LorId(AphoPassivePack_Params.PackageId, 10000010),
                }
            ));
        }
        private static void OnInitCards()
        {
            ModParameters.CardOptions.Add(AphoPassivePack_Params.PackageId, new List<CardOptions>
            {
                new CardOptions(1, cardColorOptions: new CardColorOptions(new Color(0.624f, 0.169f, 0.408f), customIconColor: new Color(0.898f, 0.169f, 0.314f), useHSVFilter: false)), //Mulligan
                new CardOptions(2, cardColorOptions: new CardColorOptions(Color.white, customIconColor: Color.white, useHSVFilter: false)), //CarteBlanche
                new CardOptions(3, cardColorOptions: new CardColorOptions(new Color(0.3f, 0.3f, 0.3f), customIconColor: Color.black, useHSVFilter: false)), //CarteBlanche
                new CardOptions(4, cardColorOptions: new CardColorOptions(Color.red, customIconColor: Color.red, useHSVFilter: false)), //ExecutionBullet
                new CardOptions(5, cardColorOptions: new CardColorOptions(new Color(0.973f, 0.859f, 0.184f), customIconColor: new Color(0.973f, 0.859f, 0.184f), useHSVFilter: false)), //SlowBullet
                new CardOptions(6, cardColorOptions: new CardColorOptions(new Color(0.145f, 1, 0.337f), customIconColor: new Color(0.145f, 1, 0.337f), useHSVFilter: false)), //HPBullet
                new CardOptions(7, cardColorOptions: new CardColorOptions(new Color(0.216f, 0.647f, 0.871f), customIconColor: new Color(0.216f, 0.647f, 0.871f), useHSVFilter: false)), //SPBullet
                new CardOptions(8, cardColorOptions: new CardColorOptions(new Color(0.898f, 0.169f, 0.314f), customIconColor: new Color(0.898f, 0.169f, 0.314f), useHSVFilter: false)), //RShield
                new CardOptions(9, cardColorOptions: new CardColorOptions(Color.white, customIconColor: Color.white, useHSVFilter: false)), //WShield
                new CardOptions(10, cardColorOptions: new CardColorOptions(new Color(0.651f, 0.388f, 0.702f), customIconColor: new Color(0.651f, 0.388f, 0.702f), useHSVFilter: false)), //BShield
                new CardOptions(11, cardColorOptions: new CardColorOptions(new Color(0.263f, 0.816f, 0.761f), customIconColor: new Color(0.263f, 0.816f, 0.761f), useHSVFilter: false)), //PShield
            });
        }
        private static void OnInitCategories()
        {
            ModParameters.CategoryOptions.Add(AphoPassivePack_Params.PackageId, new List<CategoryOptions>
            {
                new CategoryOptions(AphoPassivePack_Params.PackageId, additionalValue: "_1", categoryBooksId:new List<int>{10000001, 10000002, 10000003, 10000004, 10000005, 10000006, 10000007, 10000008, 10000009, 10000010}, categoryName: AphoPassivePack_Params.CategoryName,customIconSpriteId:AphoPassivePack_Params.PackageId, bookDataColor: new CategoryColorOptions(new Color(0.624f, 0.169f, 0.408f), new Color(0.898f, 0.169f, 0.314f)), credenzaType: CredenzaEnum.ModifiedCredenza, chapter: 1, credenzaBooksId: new List<int> { 10000001, 10000002, 10000003 , 10000004, 10000005, 10000006, 10000007, 10000008, 10000009, 10000010}),
            });
        }
        private static void OnInitKeypages()
        {
            ModParameters.KeypageOptions.Add(AphoPassivePack_Params.PackageId, new List<KeypageOptions>
            {
                new KeypageOptions(10000001, keypageColorOptions: new KeypageColorOptions(new Color(0.624f, 0.169f, 0.408f), new Color(0.898f, 0.169f, 0.314f))),
                new KeypageOptions(10000002, keypageColorOptions: new KeypageColorOptions(new Color(0.624f, 0.169f, 0.408f), new Color(0.898f, 0.169f, 0.314f))),
                new KeypageOptions(10000003, keypageColorOptions: new KeypageColorOptions(new Color(0.624f, 0.169f, 0.408f), new Color(0.898f, 0.169f, 0.314f))),
                new KeypageOptions(10000004, keypageColorOptions: new KeypageColorOptions(new Color(0.624f, 0.169f, 0.408f), new Color(0.898f, 0.169f, 0.314f))),
                new KeypageOptions(10000005, keypageColorOptions: new KeypageColorOptions(new Color(0.624f, 0.169f, 0.408f), new Color(0.898f, 0.169f, 0.314f))),
                new KeypageOptions(10000006, keypageColorOptions: new KeypageColorOptions(new Color(0.624f, 0.169f, 0.408f), new Color(0.898f, 0.169f, 0.314f))),
                new KeypageOptions(10000007, keypageColorOptions: new KeypageColorOptions(new Color(0.624f, 0.169f, 0.408f), new Color(0.898f, 0.169f, 0.314f))),
                new KeypageOptions(10000008, keypageColorOptions: new KeypageColorOptions(new Color(0.624f, 0.169f, 0.408f), new Color(0.898f, 0.169f, 0.314f))),
                new KeypageOptions(10000009, keypageColorOptions: new KeypageColorOptions(new Color(0.624f, 0.169f, 0.408f), new Color(0.898f, 0.169f, 0.314f))),
                new KeypageOptions(10000010, keypageColorOptions: new KeypageColorOptions(new Color(0.624f, 0.169f, 0.408f), new Color(0.898f, 0.169f, 0.314f))),
            });
        }
        private static void OnInitSprites()
        {
            ModParameters.SpriteOptions.Add(AphoPassivePack_Params.PackageId, new List<SpriteOptions>
            {
                new SpriteOptions(SpriteEnum.Custom, 10000001, "AphoPassivePack_Sprite"),
                new SpriteOptions(SpriteEnum.Custom, 10000002, "AphoPassivePack_Sprite"),
                new SpriteOptions(SpriteEnum.Custom, 10000003, "AphoPassivePack_Sprite"),
                new SpriteOptions(SpriteEnum.Custom, 10000004, "AphoPassivePack_Sprite"),
                new SpriteOptions(SpriteEnum.Custom, 10000005, "AphoPassivePack_Sprite"),
                new SpriteOptions(SpriteEnum.Custom, 10000006, "AphoPassivePack_Sprite"),
                new SpriteOptions(SpriteEnum.Custom, 10000007, "AphoPassivePack_Sprite"),
                new SpriteOptions(SpriteEnum.Custom, 10000008, "AphoPassivePack_Sprite"),
                new SpriteOptions(SpriteEnum.Custom, 10000009, "AphoPassivePack_Sprite"),
                new SpriteOptions(SpriteEnum.Custom, 10000010, "AphoPassivePack_Sprite"),
            });
        }
        private static void OnInitPassives()
        {
            ModParameters.PassiveOptions.Add(AphoPassivePack_Params.PackageId, new List<PassiveOptions>
            {
                //Dealer
                new PassiveOptions(12, true, passiveColorOptions: new PassiveColorOptions(Color.white, Color.white)), //CarteBlanche
                new PassiveOptions(13, true, passiveColorOptions: new PassiveColorOptions(Color.white, Color.gray)), //CarteNoir
                new PassiveOptions(10, true, passiveColorOptions: new PassiveColorOptions(new Color(0.898f, 0.169f, 0.314f), new Color(0.898f, 0.169f, 0.314f))),
                new PassiveOptions(11, true, passiveColorOptions: new PassiveColorOptions(new Color(0.898f, 0.169f, 0.314f), new Color(0.898f, 0.169f, 0.314f))),
                new PassiveOptions(14, true, passiveColorOptions: new PassiveColorOptions(new Color(0.898f, 0.169f, 0.314f), new Color(0.898f, 0.169f, 0.314f))),
                new PassiveOptions(15, true, passiveColorOptions: new PassiveColorOptions(new Color(0.898f, 0.169f, 0.314f), new Color(0.898f, 0.169f, 0.314f))),

                //Fairy
                new PassiveOptions(20, true, passiveColorOptions: new PassiveColorOptions(new Color(1f, 0.843f, 0f), new Color(1f, 0.843f, 0f))),
                new PassiveOptions(21, true, passiveColorOptions: new PassiveColorOptions(new Color(1f, 0.843f, 0f), new Color(1f, 0.843f, 0f))),
                new PassiveOptions(22, true, passiveColorOptions: new PassiveColorOptions(new Color(1f, 0.843f, 0f), new Color(1f, 0.843f, 0f))),
                new PassiveOptions(23, true, passiveColorOptions: new PassiveColorOptions(new Color(1f, 0.843f, 0f), new Color(1f, 0.843f, 0f))),
                new PassiveOptions(24, true, passiveColorOptions: new PassiveColorOptions(new Color(1f, 0.843f, 0f), new Color(1f, 0.843f, 0f))),
                new PassiveOptions(25, true, passiveColorOptions: new PassiveColorOptions(new Color(1f, 0.843f, 0f), new Color(1f, 0.843f, 0f))),

                //Gunner
                new PassiveOptions(30, true, passiveColorOptions: new PassiveColorOptions(new Color(0.898f, 0.169f, 0.314f), new Color(0.898f, 0.169f, 0.314f))),
                new PassiveOptions(31, true, passiveColorOptions: new PassiveColorOptions(new Color(0.898f, 0.169f, 0.314f), new Color(0.898f, 0.169f, 0.314f)), cannotBeUsedWithPassives: new List<LorId>
                {
                        new LorId(AphoPassivePack_Params.PackageId, 32),
                        new LorId(AphoPassivePack_Params.PackageId, 33),
                }), //APAmmo
                new PassiveOptions(32, true, passiveColorOptions: new PassiveColorOptions(new Color(0.898f, 0.169f, 0.314f), new Color(0.898f, 0.169f, 0.314f)), cannotBeUsedWithPassives: new List<LorId>
                {
                        new LorId(AphoPassivePack_Params.PackageId, 31),
                        new LorId(AphoPassivePack_Params.PackageId, 33),
                }), //FrostAmmo
                new PassiveOptions(33, true, passiveColorOptions: new PassiveColorOptions(new Color(0.898f, 0.169f, 0.314f), new Color(0.898f, 0.169f, 0.314f)), cannotBeUsedWithPassives: new List<LorId>
                {
                        new LorId(AphoPassivePack_Params.PackageId, 31),
                        new LorId(AphoPassivePack_Params.PackageId, 32),
                }), //FlameAmmo
                new PassiveOptions(34, true, passiveColorOptions: new PassiveColorOptions(new Color(0.898f, 0.169f, 0.314f), new Color(0.898f, 0.169f, 0.314f))),
                new PassiveOptions(35, true, passiveColorOptions: new PassiveColorOptions(new Color(0.898f, 0.169f, 0.314f), new Color(0.898f, 0.169f, 0.314f))),
                
                //Manager
                new PassiveOptions(41, true, passiveColorOptions: new PassiveColorOptions(new Color(0.145f, 1, 0.337f), new Color(0.145f, 1, 0.337f))), //hp
                new PassiveOptions(42, true, passiveColorOptions: new PassiveColorOptions(new Color(0.216f, 0.647f, 0.871f), new Color(0.216f, 0.647f, 0.871f))), //sp
                new PassiveOptions(43, true, passiveColorOptions: new PassiveColorOptions(new Color(0.898f, 0.169f, 0.314f), new Color(0.898f, 0.169f, 0.314f))), //Rshield
                new PassiveOptions(44, true, passiveColorOptions: new PassiveColorOptions(Color.white, Color.white)), //Wshield
                new PassiveOptions(45, true, passiveColorOptions: new PassiveColorOptions(new Color(0.651f, 0.388f, 0.702f), new Color(0.651f, 0.388f, 0.702f))), //Bshield
                new PassiveOptions(46, true, passiveColorOptions: new PassiveColorOptions(new Color(0.263f, 0.816f, 0.761f), new Color(0.263f, 0.816f, 0.761f))), //Pshield
                new PassiveOptions(47, true, passiveColorOptions: new PassiveColorOptions(new Color(0.973f, 0.859f, 0.184f), new Color(0.973f, 0.859f, 0.184f))), //Slow
                new PassiveOptions(48, true, passiveColorOptions: new PassiveColorOptions(Color.red, Color.red)), //execute

                //Gambler
                new PassiveOptions(50, true, passiveColorOptions: new PassiveColorOptions(new Color(0.898f, 0.169f, 0.314f), new Color(0.898f, 0.169f, 0.314f))),
                new PassiveOptions(51, true, passiveColorOptions: new PassiveColorOptions(new Color(0.898f, 0.169f, 0.314f), new Color(0.898f, 0.169f, 0.314f))),
                new PassiveOptions(52, true, passiveColorOptions: new PassiveColorOptions(new Color(0.898f, 0.169f, 0.314f), new Color(0.898f, 0.169f, 0.314f))),
                new PassiveOptions(53, true, passiveColorOptions: new PassiveColorOptions(new Color(0.898f, 0.169f, 0.314f), new Color(0.898f, 0.169f, 0.314f))),
                new PassiveOptions(54, true, passiveColorOptions: new PassiveColorOptions(new Color(0.898f, 0.169f, 0.314f), new Color(0.898f, 0.169f, 0.314f))),
                new PassiveOptions(55, true, passiveColorOptions: new PassiveColorOptions(new Color(0.898f, 0.169f, 0.314f), new Color(0.898f, 0.169f, 0.314f))),

                //Martyr
                new PassiveOptions(60, true, passiveColorOptions: new PassiveColorOptions(new Color(0.898f, 0.169f, 0.314f), new Color(0.898f, 0.169f, 0.314f))), //EdibleCorpse
                //skip 61-66, those will use default colors
                new PassiveOptions(67, true, passiveColorOptions: new PassiveColorOptions(new Color(0.898f, 0.169f, 0.314f), new Color(0.898f, 0.169f, 0.314f))), //IntoStarEmbrace

                //BladeUnlocked
                new PassiveOptions(70, true, cannotBeUsedWithPassives: new List<LorId>
                {
                        new LorId(250115),
                        new LorId(AphoPassivePack_Params.PackageId, 71),
                        new LorId(AphoPassivePack_Params.PackageId, 72),
                        new LorId(AphoPassivePack_Params.PackageId, 73),
                        new LorId(AphoPassivePack_Params.PackageId, 74),
                        new LorId(AphoPassivePack_Params.PackageId, 75),
                        new LorId(AphoPassivePack_Params.PackageId, 76),
                }), //ProxyOfIndex
                new PassiveOptions(71, true, passiveColorOptions: new PassiveColorOptions(Color.yellow, Color.yellow), cannotBeUsedWithPassives: new List<LorId>
                {
                        new LorId(250115),
                        new LorId(AphoPassivePack_Params.PackageId, 70),
                        new LorId(AphoPassivePack_Params.PackageId, 72),
                        new LorId(AphoPassivePack_Params.PackageId, 73),
                        new LorId(AphoPassivePack_Params.PackageId, 74),
                        new LorId(AphoPassivePack_Params.PackageId, 75),
                        new LorId(AphoPassivePack_Params.PackageId, 76),
                }), //Odd
                new PassiveOptions(72, true, passiveColorOptions: new PassiveColorOptions(Color.yellow, Color.yellow), cannotBeUsedWithPassives: new List<LorId>
                {
                        new LorId(250115),
                        new LorId(AphoPassivePack_Params.PackageId, 70),
                        new LorId(AphoPassivePack_Params.PackageId, 71),
                        new LorId(AphoPassivePack_Params.PackageId, 73),
                        new LorId(AphoPassivePack_Params.PackageId, 74),
                        new LorId(AphoPassivePack_Params.PackageId, 75),
                        new LorId(AphoPassivePack_Params.PackageId, 76),
                }), //Even
                new PassiveOptions(73, true, passiveColorOptions: new PassiveColorOptions(Color.red, Color.red), cannotBeUsedWithPassives: new List<LorId>
                {
                        new LorId(250115),
                        new LorId(AphoPassivePack_Params.PackageId, 70),
                        new LorId(AphoPassivePack_Params.PackageId, 71),
                        new LorId(AphoPassivePack_Params.PackageId, 72),
                        new LorId(AphoPassivePack_Params.PackageId, 74),
                        new LorId(AphoPassivePack_Params.PackageId, 75),
                }), //LowHP
                new PassiveOptions(74, true, passiveColorOptions: new PassiveColorOptions(Color.red, Color.red), cannotBeUsedWithPassives: new List<LorId>
                {
                        new LorId(250115),
                        new LorId(AphoPassivePack_Params.PackageId, 70),
                        new LorId(AphoPassivePack_Params.PackageId, 71),
                        new LorId(AphoPassivePack_Params.PackageId, 72),
                        new LorId(AphoPassivePack_Params.PackageId, 73),
                        new LorId(AphoPassivePack_Params.PackageId, 75),
                        new LorId(AphoPassivePack_Params.PackageId, 76),
                }), //Kill
                new PassiveOptions(75, true, passiveColorOptions: new PassiveColorOptions(new Color(1, 0.5f, 0.5f), new Color(1, 0.5f, 0.5f)), cannotBeUsedWithPassives: new List<LorId>
                {
                        new LorId(250115),
                        new LorId(AphoPassivePack_Params.PackageId, 70),
                        new LorId(AphoPassivePack_Params.PackageId, 71),
                        new LorId(AphoPassivePack_Params.PackageId, 72),
                        new LorId(AphoPassivePack_Params.PackageId, 73),
                        new LorId(AphoPassivePack_Params.PackageId, 74),
                        new LorId(AphoPassivePack_Params.PackageId, 76),
                }), //HighHP
                new PassiveOptions(76, true, passiveColorOptions: new PassiveColorOptions(new Color(1, 0.5f, 0.5f), new Color(1, 0.5f, 0.5f)), cannotBeUsedWithPassives: new List<LorId>
                {
                        new LorId(250115),
                        new LorId(AphoPassivePack_Params.PackageId, 70),
                        new LorId(AphoPassivePack_Params.PackageId, 71),
                        new LorId(AphoPassivePack_Params.PackageId, 72),
                        new LorId(AphoPassivePack_Params.PackageId, 73),
                        new LorId(AphoPassivePack_Params.PackageId, 74),
                        new LorId(AphoPassivePack_Params.PackageId, 75),
                }), //NoDeath

                //Perdition
                new PassiveOptions(80, true, passiveColorOptions: new PassiveColorOptions(new Color(0.624f, 0.169f, 0.408f), new Color(0.624f, 0.169f, 0.408f))),
                new PassiveOptions(81, true, passiveColorOptions: new PassiveColorOptions(new Color(0.624f, 0.169f, 0.408f), new Color(0.624f, 0.169f, 0.408f))),
                new PassiveOptions(82, true, passiveColorOptions: new PassiveColorOptions(new Color(0.624f, 0.169f, 0.408f), new Color(0.624f, 0.169f, 0.408f))),
                new PassiveOptions(83, true, passiveColorOptions: new PassiveColorOptions(new Color(0.624f, 0.169f, 0.408f), new Color(0.624f, 0.169f, 0.408f))),
                new PassiveOptions(84, true, passiveColorOptions: new PassiveColorOptions(new Color(0.624f, 0.169f, 0.408f), new Color(0.624f, 0.169f, 0.408f))),
                new PassiveOptions(85, true, passiveColorOptions: new PassiveColorOptions(new Color(0.624f, 0.169f, 0.408f), new Color(0.624f, 0.169f, 0.408f))),

                //Breathing
                new PassiveOptions(90, true, passiveColorOptions: new PassiveColorOptions(new Color(0.898f, 0.169f, 0.314f), new Color(0.898f, 0.169f, 0.314f))), //Deeper
                new PassiveOptions(91, true, passiveColorOptions: new PassiveColorOptions(new Color(0.898f, 0.169f, 0.314f), new Color(0.898f, 0.169f, 0.314f))), //Deepest
                new PassiveOptions(92, true, passiveColorOptions: new PassiveColorOptions(new Color(0.898f, 0.169f, 0.314f), new Color(0.898f, 0.169f, 0.314f))), //Under
                new PassiveOptions(93, true, passiveColorOptions: new PassiveColorOptions(new Color(0.898f, 0.169f, 0.314f), new Color(0.898f, 0.169f, 0.314f))), //Deathly
                new PassiveOptions(94, true, passiveColorOptions: new PassiveColorOptions(new Color(0.898f, 0.169f, 0.314f), new Color(0.898f, 0.169f, 0.314f))), //Emergency
                new PassiveOptions(95, true, passiveColorOptions: new PassiveColorOptions(new Color(0.898f, 0.169f, 0.314f), new Color(0.898f, 0.169f, 0.314f))), //Fire
            });
        }
    }
    //CombinationPassives
    public class PassiveAbility_Apho_TheStrongestProwess : PassiveAbilityBase
    {
        public static string Name = "The Strongest's Prowess";
        public static string Desc = "Choose the Speed dice with the lowest value; the Speed value of the dice change to the maximum possible value." +
            "When using a Combat Page, all dice on the page gain Power against targets with slower Speed. (+1 Power per 2 points of difference, up to 5)";
        public override void OnRollSpeedDice()
        {

            int minValue = 999;
            foreach (SpeedDice speedDice in this.owner.speedDiceResult)
            {
                if (speedDice.value < minValue)
                {
                    minValue = speedDice.value;
                }
            }
            foreach (SpeedDice speedDice2 in this.owner.speedDiceResult.FindAll((SpeedDice x) => x.value == minValue))
            {
                speedDice2.value = 999;
            }
            this.owner.speedDiceResult.Sort(delegate (SpeedDice d1, SpeedDice d2)
            {
                if (d1.breaked && d2.breaked)
                {
                    if (d1.value > d2.value)
                    {
                        return -1;
                    }
                    if (d1.value < d2.value)
                    {
                        return 1;
                    }
                    return 0;
                }
                else
                {
                    if (d1.breaked && !d2.breaked)
                    {
                        return -1;
                    }
                    if (!d1.breaked && d2.breaked)
                    {
                        return 1;
                    }
                    if (d1.value > d2.value)
                    {
                        return -1;
                    }
                    if (d1.value < d2.value)
                    {
                        return 1;
                    }
                    return 0;
                }
            });
        }
        public override void OnUseCard(BattlePlayingCardDataInUnitModel curCard)
        {
            int speedDiceResultValue = curCard.speedDiceResultValue;
            BattleUnitModel target = curCard.target;
            int targetSlotOrder = curCard.targetSlotOrder;
            if (targetSlotOrder >= 0 && targetSlotOrder < target.speedDiceResult.Count)
            {
                SpeedDice speedDice = target.speedDiceResult[targetSlotOrder];
                if (speedDiceResultValue > speedDice.value)
                {
                    int num = speedDiceResultValue - speedDice.value;
                    int num2 = Mathf.Min(5, num / 2);
                    if (num2 > 0)
                    {
                        curCard.ApplyDiceStatBonus(DiceMatch.AllDice, new DiceStatBonus
                        {
                            power = num2
                        });
                    }
                }
            }
        }
    }

    public class PassiveAbility_Apho_DiscardPassive : PassiveAbilityBase
    {
        public static string Name = "Bottom Dealing the Best Choice of Stacked Decks";
        public static string Desc = "Recover 3 HP whenever the character discards a page." +
            "If the character discards a page, restore 1 Light at the end of the Scene, and draw 1 page at the start of the next Scene.";
        public override void OnDiscardByAbility(List<BattleDiceCardModel> cards)
        {
            UnitUtil.SetPassiveCombatLog(this, owner);
            this.owner.RecoverHP(cards.Count * 3);
            this._triggeredDraw = true;
            this._triggeredLight = true;
        }

        public override void OnRoundEnd()
        {
            base.OnRoundEnd();
            if (this._triggeredLight)
            {
                this._triggeredLight = false;
                this.LightAbility();
            }
        }
        public override void OnRoundEndTheLast()
        {
            base.OnRoundEndTheLast();
            if (this._triggeredDraw)
            {
                this._triggeredDraw = false;
                this.DrawAbility();
            }
        }
        private void DrawAbility()
        {
            this.owner.allyCardDetail.DrawCards(1);
        }
        private void LightAbility()
        {
            this.owner.cardSlotDetail.RecoverPlayPoint(1);
        }
        private bool _triggeredDraw, _triggeredLight;
    }

    public class PassiveAbility_Apho_BleedPassive : PassiveAbilityBase
    {
        public static string Name = "Twist Open & Rupture Wound";
        public static string Desc = "Deal +4 damage and +1 Stagger damage against enemies with Bleed.";
        public override void BeforeGiveDamage(BattleDiceBehavior behavior)
        {
            BattleUnitModel target = behavior.card.target;
            if (target != null && target.bufListDetail.GetKewordBufStack(KeywordBuf.Bleeding) > 0)
            {
                BattleCardTotalResult battleCardResultLog = this.owner.battleCardResultLog;
                if (battleCardResultLog != null)
                {
                    battleCardResultLog.SetPassiveAbility(this);
                }
                behavior.ApplyDiceStatBonus(new DiceStatBonus
                {
                    dmg = 4,
                    breakDmg = 1
                });
            }
        }
    }

    public class PassiveAbility_Apho_FirstScene : PassiveAbilityBase
    {
        public static string Name = "Concentrated Blind Sniper Fire";
        public static string Desc = "Gain +3 Power on the first Scene." +
            "Offensive dice gain an additional +3 Power on the first Scene.";
        public override void BeforeRollDice(BattleDiceBehavior behavior)
        {
            if (Singleton<StageController>.Instance.RoundTurn == 1 && base.IsAttackDice(behavior.Detail))
            {
                BattleCardTotalResult battleCardResultLog = this.owner.battleCardResultLog;
                if (battleCardResultLog != null)
                {
                    battleCardResultLog.SetPassiveAbility(this);
                }
                behavior.ApplyDiceStatBonus(new DiceStatBonus
                {
                    power = 6
                });
            }
            else if (Singleton<StageController>.Instance.RoundTurn == 1)
            {
                BattleCardTotalResult battleCardResultLog = this.owner.battleCardResultLog;
                if (battleCardResultLog != null)
                {
                    battleCardResultLog.SetPassiveAbility(this);
                }
                behavior.ApplyDiceStatBonus(new DiceStatBonus
                {
                    power = 3
                });
            }
        }
    }

    public class PassiveAbility_Apho_Solo : PassiveAbilityBase
    {
        public static string Name = "Remembrance of a Lone Fixer";
        public static string Desc = "If an ally has died, gain 2 Strength at the end of each Scene." +
            "At the end of each Scene, gain 3 Strength if no other allies are present.";
        public override void OnRoundEnd()
        {
            if (BattleObjectManager.instance.GetList(this.owner.faction).Exists((BattleUnitModel x) => x.IsDead()))
            {
                this.owner.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Strength, 2, this.owner);
            }
            if (!BattleObjectManager.instance.GetAliveList(this.owner.faction).Exists((BattleUnitModel x) => x != this.owner))
            {
                BattleCardTotalResult battleCardResultLog = this.owner.battleCardResultLog;
                if (battleCardResultLog != null)
                {
                    battleCardResultLog.SetPassiveAbility(this);
                }
                this.owner.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Strength, 3, this.owner);
            }
        }
    }

    public class PassiveAbility_Apho_NotUse : PassiveAbilityBase
    {
        public static string Name = "Psyched-up Reaction Force";
        public static string Desc = "If the character did not use any pages, restore 1 Light and draw 1 page at the end of the Scene, and gain 1 Strength and Endurance next scene.";
        public override void OnRoundEnd()
        {
            if (this.owner.cardHistory.GetCurrentRoundCardList(Singleton<StageController>.Instance.RoundTurn).Count <= 0)
            {
                this.owner.cardSlotDetail.RecoverPlayPoint(1);
                this.owner.allyCardDetail.DrawCards(1);
                this.owner.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Endurance, 1, this.owner);
                this.owner.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Strength, 1, this.owner);
            }
        }

    }

    //CustomPassives - DEALER
    public class PassiveAbility_Apho_Mulligan : PassiveAbilityBase
    {
        public static string Name = "Mulligan";
        public static string Desc = "At the start of the Act, add a special Combat Page that allows you to discard all pages and draw the same number of pages.";
        public override void OnWaveStart()
        {
            this.owner.personalEgoDetail.AddCard(new LorId(AphoPassivePack_Params.PackageId, 1));
        }
    }
    public class DiceCardSelfAbility_Apho_MulliganCard : DiceCardSelfAbilityBase
    {
        private int _handsize;
        public static string Desc = "Discard all pages, draw the same number of pages.";
        public override void OnUseInstance(BattleUnitModel unit, BattleDiceCardModel self, BattleUnitModel targetUnit)
        {
            this._handsize = unit.allyCardDetail.GetHand().Count;
            unit.allyCardDetail.DiscardACardByAbility(unit.allyCardDetail.GetHand());
            unit.allyCardDetail.DrawCards(_handsize);
            UnitUtil.BattleAbDialog(unit.view.dialogUI, new List<AbnormalityCardDialog>
            {
                new AbnormalityCardDialog
                {
                    //id = "MulliganDialog",
                    dialog = "Draw!!"
                }
            }, AbColorType.Positive);
        }
    }


    public class PassiveAbility_Apho_DeckCycling : PassiveAbilityBase
    {
        public static string Name = "Cycling through the Deck";
        public static string Desc = "At the start of the Scene, draw 1 page and discard 1 random page.";
        public override void OnRoundStart()
        {
            this.owner.allyCardDetail.DrawCards(1);
            this.owner.allyCardDetail.DiscardACardRandomlyByAbility(1);
        }

    }
    public class PassiveAbility_Apho_CarteBlanche : PassiveAbilityBase
    {
        public static string Name = "Carte Blanche";
        public static string Desc = "If 7 or fewer pages are in-hand at the end of the Scene, add a 'Carte Blanche' to hand: 'Cost 0 - [On Play, Single-use] No effect. Exhausts when used or discarded.'";
        public override void OnRoundEnd()
        {

            if (this.owner.allyCardDetail.GetHand().Count <= 7)
            {
                this.owner.ShowPassiveTypo(this);
                this.owner.allyCardDetail.AddNewCard(new LorId(AphoPassivePack_Params.PackageId, 2), false);
            }
        }

    }
    public class DiceCardSelfAbility_Apho_CarteBlanche : DiceCardSelfAbilityBase
    {
        public static string Desc = "No effect. Exhausts when used or discarded.";
        public override void OnUseCard()
        {
            this.OnActivate(base.owner, this.card.card);
        }
        public override void OnDiscard(BattleUnitModel unit, BattleDiceCardModel self)
        {
            this.OnActivate(unit, self);
        }
        private void OnActivate(BattleUnitModel unit, BattleDiceCardModel self)
        {
            self.exhaust = true;
        }
    }

    public class PassiveAbility_Apho_CarteNoir : PassiveAbilityBase
    {
        public static string Name = "Carte Noir";
        public static string Desc = "At the start of the Act, add a 'Carte Noir' to all enemies' hands: '[On Play, Single-use] The cost of this page equals the user's Max Light. Exhausts when used or discarded; On Exhaust Lose all Light'.";

        private void GiveCarteNoir()
        {
            List<BattleUnitModel> aliveList = BattleObjectManager.instance.GetAliveList((this.owner.faction == Faction.Player) ? Faction.Enemy : Faction.Player);
            foreach (BattleUnitModel battleUnitModel in aliveList)
            {
                battleUnitModel.allyCardDetail.AddNewCard(new LorId(AphoPassivePack_Params.PackageId, 3), false);
            }
        }
        public override void OnWaveStart()
        {
            this.GiveCarteNoir();
            //this.owner.allyCardDetail.AddNewCard(new LorId(AphoPassivePack_Params.PackageId, 3), false); //Give card to self for testing purpose, remember to delete before release
        }

    }
    public class DiceCardSelfAbility_Apho_CarteNoir : DiceCardSelfAbilityBase
    {
        public static string Desc = "The cost of this page equals the User's Max Light. Exhausts when used or discarded; On Exhaust Lose all Light.";
        public override int GetCostLast(BattleUnitModel unit, BattleDiceCardModel self, int oldCost)
        {
            return unit.cardSlotDetail.GetMaxPlayPoint();
        }
        public override void OnUseCard()
        {
            this.OnActivate(base.owner, this.card.card);
        }
        public override void OnDiscard(BattleUnitModel unit, BattleDiceCardModel self)
        {
            this.OnActivate(unit, self);
        }
        private void OnActivate(BattleUnitModel unit, BattleDiceCardModel self)
        {
            int playPoint = unit.cardSlotDetail.GetMaxPlayPoint();
            this.owner.cardSlotDetail.LoseWhenStartRound(playPoint);
            this.owner.cardSlotDetail.LosePlayPoint(playPoint);
            self.exhaust = true;
        }
    }

    public class PassiveAbility_Apho_DealHand : PassiveAbilityBase
    {
        public static string Name = "Deal Hand";
        public static string Desc = "All dice gain 1 Power per 2 pages in hand, up to 5.";
        private int _bonus;
        public override void BeforeRollDice(BattleDiceBehavior behavior)
        {
            base.BeforeRollDice(behavior);
            _bonus = Mathf.Min(5, this.owner.allyCardDetail.GetHand().Count / 2);
            if (_bonus > 0)
            {
                BattleCardTotalResult battleCardResultLog = this.owner.battleCardResultLog;
                if (battleCardResultLog != null)
                {
                    battleCardResultLog.SetPassiveAbility(this);
                }
                behavior.ApplyDiceStatBonus(new DiceStatBonus
                {
                    power = _bonus
                });
            }
        }
    }

    public class PassiveAbility_Apho_PageToss : PassiveAbilityBase
    {
        public static string Name = "Page Toss";
        public static string Desc = "Deal 3 damage to a random enemy whenever the character discards a page.";

        private int _hits;
        public override void OnDiscardByAbility(List<BattleDiceCardModel> cards)
        {
            List<BattleUnitModel> aliveList = BattleObjectManager.instance.GetAliveList((this.owner.faction == Faction.Player) ? Faction.Enemy : Faction.Player);
            _hits = cards.Count;
            BattleCardTotalResult battleCardResultLog = this.owner.battleCardResultLog;
            if (battleCardResultLog != null)
            {
                battleCardResultLog.SetPassiveAbility(this);
            }
            while (aliveList.Count > 0 && _hits > 0)
            {
                BattleUnitModel battleUnitModel = RandomUtil.SelectOne<BattleUnitModel>(aliveList);
                battleUnitModel.TakeDamage(3, DamageType.Passive, this.owner, KeywordBuf.None);
                _hits--;
            }
        }
    }

    //CustomPassives - FAIRY
    public class PassiveAbility_Apho_FairyFalchion : PassiveAbilityBase
    {
        public static string Name = "Fairy Falchion";
        public static string Desc = "Inflict 1 Fairy on hit.";
        public override void OnSucceedAttack(BattleDiceBehavior behavior)
        {
            BattleCardTotalResult battleCardResultLog = this.owner.battleCardResultLog;
            if (battleCardResultLog != null)
            {
                battleCardResultLog.SetPassiveAbility(this);
            }
            BattleUnitModel target = behavior.card.target;
            if (target == null)
            {
                return;
            }
            target.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Fairy, 1, this.owner);
        }
    }
    public class PassiveAbility_Apho_ElvenEscutcheon : PassiveAbilityBase
    {
        public static string Name = "Elven Escutcheon";
        public static string Desc = "When hit, inflict 1 Fairy to attacker.";
        public override void OnTakeDamageByAttack(BattleDiceBehavior atkDice, int dmg)
        {
            BattleCardTotalResult battleCardResultLog = this.owner.battleCardResultLog;
            if (battleCardResultLog != null)
            {
                battleCardResultLog.SetPassiveAbility(this);
            }
            atkDice.owner.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Fairy, 1, this.owner);
        }
    }
    public class PassiveAbility_Apho_IgnisFatuus : PassiveAbilityBase
    {
        public static string Name = "Ignis Fatuus";
        public static string Desc = "On a successful hit, if the target had 9 or more stacks of Fairy, inflict 1 Burn and 1 Fairy to a random enemy.";
        public override void OnSucceedAttack(BattleDiceBehavior behavior)
        {
            if (behavior.card.target == null)
            {
                return;
            }
            if (behavior.card.target.bufListDetail.GetKewordBufAllStack(KeywordBuf.Fairy) >= 9)
            {
                UnitUtil.SetPassiveCombatLog(this, owner);
                List<BattleUnitModel> aliveList_random = BattleObjectManager.instance.GetAliveList_random((this.owner.faction == Faction.Enemy) ? Faction.Player : Faction.Enemy, 1);
                foreach (BattleUnitModel battleUnitModel in aliveList_random)
                {
                    battleUnitModel.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Burn, 1, this.owner);
                    battleUnitModel.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Fairy, 1, this.owner);
                }

            }
        }

    }
    public class PassiveAbility_Apho_LjosalfarLight : PassiveAbilityBase
    {
        public static string Name = "Ljosalfar Light";
        public static string Desc = "At the start of the Scene, restore 1 Light and gain 3 Fairy.";
        public override void OnRoundStart()
        {
            UnitUtil.SetPassiveCombatLog(this, owner);
            this.owner.cardSlotDetail.RecoverPlayPoint(1);
            this.owner.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Fairy, 3, this.owner);
        }
    }
    public class PassiveAbility_Apho_DokkalfarDirge : PassiveAbilityBase
    {
        public static string Name = "Dokkalfar Dirge";
        public static string Desc = "When a character dies, inflict 4 Fairy to all enemies.";
        public override void OnDie()
        {
            UnitUtil.SetPassiveCombatLog(this, owner);
            List<BattleUnitModel> aliveList = BattleObjectManager.instance.GetAliveList((this.owner.faction == Faction.Player) ? Faction.Enemy : Faction.Player);
            foreach (BattleUnitModel battleUnitModel in aliveList)
            {
                battleUnitModel.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Fairy, 4, null);
            }
        }
        public override void OnDieOtherUnit(BattleUnitModel unit)
        {
            UnitUtil.SetPassiveCombatLog(this, owner);
            List<BattleUnitModel> aliveList = BattleObjectManager.instance.GetAliveList((this.owner.faction == Faction.Player) ? Faction.Enemy : Faction.Player);
            foreach (BattleUnitModel battleUnitModel in aliveList)
            {
                battleUnitModel.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Fairy, 4, null);
            }
        }
    }
    public class PassiveAbility_Apho_FickleFairy : PassiveAbilityBase
    {
        public static string Name = "Fickle Fairy";
        public static string Desc = "At the start of the Scene, inflict 1 Fairy to a random enemy.";
        public override void OnRoundStart()
        {
            List<BattleUnitModel> aliveList_random = BattleObjectManager.instance.GetAliveList_random((this.owner.faction == Faction.Enemy) ? Faction.Player : Faction.Enemy, 1);
            this.owner.ShowPassiveTypo(this);
            foreach (BattleUnitModel battleUnitModel in aliveList_random)
            {
                battleUnitModel.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Fairy, 1, this.owner);
            }
        }
    }

    //Gunner
    public class PassiveAbility_Apho_PreloadedFirearm : PassiveAbilityBase
    {
        public static string Name = "Preloaded Firearm";
        public static string Desc = "At the start of the Act, add 2 random Ammunition to hand.";
        public override void OnWaveStart()
        {
            if (this.owner.passiveDetail.HasPassive<PassiveAbility_Apho_APAmmo>())
            {
                this.owner.allyCardDetail.AddNewCard(new LorId(602020), false);
                this.owner.allyCardDetail.AddNewCard(new LorId(602020), false);
            }
            else if (this.owner.passiveDetail.HasPassive<PassiveAbility_Apho_FrostAmmo>())
            {
                this.owner.allyCardDetail.AddNewCard(new LorId(602021), false);
                this.owner.allyCardDetail.AddNewCard(new LorId(602021), false);
            }
            else if (this.owner.passiveDetail.HasPassive<PassiveAbility_Apho_FlameAmmo>())
            {
                this.owner.allyCardDetail.AddNewCard(new LorId(602022), false);
                this.owner.allyCardDetail.AddNewCard(new LorId(602022), false);
            }
            else
            {
                this.owner.allyCardDetail.AddNewCard(ThumbBulletClass.GetRandomBulletId(), false);
                this.owner.allyCardDetail.AddNewCard(ThumbBulletClass.GetRandomBulletId(), false);
            }
        }
    }

    //Ammo IDs: AP - 602020, Frost - 602021, Flame - 602022
    public class PassiveAbility_Apho_APAmmo : PassiveAbilityBase
    {
        public static string Name = "Armor-piercing Rounds";
        public static string Desc = "All other Ammunition will be replaced with Armor-piercing Ammunition.";
        private void ReplaceAmmo()
        {
            int _replacements = -1;
            List<BattleDiceCardModel> FrostAmmo = base.owner.allyCardDetail.GetHand().FindAll((BattleDiceCardModel x) => x.GetID() == 602021);
            if (FrostAmmo != null)
            {
                _replacements = FrostAmmo.Count;
                while (_replacements > 0)
                {
                    BattleDiceCardModel battleDiceCardModel = RandomUtil.SelectOne<BattleDiceCardModel>(FrostAmmo);
                    base.owner.allyCardDetail.DiscardACardByAbility(battleDiceCardModel);
                    base.owner.allyCardDetail.AddNewCard(new LorId(602020), false);
                    _replacements--;
                }
            }
            List<BattleDiceCardModel> FlameAmmo = base.owner.allyCardDetail.GetHand().FindAll((BattleDiceCardModel x) => x.GetID() == 602022);
            if (FlameAmmo != null)
            {
                _replacements = FlameAmmo.Count;
                while (_replacements > 0)
                {
                    BattleDiceCardModel battleDiceCardModel1 = RandomUtil.SelectOne<BattleDiceCardModel>(FlameAmmo);
                    base.owner.allyCardDetail.DiscardACardByAbility(battleDiceCardModel1);
                    base.owner.allyCardDetail.AddNewCard(new LorId(602020), false);
                    _replacements--;
                }
            }

        }
        public override void OnRoundStart()
        {
            ReplaceAmmo();
        }
    }
    public class PassiveAbility_Apho_FrostAmmo : PassiveAbilityBase
    {
        public static string Name = "Frost Rounds";
        public static string Desc = "All other Ammunition will be replaced with Frost Ammunition.";
        private void ReplaceAmmo()
        {
            int _replacements = -1;
            List<BattleDiceCardModel> APAmmo = base.owner.allyCardDetail.GetHand().FindAll((BattleDiceCardModel x) => x.GetID() == 602020);
            if (APAmmo != null)
            {
                _replacements = APAmmo.Count;
                while (_replacements > 0)
                {
                    BattleDiceCardModel battleDiceCardModel = RandomUtil.SelectOne<BattleDiceCardModel>(APAmmo);
                    base.owner.allyCardDetail.DiscardACardByAbility(battleDiceCardModel);
                    base.owner.allyCardDetail.AddNewCard(new LorId(602021), false);
                    _replacements--;
                }
            }
            List<BattleDiceCardModel> FlameAmmo = base.owner.allyCardDetail.GetHand().FindAll((BattleDiceCardModel x) => x.GetID() == 602022);
            if (FlameAmmo != null)
            {
                _replacements = FlameAmmo.Count;
                while (_replacements > 0)
                {
                    BattleDiceCardModel battleDiceCardModel1 = RandomUtil.SelectOne<BattleDiceCardModel>(FlameAmmo);
                    base.owner.allyCardDetail.DiscardACardByAbility(battleDiceCardModel1);
                    base.owner.allyCardDetail.AddNewCard(new LorId(602021), false);
                    _replacements--;
                }
            }

        }
        public override void OnRoundStart()
        {
            ReplaceAmmo();
        }
    }
    public class PassiveAbility_Apho_FlameAmmo : PassiveAbilityBase
    {
        public static string Name = "Flame Rounds";
        public static string Desc = "All other Ammunition will be replaced with Flame Ammunition.";
        private void ReplaceAmmo()
        {
            int _replacements = -1;
            List<BattleDiceCardModel> APAmmo = base.owner.allyCardDetail.GetHand().FindAll((BattleDiceCardModel x) => x.GetID() == 602020);
            if (APAmmo != null)
            {
                _replacements = APAmmo.Count;
                while (_replacements > 0)
                {
                    BattleDiceCardModel battleDiceCardModel = RandomUtil.SelectOne<BattleDiceCardModel>(APAmmo);
                    base.owner.allyCardDetail.DiscardACardByAbility(battleDiceCardModel);
                    base.owner.allyCardDetail.AddNewCard(new LorId(602022), false);
                    _replacements--;
                }
            }
            List<BattleDiceCardModel> FrostAmmo = base.owner.allyCardDetail.GetHand().FindAll((BattleDiceCardModel x) => x.GetID() == 602021);
            if (FrostAmmo != null)
            {
                _replacements = FrostAmmo.Count;
                while (_replacements > 0)
                {
                    BattleDiceCardModel battleDiceCardModel1 = RandomUtil.SelectOne<BattleDiceCardModel>(FrostAmmo);
                    base.owner.allyCardDetail.DiscardACardByAbility(battleDiceCardModel1);
                    base.owner.allyCardDetail.AddNewCard(new LorId(602022), false);
                    _replacements--;
                }
            }
        }
        public override void OnRoundStart()
        {
            ReplaceAmmo();
        }
    }
    public class PassiveAbility_Apho_AmmoRecycling : PassiveAbilityBase
    {
        public static string Name = "Rounds Recycling";
        public static string Desc = "After every three successful attacks with Ranged Combat Pages, add a random Ammunition to hand.";
        public override void OnSucceedAttack(BattleDiceBehavior behavior)
        {
            if (behavior.card.card.GetSpec().Ranged == CardRange.Far)
            {
                this._count++;
                if (this._count >= 3)
                {
                    UnitUtil.SetPassiveCombatLog(this, owner);
                    this.owner.allyCardDetail.AddNewCard(ThumbBulletClass.GetRandomBulletId(), false);
                    this._count = 0;
                }
            }
        }
        private int _count;
    }
    public class PassiveAbility_Apho_AmmoOverTime : PassiveAbilityBase
    {
        public static string Name = "Ammo Delivery";
        public static string Desc = "Starting from Scene 3, add a random ammunition to hand every 3 Scenes.";
        public override void OnRoundStart()
        {
            if (Singleton<StageController>.Instance.RoundTurn % 3 == 0)
            {
                UnitUtil.SetPassiveCombatLog(this, owner);
                this.owner.allyCardDetail.AddNewCard(ThumbBulletClass.GetRandomBulletId(), false);
            }
        }
    }


    //MANAGER
    public class PassiveAbility_Apho_HPBullet : PassiveAbilityBase
    {
        public static string Name = "HP-N Bullet";
        public static string Desc = "At the start of the Act, add a special Combat Page that can recover HP for an ally. When the emotion level rises, it can be used again.";
        public override void OnWaveStart()
        {
            this.owner.personalEgoDetail.AddCard(new LorId(AphoPassivePack_Params.PackageId, 6));
        }
        public override void OnLevelUpEmotion()
        {
            List<BattleDiceCardModel> CheckHPBullet = base.owner.personalEgoDetail.GetHand().FindAll((BattleDiceCardModel x) => x.GetID() == new LorId(AphoPassivePack_Params.PackageId, 6));
            if (CheckHPBullet.Count <= 0)
            {
                this.owner.personalEgoDetail.AddCard(new LorId(AphoPassivePack_Params.PackageId, 6));
            }
        }

    }
    public class DiceCardSelfAbility_Apho_HPBullet : DiceCardSelfAbilityBase
    {
        public static string Desc = "Target ally recovers 8 HP";
        public override void OnUseInstance(BattleUnitModel unit, BattleDiceCardModel self, BattleUnitModel targetUnit)
        {
            if (targetUnit != null)
            {
                targetUnit.RecoverHP(8); SingletonBehavior<BattleManagerUI>.Instance.ui_unitListInfoSummary.UpdateCharacterProfile(targetUnit, targetUnit.faction, targetUnit.hp, targetUnit.breakDetail.breakGauge, targetUnit.bufListDetail.GetBufUIDataList());
            }
        }
        public override bool IsValidTarget(BattleUnitModel unit, BattleDiceCardModel self, BattleUnitModel targetUnit)
        {
            return targetUnit != null && targetUnit.faction == unit.faction;
        }
        public override bool IsOnlyAllyUnit()
        {
            return true;
        }
    }
    public class PassiveAbility_Apho_SPBullet : PassiveAbilityBase
    {
        public static string Name = "SP-E Bullet";
        public static string Desc = "At the start of the Act, add a special Combat Page that can recover Stagger Resist for an ally. When the emotion level rises, it can be used again.";
        public override void OnWaveStart()
        {
            this.owner.personalEgoDetail.AddCard(new LorId(AphoPassivePack_Params.PackageId, 7));
        }
        public override void OnLevelUpEmotion()
        {
            List<BattleDiceCardModel> CheckSPBullet = base.owner.personalEgoDetail.GetHand().FindAll((BattleDiceCardModel x) => x.GetID() == new LorId(AphoPassivePack_Params.PackageId, 7));
            if (CheckSPBullet.Count <= 0)
            {
                this.owner.personalEgoDetail.AddCard(new LorId(AphoPassivePack_Params.PackageId, 7));
            }
        }

    }
    public class DiceCardSelfAbility_Apho_SPBullet : DiceCardSelfAbilityBase
    {
        public static string Desc = "Target ally recovers 8 Stagger Resist";
        public override void OnUseInstance(BattleUnitModel unit, BattleDiceCardModel self, BattleUnitModel targetUnit)
        {
            if (targetUnit != null)
            {
                targetUnit.breakDetail.RecoverBreak(8);
                SingletonBehavior<BattleManagerUI>.Instance.ui_unitListInfoSummary.UpdateCharacterProfile(targetUnit, targetUnit.faction, targetUnit.hp, targetUnit.breakDetail.breakGauge, targetUnit.bufListDetail.GetBufUIDataList());
            }
        }
        public override bool IsValidTarget(BattleUnitModel unit, BattleDiceCardModel self, BattleUnitModel targetUnit)
        {
            return targetUnit != null && targetUnit.faction == unit.faction;
        }
        public override bool IsOnlyAllyUnit()
        {
            return true;
        }
    }

    public class PassiveAbility_Apho_RShieldBullet : PassiveAbilityBase
    {
        public static string Name = "Physical Intervention Shield";
        public static string Desc = "At the start of the Act, add a special Combat Page that gives an ally Protection. When the emotion level rises, it can be used again.";
        public override void OnWaveStart()
        {
            this.owner.personalEgoDetail.AddCard(new LorId(AphoPassivePack_Params.PackageId, 8));
        }
        public override void OnLevelUpEmotion()
        {
            List<BattleDiceCardModel> CheckRShieldBullet = base.owner.personalEgoDetail.GetHand().FindAll((BattleDiceCardModel x) => x.GetID() == new LorId(AphoPassivePack_Params.PackageId, 8));
            if (CheckRShieldBullet.Count <= 0)
            {
                this.owner.personalEgoDetail.AddCard(new LorId(AphoPassivePack_Params.PackageId, 8));
            }
        }

    }
    public class DiceCardSelfAbility_Apho_RShieldBullet : DiceCardSelfAbilityBase
    {
        public static string Desc = "Give target ally 4 Protection";
        public override void OnUseInstance(BattleUnitModel unit, BattleDiceCardModel self, BattleUnitModel targetUnit)
        {
            if (targetUnit != null)
            {
                targetUnit.bufListDetail.AddKeywordBufThisRoundByCard(KeywordBuf.Protection, 4, null);
                SingletonBehavior<BattleManagerUI>.Instance.ui_unitListInfoSummary.UpdateCharacterProfileAll();
            }
        }
        public override bool IsValidTarget(BattleUnitModel unit, BattleDiceCardModel self, BattleUnitModel targetUnit)
        {
            return targetUnit != null && targetUnit.faction == unit.faction;
        }
        public override bool IsOnlyAllyUnit()
        {
            return true;
        }
    }
    public class PassiveAbility_Apho_WShieldBullet : PassiveAbilityBase
    {
        public static string Name = "Trauma Shield";
        public static string Desc = "At the start of the Act, add a special Combat Page that gives an ally Stagger Protection. When the emotion level rises, it can be used again.";
        public override void OnWaveStart()
        {
            this.owner.personalEgoDetail.AddCard(new LorId(AphoPassivePack_Params.PackageId, 9));
        }
        public override void OnLevelUpEmotion()
        {
            List<BattleDiceCardModel> CheckWShieldBullet = base.owner.personalEgoDetail.GetHand().FindAll((BattleDiceCardModel x) => x.GetID() == new LorId(AphoPassivePack_Params.PackageId, 9));
            if (CheckWShieldBullet.Count <= 0)
            {
                this.owner.personalEgoDetail.AddCard(new LorId(AphoPassivePack_Params.PackageId, 9));
            }
        }

    }
    public class DiceCardSelfAbility_Apho_WShieldBullet : DiceCardSelfAbilityBase
    {
        public static string Desc = "Give target ally 4 Stagger Protection";
        public override void OnUseInstance(BattleUnitModel unit, BattleDiceCardModel self, BattleUnitModel targetUnit)
        {
            if (targetUnit != null)
            {
                targetUnit.bufListDetail.AddKeywordBufThisRoundByCard(KeywordBuf.BreakProtection, 4, null);
                SingletonBehavior<BattleManagerUI>.Instance.ui_unitListInfoSummary.UpdateCharacterProfileAll();
            }
        }
        public override bool IsValidTarget(BattleUnitModel unit, BattleDiceCardModel self, BattleUnitModel targetUnit)
        {
            return targetUnit != null && targetUnit.faction == unit.faction;
        }
        public override bool IsOnlyAllyUnit()
        {
            return true;
        }
    }

    public class PassiveAbility_Apho_BShieldBullet : PassiveAbilityBase
    {
        public static string Name = "Erosion Shield";
        public static string Desc = "At the start of the Act, add a special Combat Page that gives an ally Protection and Stagger Protection. When the emotion level rises, it can be used again.";
        public override void OnWaveStart()
        {
            this.owner.personalEgoDetail.AddCard(new LorId(AphoPassivePack_Params.PackageId, 10));
        }
        public override void OnLevelUpEmotion()
        {
            List<BattleDiceCardModel> CheckBShieldBullet = base.owner.personalEgoDetail.GetHand().FindAll((BattleDiceCardModel x) => x.GetID() == new LorId(AphoPassivePack_Params.PackageId, 10));
            if (CheckBShieldBullet.Count <= 0)
            {
                this.owner.personalEgoDetail.AddCard(new LorId(AphoPassivePack_Params.PackageId, 10));
            }
        }

    }
    public class DiceCardSelfAbility_Apho_BShieldBullet : DiceCardSelfAbilityBase
    {
        public static string Desc = "Give target ally 2 Protection and 2 Stagger Protection";
        public override void OnUseInstance(BattleUnitModel unit, BattleDiceCardModel self, BattleUnitModel targetUnit)
        {
            if (targetUnit != null)
            {
                targetUnit.bufListDetail.AddKeywordBufThisRoundByCard(KeywordBuf.BreakProtection, 2, null);
                targetUnit.bufListDetail.AddKeywordBufThisRoundByCard(KeywordBuf.Protection, 2, null);
                SingletonBehavior<BattleManagerUI>.Instance.ui_unitListInfoSummary.UpdateCharacterProfileAll();
            }
        }
        public override bool IsValidTarget(BattleUnitModel unit, BattleDiceCardModel self, BattleUnitModel targetUnit)
        {
            return targetUnit != null && targetUnit.faction == unit.faction;
        }
        public override bool IsOnlyAllyUnit()
        {
            return true;
        }
    }

    public class PassiveAbility_Apho_PShieldBullet : PassiveAbilityBase
    {
        public static string Name = "Pale Shield";
        public static string Desc = "At the start of the Act, add a special Combat Page that gives an ally Endurance. When the emotion level rises, it can be used again.";
        public override void OnWaveStart()
        {
            this.owner.personalEgoDetail.AddCard(new LorId(AphoPassivePack_Params.PackageId, 11));
        }
        public override void OnLevelUpEmotion()
        {
            List<BattleDiceCardModel> CheckPShieldBullet = base.owner.personalEgoDetail.GetHand().FindAll((BattleDiceCardModel x) => x.GetID() == new LorId(AphoPassivePack_Params.PackageId, 11));
            if (CheckPShieldBullet.Count <= 0)
            {
                this.owner.personalEgoDetail.AddCard(new LorId(AphoPassivePack_Params.PackageId, 11));
            }
        }

    }
    public class DiceCardSelfAbility_Apho_PShieldBullet : DiceCardSelfAbilityBase
    {
        public static string Desc = "Give target ally 2 Endurance";
        public override void OnUseInstance(BattleUnitModel unit, BattleDiceCardModel self, BattleUnitModel targetUnit)
        {
            if (targetUnit != null)
            {
                targetUnit.bufListDetail.AddKeywordBufThisRoundByCard(KeywordBuf.Endurance, 2, null); SingletonBehavior<BattleManagerUI>.Instance.ui_unitListInfoSummary.UpdateCharacterProfileAll();
            }
        }
        public override bool IsValidTarget(BattleUnitModel unit, BattleDiceCardModel self, BattleUnitModel targetUnit)
        {
            return targetUnit != null && targetUnit.faction == unit.faction;
        }
        public override bool IsOnlyAllyUnit()
        {
            return true;
        }
    }

    public class PassiveAbility_Apho_SlowBullet : PassiveAbilityBase
    {
        public static string Name = "Qliphoth Intervention Field";
        public static string Desc = "At the start of the Act, add a special Combat Page that inflicts Paralysis. When the emotion level rises, it can be used again.";
        public override void OnWaveStart()
        {
            this.owner.personalEgoDetail.AddCard(new LorId(AphoPassivePack_Params.PackageId, 5));
        }
        public override void OnLevelUpEmotion()
        {
            List<BattleDiceCardModel> CheckSlowBullet = base.owner.personalEgoDetail.GetHand().FindAll((BattleDiceCardModel x) => x.GetID() == new LorId(AphoPassivePack_Params.PackageId, 5));
            if (CheckSlowBullet.Count <= 0)
            {
                this.owner.personalEgoDetail.AddCard(new LorId(AphoPassivePack_Params.PackageId, 5));
            }
        }
    }
    public class DiceCardSelfAbility_Apho_SlowBullet : DiceCardSelfAbilityBase
    {
        public static string Desc = "Inflict 1 Paralysis";
        public override void OnUseInstance(BattleUnitModel unit, BattleDiceCardModel self, BattleUnitModel targetUnit)
        {
            if (targetUnit != null)
            {
                targetUnit.bufListDetail.AddKeywordBufThisRoundByCard(KeywordBuf.Paralysis, 1, null); SingletonBehavior<BattleManagerUI>.Instance.ui_unitListInfoSummary.UpdateCharacterProfileAll();
            }
        }
    }
    public class PassiveAbility_Apho_ExecutionBullet : PassiveAbilityBase
    {
        public static string Name = "Execution Bullet";
        public static string Desc = "At the start of the Act, add a special Combat Page that can kill an ally. When the emotion level rises, it can be used again.";
        public override void OnWaveStart()
        {
            this.owner.personalEgoDetail.AddCard(new LorId(AphoPassivePack_Params.PackageId, 4));
        }
        public override void OnLevelUpEmotion()
        {
            List<BattleDiceCardModel> CheckExecutionBullet = base.owner.personalEgoDetail.GetHand().FindAll((BattleDiceCardModel x) => x.GetID() == new LorId(AphoPassivePack_Params.PackageId, 4));
            if (CheckExecutionBullet.Count <= 0)
            {
                this.owner.personalEgoDetail.AddCard(new LorId(AphoPassivePack_Params.PackageId, 4));
            }
        }
    }
    public class DiceCardSelfAbility_Apho_ExecutionBullet : DiceCardSelfAbilityBase
    {
        public static string Desc = "Kill target ally";
        public override void OnUseInstance(BattleUnitModel unit, BattleDiceCardModel self, BattleUnitModel targetUnit)
        {
            targetUnit.Die(null, true);
        }
        public override bool IsValidTarget(BattleUnitModel unit, BattleDiceCardModel self, BattleUnitModel targetUnit)
        {
            return targetUnit != null && targetUnit.faction == unit.faction;
        }
        public override bool IsOnlyAllyUnit()
        {
            return true;
        }
    }

    //GAMBLER
    public class PassiveAbility_Apho_GachaSword : PassiveAbilityBase
    {
        public static string Name = "Gacha Sword";
        public static string Desc = "On hit, inflict 1-2 Burn, Bleed, Erosion, Fairy, or Paralysis.";
        public override void OnSucceedAttack(BattleDiceBehavior behavior)
        {
            BattleUnitModel target = behavior.card.target;
            if (target == null)
            {
                return;
            }
            int Apho_GachaSword_RNG = RandomUtil.Range(0, 4);
            int stack = RandomUtil.Range(1, 2);
            switch (Apho_GachaSword_RNG)
            {
                case 0:
                    //Desc = "Inflict 1-2 Burn";
                    target.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Burn, stack, this.owner);
                    break;
                case 1:
                    //Desc = "Inflict 1-2 Bleed";
                    target.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Bleeding, stack, this.owner);
                    break;
                case 2:
                    //Desc = "Inflict 1-2 Erosion";
                    target.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Decay, stack, this.owner);
                    break;
                case 3:
                    //Desc = "Inflict 1-2 Fairy";
                    target.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Fairy, stack, this.owner);
                    break;
                case 4:
                    //Desc = "Inflict 1-2 Paralysis";
                    target.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Paralysis, stack, this.owner);
                    break;
            }
            UnitUtil.SetPassiveCombatLog(this, owner);
        }
    }
    public class PassiveAbility_Apho_Jackpot : PassiveAbilityBase
    {
        public static string Name = "Jackpot";
        public static string Desc = "Whenever an offensive dice rolls the maximum value, deal 1-3 damage.";
        public override void OnRollDice(BattleDiceBehavior behavior)
        {
            if (behavior.DiceVanillaValue == behavior.GetDiceMax())
            {
                BattleUnitModel target = behavior.card.target;
                if (target == null)
                {
                    return;
                }
                int _bonus = RandomUtil.Range(1, 3);
                UnitUtil.SetPassiveCombatLog(this, owner);
                target.TakeDamage(_bonus, DamageType.Passive, target, KeywordBuf.None);

            }
        }
    }
    public class PassiveAbilityBase_Apho_LightLuck : PassiveAbilityBase
    {
        public static string Name = "Light of Luck";
        public static string Desc = "At the start of the Scene, either restore 1-2 Light or lose 1 Light at random.";
        public override void OnRoundStart()
        {
            int _rng;
            _rng = RandomUtil.Range(0, 2);
            if (_rng == 0)
            {
                this.owner.cardSlotDetail.LosePlayPoint(1);
            }
            else
            {
                this.owner.cardSlotDetail.RecoverPlayPoint(_rng);
            }
        }
    }
    public class PassiveAbility_Apho_DrawLuck : PassiveAbilityBase
    {
        public static string Name = "Luck of the Draw";
        public static string Desc = "At the start of the Scene, either draw 1 page or discard 1 random page at random.";
        public override void OnRoundStart()
        {
            int _rng;
            _rng = RandomUtil.Range(0, 1);
            if (_rng == 0)
            {
                this.owner.allyCardDetail.DrawCards(1);
            }
            else
            {
                this.owner.allyCardDetail.DiscardACardRandomlyByAbility(1);
            }
        }
    }
    public class PassiveAbility_Apho_RandomHauler : PassiveAbilityBase
    {
        public static string Name = "Random Hauler";
        public static string Desc = "On a successful attack, recover 1-3 HP or Stagger Resist at random.";
        public override void OnSucceedAttack(BattleDiceBehavior behavior)
        {
            int _rng, _rec;
            _rng = RandomUtil.Range(0, 1);
            _rec = RandomUtil.Range(1, 3);
            if (_rng == 0)
            {
                this.owner.RecoverHP(_rec);
            }
            else
            {
                this.owner.breakDetail.RecoverBreak(_rec);
            }
            UnitUtil.SetPassiveCombatLog(this, owner);
        }
    }
    public class PassiveAbility_Apho_RaisedStakes : PassiveAbilityBase
    {
        public static string Name = "Raised Stakes";
        public static string Desc = "In a clash, the character's dice gain 2-3 Power, and the opponent's dice gain 1-2 Power.";
        public override void BeforeRollDice(BattleDiceBehavior behavior)
        {
            if (behavior.IsParrying())
            {
                UnitUtil.SetPassiveCombatLog(this, owner);
                int _selfbonus, _foebonus;
                _selfbonus = RandomUtil.Range(2, 3);
                _foebonus = RandomUtil.Range(1, 2);
                behavior.ApplyDiceStatBonus(new DiceStatBonus
                {
                    power = _selfbonus
                });
                behavior.TargetDice.ApplyDiceStatBonus(new DiceStatBonus
                {
                    power = _foebonus
                });
            }
        }

    }

    //Martyr
    public class PassiveAbility_Apho_EdibleCorpse : PassiveAbilityBase
    {
        public static string Name = "Edible Corpse";
        public static string Desc = "Upon death, all allies recover HP equal to 20% of this character's max HP.";
        public override void OnDie()
        {
            UnitUtil.SetPassiveCombatLog(this, owner);
            List<BattleUnitModel> aliveList = BattleObjectManager.instance.GetAliveList(this.owner.faction);
            int _rec = (int)((float)this.owner.MaxHp * 0.2f);
            foreach (BattleUnitModel battleUnitModel in aliveList)
            {
                battleUnitModel.RecoverHP(_rec);
            }
        }
    }
    public class PassiveAbility_Apho_OxideOverload : PassiveAbilityBase
    {
        public static string Name = "Oxide Overload";
        public static string Desc = "Upon death, allies are inflicted with 10 Smoke.";
        public override void OnDie()
        {
            UnitUtil.SetPassiveCombatLog(this, owner);
            List<BattleUnitModel> aliveList = BattleObjectManager.instance.GetAliveList(this.owner.faction);
            if (aliveList.Count == 0)
            {
                return;
            }
            foreach (BattleUnitModel battleUnitModel in aliveList)
            {
                battleUnitModel.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Smoke, 10, this.owner);
            }
        }
    }
    public class PassiveAbility_Apho_ExpiringDirge : PassiveAbilityBase
    {
        public static string Name = "Erlöschend Dirge of a War Grave";
        public static string Desc = "Upon death, allies gain 3 Strength, Endurance, and Haste next scene.";
        public override void OnDie()
        {
            UnitUtil.SetPassiveCombatLog(this, owner);
            List<BattleUnitModel> aliveList = BattleObjectManager.instance.GetAliveList(this.owner.faction);
            foreach (BattleUnitModel battleUnitModel in aliveList)
            {
                battleUnitModel.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Strength, 3, this.owner);
                battleUnitModel.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Endurance, 3, this.owner);
                battleUnitModel.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Quickness, 3, this.owner);
            }
        }
    }
    public class PassiveAbility_Apho_GardePerdue : PassiveAbilityBase
    {
        public static string Name = "Garde Perdue";
        public static string Desc = "Upon death, all enemies are inflicted with 5 Fragile next scene.";
        public override void OnDie()
        {
            UnitUtil.SetPassiveCombatLog(this, owner);
            List<BattleUnitModel> aliveList = BattleObjectManager.instance.GetAliveList((this.owner.faction == Faction.Player) ? Faction.Enemy : Faction.Player);
            foreach (BattleUnitModel battleUnitModel in aliveList)
            {
                battleUnitModel.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Vulnerable, 5, null);
            }
        }
    }
    public class PassiveAbility_Apho_EndOfShow : PassiveAbilityBase
    {
        public static string Name = "The End of the Show";
        public static string Desc = "Upon death, allies fully restore stagger resist, and all status ailments on them are halved.";
        public override void OnDie()
        {
            UnitUtil.SetPassiveCombatLog(this, owner);
            List<BattleUnitModel> aliveList = BattleObjectManager.instance.GetAliveList(this.owner.faction);
            foreach (BattleUnitModel battleUnitModel in aliveList)
            {
                battleUnitModel.RecoverBreakLife(battleUnitModel.MaxBreakLife, false);
                battleUnitModel.breakDetail.nextTurnBreak = false;
                battleUnitModel.breakDetail.RecoverBreak(battleUnitModel.breakDetail.GetDefaultBreakGauge());
                foreach (BattleUnitBuf battleUnitBuf in battleUnitModel.bufListDetail.GetActivatedBufList())
                {
                    if (battleUnitBuf.positiveType == BufPositiveType.Negative && battleUnitBuf.stack >= 2)
                    {
                        battleUnitBuf.stack = (battleUnitBuf.stack + 1) / 2;
                    }
                }
            }
        }
    }
    public class PassiveAbility_Apho_FerventBeats : PassiveAbilityBase
    {
        public static string Name = "Fervent Beats";
        public static string Desc = "Die at the end of the third Scene. Gain 4 Strength, Endurance, Haste, and Protection each Scene until death. All Stagger damage resistances change to \"Ineffective\".";
        public override void OnWaveStart()
        {
            base.OnWaveStart();
            SingletonBehavior<DiceEffectManager>.Instance.CreateNewFXCreatureEffect("0_K/FX_IllusionCard_0_K_FastBeat", 1f, base.owner.view, base.owner.view, -1f);
            SoundEffectPlayer soundEffectPlayer = SingletonBehavior<SoundEffectManager>.Instance.PlayClip("Creature/Heart_Fast", false, 1f, null);
            if (soundEffectPlayer == null)
            {
                return;
            }
            soundEffectPlayer.SetGlobalPosition(base.owner.view.WorldPosition);
        }
        public override void OnRoundStart()
        {
            if (Singleton<StageController>.Instance.RoundTurn <= 3)
            {
                UnitUtil.SetPassiveCombatLog(this, owner);
                this.owner.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Strength, 4, this.owner);
                this.owner.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Endurance, 4, this.owner);
                this.owner.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Quickness, 4, this.owner);
                this.owner.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Protection, 4, this.owner);
            }    
        }
        public override AtkResist GetResistBP(AtkResist origin, BehaviourDetail detail)
        {
            return AtkResist.Resist;
        }
        public override void OnRoundEnd()
        {
            if (Singleton<StageController>.Instance.RoundTurn >= 3)
            {
                UnitUtil.SetPassiveCombatLog(this, owner);
                this.owner.Die();
            }
        }
    }
    public class PassiveAbility_Apho_OxideOverload2 : PassiveAbilityBase
    {
        public static string Name = "Oxide Overload II";
        public static string Desc = "Upon death, all enemies are inflicted with 10 Smoke.";
        public override void OnDie()
        {
            UnitUtil.SetPassiveCombatLog(this, owner);
            List<BattleUnitModel> aliveList = BattleObjectManager.instance.GetAliveList((this.owner.faction == Faction.Player) ? Faction.Enemy : Faction.Player);
            foreach (BattleUnitModel battleUnitModel in aliveList)
            {
                battleUnitModel.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Smoke, 10, null);
            }
        }
    }
    public class PassiveAbility_Apho_IntoStarEmbrace : PassiveAbilityBase
    {
        public static string Name = "Into the Star's Embrace";
        public static string Desc = "If this character is staggered, they die.";
        public override void OnBreakState()
        {
            UnitUtil.SetPassiveCombatLog(this, owner);
            SingletonBehavior<DiceEffectManager>.Instance.CreateNewFXCreatureEffect("9_H/FX_IllusionCard_9_H_Martyr", 1f, owner.view, owner.view, 3f);
            SoundEffectPlayer.PlaySound("Creature/BlueStar_In");
            this.owner.Die();
        }
    }


    //BladeUnlocked
    public class BattleUnitBuf_Apho_IndexBuffYellow : BattleUnitBuf
    {
        public override KeywordBuf bufType => KeywordBuf.IndexRelease;
        public override void Init(BattleUnitModel owner)
        {
            base.Init(owner);
            CreateAura();
        }
        private GameObject _aura;
        protected override string keywordId => "IndexRelease";
        protected override string keywordIconId => "IndexRelease";
        public override void BeforeRollDice(BattleDiceBehavior behavior)
        {
            behavior.ApplyDiceStatBonus(new DiceStatBonus { power = 1 });
        }

        private void CreateAura()
        {
            if (_aura != null) return;
            var @object = Resources.Load("Prefabs/Battle/SpecialEffect/IndexRelease_Aura");
            if (@object != null)
            {
                var gameObject = UnityEngine.Object.Instantiate(@object) as GameObject;
                if (gameObject != null)
                {
                    gameObject.transform.parent = _owner.view.charAppearance.transform;
                    gameObject.transform.localPosition = Vector3.zero;
                    gameObject.transform.localRotation = Quaternion.identity;
                    gameObject.transform.localScale = Vector3.one;
                    var component = gameObject.GetComponent<IndexReleaseAura>();
                    if (component != null) component.Init(_owner.view);
                    _aura = gameObject;
                }

                if (_aura != null)
                    foreach (var particle in _aura.GetComponentsInChildren<ParticleSystem>())
                    {
                        var main = particle.main;
                        main.startColor = new Color(1, 1, 0, 1);
                    }
            }
            SingletonBehavior<SoundEffectManager>.Instance.PlayClip("Buf/Effect_Index_Unlock");
        }
        public override void Destroy()
        {
            if (this._aura != null)
            {
                UnityEngine.Object.Destroy(this._aura);
            }
        }

    }
    public class BattleUnitBuf_Apho_IndexBuffRed : BattleUnitBuf
    {
        public override KeywordBuf bufType => KeywordBuf.IndexRelease;
        public override void Init(BattleUnitModel owner)
        {
            base.Init(owner);
            CreateAura();
        }
        private GameObject _aura;
        protected override string keywordId => "IndexRelease";
        protected override string keywordIconId => "IndexRelease";
        public override void BeforeRollDice(BattleDiceBehavior behavior)
        {
            behavior.ApplyDiceStatBonus(new DiceStatBonus { power = 1 });
        }

        private void CreateAura()
        {
            if (_aura != null) return;
            var @object = Resources.Load("Prefabs/Battle/SpecialEffect/IndexRelease_Aura");
            if (@object != null)
            {
                var gameObject = UnityEngine.Object.Instantiate(@object) as GameObject;
                if (gameObject != null)
                {
                    gameObject.transform.parent = _owner.view.charAppearance.transform;
                    gameObject.transform.localPosition = Vector3.zero;
                    gameObject.transform.localRotation = Quaternion.identity;
                    gameObject.transform.localScale = Vector3.one;
                    var component = gameObject.GetComponent<IndexReleaseAura>();
                    if (component != null) component.Init(_owner.view);
                    _aura = gameObject;
                }

                if (_aura != null)
                    foreach (var particle in _aura.GetComponentsInChildren<ParticleSystem>())
                    {
                        var main = particle.main;
                        main.startColor = new Color(1, 0, 0, 1);
                    }
            }
            SingletonBehavior<SoundEffectManager>.Instance.PlayClip("Buf/Effect_Index_Unlock");
        }
        public override void Destroy()
        {
            if (this._aura != null)
            {
                UnityEngine.Object.Destroy(this._aura);
            }
        }

    }
    public class BattleUnitBuf_Apho_IndexBuffPink : BattleUnitBuf
    {
        public override KeywordBuf bufType => KeywordBuf.IndexRelease;
        public override void Init(BattleUnitModel owner)
        {
            base.Init(owner);
            CreateAura();
        }
        private GameObject _aura;
        protected override string keywordId => "IndexRelease";
        protected override string keywordIconId => "IndexRelease";
        public override void BeforeRollDice(BattleDiceBehavior behavior)
        {
            behavior.ApplyDiceStatBonus(new DiceStatBonus { power = 1 });
        }

        private void CreateAura()
        {
            if (_aura != null) return;
            var @object = Resources.Load("Prefabs/Battle/SpecialEffect/IndexRelease_Aura");
            if (@object != null)
            {
                var gameObject = UnityEngine.Object.Instantiate(@object) as GameObject;
                if (gameObject != null)
                {
                    gameObject.transform.parent = _owner.view.charAppearance.transform;
                    gameObject.transform.localPosition = Vector3.zero;
                    gameObject.transform.localRotation = Quaternion.identity;
                    gameObject.transform.localScale = Vector3.one;
                    var component = gameObject.GetComponent<IndexReleaseAura>();
                    if (component != null) component.Init(_owner.view);
                    _aura = gameObject;
                }

                if (_aura != null)
                    foreach (var particle in _aura.GetComponentsInChildren<ParticleSystem>())
                    {
                        var main = particle.main;
                        main.startColor = new Color(1, 0.5f, 0.5f, 1);
                    }
            }
            SingletonBehavior<SoundEffectManager>.Instance.PlayClip("Buf/Effect_Index_Unlock");
        }
        public override void Destroy()
        {
            if (this._aura != null)
            {
                UnityEngine.Object.Destroy(this._aura);
            }
        }

    }
    public class PassiveAbility_Apho_BladeUnlockedProxyOfIndex : PassiveAbilityBase
    {
        private static void Activate(BattleUnitModel unit)
        {
            if (unit.bufListDetail.GetActivatedBuf(KeywordBuf.IndexRelease) == null)
            {
                unit.bufListDetail.AddBufWithoutDuplication(new BattleUnitBuf_CustomInstantIndexRelease_DLL4221());
            }
        }
        public override void OnRoundStart()
        {
            if(Singleton<StageController>.Instance.RoundTurn >= 2)
            {
                Activate(this.owner);
            }
        }
    }

    public class PassiveAbility_Apho_BladeUnlockedOdd : PassiveAbilityBase
    {
        private bool _activated;
        private static void Activate(BattleUnitModel unit)
        {
            unit.bufListDetail.AddBufWithoutDuplication(new BattleUnitBuf_Apho_IndexBuffYellow());
        }
        private static void Deactivate(BattleUnitModel unit)
        {
            BattleUnitBuf buf = unit.bufListDetail.GetActivatedBuf(KeywordBuf.IndexRelease);
            buf.Destroy();
            unit.bufListDetail.RemoveBuf(buf);
            SingletonBehavior<BattleManagerUI>.Instance.ui_unitListInfoSummary.UpdateCharacterProfileAll();
        }
        public override void OnRoundStart()
        {
            if (Singleton<StageController>.Instance.RoundTurn % 2 == 1 && owner.bufListDetail.GetActivatedBuf(KeywordBuf.IndexRelease) == null)
            {
                Activate(this.owner);
                this._activated = true;
            }
        }
        public override void OnRoundEnd()
        {
            if (this._activated == true)
            {
                Deactivate(this.owner);
                this._activated = false;
            }
        }
    }

    public class PassiveAbility_Apho_BladeUnlockedEven : PassiveAbilityBase
    {
        private bool _activated;
        private static void Activate(BattleUnitModel unit)
        {
            unit.bufListDetail.AddBufWithoutDuplication(new BattleUnitBuf_Apho_IndexBuffYellow());
        }
        private static void Deactivate(BattleUnitModel unit)
        {
            BattleUnitBuf buf = unit.bufListDetail.GetActivatedBuf(KeywordBuf.IndexRelease);
            buf.Destroy();
            unit.bufListDetail.RemoveBuf(buf);
            SingletonBehavior<BattleManagerUI>.Instance.ui_unitListInfoSummary.UpdateCharacterProfileAll();
        }
        public override void OnRoundStart()
        {
            if (Singleton<StageController>.Instance.RoundTurn % 2 == 0 && owner.bufListDetail.GetActivatedBuf(KeywordBuf.IndexRelease) == null)
            {
                Activate(this.owner);
                this._activated = true;
            }
        }
        public override void OnRoundEnd()
        {
            if (this._activated == true)
            {
                Deactivate(this.owner);
                this._activated = false;
            }
        }
    }

    public class PassiveAbility_Apho_BladeUnlockedLowHP : PassiveAbilityBase
    {
        private static void Activate(BattleUnitModel unit)
        {
            unit.bufListDetail.AddBufWithoutDuplication(new BattleUnitBuf_Apho_IndexBuffRed());
        }
        private static void Deactivate(BattleUnitModel unit)
        {
            BattleUnitBuf buf = unit.bufListDetail.GetActivatedBuf(KeywordBuf.IndexRelease);
            buf.Destroy();
            unit.bufListDetail.RemoveBuf(buf);
            SingletonBehavior<BattleManagerUI>.Instance.ui_unitListInfoSummary.UpdateCharacterProfileAll();
        }
        public override void OnRoundStart()
        {
            Console.WriteLine(owner.bufListDetail.GetActivatedBuf(KeywordBuf.IndexRelease));
            if (owner.hp <= owner.MaxHp * 0.25 && owner.bufListDetail.GetActivatedBuf(KeywordBuf.IndexRelease) == null)
            {
                UnitUtil.SetPassiveCombatLog(this, owner);
                Activate(this.owner);
            }
            else if (owner.hp > owner.MaxHp * 0.25 && owner.bufListDetail.GetActivatedBuf(KeywordBuf.IndexRelease) != null)
            {
                Deactivate(this.owner);
            }
        }
        public override void AfterTakeDamage(BattleUnitModel attacker, int dmg)
        {
            if (owner.hp <= owner.MaxHp * 0.25 && owner.bufListDetail.GetActivatedBuf(KeywordBuf.IndexRelease) == null)
            {
                UnitUtil.SetPassiveCombatLog(this, owner);
                Activate(this.owner);
            }
            else if (owner.hp > owner.MaxHp * 0.25 && owner.bufListDetail.GetActivatedBuf(KeywordBuf.IndexRelease) != null)
            {
                Deactivate(this.owner);
            }
        }
        public override void OnRecoverHp(int amount)
        {
            if (owner.hp <= owner.MaxHp * 0.25 && owner.bufListDetail.GetActivatedBuf(KeywordBuf.IndexRelease) == null)
            {
                UnitUtil.SetPassiveCombatLog(this, owner);
                Activate(this.owner);
            }
            else if (owner.hp > owner.MaxHp * 0.25 && owner.bufListDetail.GetActivatedBuf(KeywordBuf.IndexRelease) != null)
            {
                Deactivate(this.owner);
            }
        }
    }

    public class PassiveAbility_Apho_BladeUnlockedKill : PassiveAbilityBase
    {
        private static void Activate(BattleUnitModel unit)
        {
            unit.bufListDetail.AddBufWithoutDuplication(new BattleUnitBuf_Apho_IndexBuffRed());
        }
        public override void OnKill(BattleUnitModel target)
        {
            if (target.faction != this.owner.faction && owner.bufListDetail.GetActivatedBuf(KeywordBuf.IndexRelease) == null)
            {
                UnitUtil.SetPassiveCombatLog(this, owner);
                Activate(this.owner);
            }
        }
    }

    public class PassiveAbility_Apho_BladeUnlockedHighHP : PassiveAbilityBase
    {
        private static void Activate(BattleUnitModel unit)
        {
            unit.bufListDetail.AddBufWithoutDuplication(new BattleUnitBuf_Apho_IndexBuffPink());
        }
        private static void Deactivate(BattleUnitModel unit)
        {
            BattleUnitBuf buf = unit.bufListDetail.GetActivatedBuf(KeywordBuf.IndexRelease);
            buf.Destroy();
            unit.bufListDetail.RemoveBuf(buf);
            SingletonBehavior<BattleManagerUI>.Instance.ui_unitListInfoSummary.UpdateCharacterProfileAll();
        }
        public override void OnRoundStart()
        {
            Console.WriteLine(owner.bufListDetail.GetActivatedBuf(KeywordBuf.IndexRelease));
            if (owner.hp >= owner.MaxHp && owner.bufListDetail.GetActivatedBuf(KeywordBuf.IndexRelease) == null)
            {
                UnitUtil.SetPassiveCombatLog(this, owner);
                Activate(this.owner);
            }
            else if (owner.hp < owner.MaxHp && owner.bufListDetail.GetActivatedBuf(KeywordBuf.IndexRelease) != null)
            {
                Deactivate(this.owner);
            }
        }
        public override void AfterTakeDamage(BattleUnitModel attacker, int dmg)
        {
            if (owner.hp >= owner.MaxHp && owner.bufListDetail.GetActivatedBuf(KeywordBuf.IndexRelease) == null)
            {
                UnitUtil.SetPassiveCombatLog(this, owner);
                Activate(this.owner);
            }
            else if (owner.hp < owner.MaxHp && owner.bufListDetail.GetActivatedBuf(KeywordBuf.IndexRelease) != null)
            {
                Deactivate(this.owner);
            }
        }
        public override void OnRecoverHp(int amount)
        {
            if (owner.hp >= owner.MaxHp && owner.bufListDetail.GetActivatedBuf(KeywordBuf.IndexRelease) == null)
            {
                UnitUtil.SetPassiveCombatLog(this, owner);
                Activate(this.owner);
            }
            else if (owner.hp < owner.MaxHp && owner.bufListDetail.GetActivatedBuf(KeywordBuf.IndexRelease) != null)
            {
                Deactivate(this.owner);
            }
        }
    }

    public class PassiveAbility_Apho_BladeUnlockedNoDeath : PassiveAbilityBase
    {
        private static void Activate(BattleUnitModel unit)
        {
            unit.bufListDetail.AddBufWithoutDuplication(new BattleUnitBuf_Apho_IndexBuffPink());
        }
        private static void Deactivate(BattleUnitModel unit)
        {
            BattleUnitBuf buf = unit.bufListDetail.GetActivatedBuf(KeywordBuf.IndexRelease);
            buf.Destroy();
            unit.bufListDetail.RemoveBuf(buf);
            SingletonBehavior<BattleManagerUI>.Instance.ui_unitListInfoSummary.UpdateCharacterProfileAll();
        }
        public override void OnWaveStart()
        {
            int count = BattleObjectManager.instance.GetAliveList(this.owner.faction).Count;
            if (count >= 2)
            {
                UnitUtil.SetPassiveCombatLog(this, owner);
                Activate(this.owner);
            }
        }
        public override void OnRoundEnd()
        {
            int count = BattleObjectManager.instance.GetList(this.owner.faction).Count;
            int count2 = BattleObjectManager.instance.GetAliveList(this.owner.faction).Count;
            if (count2 < count)
            {
                Deactivate(this.owner);
            }
        }
    }

    //Perdition
    public class PassiveAbility_Apho_SeedOfDarkness : PassiveAbilityBase
    {
        public override void OnRoundStart()
        {
            this.GiveBuf();
        }
        private void GiveBuf()
        {
            foreach (BattleUnitModel battleUnitModel in BattleObjectManager.instance.GetAliveList(this.owner.faction))
            {
                if (battleUnitModel.bufListDetail.GetActivatedBuf(KeywordBuf.KeterFinal_DoubleEmotion) == null)
                {
                    battleUnitModel.bufListDetail.AddBuf(new BattleUnitBuf_Apho_SeedOfDarkness());
                }
            }
        }
    }
    public class BattleUnitBuf_Apho_SeedOfDarkness : BattleUnitBuf
    {
        public override BufPositiveType positiveType
        {
            get
            {
                return BufPositiveType.Negative;
            }
        }
        public override void Init(BattleUnitModel owner)
        {
            base.Init(owner);
            this.stack = 0;
        }
        public override int GetEmotionCoinAdder(int defaultCount)
        {
            int penalty = (int)(defaultCount * -0.5);
            return penalty;
        }
    }
    public class PassiveAbility_Apho_ExpiredRations : PassiveAbilityBase
    {
        public override void OnRoundStart()
        {
            this.owner.ShowPassiveTypo(this);
            this.owner.LoseHp(2);
        }
    }
    public class PassiveAbility_Apho_MistakeCooking: PassiveAbilityBase
    {
        public override void OnKill(BattleUnitModel target)
        {
            int num = this.owner.MaxHp / 10;
            this.owner.ShowPassiveTypo(this);
            this.owner.LoseHp(num);
        }
    }
}