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
        public static void Init(LocalizedStringTable characterValueTable)
        {
            //Load Localization Table
            StringTable stringTable = characterValueTable.GetTable();

            MainAttributeDatabase.Init(stringTable);
            SkillDatabase.Init(stringTable);
            CombatTechnicDatabase.Init(stringTable);
            CombatValueDatabase.Init(stringTable);
            BaseValueDatabase.Init(stringTable);
            PoolValueDatabase.Init(stringTable);
        }
    }

    public static class MainAttributeDatabase
    {
        public static MainAttributeData[] MainAttributesData;

        public static void Init(StringTable localizedTable)
        {
            MainAttributesData = new MainAttributeData[]
            {
                new MainAttributeData(MainAttributeType.Courage, localizedTable["courage"].LocalizedValue, localizedTable["courage_abbreviation"].LocalizedValue),
                new MainAttributeData(MainAttributeType.Sagacity, localizedTable["sagacity"].LocalizedValue, localizedTable["sagacity_abbreviation"].LocalizedValue),
                new MainAttributeData(MainAttributeType.Intuition, localizedTable["intuition"].LocalizedValue, localizedTable["intuition_abbreviation"].LocalizedValue),
                new MainAttributeData(MainAttributeType.Charisma, localizedTable["charisma"].LocalizedValue, localizedTable["charisma_abbreviation"].LocalizedValue),
                new MainAttributeData(MainAttributeType.Dexterity, localizedTable["dexterity"].LocalizedValue, localizedTable["dexterity_abbreviation"].LocalizedValue),
                new MainAttributeData(MainAttributeType.Agility, localizedTable["agility"].LocalizedValue, localizedTable["agility_abbreviation"].LocalizedValue),
                new MainAttributeData(MainAttributeType.Constitution, localizedTable["constitution"].LocalizedValue, localizedTable["constitution_abbreviation"].LocalizedValue),
                new MainAttributeData(MainAttributeType.Strength, localizedTable["strength"].LocalizedValue, localizedTable["strength_abbreviation"].LocalizedValue),
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

        public static void Init(StringTable localizedTable)
        {
            PhysicalSkillData = new SkillData[]
            {
                new SkillData(SkillType.Flying, MainAttributeType.Courage, MainAttributeType.Intuition, MainAttributeType.Agility, IncreaseCostType.B, localizedTable["flying"].LocalizedValue),
                new SkillData(SkillType.Gaukelei, MainAttributeType.Courage, MainAttributeType.Charisma, MainAttributeType.Dexterity, IncreaseCostType.A, localizedTable["gaukelei"].LocalizedValue),
                new SkillData(SkillType.Climbing, MainAttributeType.Courage, MainAttributeType.Agility, MainAttributeType.Strength, IncreaseCostType.B, localizedTable["climbing"].LocalizedValue),
                new SkillData(SkillType.BodyControl, MainAttributeType.Agility, MainAttributeType.Agility, MainAttributeType.Constitution, IncreaseCostType.D, localizedTable["body_control"].LocalizedValue),
                new SkillData(SkillType.FeatOfStrength, MainAttributeType.Constitution, MainAttributeType.Strength, MainAttributeType.Strength, IncreaseCostType.B, localizedTable["feat_of_strength"].LocalizedValue),
                new SkillData(SkillType.Riding, MainAttributeType.Charisma, MainAttributeType.Agility, MainAttributeType.Strength, IncreaseCostType.B, localizedTable["riding"].LocalizedValue),
                new SkillData(SkillType.Swimming, MainAttributeType.Agility, MainAttributeType.Constitution, MainAttributeType.Strength, IncreaseCostType.B, localizedTable["swimming"].LocalizedValue),
                new SkillData(SkillType.SelfControl, MainAttributeType.Courage, MainAttributeType.Courage, MainAttributeType.Constitution, IncreaseCostType.D, localizedTable["self_control"].LocalizedValue),
                new SkillData(SkillType.Singing, MainAttributeType.Sagacity, MainAttributeType.Charisma, MainAttributeType.Constitution, IncreaseCostType.A, localizedTable["singing"].LocalizedValue),
                new SkillData(SkillType.Perception, MainAttributeType.Sagacity, MainAttributeType.Sagacity, MainAttributeType.Intuition, IncreaseCostType.D, localizedTable["perception"].LocalizedValue),
                new SkillData(SkillType.Dancing, MainAttributeType.Sagacity, MainAttributeType.Charisma, MainAttributeType.Agility, IncreaseCostType.A, localizedTable["dancing"].LocalizedValue),
                new SkillData(SkillType.Pickpocket, MainAttributeType.Courage, MainAttributeType.Dexterity, MainAttributeType.Agility, IncreaseCostType.B, localizedTable["pickpocket"].LocalizedValue),
                new SkillData(SkillType.Stealth, MainAttributeType.Courage, MainAttributeType.Intuition, MainAttributeType.Agility, IncreaseCostType.C, localizedTable["flying"].LocalizedValue),
                new SkillData(SkillType.Carousing, MainAttributeType.Sagacity, MainAttributeType.Constitution, MainAttributeType.Strength, IncreaseCostType.A, localizedTable["carousing"].LocalizedValue),
            };

            SocialSkillData = new SkillData[]
            {
                new SkillData(SkillType.Persuasion, MainAttributeType.Courage, MainAttributeType.Sagacity, MainAttributeType.Charisma, IncreaseCostType.B, localizedTable["persuasion"].LocalizedValue),
                new SkillData(SkillType.Seduction, MainAttributeType.Courage, MainAttributeType.Charisma, MainAttributeType.Charisma, IncreaseCostType.B, localizedTable["seduction"].LocalizedValue),
                new SkillData(SkillType.Intimidation, MainAttributeType.Courage, MainAttributeType.Intuition, MainAttributeType.Charisma, IncreaseCostType.B, localizedTable["intimidation"].LocalizedValue),
                new SkillData(SkillType.Etiquette, MainAttributeType.Sagacity, MainAttributeType.Intuition, MainAttributeType.Charisma, IncreaseCostType.B, localizedTable["etiquette"].LocalizedValue),
                new SkillData(SkillType.Streetwise, MainAttributeType.Sagacity, MainAttributeType.Intuition, MainAttributeType.Charisma, IncreaseCostType.C, localizedTable["streetwise"].LocalizedValue),
                new SkillData(SkillType.Empathy, MainAttributeType.Sagacity, MainAttributeType.Intuition, MainAttributeType.Charisma, IncreaseCostType.C, localizedTable["empathy"].LocalizedValue),
                new SkillData(SkillType.FastTalk, MainAttributeType.Courage, MainAttributeType.Intuition, MainAttributeType.Charisma, IncreaseCostType.C, localizedTable["fast_talk"].LocalizedValue),
                new SkillData(SkillType.Disguise, MainAttributeType.Intuition, MainAttributeType.Charisma, MainAttributeType.Agility, IncreaseCostType.B, localizedTable["disguise"].LocalizedValue),
                new SkillData(SkillType.Willpower, MainAttributeType.Courage, MainAttributeType.Intuition, MainAttributeType.Charisma, IncreaseCostType.D, localizedTable["willpower"].LocalizedValue),
            };

            NatureSkillData = new SkillData[]
            {
                new SkillData(SkillType.Tracking, MainAttributeType.Courage, MainAttributeType.Intuition, MainAttributeType.Agility, IncreaseCostType.C, localizedTable["tracking"].LocalizedValue),
                new SkillData(SkillType.Ropes, MainAttributeType.Sagacity, MainAttributeType.Dexterity, MainAttributeType.Strength, IncreaseCostType.A, localizedTable["ropes"].LocalizedValue),
                new SkillData(SkillType.Fishing, MainAttributeType.Dexterity, MainAttributeType.Agility, MainAttributeType.Constitution, IncreaseCostType.A, localizedTable["fishing"].LocalizedValue),
                new SkillData(SkillType.Orienting, MainAttributeType.Sagacity, MainAttributeType.Intuition, MainAttributeType.Intuition, IncreaseCostType.B, localizedTable["orienting"].LocalizedValue),
                new SkillData(SkillType.PlantLore, MainAttributeType.Sagacity, MainAttributeType.Dexterity, MainAttributeType.Constitution, IncreaseCostType.C, localizedTable["plant_lore"].LocalizedValue),
                new SkillData(SkillType.AnimalLore, MainAttributeType.Courage, MainAttributeType.Courage, MainAttributeType.Charisma, IncreaseCostType.C, localizedTable["animal_lore"].LocalizedValue),
                new SkillData(SkillType.Survival, MainAttributeType.Courage, MainAttributeType.Agility, MainAttributeType.Constitution, IncreaseCostType.C, localizedTable["survival"].LocalizedValue),
            };

            KnowledgeSkillData = new SkillData[]
            {
                new SkillData(SkillType.Gambling, MainAttributeType.Sagacity, MainAttributeType.Sagacity, MainAttributeType.Intuition, IncreaseCostType.A, localizedTable["gambling"].LocalizedValue),
                new SkillData(SkillType.Geography, MainAttributeType.Sagacity, MainAttributeType.Sagacity, MainAttributeType.Intuition, IncreaseCostType.B, localizedTable["geography"].LocalizedValue),
                new SkillData(SkillType.History, MainAttributeType.Sagacity, MainAttributeType.Sagacity, MainAttributeType.Intuition, IncreaseCostType.B, localizedTable["history"].LocalizedValue),
                new SkillData(SkillType.Religions, MainAttributeType.Sagacity, MainAttributeType.Sagacity, MainAttributeType.Intuition, IncreaseCostType.B, localizedTable["religions"].LocalizedValue),
                new SkillData(SkillType.Warfare, MainAttributeType.Courage, MainAttributeType.Sagacity, MainAttributeType.Intuition, IncreaseCostType.B, localizedTable["warfare"].LocalizedValue),
                new SkillData(SkillType.MagicalLore, MainAttributeType.Sagacity, MainAttributeType.Sagacity, MainAttributeType.Intuition, IncreaseCostType.C, localizedTable["magical_lore"].LocalizedValue),
                new SkillData(SkillType.Mechanics, MainAttributeType.Sagacity, MainAttributeType.Sagacity, MainAttributeType.Dexterity, IncreaseCostType.B, localizedTable["mechanics"].LocalizedValue),
                new SkillData(SkillType.Math, MainAttributeType.Sagacity, MainAttributeType.Sagacity, MainAttributeType.Intuition, IncreaseCostType.A, localizedTable["math"].LocalizedValue),
                new SkillData(SkillType.Law, MainAttributeType.Sagacity, MainAttributeType.Sagacity, MainAttributeType.Intuition, IncreaseCostType.A, localizedTable["law"].LocalizedValue),
                new SkillData(SkillType.MythsAndLegends, MainAttributeType.Sagacity, MainAttributeType.Sagacity, MainAttributeType.Intuition, IncreaseCostType.B, localizedTable["myths_and_legends"].LocalizedValue),
                new SkillData(SkillType.SphereLore, MainAttributeType.Sagacity, MainAttributeType.Sagacity, MainAttributeType.Intuition, IncreaseCostType.B, localizedTable["sphere_lore"].LocalizedValue),
                new SkillData(SkillType.Astronomy, MainAttributeType.Sagacity, MainAttributeType.Sagacity, MainAttributeType.Intuition, IncreaseCostType.A, localizedTable["astronomy"].LocalizedValue),
            };

            CraftSkillData = new SkillData[]
            {
                new SkillData(SkillType.Alchemy, MainAttributeType.Courage, MainAttributeType.Sagacity, MainAttributeType.Dexterity, IncreaseCostType.C, localizedTable["alchemy"].LocalizedValue),
                new SkillData(SkillType.Sailing, MainAttributeType.Dexterity, MainAttributeType.Agility, MainAttributeType.Strength, IncreaseCostType.B, localizedTable["sailing"].LocalizedValue),
                new SkillData(SkillType.Driving, MainAttributeType.Charisma, MainAttributeType.Dexterity, MainAttributeType.Constitution, IncreaseCostType.A, localizedTable["driving"].LocalizedValue),
                new SkillData(SkillType.Commerce, MainAttributeType.Sagacity, MainAttributeType.Intuition, MainAttributeType.Charisma, IncreaseCostType.B, localizedTable["commerce"].LocalizedValue),
                new SkillData(SkillType.TreatPoison, MainAttributeType.Courage, MainAttributeType.Sagacity, MainAttributeType.Intuition, IncreaseCostType.B, localizedTable["treat_poison"].LocalizedValue),
                new SkillData(SkillType.TreatDisease, MainAttributeType.Courage, MainAttributeType.Intuition, MainAttributeType.Constitution, IncreaseCostType.B, localizedTable["treat_disease"].LocalizedValue),
                new SkillData(SkillType.TreatSoul, MainAttributeType.Intuition, MainAttributeType.Charisma, MainAttributeType.Constitution, IncreaseCostType.B, localizedTable["treat_soul"].LocalizedValue),
                new SkillData(SkillType.TreatWounds, MainAttributeType.Sagacity, MainAttributeType.Dexterity, MainAttributeType.Dexterity, IncreaseCostType.D, localizedTable["treat_wounds"].LocalizedValue),
                new SkillData(SkillType.Woodworking, MainAttributeType.Dexterity, MainAttributeType.Agility, MainAttributeType.Strength, IncreaseCostType.B, localizedTable["woodworking"].LocalizedValue),
                new SkillData(SkillType.PrepareFood, MainAttributeType.Intuition, MainAttributeType.Dexterity, MainAttributeType.Dexterity, IncreaseCostType.A, localizedTable["prepare_food"].LocalizedValue),
                new SkillData(SkillType.Leatherworking, MainAttributeType.Dexterity, MainAttributeType.Agility, MainAttributeType.Constitution, IncreaseCostType.B, localizedTable["leatherworking"].LocalizedValue),
                new SkillData(SkillType.ArtisticAbility, MainAttributeType.Intuition, MainAttributeType.Dexterity, MainAttributeType.Dexterity, IncreaseCostType.A, localizedTable["artistic_ability"].LocalizedValue),
                new SkillData(SkillType.Metalworking, MainAttributeType.Dexterity, MainAttributeType.Constitution, MainAttributeType.Strength, IncreaseCostType.C, localizedTable["metalworking"].LocalizedValue),
                new SkillData(SkillType.Music, MainAttributeType.Charisma, MainAttributeType.Dexterity, MainAttributeType.Constitution, IncreaseCostType.A, localizedTable["music"].LocalizedValue),
                new SkillData(SkillType.PickLocks, MainAttributeType.Intuition, MainAttributeType.Dexterity, MainAttributeType.Dexterity, IncreaseCostType.C, localizedTable["pick_locks"].LocalizedValue),
                new SkillData(SkillType.Earthencraft, MainAttributeType.Dexterity, MainAttributeType.Dexterity, MainAttributeType.Strength, IncreaseCostType.A, localizedTable["earthencraft"].LocalizedValue),
                new SkillData(SkillType.Clothworking, MainAttributeType.Sagacity, MainAttributeType.Dexterity, MainAttributeType.Dexterity, IncreaseCostType.A, localizedTable["clothworking"].LocalizedValue),
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

        public static void Init(StringTable localizedTable)
        {
            CombatTechnicsData = new CombatTechnicData[]
            {
                new CombatTechnicData(CombatTechnicType.Crossbow, IncreaseCostType.B, localizedTable["crossbow"].LocalizedValue, MainAttributeType.Dexterity),
                new CombatTechnicData(CombatTechnicType.Bow, IncreaseCostType.C, localizedTable["bow"].LocalizedValue, MainAttributeType.Dexterity),
                new CombatTechnicData(CombatTechnicType.ThrownWeapon, IncreaseCostType.B, localizedTable["thrown_weapon"].LocalizedValue, MainAttributeType.Dexterity),
                new CombatTechnicData(CombatTechnicType.Dagger, IncreaseCostType.B, localizedTable["dagger"].LocalizedValue, MainAttributeType.Agility),
                new CombatTechnicData(CombatTechnicType.FencingWeapon, IncreaseCostType.C, localizedTable["fencing_weapon"].LocalizedValue, MainAttributeType.Agility),
                new CombatTechnicData(CombatTechnicType.ImpactWeapon, IncreaseCostType.C, localizedTable["impact_weapon"].LocalizedValue, MainAttributeType.Strength),
                new CombatTechnicData(CombatTechnicType.ChainWeapon, IncreaseCostType.C, localizedTable["chain_weapon"].LocalizedValue, MainAttributeType.Strength),
                new CombatTechnicData(CombatTechnicType.Lance, IncreaseCostType.B, localizedTable["lance"].LocalizedValue, MainAttributeType.Strength),
                new CombatTechnicData(CombatTechnicType.Shield, IncreaseCostType.C, localizedTable["shield"].LocalizedValue, MainAttributeType.Strength),
                new CombatTechnicData(CombatTechnicType.TwoHandedImpactWeapon, IncreaseCostType.C, localizedTable["two_handed_impact_weapon"].LocalizedValue, MainAttributeType.Strength),
                new CombatTechnicData(CombatTechnicType.TwoHandedSword, IncreaseCostType.C, localizedTable["two_handed_sword"].LocalizedValue, MainAttributeType.Strength),
                new CombatTechnicData(CombatTechnicType.Brawling, IncreaseCostType.B, localizedTable["brawling"].LocalizedValue, MainAttributeType.Strength, MainAttributeType.Agility),
                new CombatTechnicData(CombatTechnicType.Sword, IncreaseCostType.C, localizedTable["sword"].LocalizedValue, MainAttributeType.Strength, MainAttributeType.Agility),
                new CombatTechnicData(CombatTechnicType.PoleWeapon, IncreaseCostType.C, localizedTable["pole_weapon"].LocalizedValue, MainAttributeType.Strength, MainAttributeType.Agility),
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

        public static void Init(StringTable localizedTable)
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

        public static void Init(StringTable localizedTable)
        {
            BaseValuesData = new BaseValueData[]
            {
                new BaseValueData(BaseValueType.Dodge, new DodgeCalculationFactory(), localizedTable["dodge"].LocalizedValue, localizedTable["dodge_abbreviation"].LocalizedValue),
                new BaseValueData(BaseValueType.Initative, new InitiativeCalculationFactory(), localizedTable["initiative"].LocalizedValue, localizedTable["initiative_abbreviation"].LocalizedValue),
                new BaseValueData(BaseValueType.Movement, new MovementCalculationFactory(), localizedTable["movement"].LocalizedValue, localizedTable["movement_abbreviation"].LocalizedValue),
                new BaseValueData(BaseValueType.Spirit, new SpiritCalculationFactory(), localizedTable["spirit"].LocalizedValue, localizedTable["spirit_abbreviation"].LocalizedValue),
                new BaseValueData(BaseValueType.Toughness, new ToughnessCalculationFactory(), localizedTable["toughness"].LocalizedValue, localizedTable["toughness_abbreviation"].LocalizedValue),
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

        public static void Init(StringTable localizedTable)
        {
            PoolValuesData = new PoolValueData[]
            {
                new PoolValueData(PoolValueType.ArcaneEnergy, localizedTable["arcane_energy"].LocalizedValue),
                new PoolValueData(PoolValueType.KarmaPoints, localizedTable["karma_points"].LocalizedValue),
                new PoolValueData(PoolValueType.LifePoints, localizedTable["life_points"].LocalizedValue),
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

