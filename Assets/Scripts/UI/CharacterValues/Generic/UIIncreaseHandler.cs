using DSA.Character.Modifier;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIIncreaseHandler : MonoBehaviour
{
    [SerializeField]
    private Button increaseButton;

    [SerializeField]
    private Button decreaseButton;

    [SerializeField]
    private TMP_Text increaseCostDisplay;

    private IIncreasable increasable;
    private IIncreaser increaser;

    private void Awake()
    {
        increaseButton.onClick.AddListener(Increase);
        decreaseButton.onClick.AddListener(Decrease);
    }

    public void SetIncreasable(IIncreasable increasable)
    {
        this.increasable = increasable;
    }

    public void Increase()
    {
        if (!increaser.Increase(increasable).Successful)
        {
            Debug.Log("The increase failed!");
        }
    }

    public void Decrease()
    {
        if (!increaser.Decrease(increasable).Successful)
        {
            Debug.Log("The decrease failed!");
        }
    }

    public void EnableIncrease(IIncreaser increaser)
    {
        this.increaser = increaser;

        increaser.OnIncreaserUpdate += IncreaserUpdate;

        this.gameObject.SetActive(true);

        IncreaserUpdate();
    }

    public void DisableIncrease()
    {
        increaser.OnIncreaserUpdate -= IncreaserUpdate;

        increaser = null;

        this.gameObject.SetActive(false);
    }

    private void IncreaserUpdate()
    {
        IncreaseData data = increaser.CheckValue(increasable);

        increaseCostDisplay.text = $"({data.IncreaseCost})";
        increaseCostDisplay.color = (data.EnoughXP) ? Color.green : Color.red;

        increaseButton.gameObject.SetActive(data.CanBeIncreased);
        decreaseButton.gameObject.SetActive(data.CanBeDecreased);
    }
}
