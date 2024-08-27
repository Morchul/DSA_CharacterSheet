using DSA.Character.Modifier;
using DSA.Character.Value.Data;

namespace DSA.Character.Value
{
    public class SpiritValue : BaseValue
    {
        public SpiritValue(Character character, BaseValueDatabase.BaseValueData data) : base(character, data)
        {
        }

        protected override Calculation.Value Init()
        {
            SpiritCalculation calculation = new SpiritCalculation(this);

            return new Calculation.Value(Type, new IBaseModifier[] { calculation });
        }
    }
}