using DSA.Character.Modifier;
using DSA.Character.Value;
using UnityEngine;

public static class Constant
{
    public const int BASE_ARCANE_ENERGIE = 20;
    public const int BASE_KARMA_ENERGIE = 20;

    //Minimum value character has to start with
    public const int ATTR_START_VALUE = 8;
    public const int SKILL_START_VALUE = 0;
    public const int COMBAT_TECHNIC_START_VALUE = 6;

    public const int MAX_AP_FOR_CHARACTER_FINISH = 100;

    public const int NO_MAX = int.MaxValue;

    public const int CONDITION_MAX = 4;

    public const int INCAPACITADED = 999;

    #region increase
    public const int TAL_INC_COST_TYPE_A = 1;
    public const int TAL_INC_COST_TYPE_B = 2;
    public const int TAL_INC_COST_TYPE_C = 3;
    public const int TAL_INC_COST_TYPE_D = 4;
    public const int TAL_INC_COST_TYPE_E = 15;
}

public static class Utility
{
    public static int GetIncreaseCost(IncreaseCostType type, int level)
    {
        return type switch
        {
            IncreaseCostType.A => Mathf.Max(level - 11, 1) * Constant.TAL_INC_COST_TYPE_A,
            IncreaseCostType.B => Mathf.Max(level - 11, 1) * Constant.TAL_INC_COST_TYPE_B,
            IncreaseCostType.C => Mathf.Max(level - 11, 1) * Constant.TAL_INC_COST_TYPE_C,
            IncreaseCostType.D => Mathf.Max(level - 11, 1) * Constant.TAL_INC_COST_TYPE_D,
            IncreaseCostType.E => Mathf.Max(level - 13, 1) * Constant.TAL_INC_COST_TYPE_E,
                _ => throw new System.ArgumentException("There is no costType: " + type)
        };
    }

    //public static int GetQualityLevel(this TestResult testResult)
    //{
    //    if (testResult.RemainingPoints < 0) 
    //        return 0;

    //    return (testResult.RemainingPoints - 1) / 3 + 1;
    //}

    public static int RollDice(DiceType diceType)
    {
        return UnityEngine.Random.Range(0, (int)diceType) + 1;
    }

    #region Checks
    //public static int GetAttributeMaximum(Character character, ObsoleteAttribute attribute)
    //{
    //    if (character.InBuildMode)
    //    {
    //        if (character.Attributes.array.Sum((atr) => atr.BaseValue) >= character.Experience.MaxAttributePoints) return attribute.BaseValue;
    //        return character.Experience.AttributeMax + character.Species.GetAttributeInfluence(character, attribute.Type);
    //    }

    //    return (Rules.AttributeMaximum) ? character.Experience.AttributeMax + 2 : NO_MAX;
    //}

    //public static int GetSkillMaximum(Character character, Skill skill)
    //{
    //    int skillMax = character.Attributes.GetMaxCurrentValue(skill.Attributes) + 2;

    //    if (character.InBuildMode) return Mathf.Min(character.Experience.SkillMax, skillMax);

    //    return skillMax;
    //}

    //public static int GetCombatTechnicMaximum(Character character, CombatTechnic combatTechnic)
    //{
    //    int ctMax = combatTechnic.GetLeadAttribute().BaseValue + 2;
    //    if (character.InBuildMode) return Mathf.Min(character.Experience.CombatTechnicMax, ctMax);
    //    return ctMax;
    //}

    //public static int GetHealthPointsMaximum(Character character)
    //{
    //    return character.Attributes[AttributeType.Constitution].BaseValue;
    //}

    //public static int GetArcaneEnergieMaximum(Character character)
    //{
    //    return character.Attributes[character.Mage.Tradition.LeadAttribute].BaseValue;
    //}

    //public static int GetKarmaEnergieMaximum(Character character)
    //{
    //    return character.Attributes[character.Priest.Tradition.LeadAttribute].BaseValue;
    //}
    #endregion

    #endregion
}

public static class MathUtility
{
    public static int Round(this float value)
    {
        return Mathf.RoundToInt(value);
    }

    public static int DivideByTwo(this int value)
    {
        return (value + 1) / 2;
    }

    public static int DivideBySix(this int value)
    {
        return (value + 3) / 6;
    }

    public static int DivideByThree(this int value)
    {
        return (value + 1) / 3;
    }

    public static int GetMaxBaseValue(this CharacterValueBase[] characterValues)
    {
        int max = 0; 
        for(int i = 0; i < characterValues.Length; ++i)
        {
            max = Mathf.Max(max, characterValues[i].Value.BaseValue);
        }

        return max;
    }

    public static int GetMaxCurrentValue(this CharacterValueBase[] characterValues)
    {
        int max = 0;
        for (int i = 0; i < characterValues.Length; ++i)
        {
            max = Mathf.Max(max, characterValues[i].Value.CurrentValue);
        }

        return max;
    }
}

public class Rules
{
    public static bool AttributeMaximum;
}

public class UIUtility
{
    public const string STLYE_NEGATIV_MODIFIER = "<style=\"NegativeModifier\">";
    public const string STLYE_POSITIV_MODIFIER = "<style=\"PositivModifier\">";
    public const string STLYE_POSITIV_VALUE = "<style=\"PositivValue\">";
    public const string STLYE_NEGATIV_VALUE = "<style=\"NegativeValue\">";
    public const string STYLE_BOLD = "<style=\"Bold\">";
    public const string STYLE_CLOSE = "</style>";

    public static string SetStyle(string text, string style)
    {
        return style + text + STYLE_CLOSE;
    }

    public static string SetStyleForNumber(int number, string positivStlye = STLYE_POSITIV_MODIFIER, string negativeStyle = STLYE_NEGATIV_MODIFIER, bool addSign = true, bool addBrackets = true)
    {
        if (number == 0) return (addBrackets) ? "(0)" : "0";

        string res;
        if (number < 0)
        {
            res = negativeStyle +
                ((addBrackets) ? "(" : "");
        }
        else
        {
            res = positivStlye +
                ((addBrackets) ? "(" : "") +
                ((addSign) ? "+" : "");
        }
        res += number;
        if (addBrackets) res += ")";
        res += STYLE_CLOSE;
        return res;
    }

    //public static string SetStyleForModifier(Tuple<int, Modifier> modifier, string positivStlye = STLYE_POSITIV_MODIFIER, string negativeStyle = STLYE_NEGATIV_MODIFIER, bool addSign = true, bool addBrackets = true)
    //{
    //    if (modifier.Item1 == 0) return (addBrackets) ? "(0)" : "0";

    //    string res;
    //    if (modifier.Item1 < 0)
    //    {
    //        res = negativeStyle +
    //            ((addBrackets) ? "(" : "");
    //    }
    //    else
    //    {
    //        res = positivStlye +
    //            ((addBrackets) ? "(" : "") +
    //            ((addSign) ? "+" : "");
    //    }
    //    res += modifier.Item1;
    //    if (modifier.Item2.HasAdditionalInfo) res += "*";
    //    if (addBrackets) res += ")";
    //    res += STYLE_CLOSE;
    //    return res;
    //}

    //public static string SetStyleForCurrentValue(Value value, string positivStlye = STLYE_POSITIV_VALUE, string negativeStyle = STLYE_NEGATIV_VALUE)
    //{
    //    int modification = value.GetModification();
    //    if (modification == 0) return value.CurrentValue.ToString();

    //    string res = ((modification < 0) ? negativeStyle : positivStlye) + value.CurrentValue;
    //    if (value.Modifications.AdditionalInfo) res += "*";
    //    res += STYLE_CLOSE;
    //    return res;
    //}

    public static string GetNumberWithSign(int number)
    {
        if (number >= 0) return "+" + number;
        return number.ToString();
    }
}

public class FileUtility
{
    public static string GetDirectoryPath(string filePath)
    {
        return filePath.Substring(0, filePath.LastIndexOf('/'));
    }

    public static string GetFile(string filePath, bool withoutExtension)
    {
        string file = filePath.Substring(filePath.LastIndexOf('/') + 1);
        if(withoutExtension)
        {
            file = file.Substring(0, file.LastIndexOf('.'));
        }
        return file;
    }
}
