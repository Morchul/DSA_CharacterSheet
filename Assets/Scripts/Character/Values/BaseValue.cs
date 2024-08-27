using DSA.Character.Modifier;
using static DSA.Character.Value.Data.BaseValueDatabase;

namespace DSA.Character.Value
{
    public class BaseValue : CharacterValueBase
    {
        public BaseValueData Data { get; }

        public override int Type => (int)Data.Type;
        public override string Name => Data.Name;

        public BaseValue(Character character, BaseValueData data) : base(character)
        {
            Data = data;

            Value = new Calculation.Value(Type, new IBaseModifier[] { data.BaseCalculationFactory.Create(this) });

            AttachLogCalculation();
        }
    }
}

