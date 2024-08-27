using DSA.Character.Modifier;
using DSA.Character.Value.Data;

namespace DSA.Character.Value
{
    public class MovementValue : BaseValue
    {
        public MovementValue(Character character, BaseValueDatabase.BaseValueData data) : base(character, data)
        {
        }

        protected override Calculation.Value Init()
        {
            MovementCalculation calculation = new MovementCalculation(this);

            return new Calculation.Value(Type, new IBaseModifier[] { calculation });
        }
    }
}
