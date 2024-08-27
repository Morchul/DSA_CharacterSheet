using DSA.Character.Modifier;
using DSA.Character.Value.Data;

namespace DSA.Character.Value
{
    public class InitiativeValue : BaseValue
    {
        public InitiativeValue(Character character, BaseValueDatabase.BaseValueData data) : base(character, data)
        {
        }

        protected override Calculation.Value Init()
        {
            InitiativeCalculation calculation = new InitiativeCalculation(this);

            return new Calculation.Value(Type, new IBaseModifier[] { calculation });
        }
    }
}