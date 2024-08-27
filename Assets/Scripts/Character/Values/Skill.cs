using DSA.Character.Modifier;
using static DSA.Character.Value.Data.SkillDatabase;

namespace DSA.Character.Value
{
    public class Skill : CharacterValueBase
    {
        public SkillData Data { get; }
        public MainAttribute[] BaseAttributes { get; private set; }
        public SkillIncreasable Increasable { get; private set; }

        public override int Type => (int)Data.Type;
        public override string Name => Data.Name;

        public Skill(Character character, SkillData data) : base(character)
        {
            this.Data = data;

            BaseAttributes = Character.GetAttributes(Data.BaseAttributeTypes);

            Increasable = new SkillIncreasable(this);

            Value = new Calculation.Value(Type, new IBaseModifier[] { Increasable });

            AttachLogCalculation();
        }
    }
}

