using DSA.Character.Effect;
using DSA.Character.Value;
using System.Collections.Generic;

namespace DSA.Character.Test
{
    public abstract class TestBase<T> where T : CharacterValueBase
    {
        protected List<IEffect>[] effects;
        protected int modifikation;

        protected T targetValue;

        public TestBase(T targetValue)
        {
            this.targetValue = targetValue;

            effects = new List<IEffect>[2];

            for (int i = 0; i < effects.Length; ++i)
            {
                effects[i] = new List<IEffect>();
            }
        }

        public void AddEffect(IEffect effect)
        {
            effects[(int)effect.Stage].Add(effect);
        }

        public bool RemoveEffect(IEffect effect)
        {
            return effects[(int)effect.Stage].Remove(effect);
        }

        public IEffect RemoveEffect(int type, TestCalculationStage stage)
        {
            return RemoveEffect(type, (int)stage);
        }

        public IEffect RemoveEffect(int type)
        {
            for (int i = 0; i < effects.Length; ++i)
            {
                IEffect effect = RemoveEffect(type, i);
                if (effect != null)
                {
                    return effect;
                }
            }
            return null;
        }

        private IEffect RemoveEffect(int type, int stage)
        {
            List<IEffect> effects = this.effects[stage];
            for(int i = 0; i < effects.Count; ++i)
            {
                IEffect effect = effects[i];

                if(effect.Type == type)
                {
                    effects.RemoveAt(i);
                    return effect;
                }
            }

            return null;
        }

        public TestCalculationPipeline GetPipeline()
        {
            return new TestCalculationPipeline(effects[0], effects[1]);
        }
    }
}

