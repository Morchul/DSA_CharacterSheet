using DSA.Character.Modifier;
using static DSA.Character.Value.Data.PoolValueDatabase;

namespace DSA.Character.Value
{
    public class PoolValue : CharacterValueBase
    {
        public PoolValueData Data { get; }

        public override int Type => (int)Data.Type;
        public override string Name => Data.Name;

        public PoolValueIncreasable Increasable { get; private set; }

        public PoolValue(Character character, PoolValueData data) : base(character)
        {
            this.Data = data;

            Increasable = new PoolValueIncreasable(this);

            Value = new Calculation.Value(Type, new IBaseModifier[] { Increasable });
        }
    }
}

