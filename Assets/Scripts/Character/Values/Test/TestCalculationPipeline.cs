using DSA.Character.Effect;
using System.Collections.Generic;

namespace DSA.Character.Test
{
    public class TestCalculationPipeline
    {
        private TestModificationStep[] effects;
        private TestModificationStep[] postEffects;

        public TestCalculationPipeline(List<IEffect> effects, List<IEffect> postEffects)
        {
            this.effects = new TestModificationStep[effects.Count];
            this.postEffects = new TestModificationStep[postEffects.Count];

            for(int i = 0; i< effects.Count; ++i)
            {
                this.effects[i] = new TestModificationStep(effects[i]);
            }


            for (int i = 0; i < postEffects.Count; ++i)
            {
                this.postEffects[i] = new TestModificationStep(postEffects[i]);
            }
        }

        public int CalculateModification()
        {
            int modification = 0;
            TestCalculationParams param = new TestCalculationParams();

            for (int i = 0; i < effects.Length; ++i)
            {
                TestCalculationStepResult result = effects[i].effect.CalculationMethod(param);
                modification += result.Modification;
            }


            for (int i = 0; i < postEffects.Length; ++i)
            {
                TestCalculationStepResult result = postEffects[i].effect.CalculationMethod(param);
                modification += result.Modification;
            }

            return modification;
        }
    }

    public class TestModificationStep
    {
        public bool Active;

        public IEffect effect;

        public TestModificationStep(IEffect effect)
        {
            this.effect = effect;
            Active = true;
        }
    }
}

