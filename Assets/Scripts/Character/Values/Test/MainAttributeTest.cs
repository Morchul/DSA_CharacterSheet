using DSA.Character.Value;

namespace DSA.Character.Test
{
    public class MainAttributeTest : TestBase<MainAttribute>
    {
        public MainAttributeTest(MainAttribute targetValue) : base(targetValue)
        {
        }

        public MainAttributeTestResult Test()
        {
            TestCalculationPipeline pipeline = this.GetPipeline();
            int modifikation = pipeline.CalculateModification();
            return new MainAttributeTestResult(Utility.RollDice(DiceType.D20) <= targetValue.Value.CurrentValue + modifikation);
        }
    }
}
