using DSA.Character.Value;

namespace DSA.Character.Modifier
{
    public interface IBaseValueBaseCalculationFactory
    {
        public IBaseModifier Create(BaseValue baseValue);
    }
}
