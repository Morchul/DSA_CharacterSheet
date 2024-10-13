using DSA.Character.Modifier;
using UnityEngine;
using UnityEngine.UIElements;

public class IncreaseContainer : VisualElement
{
    private readonly Label increaseCost;
    private readonly Button increase;
    private readonly Button decrease;

    private IIncreaser increaser;
    private IIncreasable increasable;

    public IncreaseContainer()
    {
        this.increaseCost = new Label("(99)");
        this.increase = new Button(Increase);
        this.decrease = new Button(Decrease);

        this.Add(increase);
        this.Add(increaseCost);
        this.Add(decrease);

        this.style.alignItems = new StyleEnum<Align>(Align.Center);

        this.AddToClassList("hide");
    }

    public void SetIncreasable(IIncreasable increasable)
    {
        this.increasable = increasable;
    }

    public void ActivateIncreaser(IIncreaser increaser)
    {
        this.increaser = increaser;
        increaser.OnIncreaserUpdate += IncreaserUpdate;
        this.RemoveFromClassList("hide");

        IncreaserUpdate();
    }

    public void DeactivateIncreaser()
    {
        increaser.OnIncreaserUpdate -= IncreaserUpdate;
        this.increaser = null;
        this.AddToClassList("hide");
    }

    public void Increase()
    {
        if (!increaser.Increase(increasable).Successful)
        {
            Log.Warning("The increase failed!");
        }
    }

    public void Decrease()
    {
        if (!increaser.Decrease(increasable).Successful)
        {
            Log.Warning("The decrease failed!");
        }
    }

    private void IncreaserUpdate()
    {
        IncreaseData data = increaser.CheckValue(increasable);

        increaseCost.text = $"({data.IncreaseCost})";
        increaseCost.style.backgroundColor = (data.EnoughXP) ? new StyleColor(Color.green) : new StyleColor(Color.red);

        increase.SetEnabled(data.CanBeIncreased);
        decrease.SetEnabled(data.CanBeDecreased);
    }
}
