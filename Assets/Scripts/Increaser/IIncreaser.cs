using DSA.Character;
using DSA.Character.Modifier;

public interface IIncreaser
{
    public bool AllowEditOfAdvantages { get; }
    public bool AllowFinishWithWarnings { get; }

    public event System.Action OnIncreaserUpdate;

    public void Start(Character character);
    public void Apply();
    public void Reset();

    public IncreaseData CheckValue(IIncreasable increasable);

    public IncreaseResult Increase(IIncreasable increasable);
    public IncreaseResult Decrease(IIncreasable increasable);
}

public interface IIncreaserFactory
{
    public IIncreaser Create();
}

public struct IncreaseData
{
    public static IncreaseData NotIncreasable = new IncreaseData() { IsIncreasable = false, CanBeDecreased = false, CanBeIncreased = false, EnoughXP = false, IncreaseCost = 0, DecreaseRefund = 0 };

    public bool IsIncreasable;
    public bool CanBeIncreased;
    public bool CanBeDecreased;
    public bool EnoughXP;
    public int IncreaseCost;
    public int DecreaseRefund;
}

public struct IncreaseResult
{
    public bool Successful;
}
