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

    public static class SkillsDatabase
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
        public class CombatTechnicData
        {
            public CombatTechnicType Type;
            public MainAttributeType[] PrimaryAttributesTypes;
            public IncreaseCostType IncreaseCostType;

            public string Name;
        }
    }

    public static class CombatValueDatabase
    {
        public class CombatValueData
        {
            public CombatValueType Type;
            public CombatTechnicType CombatTechnic;

            public string Name;
        }
    }

    public static class BaseValueDatabase
    {
        public class BaseValueData
        {
            public BaseValueType Type;

            public string Name;
            public string Abbreviation;
        }
    }

    public static class PoolValueDatabase
    {
        public class PoolValueData
        {
            public PoolValueType Type;

            public string Name;

            public IncreaseCostType IncreaseCostType = IncreaseCostType.D;
        }
    }
}

