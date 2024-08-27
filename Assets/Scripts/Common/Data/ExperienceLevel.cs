using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Experience Level", menuName = "Experience Level")]
public class ExperienceLevel : ScriptableObject
{
    public int XP;
    public int MaxAttribute;
    public int MaxSkill;
    public int MaxCombatTechnic;
    public int MaxTotalAttributePoints;
}
