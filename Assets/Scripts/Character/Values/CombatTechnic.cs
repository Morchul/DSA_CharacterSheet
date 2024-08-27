using DSA.Character.Modifier;
using static DSA.Character.Value.Data.CombatTechnicDatabase;

namespace DSA.Character.Value
{
    public class CombatTechnic : CharacterValueBase
    {
        public CombatTechnicData Data { get; }
        public MainAttribute[] PrimaryAttributes { get; private set; }
        public CombatTechnicIncreasable Increasable { get; private set; }

        public override int Type => (int)Data.Type;
        public override string Name => Data.Name;

        public CombatTechnic(Character character, CombatTechnicData data) : base(character)
        {
            Data = data;

            PrimaryAttributes = Character.GetAttributes(Data.PrimaryAttributesTypes);

            Increasable = new CombatTechnicIncreasable(this);

            Value = new Calculation.Value(Type, new IBaseModifier[] { Increasable });

            AttachLogCalculation();
        }
    }
}

