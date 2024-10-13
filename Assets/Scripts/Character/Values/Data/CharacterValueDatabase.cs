using DSA.Character.Modifier;
using UnityEngine.Localization;
using UnityEngine.Localization.Tables;


/// <summary>
/// Character Value Database with all static data of the Character
/// </summary>
namespace DSA.Character.Value.Data
{
    public static class CharacterValueDatabase
    {
        public static void Init(Localization localization)
        {
            //Load Localization Table

            MainAttributeDatabase.Init(localization);
            SkillDatabase.Init(localization);
            CombatTechnicDatabase.Init(localization);
            CombatValueDatabase.Init(localization);
            BaseValueDatabase.Init(localization);
            PoolValueDatabase.Init(localization);
        }
    }

    public static class MainAttributeDatabase
    {
        public static MainAttributeData[] MainAttributesData;

        public static void Init(Localization localization)
        {
            MainAttributesData = new MainAttributeData[]
            {
                new MainAttributeData(MainAttributeType.Courage, localization.GetCharacterValueText("courage"), localization.GetCharacterValueText("courage_abbreviation")),
                new MainAttributeData(MainAttributeType.Sagacity, localization.GetCharacterValueText("sagacity"), localization.GetCharacterValueText("sagacity_abbreviation")),
                new MainAttributeData(MainAttributeType.Intuition, localization.GetCharacterValueText("intuition"), localization.GetCharacterValueText("intuition_abbreviation")),
                new MainAttributeData(MainAttributeType.Charisma, localization.GetCharacterValueText("charisma"), localization.GetCharacterValueText("charisma_abbreviation")),
                new MainAttributeData(MainAttributeType.Dexterity, localization.GetCharacterValueText("dexterity"), localization.GetCharacterValueText("dexterity_abbreviation")),
                new MainAttributeData(MainAttributeType.Agility, localization.GetCharacterValueText("agility"), localization.GetCharacterValueText("agility_abbreviation")),
                new MainAttributeData(MainAttributeType.Constitution, localization.GetCharacterValueText("constitution"), localization.GetCharacterValueText("constitution_abbreviation")),
                new MainAttributeData(MainAttributeType.Strength, localization.GetCharacterValueText("strength"), localization.GetCharacterValueText("strength_abbreviation")),
            };
        }

        public class MainAttributeData
        {
            public MainAttributeData(MainAttributeType type, string name, string abbreviation)
            {
                this.Type = type;
                this.Name = name;
                this.Abbreviation = abbreviation;
                IncreaseCostType = IncreaseCostType.E;
            }

            public readonly MainAttributeType Type;
            public readonly IncreaseCostType IncreaseCostType;

            public string Name;
            public string Abbreviation;
        }
    }

    public static class SkillDatabase
    {
        public static SkillData[] PhysicalSkillData;
        public static SkillData[] SocialSkillData;
        public static SkillData[] NatureSkillData;
        public static SkillData[] KnowledgeSkillData;
        public static SkillData[] CraftSkillData;

        public static void Init(Localization localization)
        {
            PhysicalSkillData = new SkillData[]
            {
                new SkillData(SkillType.Flying, MainAttributeType.Courage, MainAttributeType.Intuition, MainAttributeType.Agility, IncreaseCostType.B, localization.GetCharacterValueText("flying")),
                new SkillData(SkillType.Gaukelei, MainAttributeType.Courage, MainAttributeType.Charisma, MainAttributeType.Dexterity, IncreaseCostType.A, localization.GetCharacterValueText("gaukelei")),
                new SkillData(SkillType.Climbing, MainAttributeType.Courage, MainAttributeType.Agility, MainAttributeType.Strength, IncreaseCostType.B, localization.GetCharacterValueText("climbing")),
                new SkillData(SkillType.BodyControl, MainAttributeType.Agility, MainAttributeType.Agility, MainAttributeType.Constitution, IncreaseCostType.D, localization.GetCharacterValueText("body_control")),
                new SkillData(SkillType.FeatOfStrength, MainAttributeType.Constitution, MainAttributeType.Strength, MainAttributeType.Strength, IncreaseCostType.B, localization.GetCharacterValueText("feat_of_strength")),
                new SkillData(SkillType.Riding, MainAttributeType.Charisma, MainAttributeType.Agility, MainAttributeType.Strength, IncreaseCostType.B, localization.GetCharacterValueText("riding")),
                new SkillData(SkillType.Swimming, MainAttributeType.Agility, MainAttributeType.Constitution, MainAttributeType.Strength, IncreaseCostType.B, localization.GetCharacterValueText("swimming")),
                new SkillData(SkillType.SelfControl, MainAttributeType.Courage, MainAttributeType.Courage, MainAttributeType.Constitution, IncreaseCostType.D, localization.GetCharacterValueText("self_control")),
                new SkillData(SkillType.Singing, MainAttributeType.Sagacity, MainAttributeType.Charisma, MainAttributeType.Constitution, IncreaseCostType.A, localization.GetCharacterValueText("singing")),
                new SkillData(SkillType.Perception, MainAttributeType.Sagacity, MainAttributeType.Sagacity, MainAttributeType.Intuition, IncreaseCostType.D, localization.GetCharacterValueText("perception")),
                new SkillData(SkillType.Dancing, MainAttributeType.Sagacity, MainAttributeType.Charisma, MainAttributeType.Agility, IncreaseCostType.A, localization.GetCharacterValueText("dancing")),
                new SkillData(SkillType.Pickpocket, MainAttributeType.Courage, MainAttributeType.Dexterity, MainAttributeType.Agility, IncreaseCostType.B, localization.GetCharacterValueText("pickpocket")),
                new SkillData(SkillType.Stealth, MainAttributeType.Courage, MainAttributeType.Intuition, MainAttributeType.Agility, IncreaseCostType.C, localization.GetCharacterValueText("flying")),
                new SkillData(SkillType.Carousing, MainAttributeType.Sagacity, MainAttributeType.Constitution, MainAttributeType.Strength, IncreaseCostType.A, localization.GetCharacterValueText("carousing")),
            };

            SocialSkillData = new SkillData[]
            {
                new SkillData(SkillType.Persuasion, MainAttributeType.Courage, MainAttributeType.Sagacity, MainAttributeType.Charisma, IncreaseCostType.B, localization.GetCharacterValueText("persuasion")),
                new SkillData(SkillType.Seduction, MainAttributeType.Courage, MainAttributeType.Charisma, MainAttributeType.Charisma, IncreaseCostType.B, localization.GetCharacterValueText("seduction")),
                new SkillData(SkillType.Intimidation, MainAttributeType.Courage, MainAttributeType.Intuition, MainAttributeType.Charisma, IncreaseCostType.B, localization.GetCharacterValueText("intimidation")),
                new SkillData(SkillType.Etiquette, MainAttributeType.Sagacity, MainAttributeType.Intuition, MainAttributeType.Charisma, IncreaseCostType.B, localization.GetCharacterValueText("etiquette")),
                new SkillData(SkillType.Streetwise, MainAttributeType.Sagacity, MainAttributeType.Intuition, MainAttributeType.Charisma, IncreaseCostType.C, localization.GetCharacterValueText("streetwise")),
                new SkillData(SkillType.Empathy, MainAttributeType.Sagacity, MainAttributeType.Intuition, MainAttributeType.Charisma, IncreaseCostType.C, localization.GetCharacterValueText("empathy")),
                new SkillData(SkillType.FastTalk, MainAttributeType.Courage, MainAttributeType.Intuition, MainAttributeType.Charisma, IncreaseCostType.C, localization.GetCharacterValueText("fast_talk")),
                new SkillData(SkillType.Disguise, MainAttributeType.Intuition, MainAttributeType.Charisma, MainAttributeType.Agility, IncreaseCostType.B, localization.GetCharacterValueText("disguise")),
                new SkillData(SkillType.Willpower, MainAttributeType.Courage, MainAttributeType.Intuition, MainAttributeType.Charisma, IncreaseCostType.D, localization.GetCharacterValueText("willpower")),
            };

            NatureSkillData = new SkillData[]
            {
                new SkillData(SkillType.Tracking, MainAttributeType.Courage, MainAttributeType.Intuition, MainAttributeType.Agility, IncreaseCostType.C, localization.GetCharacterValueText("tracking")),
                new SkillData(SkillType.Ropes, MainAttributeType.Sagacity, MainAttributeType.Dexterity, MainAttributeType.Strength, IncreaseCostType.A, localization.GetCharacterValueText("ropes")),
                new SkillData(SkillType.Fishing, MainAttributeType.Dexterity, MainAttributeType.Agility, MainAttributeType.Constitution, IncreaseCostType.A, localization.GetCharacterValueText("fishing")),
                new SkillData(SkillType.Orienting, MainAttributeType.Sagacity, MainAttributeType.Intuition, MainAttributeType.Intuition, IncreaseCostType.B, localization.GetCharacterValueText("orienting")),
                new SkillData(SkillType.PlantLore, MainAttributeType.Sagacity, MainAttributeType.Dexterity, MainAttributeType.Constitution, IncreaseCostType.C, localization.GetCharacterValueText("plant_lore")),
                new SkillData(SkillType.AnimalLore, MainAttributeType.Courage, MainAttributeType.Courage, MainAttributeType.Charisma, IncreaseCostType.C, localization.GetCharacterValueText("animal_lore")),
                new SkillData(SkillType.Survival, MainAttributeType.Courage, MainAttributeType.Agility, MainAttributeType.Constitution, IncreaseCostType.C, localization.GetCharacterValueText("survival")),
            };

            KnowledgeSkillData = new SkillData[]
            {
                new SkillData(SkillType.Gambling, MainAttributeType.Sagacity, MainAttributeType.Sagacity, MainAttributeType.Intuition, IncreaseCostType.A, localization.GetCharacterValueText("gambling")),
                new SkillData(SkillType.Geography, MainAttributeType.Sagacity, MainAttributeType.Sagacity, MainAttributeType.Intuition, IncreaseCostType.B, localization.GetCharacterValueText("geography")),
                new SkillData(SkillType.History, MainAttributeType.Sagacity, MainAttributeType.Sagacity, MainAttributeType.Intuition, IncreaseCostType.B, localization.GetCharacterValueText("history")),
                new SkillData(SkillType.Religions, MainAttributeType.Sagacity, MainAttributeType.Sagacity, MainAttributeType.Intuition, IncreaseCostType.B, localization.GetCharacterValueText("religions")),
                new SkillData(SkillType.Warfare, MainAttributeType.Courage, MainAttributeType.Sagacity, MainAttributeType.Intuition, IncreaseCostType.B, localization.GetCharacterValueText("warfare")),
                new SkillData(SkillType.MagicalLore, MainAttributeType.Sagacity, MainAttributeType.Sagacity, MainAttributeType.Intuition, IncreaseCostType.C, localization.GetCharacterValueText("magical_lore")),
                new SkillData(SkillType.Mechanics, MainAttributeType.Sagacity, MainAttributeType.Sagacity, MainAttributeType.Dexterity, IncreaseCostType.B, localization.GetCharacterValueText("mechanics")),
                new SkillData(SkillType.Math, MainAttributeType.Sagacity, MainAttributeType.Sagacity, MainAttributeType.Intuition, IncreaseCostType.A, localization.GetCharacterValueText("math")),
                new SkillData(SkillType.Law, MainAttributeType.Sagacity, MainAttributeType.Sagacity, MainAttributeType.Intuition, IncreaseCostType.A, localization.GetCharacterValueText("law")),
                new SkillData(SkillType.MythsAndLegends, MainAttributeType.Sagacity, MainAttributeType.Sagacity, MainAttributeType.Intuition, IncreaseCostType.B, localization.GetCharacterValueText("myths_and_legends")),
                new SkillData(SkillType.SphereLore, MainAttributeType.Sagacity, MainAttributeType.Sagacity, MainAttributeType.Intuition, IncreaseCostType.B, localization.GetCharacterValueText("sphere_lore")),
                new SkillData(SkillType.Astronomy, MainAttributeType.Sagacity, MainAttributeType.Sagacity, MainAttributeType.Intuition, IncreaseCostType.A, localization.GetCharacterValueText("astronomy")),
            };

            CraftSkillData = new SkillData[]
            {
                new SkillData(SkillType.Alchemy, MainAttributeType.Courage, MainAttributeType.Sagacity, MainAttributeType.Dexterity, IncreaseCostType.C, localization.GetCharacterValueText("alchemy")),
                new SkillData(SkillType.Sailing, MainAttributeType.Dexterity, MainAttributeType.Agility, MainAttributeType.Strength, IncreaseCostType.B, localization.GetCharacterValueText("sailing")),
                new SkillData(SkillType.Driving, MainAttributeType.Charisma, MainAttributeType.Dexterity, MainAttributeType.Constitution, IncreaseCostType.A, localization.GetCharacterValueText("driving")),
                new SkillData(SkillType.Commerce, MainAttributeType.Sagacity, MainAttributeType.Intuition, MainAttributeType.Charisma, IncreaseCostType.B, localization.GetCharacterValueText("commerce")),
                new SkillData(SkillType.TreatPoison, MainAttributeType.Courage, MainAttributeType.Sagacity, MainAttributeType.Intuition, IncreaseCostType.B, localization.GetCharacterValueText("treat_poison")),
                new SkillData(SkillType.TreatDisease, MainAttributeType.Courage, MainAttributeType.Intuition, MainAttributeType.Constitution, IncreaseCostType.B, localization.GetCharacterValueText("treat_disease")),
                new SkillData(SkillType.TreatSoul, MainAttributeType.Intuition, MainAttributeType.Charisma, MainAttributeType.Constitution, IncreaseCostType.B, localization.GetCharacterValueText("treat_soul")),
                new SkillData(SkillType.TreatWounds, MainAttributeType.Sagacity, MainAttributeType.Dexterity, MainAttributeType.Dexterity, IncreaseCostType.D, localization.GetCharacterValueText("treat_wounds")),
                new SkillData(SkillType.Woodworking, MainAttributeType.Dexterity, MainAttributeType.Agility, MainAttributeType.Strength, IncreaseCostType.B, localization.GetCharacterValueText("woodworking")),
                new SkillData(SkillType.PrepareFood, MainAttributeType.Intuition, MainAttributeType.Dexterity, MainAttributeType.Dexterity, IncreaseCostType.A, localization.GetCharacterValueText("prepare_food")),
                new SkillData(SkillType.Leatherworking, MainAttributeType.Dexterity, MainAttributeType.Agility, MainAttributeType.Constitution, IncreaseCostType.B, localization.GetCharacterValueText("leatherworking")),
                new SkillData(SkillType.ArtisticAbility, MainAttributeType.Intuition, MainAttributeType.Dexterity, MainAttributeType.Dexterity, IncreaseCostType.A, localization.GetCharacterValueText("artistic_ability")),
                new SkillData(SkillType.Metalworking, MainAttributeType.Dexterity, MainAttributeType.Constitution, MainAttributeType.Strength, IncreaseCostType.C, localization.GetCharacterValueText("metalworking")),
                new SkillData(SkillType.Music, MainAttributeType.Charisma, MainAttributeType.Dexterity, MainAttributeType.Constitution, IncreaseCostType.A, localization.GetCharacterValueText("music")),
                new SkillData(SkillType.PickLocks, MainAttributeType.Intuition, MainAttributeType.Dexterity, MainAttributeType.Dexterity, IncreaseCostType.C, localization.GetCharacterValueText("pick_locks")),
                new SkillData(SkillType.Earthencraft, MainAttributeType.Dexterity, MainAttributeType.Dexterity, MainAttributeType.Strength, IncreaseCostType.A, localization.GetCharacterValueText("earthencraft")),
                new SkillData(SkillType.Clothworking, MainAttributeType.Sagacity, MainAttributeType.Dexterity, MainAttributeType.Dexterity, IncreaseCostType.A, localization.GetCharacterValueText("clothworking")),
            };
        }

        public class SkillData
        {
            public SkillData(SkillType type, MainAttributeType baseAttribute1, MainAttributeType baseAttribute2, MainAttributeType baseAttribute3, IncreaseCostType increaseCostType, string name)
            {
                this.Type = type;
                this.BaseAttributeTypes = new MainAttributeType[] { baseAttribute1, baseAttribute2, baseAttribute3 };
                this.IncreaseCostType = increaseCostType;
                this.Name = name;
            }

            public SkillType Type;
            public MainAttributeType[] BaseAttributeTypes;
            public IncreaseCostType IncreaseCostType;

            public string Name;
        }
    }

    public static class CombatTechnicDatabase
    {
        public static CombatTechnicData[] CombatTechnicsData;

        public static void Init(Localization localization)
        {
            CombatTechnicsData = new CombatTechnicData[]
            {
                new CombatTechnicData(CombatTechnicType.Crossbow, IncreaseCostType.B, localization.GetCharacterValueText("crossbows"), MainAttributeType.Dexterity),
                new CombatTechnicData(CombatTechnicType.Bow, IncreaseCostType.C, localization.GetCharacterValueText("bows"), MainAttributeType.Dexterity),
                new CombatTechnicData(CombatTechnicType.ThrownWeapon, IncreaseCostType.B, localization.GetCharacterValueText("thrown_weapons"), MainAttributeType.Dexterity),
                new CombatTechnicData(CombatTechnicType.Dagger, IncreaseCostType.B, localization.GetCharacterValueText("daggers"), MainAttributeType.Agility),
                new CombatTechnicData(CombatTechnicType.FencingWeapon, IncreaseCostType.C, localization.GetCharacterValueText("fencing_weapons"), MainAttributeType.Agility),
                new CombatTechnicData(CombatTechnicType.ImpactWeapon, IncreaseCostType.C, localization.GetCharacterValueText("impact_weapons"), MainAttributeType.Strength),
                new CombatTechnicData(CombatTechnicType.ChainWeapon, IncreaseCostType.C, localization.GetCharacterValueText("chain_weapons"), MainAttributeType.Strength),
                new CombatTechnicData(CombatTechnicType.Lance, IncreaseCostType.B, localization.GetCharacterValueText("lances"), MainAttributeType.Strength),
                new CombatTechnicData(CombatTechnicType.Shield, IncreaseCostType.C, localization.GetCharacterValueText("shields"), MainAttributeType.Strength),
                new CombatTechnicData(CombatTechnicType.TwoHandedImpactWeapon, IncreaseCostType.C, localization.GetCharacterValueText("two_handed_impact_weapons"), MainAttributeType.Strength),
                new CombatTechnicData(CombatTechnicType.TwoHandedSword, IncreaseCostType.C, localization.GetCharacterValueText("two_handed_swords"), MainAttributeType.Strength),
                new CombatTechnicData(CombatTechnicType.Brawling, IncreaseCostType.B, localization.GetCharacterValueText("brawling"), MainAttributeType.Strength, MainAttributeType.Agility),
                new CombatTechnicData(CombatTechnicType.Sword, IncreaseCostType.C, localization.GetCharacterValueText("swords"), MainAttributeType.Strength, MainAttributeType.Agility),
                new CombatTechnicData(CombatTechnicType.PoleWeapon, IncreaseCostType.C, localization.GetCharacterValueText("pole_weapons"), MainAttributeType.Strength, MainAttributeType.Agility),
            };
        }

        public class CombatTechnicData
        {
            public CombatTechnicData(CombatTechnicType type, IncreaseCostType increaseCostType, string name, MainAttributeType primaryAttribute1, MainAttributeType primaryAttribute2 = 0)
            {
                this.Type = type;
                this.IncreaseCostType = increaseCostType;
                this.Name = name;

                if (primaryAttribute2 == 0)
                {
                    PrimaryAttributesTypes = new MainAttributeType[] { primaryAttribute1 };
                }
                else
                {
                    PrimaryAttributesTypes = new MainAttributeType[] { primaryAttribute1, primaryAttribute2 };
                }
            }

            public CombatTechnicType Type;
            public MainAttributeType[] PrimaryAttributesTypes;
            public IncreaseCostType IncreaseCostType;

            public string Name;
        }
    }

    public static class CombatValueDatabase
    {
        public static CombatValueData[] CombatValuesData;

        public static void Init(Localization localization)
        {
            ICombatValueBaseCalculationFactory rangedCalculationFactory = new RangedValueCalculationFactory();
            ICombatValueBaseCalculationFactory attackCalculationFactory = new AttackValueCalculationFactory();
            ICombatValueBaseCalculationFactory defendCalculationFactory = new DefendValueCalculationFactory();

            CombatValuesData = new CombatValueData[]
            {
                new CombatValueData(CombatValueType.CrossbowAT, CombatTechnicType.Crossbow, rangedCalculationFactory),
                new CombatValueData(CombatValueType.BowAT, CombatTechnicType.Bow, rangedCalculationFactory),
                new CombatValueData(CombatValueType.DaggerAT, CombatTechnicType.Dagger, attackCalculationFactory),
                new CombatValueData(CombatValueType.DaggerDE, CombatTechnicType.Dagger, defendCalculationFactory),
                new CombatValueData(CombatValueType.FencingWeaponAT, CombatTechnicType.FencingWeapon, attackCalculationFactory),
                new CombatValueData(CombatValueType.FencingWeaponDE, CombatTechnicType.FencingWeapon, defendCalculationFactory),
                new CombatValueData(CombatValueType.ImpactWeaponAT, CombatTechnicType.ImpactWeapon, attackCalculationFactory),
                new CombatValueData(CombatValueType.ImpactWeaponDE, CombatTechnicType.ImpactWeapon, defendCalculationFactory),
                new CombatValueData(CombatValueType.ChainWeaponAT, CombatTechnicType.ChainWeapon, attackCalculationFactory),
                new CombatValueData(CombatValueType.LanceAT, CombatTechnicType.Lance, attackCalculationFactory),
                new CombatValueData(CombatValueType.LanceDE, CombatTechnicType.Lance, defendCalculationFactory),
                new CombatValueData(CombatValueType.BrawlingAT, CombatTechnicType.Brawling, attackCalculationFactory),
                new CombatValueData(CombatValueType.BrawlingDE, CombatTechnicType.Brawling, defendCalculationFactory),
                new CombatValueData(CombatValueType.ShieldAT, CombatTechnicType.Shield, attackCalculationFactory),
                new CombatValueData(CombatValueType.ShieldDE, CombatTechnicType.Shield, defendCalculationFactory),
                new CombatValueData(CombatValueType.SwordAT, CombatTechnicType.Sword, attackCalculationFactory),
                new CombatValueData(CombatValueType.SwordDE, CombatTechnicType.Sword, defendCalculationFactory),
                new CombatValueData(CombatValueType.PoleWeaponAT, CombatTechnicType.PoleWeapon, attackCalculationFactory),
                new CombatValueData(CombatValueType.PoleWeaponDE, CombatTechnicType.PoleWeapon, defendCalculationFactory),
                new CombatValueData(CombatValueType.ThrownWeaponAT, CombatTechnicType.ThrownWeapon, rangedCalculationFactory),
                new CombatValueData(CombatValueType.TwoHandedImpactWeaponAT, CombatTechnicType.TwoHandedImpactWeapon, attackCalculationFactory),
                new CombatValueData(CombatValueType.TwoHandedImpactWeaponDE, CombatTechnicType.TwoHandedImpactWeapon, defendCalculationFactory),
                new CombatValueData(CombatValueType.TwoHandedSwordAT, CombatTechnicType.TwoHandedSword, attackCalculationFactory),
                new CombatValueData(CombatValueType.TwoHandedSwordDE, CombatTechnicType.TwoHandedSword, defendCalculationFactory),
            };
        }

        public class CombatValueData
        {
            public CombatValueData(CombatValueType type, CombatTechnicType combatTechnic, ICombatValueBaseCalculationFactory baseCalculationFactory)
            {
                this.Type = type;
                this.CombatTechnic = combatTechnic;
                this.Name = "";
                this.BaseCalculationFactory = baseCalculationFactory;
            }

            public CombatValueType Type;
            public CombatTechnicType CombatTechnic;

            public ICombatValueBaseCalculationFactory BaseCalculationFactory;

            public string Name;
        }
    }

    public static class BaseValueDatabase
    {
        public static BaseValueData[] BaseValuesData;

        public static void Init(Localization localization)
        {
            BaseValuesData = new BaseValueData[]
            {
                new BaseValueData(BaseValueType.Dodge, new DodgeCalculationFactory(), localization.GetCharacterValueText("dodge"), localization.GetCharacterValueText("dodge_abbreviation")),
                new BaseValueData(BaseValueType.Initative, new InitiativeCalculationFactory(), localization.GetCharacterValueText("initiative"), localization.GetCharacterValueText("initiative_abbreviation")),
                new BaseValueData(BaseValueType.Movement, new MovementCalculationFactory(), localization.GetCharacterValueText("movement"), "-"),
                new BaseValueData(BaseValueType.Spirit, new SpiritCalculationFactory(), localization.GetCharacterValueText("spirit"), localization.GetCharacterValueText("spirit_abbreviation")),
                new BaseValueData(BaseValueType.Toughness, new ToughnessCalculationFactory(), localization.GetCharacterValueText("toughness"), localization.GetCharacterValueText("toughness_abbreviation")),
            };
        }

        public class BaseValueData
        {
            public BaseValueData(BaseValueType type, IBaseValueBaseCalculationFactory baseCalculationFactory, string name, string abbreviation)
            {
                this.Type = type;
                this.Name = name;
                this.Abbreviation = abbreviation;
                this.BaseCalculationFactory = baseCalculationFactory;
            }

            public BaseValueType Type;

            public IBaseValueBaseCalculationFactory BaseCalculationFactory;

            public string Name;
            public string Abbreviation;
        }
    }

    public static class PoolValueDatabase
    {
        public static PoolValueData[] PoolValuesData;

        public static void Init(Localization localization)
        {
            PoolValuesData = new PoolValueData[]
            {
                new PoolValueData(PoolValueType.ArcaneEnergy, "-"),
                new PoolValueData(PoolValueType.KarmaPoints, "-"),
                new PoolValueData(PoolValueType.LifePoints, localization.GetCharacterValueText("life_points")),
            };
        }

        public class PoolValueData
        {
            public PoolValueData(PoolValueType type, string name)
            {
                this.Type = type;
                this.Name = name;
            }

            public PoolValueType Type;
            public IncreaseCostType IncreaseCostType = IncreaseCostType.D;
            public string Name;
        }
    }
}

