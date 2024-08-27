using DSA.Character.Value;

namespace DSA.Character.Modifier
{
    public interface ICombatValueBaseCalculationFactory
    {
        public IBaseModifier Create(CombatValue combatValue);
    }
}