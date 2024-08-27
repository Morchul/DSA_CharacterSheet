using DSA.Character;
using DSA.Character.Modifier;
using System.Collections.Generic;

public abstract class BaseIncreaser : IIncreaser
{
    protected Character character;
    protected Dictionary<IIncreasable, int> changes;

    public event System.Action OnIncreaserUpdate;
    private int startXP;

    public abstract bool AllowEditOfAdvantages { get; }
    public abstract bool AllowFinishWithWarnings { get; }

    public BaseIncreaser()
    {
        changes = new Dictionary<IIncreasable, int>();
    }

    public void Start(Character character)
    {
        Log.Verbose($"Start Increaser for {character.Name} currentXP {character.XP}");
        this.character = character;
        startXP = character.XP;
    }

    public void Apply()
    {
        character = null;
        OnIncreaserUpdate = null;
        changes.Clear();
    }

    public void Reset()
    {
        Log.Verbose($"Reset Increaser changes");

        foreach (KeyValuePair<IIncreasable, int> change in changes)
        {
            change.Key.Change(-change.Value);
        }

        character.XP = startXP;

        Apply();
    }

    public IncreaseData CheckValue(IIncreasable increasable)
    {
        return new IncreaseData()
        {
            IsIncreasable = true,
            CanBeIncreased = CanBeIncreased(increasable),
            CanBeDecreased = CanBeDecreased(increasable),
            EnoughXP = character.XP >= GetIncreaseCost(increasable),
            IncreaseCost = GetIncreaseCost(increasable),
            DecreaseRefund = GetDecreaseRefund(increasable),
        };
    }

    public IncreaseResult Decrease(IIncreasable increasable)
    {
        if (increasable.CanBeDecreased)
        {
            InternalDecrease(increasable);

            OnIncreaserUpdate?.Invoke();

            return new IncreaseResult()
            {
                Successful = true
            };
        }

        return new IncreaseResult()
        {
            Successful = false
        };
    }

    public IncreaseResult Increase(IIncreasable increasable)
    {
        if (CanBeIncreased(increasable))
        {
            InternalIncrease(increasable);

            OnIncreaserUpdate?.Invoke();

            return new IncreaseResult()
            {
                Successful = true
            };
        }

        return new IncreaseResult()
        {
            Successful = false
        };
    }

    protected virtual void InternalIncrease(IIncreasable increasable)
    {
        character.XP -= GetIncreaseCost(increasable);
        ApplyChange(increasable, 1);
    }

    protected virtual void InternalDecrease(IIncreasable increasable)
    {
        character.XP += GetDecreaseRefund(increasable);
        ApplyChange(increasable, -1);
    }

    protected void ApplyChange(IIncreasable increasable, int change)
    {
        increasable.Change(change);

        if (changes.ContainsKey(increasable))
        {
            changes[increasable] += change;
        }
        else
        {
            changes.Add(increasable, change);
        }
    }

    protected virtual bool CanBeIncreased(IIncreasable increasable) => increasable.CanBeIncreased && character.XP >= GetIncreaseCost(increasable);
    protected virtual bool CanBeDecreased(IIncreasable increasable) => increasable.CanBeDecreased;
    protected virtual int GetIncreaseCost(IIncreasable increasable) => Utility.GetIncreaseCost(increasable.IncreaseCostType, increasable.IncreaseValue + 1);
    protected virtual int GetDecreaseRefund(IIncreasable increasable) => Utility.GetIncreaseCost(increasable.IncreaseCostType, increasable.IncreaseValue);

}
