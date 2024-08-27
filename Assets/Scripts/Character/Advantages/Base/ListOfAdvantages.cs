using UnityEngine;

namespace DSA.Character.Advantage
{
    [CreateAssetMenu(fileName = "Advantages List", menuName = "Advantages/List")]
    public class ListOfAdvantages : ScriptableObject
    {
        [SerializeField]
        private SimpleAdvantage[] simpleAdvantages;

        [SerializeField]
        private LevelAdvantage[] levelAdvantages;

        [SerializeField]
        private SelectAdvantage[] selectAdvantages;

        public SimpleAdvantage GetSimpleAdvantage(AdvantageType type)
        {
            if (type.HasLevelAddition() || type.HasSelectAddition())
            {
                throw new System.ArgumentException($"Try to get a SimpleAdvantage which has at least one addition. [{type}]");
            }

            for (int i = 0; i < simpleAdvantages.Length; ++i)
            {
                if (simpleAdvantages[i].Type == type)
                    return simpleAdvantages[i];
            }

            return null;
        }

        public LevelAdvantage GetLevelAdvantage(AdvantageType type)
        {
            if (!type.HasLevelAddition() || type.HasSelectAddition())
            {
                throw new System.ArgumentException($"Try to get a LevelAdvantage which does not only have the Level Addition. [{type}]");
            }

            for (int i = 0; i < levelAdvantages.Length; ++i)
            {
                if (levelAdvantages[i].Type == type)
                    return levelAdvantages[i];
            }

            return null;
        }

        public SelectAdvantage GetSelectAdvantage(AdvantageType type)
        {
            if (!type.HasSelectAddition() || type.HasLevelAddition())
            {
                throw new System.ArgumentException($"Try to get a SelectAdvantage which does not only have the Select Addition. [{type}]");
            }

            for (int i = 0; i < selectAdvantages.Length; ++i)
            {
                if (selectAdvantages[i].Type == type)
                    return selectAdvantages[i];
            }

            return null;
        }
    }
}
