using static DSA.Character.Value.Data.BaseValueDatabase;

namespace DSA.Character.Value
{
    public abstract class BaseValue : CharacterValueBase
    {
        public BaseValueData Data { get; }

        public override int Type => (int)Data.Type;
        public override string Name => Data.Name;

        public BaseValue(Character character, BaseValueData data) : base(character)
        {
            Data = data;

            Value = Init();

            AttachLogCalculation();
        }

        protected abstract Calculation.Value Init();
    }
}

