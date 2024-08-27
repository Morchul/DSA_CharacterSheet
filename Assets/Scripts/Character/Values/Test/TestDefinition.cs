namespace DSA.Character.Test
{
    [System.Serializable]
    public enum TestCalculationStage
    {
        Default = 0,
        Post = 1,
    }

    public delegate TestCalculationStepResult TestCalculationMethod(TestCalculationParams param);
}

    
