using UnityEngine.Localization;

namespace DSA.Character.Advantage
{
    public interface IAdvantage
    {
        //The id is currently only decided by the type
        //but for selec advantage the id has to be extended to include the selection
        //(this does not apply for level advantage since you can't have the same advantage at level 1 and 2 but maybe it is still necesarry to differ between those two)

        public int Type { get; }

        public LocalizedString Description { get; }
        public LocalizedString Name { get; }

        public void Add(Character character);
        public bool Remove(Character character);
    }
}

