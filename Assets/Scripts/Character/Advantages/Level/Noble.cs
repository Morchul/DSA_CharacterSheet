using DSA.Character.Modifier;
using DSA.Character.Value;
using DSA.Character.Value.Calculation;
using System;
using UnityEngine.Localization;
using UnityEngine;

namespace DSA.Character.Advantage
{
    //The advantage exists only once
    [CreateAssetMenu(fileName = "Noble Advantage", menuName = "Advantages/Noble")]
    public class Noble : LevelAdvantage
    {
        protected override IAdvantage CreateAdvantageIntern(LocalizedString name, LocalizedString description, int level)
        {
            return new NobleAdvantage(name, description, Type, level);
        }

        //The IAdvantage instance exists one for each different version of the Advantage
        public class NobleAdvantage : IAdvantage
        {
            public int Type { get; }

            public LocalizedString Description { get; }

            public LocalizedString Name { get; }

            private readonly int level;

            public NobleAdvantage(LocalizedString name, LocalizedString description, AdvantageType type, int level)
            {
                this.Type = type.AddSpecialIdentifier(level);
                this.Name = name;
                this.Description = description;
                this.level = level;
            }

            public void Add(Character character)
            {
                Skill seduction = character.GetSkill(SkillType.Flying);

                seduction.Value.AddModifier(new NobleModifier(Type, level, Name, Description));
            }

            public bool Remove(Character character)
            {
                Skill seduction = character.GetSkill(SkillType.Flying);

                return seduction.Value.RemoveModifier(Type);
            }
        }

        //The instance which exist on each Character
        public class NobleModifier : IValueModifier
        {
            public CalculationMethod CalculationMethod => NobleBuff;

            public LocalizedString Name { get; }

            public LocalizedString Description { get; }

            public int Type { get; }

            public event Action OnValueChanged;

            private int level;

            public NobleModifier(int type, int level, LocalizedString name, LocalizedString description)
            {
                Type = type;
                this.level = level;
                this.Name = name;
                this.Description = description;
            }

            public int NobleBuff(ValueCalculationParams param)
            {
                return level;
            }
        }
    }
}