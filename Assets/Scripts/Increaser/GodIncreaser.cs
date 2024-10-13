using DSA.Character.Modifier;

public class GodIncreaser : BaseIncreaser
{
    private bool applyXP;

    public override IIncreaserPermissions Permissions => IIncreaserPermissions.EditAdvantages | IIncreaserPermissions.EditPersonalData | IIncreaserPermissions.FinishWithWarnings;

    public GodIncreaser(bool applyXP)
    {
        this.applyXP = applyXP;
    }

    protected override bool CanBeIncreased(IIncreasable increasable) => true;
    protected override bool CanBeDecreased(IIncreasable increasable) => increasable.IncreaseValue > 0;

    protected override void InternalIncrease(IIncreasable increasable)
    {
        if (applyXP)
        {
            base.InternalIncrease(increasable);
        }
        else
        {
            ApplyChange(increasable, 1);
        }
    }

    protected override void InternalDecrease(IIncreasable increasable)
    {
        if (applyXP)
        {
            base.InternalDecrease(increasable);
        }
        else
        {
            ApplyChange(increasable, -1);
        }
    }
}

public class GodIncreaserFactory : IIncreaserFactory
{
    private bool applyXP;

    public GodIncreaserFactory(bool applyXP)
    {
        this.applyXP = applyXP;
    }

    public IIncreaser Create()
    {
        return new GodIncreaser(applyXP);
    }
}
