using UnityEngine;
using UnityEngine.Localization;

namespace DSA.Character.Advantage
{
    public abstract class LevelAdvantage : BaseAdvantage
    {
        [SerializeField]
        private LocalizedString Name;

        [SerializeField]
        private LocalizedString[] descriptions;

        [SerializeField]
        [Range(2, 5)]
        private int maxLevel;

        private IAdvantage[] advantages;

        public IAdvantage GetAdvantage(int level)
        {
            if (level > maxLevel || level < 1)
            {
                throw new System.ArgumentException($"The advantage {Type} does not exist for level: {level}");
            }

            //First call
            if (advantages == null)
            {
                advantages = new IAdvantage[maxLevel];

                for(int i = 1; i <= maxLevel; ++i)
                {
                    advantages[i - 1] = CreateAdvantage(i);
                }
            }

            return advantages[level - 1];
        }

        protected IAdvantage CreateAdvantage(int level)
        {
            //TODO adjust LANGUAGE CHANGE CAN ONLY HAPPEN AT RESTART!!!
            string finalName = Name + " ";
            for (int i = 0; i < level; ++i)
            {
                finalName += "I";
            }

            return CreateAdvantageIntern(Name, descriptions[level - 1], level);
        }

        protected abstract IAdvantage CreateAdvantageIntern(LocalizedString name, LocalizedString description, int level);
    }
}

