public enum Role
{
    Player,
    DM
}

public static class AdvantageTypeDefinition
{
    public const int ADVANTAGE_TYPE_BIT_SIZE = 10;
    public const int ADVANTAGE_TYPE_BIT_MASK = 0b11_11_11_11_11;

    public const int ADVANTAGE_ADDITON_BIT_SIZE = 2;
    public const int ADVANTAGE_ADDITON_BIT_MASK = 0b11_00_00_00_00_00;

    public static bool HasLevelAddition(this AdvantageType advantage) => ((int)advantage & (int)AdvantageAddition.Level) > 0;
    public static bool HasSelectAddition(this AdvantageType advantage) => ((int)advantage & (int)AdvantageAddition.Selection) > 0;

    public static int AddSpecialIdentifier(this AdvantageType advantageType, int id) => (int)advantageType & (id << (ADVANTAGE_TYPE_BIT_SIZE + ADVANTAGE_ADDITON_BIT_MASK));

}

[System.Flags]
public enum AdvantageAddition
{
    Level = 0b01 << AdvantageTypeDefinition.ADVANTAGE_TYPE_BIT_SIZE,
    Selection = 0b10 << AdvantageTypeDefinition.ADVANTAGE_TYPE_BIT_SIZE,
}

public enum AdvantageType
{
    Noble = 1 | AdvantageAddition.Level,
    AgeResistant = 2,
    ComfortableSmell = 3,
    Talented = 4,
    Twohanded = 5,
    DarfVision = 6,
    IronResistantAura = 7,
    SenseForDistance = 8,
    Agile = 9,
    FoxSense = 10,
    Convincing = 11,
    Blessed = 12,
    PoisonResistant = 13,
    Lucky = 14,
    GoodLoking = 15,
    ExtraordinarySkill = 16,
    ExtraordinaryCombatTechnic = 17,
    ExtraordinarySense = 18,
    HeatResistant = 19,
    HighArcaneEnergy = 20,
    HighKarmaEnergy = 21,
    HighLifePoints = 22,
    HighSpirit = 23,
    HighToughness = 24,
    PoisonImmunity = 25,
    DiseaseImmunity = 26,
    ColdResistant = 27,
    DiseaseResistat = 28,
    MagicalSynergy = 29,
    Mystic = 30,
    NonSleeper = 31,
    Pragmatic = 32,
    Rich = 33,
    SenseForDirection = 34,
    Contortionist = 35,
    HardToEnchant = 36,
    SocialAdjustment = 37,
    Inconspicuous = 38,
    ImprovedArcaneRegeneration = 39,
    ImprovedKarmaRegeneration = 40,
    ImprovedLifePointRegeneration = 41,
    DisguisedAura = 42,
    TrustingAura = 43,
    WeaponTalent = 44,
    NiceVoice = 45,
    ToughDog = 46,
    Magician = 47,
    SenseOfTime = 48,
    TwovoiceSinging = 49,
    Dwarfensnose = 50,
}
