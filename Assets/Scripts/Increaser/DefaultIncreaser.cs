using DSA.Character.Modifier;

public class DefaultIncreaser : BaseIncreaser
{
    public override IIncreaserPermissions Permissions => IIncreaserPermissions.EditPersonalData;

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
