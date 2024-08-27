using DSA.Character.Modifier;
using DSA.Character.Value.Data;

namespace DSA.Character.Value
{
    public class DodgeValue : BaseValue
    {
        public DodgeValue(Character character, BaseValueDatabase.BaseValueData data) : base(character, data)
        {
        }

        protected override Calculation.Value Init()
        {
            DodgeCalculation calculation = new DodgeCalculation(this);

            return new Calculation.Value(Type, new IBaseModifier[] { calculation });
        }
    }
}

