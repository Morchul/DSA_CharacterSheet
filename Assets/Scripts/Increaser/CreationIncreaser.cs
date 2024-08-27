using DSA.Character;
using DSA.Character.Modifier;
using DSA.Character.Value;

public class CreationIncreaser : BaseIncreaser
{
    private ExperienceLevel experienceLevel;

    public CreationIncreaser(ExperienceLevel experienceLevel)
    {
        this.experienceLevel = experienceLevel;
    }

    public override bool AllowEditOfAdvantages => true;
    public override bool AllowFinishWithWarnings => false;

    protected override bool CanBeIncreased(IIncreasable increasable)
    {
        int creationMaximum = 0;

        switch (increasable.Type.GetValueBaseType())
        {
            case ValueBaseType.Attribute:
                creationMaximum = MaxAttributePointsReached() ? 0 : GetAttributeMax(increasable);
                break;
            case ValueBaseType.PhysicalSkill:
            case ValueBaseType.SocialSkill:
            case ValueBaseType.NatureSkill:
            case ValueBaseType.KnowledgeSkill:
            case ValueBaseType.CraftSkill:
                creationMaximum = experienceLevel.MaxSkill;
                break;
            case ValueBaseType.CombatTechnic:
                creationMaximum = experienceLevel.MaxCombatTechnic;
                break;
            case ValueBaseType.PoolValue:
                creationMaximum = 0;
                break;
        }

        return increasable.IncreaseValue < creationMaximum && base.CanBeIncreased(increasable);
    }

    private int GetAttributeMax(IIncreasable increasable)
    {
        int maxAttribute = experienceLevel.MaxAttribute;

        //There is some more race specific testing which might change the maximum
        foreach (Race.RaceAttributeCreationModifier andModifier in character.Race.AndModification)
        {
            if((int)andModifier.AttributeType == increasable.Type)
            {
                return maxAttribute + andModifier.Modifier;
            }
        }

        bool malusRuleFound = false;
        bool malusApplies = false;
        int attributeMales = 0;
        bool bonusRuleFound = false;

        foreach (Race.RaceAttributeCreationModifier orModifier in character.Race.OrModification)
        {
            MainAttribute attribute = character.GetAttribute(orModifier.AttributeType);

            if (orModifier.Modifier > 0 && attribute.Value.BaseValue > maxAttribute)
            {
                if (bonusRuleFound)
                {
                    return maxAttribute;
                }

                if(increasable.Type == (int)orModifier.AttributeType)
                {
                    return maxAttribute + orModifier.Modifier;
                }

                bonusRuleFound = true;
            }

            if(orModifier.Modifier < 0 && attribute.Value.BaseValue <= maxAttribute + orModifier.Modifier)
            {
                if (increasable.Type != (int)orModifier.AttributeType)
                    malusRuleFound = true;
                else
                {
                    attributeMales = orModifier.Modifier;
                    malusApplies = true;
                }
            }
        }

        if (malusApplies && !malusRuleFound)
            return maxAttribute + attributeMales;

        return maxAttribute;
    }

    private bool MaxAttributePointsReached()
    {
        int totalAttributePoints = 0;

        totalAttributePoints += character.GetAttribute(MainAttributeType.Agility).Value.BaseValue;
        totalAttributePoints += character.GetAttribute(MainAttributeType.Courage).Value.BaseValue;
        totalAttributePoints += character.GetAttribute(MainAttributeType.Constitution).Value.BaseValue;
        totalAttributePoints += character.GetAttribute(MainAttributeType.Dexterity).Value.BaseValue;
        totalAttributePoints += character.GetAttribute(MainAttributeType.Sagacity).Value.BaseValue;
        totalAttributePoints += character.GetAttribute(MainAttributeType.Intuition).Value.BaseValue;
        totalAttributePoints += character.GetAttribute(MainAttributeType.Charisma).Value.BaseValue;
        totalAttributePoints += character.GetAttribute(MainAttributeType.Strength).Value.BaseValue;

        return totalAttributePoints == experienceLevel.MaxTotalAttributePoints;
    }
}

public class CreationIncreaserFactory : IIncreaserFactory
{
    private ExperienceLevel experienceLevel;

    public CreationIncreaserFactory(ExperienceLevel experienceLevel)
    {
        this.experienceLevel = experienceLevel;
    }

    public IIncreaser Create()
    {
        return new CreationIncreaser(experienceLevel);
    }
}