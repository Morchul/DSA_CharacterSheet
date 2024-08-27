using DSA.Character.Modifier;
using DSA.Character.Test;
using static DSA.Character.Value.Data.MainAttributeDatabase;

namespace DSA.Character.Value
{
    public class MainAttribute : CharacterValueBase
    {
        public MainAttributeData Data { get; }

        public MainAttributeIncreasable Increasable { get; private set; }
        public MainAttributeTest Testable { get; private set; }

        public override int Type => (int)Data.Type;
        public override string Name => Data.Name;

        public MainAttribute(Character character, MainAttributeData data) : base(character)
        {
            this.Data = data;

            Testable = new MainAttributeTest(this);
            Increasable = new MainAttributeIncreasable(this);

            Value = new Calculation.Value(Type, new IBaseModifier[] { Increasable });

            AttachLogCalculation();
        }
    }
}
