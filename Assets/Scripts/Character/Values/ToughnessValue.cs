using DSA.Character.Modifier;
using DSA.Character.Value.Data;

namespace DSA.Character.Value
{
    public class ToughnessValue : BaseValue
    {
        public ToughnessValue(Character character, BaseValueDatabase.BaseValueData data) : base(character, data)
        {
        }

        protected override Calculation.Value Init()
        {
            ToughnessCalculation calculation = new ToughnessCalculation(this);

            return new Calculation.Value(Type, new IBaseModifier[] { calculation });
        }
    }
}