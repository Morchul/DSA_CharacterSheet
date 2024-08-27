using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Type
{
    public const int ATTIBUTE_TYPE_SCOPE = 0;
    public const int POOL_VALUE_TYPE_SCOPE = 10;
    public const int SKILLS_TYPE_SCOPE = 100;
    public const int PHYSICAL_SKILL_TYPE_SCOPE = 100;
    public const int SOCIAL_SKILL_TYPE_SCOPE = 120;
    public const int NATURE_SKILL_TYPE_SCOPE = 140;
    public const int KNOWLEDGE_SKILL_TYPE_SCOPE = 160;
    public const int CRAFT_SKILL_TYPE_SCOPE = 180;
}

[System.Serializable]
public enum AttributeType : int
{
    Courage = Type.ATTIBUTE_TYPE_SCOPE,
    Sagacity = Type.ATTIBUTE_TYPE_SCOPE + 1,
    Intuition = Type.ATTIBUTE_TYPE_SCOPE + 2,
    Charisma = Type.ATTIBUTE_TYPE_SCOPE + 3,
    Dexterity = Type.ATTIBUTE_TYPE_SCOPE + 4,
    Agility = Type.ATTIBUTE_TYPE_SCOPE + 5,
    Constitution = Type.ATTIBUTE_TYPE_SCOPE + 6,
    Strength = Type.ATTIBUTE_TYPE_SCOPE + 7
}

//[System.Serializable]
//public enum PoolValueType : int
//{
//    HealhtPoints = Type.POOL_VALUE_TYPE_SCOPE,
//    ArcaneEnergie = Type.POOL_VALUE_TYPE_SCOPE + 1,
//    KarmaEnergie = Type.POOL_VALUE_TYPE_SCOPE + 2
//}

#region Skills
[System.Serializable]
public enum PhysicalSkillType : int
{
    BodyControl = Type.PHYSICAL_SKILL_TYPE_SCOPE,
    Carousing = Type.PHYSICAL_SKILL_TYPE_SCOPE + 1,
    Climbing = Type.PHYSICAL_SKILL_TYPE_SCOPE + 2,
    Dancing = Type.PHYSICAL_SKILL_TYPE_SCOPE + 3,
    FeatOfStrength = Type.PHYSICAL_SKILL_TYPE_SCOPE + 4,
    Flying = Type.PHYSICAL_SKILL_TYPE_SCOPE + 5,
    Gaukelei = Type.PHYSICAL_SKILL_TYPE_SCOPE + 6,
    Perception = Type.PHYSICAL_SKILL_TYPE_SCOPE + 7,
    Pickpocket = Type.PHYSICAL_SKILL_TYPE_SCOPE + 8,
    Riding = Type.PHYSICAL_SKILL_TYPE_SCOPE + 9,
    SelfControl = Type.PHYSICAL_SKILL_TYPE_SCOPE + 10,
    Singing = Type.PHYSICAL_SKILL_TYPE_SCOPE + 11,
    Stealth = Type.PHYSICAL_SKILL_TYPE_SCOPE + 12,
    Swimming = Type.PHYSICAL_SKILL_TYPE_SCOPE + 13
}
[System.Serializable]
public enum SocialSkillType : int
{
    Disguise = Type.SOCIAL_SKILL_TYPE_SCOPE,
    Empathy = Type.SOCIAL_SKILL_TYPE_SCOPE + 1,
    Etiquette = Type.SOCIAL_SKILL_TYPE_SCOPE + 2,
    FastTalk = Type.SOCIAL_SKILL_TYPE_SCOPE + 3,
    Intimidation = Type.SOCIAL_SKILL_TYPE_SCOPE + 4,
    Persuasion = Type.SOCIAL_SKILL_TYPE_SCOPE + 5,
    Seduction = Type.SOCIAL_SKILL_TYPE_SCOPE + 6,
    Steetwise = Type.SOCIAL_SKILL_TYPE_SCOPE + 7,
    Willpower = Type.SOCIAL_SKILL_TYPE_SCOPE + 8,
}
[System.Serializable]
public enum NatureSkillType : int
{
    AnimalLore = Type.NATURE_SKILL_TYPE_SCOPE,
    Fishing = Type.NATURE_SKILL_TYPE_SCOPE + 1,
    Orienting = Type.NATURE_SKILL_TYPE_SCOPE + 2,
    PlantLore = Type.NATURE_SKILL_TYPE_SCOPE + 3,
    Ropes = Type.NATURE_SKILL_TYPE_SCOPE + 4,
    Survival = Type.NATURE_SKILL_TYPE_SCOPE + 5,
    Tracking = Type.NATURE_SKILL_TYPE_SCOPE + 6,
}
[System.Serializable]
public enum KnowledgeSkillType : int
{
    Astronomy = Type.KNOWLEDGE_SKILL_TYPE_SCOPE,
    Gambling = Type.KNOWLEDGE_SKILL_TYPE_SCOPE + 1,
    Geography = Type.KNOWLEDGE_SKILL_TYPE_SCOPE + 2,
    History = Type.KNOWLEDGE_SKILL_TYPE_SCOPE + 3,
    Law = Type.KNOWLEDGE_SKILL_TYPE_SCOPE + 4,
    MagicalLore = Type.KNOWLEDGE_SKILL_TYPE_SCOPE + 5,
    Math = Type.KNOWLEDGE_SKILL_TYPE_SCOPE + 6,
    Mechanics = Type.KNOWLEDGE_SKILL_TYPE_SCOPE + 7,
    MythsLegends = Type.KNOWLEDGE_SKILL_TYPE_SCOPE + 8,
    Religions = Type.KNOWLEDGE_SKILL_TYPE_SCOPE + 9,
    SphereLore = Type.KNOWLEDGE_SKILL_TYPE_SCOPE + 10,
    Warfare = Type.KNOWLEDGE_SKILL_TYPE_SCOPE + 11,
}
[System.Serializable]
public enum CraftSkillType : int
{
    Alchemy = Type.CRAFT_SKILL_TYPE_SCOPE,
    ArtisticAbility = Type.CRAFT_SKILL_TYPE_SCOPE + 1,
    Clothworking = Type.CRAFT_SKILL_TYPE_SCOPE + 2,
    Commerce = Type.CRAFT_SKILL_TYPE_SCOPE + 3,
    Driving = Type.CRAFT_SKILL_TYPE_SCOPE + 4,
    Earthencraft = Type.CRAFT_SKILL_TYPE_SCOPE + 5,
    Leatherworking = Type.CRAFT_SKILL_TYPE_SCOPE + 6,
    Metalworking = Type.CRAFT_SKILL_TYPE_SCOPE + 7,
    Music = Type.CRAFT_SKILL_TYPE_SCOPE + 8,
    PickLocks = Type.CRAFT_SKILL_TYPE_SCOPE + 9,
    PrepareFood = Type.CRAFT_SKILL_TYPE_SCOPE + 10,
    Sailing = Type.CRAFT_SKILL_TYPE_SCOPE + 11,
    TreatDisease = Type.CRAFT_SKILL_TYPE_SCOPE + 12,
    TreatPoison = Type.CRAFT_SKILL_TYPE_SCOPE + 13,
    TreatSoul = Type.CRAFT_SKILL_TYPE_SCOPE + 14,
    TreatWounds = Type.CRAFT_SKILL_TYPE_SCOPE + 15,
    Woodworking = Type.CRAFT_SKILL_TYPE_SCOPE + 16,
}
#endregion

//[System.Serializable]
//public enum CombatTechnicType : int
//{
//    Bows,
//    Brawling,
//    ChainWeapons,
//    Crossbows,
//    Daggers,
//    FencingWeapons,
//    ImpactWeapons,
//    Lances,
//    PoleWeapons,
//    Shields,
//    Swords,
//    ThrownWeapons,
//    TwoHandedImpactWeapons,
//    TwoHandedSwords
//}

[System.Serializable]
public enum DiceType : int
{
    D3 = 3,
    D4 = 4,
    D6 = 6,
    D10 = 10,
    D12 = 12,
    D20 = 20,
    D100 = 100
}

[System.Serializable]
public enum ModifierType : int
{
    Condition,
}

[System.Serializable]
public enum ConditionType : int
{
    Pain,
}

