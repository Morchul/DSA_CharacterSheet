namespace DSA.Character.Value.Calculation
{
    [System.Serializable]
    public struct ValueCalculationParams
    {
        public readonly int BaseValue;

        public ValueCalculationParams(int baseValue)
        {
            this.BaseValue = baseValue;
        }
    }

    [System.Serializable]
    public struct ValueCalculationResult
    {
        public int BaseValue;
        public int CurrentValue;
    }
}
