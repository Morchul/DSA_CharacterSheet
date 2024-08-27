using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class ContextMenuItem : MonoBehaviour, IPointerClickHandler
{
    public bool IsEnabled { get; set; }

    protected ContextMenu parent;

    private Image background;

    private void Awake()
    {
        background = GetComponent<Image>();
        IsEnabled = true;
    }

    public void Init(ContextMenu parent)
    {
        this.parent = parent;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (IsEnabled)
        {
            Select();
        }
    }

    public virtual void Select()
    {
        parent.ForceClose();
    }

    public void Show()
    {
        background.color = (IsEnabled) ? Color.blue : Color.grey;
    }
}
