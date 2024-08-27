using DSA.Character.Advantage;
using DSA.Character.Value;
using System;
using System.Collections.Generic;
using UnityEngine;
using static DSA.Character.Value.Data.MainAttributeDatabase;
using static DSA.Character.Value.Data.SkillsDatabase;

namespace DSA.Character
{
    public class Character : MonoBehaviour
    {
        public MainAttribute[] MainAttributes { get; private set; }

        public Skill[] PhysicalSkills { get; private set; }
        public Skill[] SocialSkills { get; private set; }
        public Skill[] NatureSkills { get; private set; }
        public Skill[] KnowledgeSkills { get; private set; }
        public Skill[] CraftSkills { get; private set; }

        public CombatTechnic[] CombatTechnics { get; private set; }
        public CombatValue[] CombatValues { get; private set; }

        public PoolValue[] PoolValues { get; private set; }
        public BaseValue[] BaseValues { get; private set; }

        public List<IAdvantage> Advantages { get; private set; }

        public PersonalData PersonalData { get; private set; }

        public Race Race => PersonalData.Race;
        public string Name => PersonalData.Name;

        public int XP;

        private void Awake()
        {
            //The order in which these are called are important
            Log.Verbose("Character Awake");

            PersonalData = GetComponent<PersonalData>();

            Log.Verbose("Start Character Value Creation");

            MainAttributes = GetAttributeArray();

            PhysicalSkills = GetSkillArray(PhysicalSkillData);
            SocialSkills = GetSkillArray(SocialSkillData);
            NatureSkills = GetSkillArray(NatureSkillData);
            KnowledgeSkills = GetSkillArray(KnowledgeSkillData);
            CraftSkills = GetSkillArray(CraftSkillData);

            CombatTechnics = GetCombatTechnicArray();
            CombatValues = GetCombatValueArray();

            PoolValues = GetPoolValueArray();
            BaseValues = GetBaseValueArray();

            Log.Verbose("All Character Values Created");
        }

        public void AddAdvantage(IAdvantage advantage)
        {
            //Add check if it already exists

            advantage.Add(this);
            Advantages.Add(advantage);
        }

        public void RemoveAdvantage(IAdvantage advantage)
        {
            for (int i = 0; i < Advantages.Count; ++i)
            {
                if (Advantages[i].Type == advantage.Type)
                {
                    Advantages.RemoveAt(i);
                    break;
                }
            }
        }

        #region Fill Arrays
        private MainAttribute[] GetAttributeArray()
        {
            MainAttribute[] attributes = new MainAttribute[MainAttributesData.Length];

            for(int i = 0; i < attributes.Length; ++i)
            {
                MainAttributeData data = MainAttributesData[i];
                attributes[((int)data.Type).GetValueTypeArrayIndex()] = new MainAttribute(this, data);
            }

            return attributes;
        }

        private Skill[] GetSkillArray(SkillData[] skillData)
        {
            Skill[] skills = new Skill[skillData.Length];

            for (int i = 0; i < skills.Length; ++i)
            {
                SkillData data = skillData[i];
                skills[((int)data.Type).GetValueTypeArrayIndex()] = new Skill(this, data);
            }

            return skills;
        }

        private CombatTechnic[] GetCombatTechnicArray()
        {
            CombatTechnic[] tmpCombatTechnicSet = parentObject.GetComponentsInChildren<CombatTechnic>();
            CombatTechnic[] combatTechnicArray = new CombatTechnic[tmpCombatTechnicSet.Length];
            for (int i = 0; i < tmpCombatTechnicSet.Length; ++i)
            {
                tmpCombatTechnicSet[i].Bind(this);
                combatTechnicArray[((int)tmpCombatTechnicSet[i].Data.Type).GetValueTypeArrayIndex()] = tmpCombatTechnicSet[i];
            }
            return combatTechnicArray;
        }

        private CombatValue[] GetCombatValueArray()
        {
            CombatValue[] tmpCombatValueSet = parentObject.GetComponentsInChildren<CombatValue>();
            CombatValue[] combatValueArray = new CombatValue[tmpCombatValueSet.Length];
            for (int i = 0; i < tmpCombatValueSet.Length; ++i)
            {
                tmpCombatValueSet[i].Bind(this);
                combatValueArray[((int)tmpCombatValueSet[i].Data.Type).GetValueTypeArrayIndex()] = tmpCombatValueSet[i];
            }

            return combatValueArray;
        }

        private PoolValue[] GetPoolValueArray()
        {
            PoolValue[] tmpPoolValues = parentObject.GetComponentsInChildren<PoolValue>();
            PoolValue[] poolValueArray = new PoolValue[tmpPoolValues.Length];
            for (int i = 0; i < tmpPoolValues.Length; ++i)
            {
                tmpPoolValues[i].Bind(this);
                poolValueArray[((int)tmpPoolValues[i].Data.Type).GetValueTypeArrayIndex()] = tmpPoolValues[i];
            }

            return poolValueArray;
        }

        private BaseValue[] GetBaseValueArray()
        {
            BaseValue[] tmpBaseValues = parentObject.GetComponentsInChildren<BaseValue>();
            BaseValue[] baseValueArray = new BaseValue[tmpBaseValues.Length];
            for (int i = 0; i < tmpBaseValues.Length; ++i)
            {
                tmpBaseValues[i].Bind(this);
                baseValueArray[((int)tmpBaseValues[i].Data.Type).GetValueTypeArrayIndex()] = tmpBaseValues[i];
            }

            return baseValueArray;
        }
        #endregion

        #region Get Values
        public MainAttribute GetAttribute(MainAttributeType attributeType)
        {
            return MainAttributes[((int)attributeType).GetValueTypeArrayIndex()];
        }

        public MainAttribute[] GetAttributes(params MainAttributeType[] attributeTypes)
        {
            MainAttribute[] attributes = new MainAttribute[attributeTypes.Length];
            for (int i = 0; i < attributes.Length; ++i)
            {
                attributes[i] = GetAttribute(attributeTypes[i]);
            }
            return attributes;
        }

        public Skill GetSkill(SkillType skillType)
        {
            switch (((int)skillType).GetValueBaseType())
            {
                case ValueBaseType.PhysicalSkill: return PhysicalSkills[((int)skillType).GetValueTypeArrayIndex()];
                case ValueBaseType.SocialSkill: return SocialSkills[((int)skillType).GetValueTypeArrayIndex()];
                case ValueBaseType.NatureSkill: return NatureSkills[((int)skillType).GetValueTypeArrayIndex()];
                case ValueBaseType.KnowledgeSkill: return KnowledgeSkills[((int)skillType).GetValueTypeArrayIndex()];
                case ValueBaseType.CraftSkill: return CraftSkills[((int)skillType).GetValueTypeArrayIndex()];
                default:
                    Debug.LogError("Unable to find skill of type: " + Enum.GetName(typeof(SkillType), skillType));
                    return null;
            }
        }

        public CombatTechnic GetCombatTechnic(CombatTechnicType combatTechnicType)
        {
            return CombatTechnics[((int)combatTechnicType).GetValueTypeArrayIndex()];
        }

        public CombatValue GetCombatValue(CombatValueType combatValueType)
        {
            return CombatValues[((int)combatValueType).GetValueTypeArrayIndex()];
        }

        public PoolValue GetPoolValue(PoolValueType poolValueType)
        {
            return PoolValues[((int)poolValueType).GetValueTypeArrayIndex()];
        }

        public BaseValue GetBaseValue(BaseValueType baseValueType)
        {
            return BaseValues[((int)baseValueType).GetValueTypeArrayIndex()];
        }
        #endregion
    }
}
