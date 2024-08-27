using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class ContextMenuBranch : ContextMenuItem, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private ContextMenu subMenu;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Select();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        StartCoroutine(DelayedPointerExit());
    }

    public IEnumerator DelayedPointerExit()
    {
        yield return new WaitForEndOfFrame();
        subMenu.Close();
    }

    public virtual void Init(ContextMenu parent, ContextMenu contextMenu)
    {
        Init(parent);
        subMenu = contextMenu;
    }

    public override void Select()
    {
        subMenu.Show();
    }
}
