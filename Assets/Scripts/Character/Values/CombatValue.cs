using DSA.Character.Modifier;
using static DSA.Character.Value.Data.CombatValueDatabase;

namespace DSA.Character.Value
{
    public class CombatValue : CharacterValueBase
    {
        public CombatValueData Data { get; }
        public CombatTechnic CombatTechnic { get; private set; }

        public override int Type => (int)Data.Type;
        public override string Name => Data.Name;

        public CombatValue(Character character, CombatValueData data) : base(character)
        {
            Data = data;

            CombatTechnic = Character.GetCombatTechnic(Data.CombatTechnic);
            
            Value = new Calculation.Value(Type, new IBaseModifier[] { data.BaseCalculationFactory.Create(this) });

            AttachLogCalculation();
        }
    }
}
