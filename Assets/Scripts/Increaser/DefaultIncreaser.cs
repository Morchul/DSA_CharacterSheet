using DSA.Character.Modifier;

public class DefaultIncreaser : BaseIncreaser
{
    public override bool AllowEditOfAdvantages => false;
    public override bool AllowFinishWithWarnings => false;

    public DefaultIncreaser()
    {
    }

    protected override bool CanBeDecreased(IIncreasable increasable)
    {
        if (changes.TryGetValue(increasable, out int changeValue))
        {
            return changeValue > 0 && base.CanBeDecreased(increasable);
        }

        return false;
    }
}

public class DefaultIncreaserFactory : IIncreaserFactory
{
    public IIncreaser Create()
    {
        return new DefaultIncreaser();
    }
}
