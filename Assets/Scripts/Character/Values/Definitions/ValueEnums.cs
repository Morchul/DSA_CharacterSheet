namespace DSA.Character.Value
{
    public static class ValueTypeDefinition
    {
        public const int VALUE_BASE_TYPE_BIT_SIZE = 5;
        public const int VALUE_BASE_TYPE_BIT_MASK = 0b11111;

        public static int GetValueTypeIndex(this int type) => type >> VALUE_BASE_TYPE_BIT_SIZE;
        public static int GetValueTypeArrayIndex(this int type) => (type >> VALUE_BASE_TYPE_BIT_SIZE) - 1;
        public static ValueBaseType GetValueBaseType(this int type) => (ValueBaseType)(type & VALUE_BASE_TYPE_BIT_MASK);

        public static string GetNameOfValueType(this int type)
        {
            switch (type.GetValueBaseType())
            {
                case ValueBaseType.Attribute:
                    return ((MainAttributeType)type).ToString();
                case ValueBaseType.BaseValue:
                    return ((BaseValueType)type).ToString();
                case ValueBaseType.PoolValue:
                    return ((PoolValueType)type).ToString();
                case ValueBaseType.PhysicalSkill:
                case ValueBaseType.SocialSkill:
                case ValueBaseType.NatureSkill:
                case ValueBaseType.KnowledgeSkill:
                case ValueBaseType.CraftSkill:
                    return ((SkillType)type).ToString();
                case ValueBaseType.CombatTechnic:
                    return ((CombatTechnicType)type).ToString();
                case ValueBaseType.CombatValue:
                    return ((CombatValueType)type).ToString();
                case ValueBaseType.CurrentPoolValue:
                    return ((CurrentPoolValueType)type).ToString();
            }

            return "";
        }
    }

    [System.Serializable]
    public enum ValueBaseType
    {
        Attribute = 1,

        BaseValue = 2,
        PoolValue = 3,

        PhysicalSkill = 4,
        SocialSkill = 5,
        NatureSkill = 6,
        KnowledgeSkill = 7,
        CraftSkill = 8,

        CombatTechnic = 9,
        CombatValue = 10,

        CurrentPoolValue = 11,
    }

    [System.Serializable]
    public enum MainAttributeType
    {
        //Attributes
        Courage = ValueBaseType.Attribute | (1 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
        Sagacity = ValueBaseType.Attribute | (2 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
        Intuition = ValueBaseType.Attribute | (3 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
        Charisma = ValueBaseType.Attribute | (4 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
        Dexterity = ValueBaseType.Attribute | (5 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
        Agility = ValueBaseType.Attribute | (6 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
        Constitution = ValueBaseType.Attribute | (7 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
        Strength = ValueBaseType.Attribute | (8 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
    }

    [System.Serializable]
    public enum SkillType
    {
        //Physical Skills
        BodyControl = ValueBaseType.PhysicalSkill | (1 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
        Carousing = ValueBaseType.PhysicalSkill | (2 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
        Climbing = ValueBaseType.PhysicalSkill | (3 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
        Dancing = ValueBaseType.PhysicalSkill | (4 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
        FeatOfStrength = ValueBaseType.PhysicalSkill | (5 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
        Flying = ValueBaseType.PhysicalSkill | (6 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
        Gaukelei = ValueBaseType.PhysicalSkill | (7 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
        Perception = ValueBaseType.PhysicalSkill | (8 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
        Pickpocket = ValueBaseType.PhysicalSkill | (9 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
        Riding = ValueBaseType.PhysicalSkill | (10 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
        SelfControl = ValueBaseType.PhysicalSkill | (11 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
        Singing = ValueBaseType.PhysicalSkill | (12 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
        Stealth = ValueBaseType.PhysicalSkill | (13 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
        Swimming = ValueBaseType.PhysicalSkill | (14 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),

        //Social Skills
        Disguise = ValueBaseType.SocialSkill | (1 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
        Empathy = ValueBaseType.SocialSkill | (2 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
        Etiquette = ValueBaseType.SocialSkill | (3 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
        FastTalk = ValueBaseType.SocialSkill | (4 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
        Intimidation = ValueBaseType.SocialSkill | (5 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
        Persuasion = ValueBaseType.SocialSkill | (6 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
        Seduction = ValueBaseType.SocialSkill | (7 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
        Streetwise = ValueBaseType.SocialSkill | (8 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
        Willpower = ValueBaseType.SocialSkill | (9 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),

        //Nature Skills
        AnimalLore = ValueBaseType.NatureSkill | (1 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
        Fishing = ValueBaseType.NatureSkill | (2 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
        Orienting = ValueBaseType.NatureSkill | (3 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
        PlantLore = ValueBaseType.NatureSkill | (4 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
        Ropes = ValueBaseType.NatureSkill | (5 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
        Survival = ValueBaseType.NatureSkill | (6 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
        Tracking = ValueBaseType.NatureSkill | (7 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),

        //Knowledge Skills
        Astronomy = ValueBaseType.KnowledgeSkill | (1 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
        Gambling = ValueBaseType.KnowledgeSkill | (2 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
        Geography = ValueBaseType.KnowledgeSkill | (3 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
        History = ValueBaseType.KnowledgeSkill | (4 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
        Law = ValueBaseType.KnowledgeSkill | (5 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
        MagicalLore = ValueBaseType.KnowledgeSkill | (6 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
        Math = ValueBaseType.KnowledgeSkill | (7 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
        Mechanics = ValueBaseType.KnowledgeSkill | (8 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
        MythsAndLegends = ValueBaseType.KnowledgeSkill | (9 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
        Religions = ValueBaseType.KnowledgeSkill | (10 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
        SphereLore = ValueBaseType.KnowledgeSkill | (11 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
        Warfare = ValueBaseType.KnowledgeSkill | (12 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),

        //Craft Skills
        Alchemy = ValueBaseType.CraftSkill | (1 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
        ArtisticAbility = ValueBaseType.CraftSkill | (2 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
        Clothworking = ValueBaseType.CraftSkill | (3 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
        Commerce = ValueBaseType.CraftSkill | (4 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
        Driving = ValueBaseType.CraftSkill | (5 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
        Earthencraft = ValueBaseType.CraftSkill | (6 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
        Leatherworking = ValueBaseType.CraftSkill | (7 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
        Metalworking = ValueBaseType.CraftSkill | (8 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
        Music = ValueBaseType.CraftSkill | (9 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
        PickLocks = ValueBaseType.CraftSkill | (10 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
        PrepareFood = ValueBaseType.CraftSkill | (11 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
        Sailing = ValueBaseType.CraftSkill | (12 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
        TreatDisease = ValueBaseType.CraftSkill | (13 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
        TreatPoison = ValueBaseType.CraftSkill | (14 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
        TreatSoul = ValueBaseType.CraftSkill | (15 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
        TreatWounds = ValueBaseType.CraftSkill | (16 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
        Woodworking = ValueBaseType.CraftSkill | (17 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
    }

    [System.Serializable]
    public enum CombatTechnicType
    {
        //Combat Technic
        Crossbow = ValueBaseType.CombatTechnic | (1 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
        Bow = ValueBaseType.CombatTechnic | (2 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
        Dagger = ValueBaseType.CombatTechnic | (3 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
        FencingWeapon = ValueBaseType.CombatTechnic | (4 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
        ImpactWeapon = ValueBaseType.CombatTechnic | (5 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
        ChainWeapon = ValueBaseType.CombatTechnic | (6 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
        Lance = ValueBaseType.CombatTechnic | (7 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
        Brawling = ValueBaseType.CombatTechnic | (8 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
        Shield = ValueBaseType.CombatTechnic | (9 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
        Sword = ValueBaseType.CombatTechnic | (10 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
        PoleWeapon = ValueBaseType.CombatTechnic | (11 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
        ThrownWeapon = ValueBaseType.CombatTechnic | (12 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
        TwoHandedImpactWeapon = ValueBaseType.CombatTechnic | (13 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
        TwoHandedSword = ValueBaseType.CombatTechnic | (14 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
    }

    [System.Serializable]
    public enum CombatValueType
    {
        //Combat Value
        CrossbowAT = ValueBaseType.CombatValue | (1 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
        BowAT = ValueBaseType.CombatValue | (2 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
        DaggerAT = ValueBaseType.CombatValue | (3 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
        DaggerDE = ValueBaseType.CombatValue | (4 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
        FencingWeaponAT = ValueBaseType.CombatValue | (5 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
        FencingWeaponDE = ValueBaseType.CombatValue | (6 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
        ImpactWeaponAT = ValueBaseType.CombatValue | (7 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
        ImpactWeaponDE = ValueBaseType.CombatValue | (8 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
        ChainWeaponAT = ValueBaseType.CombatValue | (9 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
        LanceAT = ValueBaseType.CombatValue | (10 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
        LanceDE = ValueBaseType.CombatValue | (11 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
        BrawlingAT = ValueBaseType.CombatValue | (12 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
        BrawlingDE = ValueBaseType.CombatValue | (13 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
        ShieldAT = ValueBaseType.CombatValue | (14 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
        ShieldDE = ValueBaseType.CombatValue | (15 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
        SwordAT = ValueBaseType.CombatValue | (16 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
        SwordDE = ValueBaseType.CombatValue | (17 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
        PoleWeaponAT = ValueBaseType.CombatValue | (18 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
        PoleWeaponDE = ValueBaseType.CombatValue | (19 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
        ThrownWeaponAT = ValueBaseType.CombatValue | (20 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
        TwoHandedImpactWeaponAT = ValueBaseType.CombatValue | (21 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
        TwoHandedImpactWeaponDE = ValueBaseType.CombatValue | (22 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
        TwoHandedSwordAT = ValueBaseType.CombatValue | (23 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
        TwoHandedSwordDE = ValueBaseType.CombatValue | (24 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
    }

    [System.Serializable]
    public enum PoolValueType
    {
        LifePoints = ValueBaseType.PoolValue | (1 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
        ArcaneEnergy = ValueBaseType.PoolValue | (2 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
        KarmaPoints = ValueBaseType.PoolValue | (3 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),

    }

    [System.Serializable]
    public enum CurrentPoolValueType
    {
        CurrentLifePoints = ValueBaseType.CurrentPoolValue | (1 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
        CurrentArcaneEnergy = ValueBaseType.CurrentPoolValue | (2 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
        CurrentKarmaPoints = ValueBaseType.CurrentPoolValue | (3 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
    }

    [System.Serializable]
    public enum BaseValueType
    {
        Spirit = ValueBaseType.BaseValue | (1 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
        Toughness = ValueBaseType.BaseValue | (2 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
        Dodge = ValueBaseType.BaseValue | (3 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
        Movement = ValueBaseType.BaseValue | (4 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
        Initative = ValueBaseType.BaseValue | (5 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
    }
}

namespace DSA.Character.Modifier
{
    [System.Serializable]
    public enum IncreaseCostType
    {
        A, B, C, D, E
    }

    [System.Serializable]
    public enum ModifierIdentifier
    {
        None = 0,
    }
}
