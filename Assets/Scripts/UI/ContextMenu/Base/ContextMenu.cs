using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ContextMenu : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler
{
    private ContextMenuItem[] menuItems;
    private ContextMenu[] subMenus;

    private ContextMenu parent;

    public bool Active { get; private set; }

    public string Name { get; private set; }

    private void Awake()
    {
        List<ContextMenuItem> menuItems = new List<ContextMenuItem>();
        List<ContextMenu> subMenus = new List<ContextMenu>();
        for(int i = 0; i < transform.childCount; ++i)
        {
            if (transform.GetChild(i).TryGetComponent(out ContextMenuItem menuItem))
            {
                menuItems.Add(menuItem);
                menuItem.Init(this);
            }
            if (transform.GetChild(i).TryGetComponent(out ContextMenu subMenu))
            {
                subMenus.Add(subMenu);
                subMenu.Init(this);
            }
        }

        this.menuItems = menuItems.ToArray();
        this.subMenus = subMenus.ToArray();
    }

    protected void CloseRecursive()
    {
        foreach (ContextMenu subMenu in subMenus)
        {
            subMenu.CloseRecursive();
        }
        Close();
    }

    public void Init(ContextMenu parent)
    {
        this.parent = parent;
    }

    //public virtual void Show(Vector2 pos)
    //{
    //    transform.position = pos;
    //    gameObject.SetActive(true);

    //    for(int i= 0; i < menuItems.Length; ++i)
    //    {
    //        menuItems[i].Show();
    //    }
    //}

    public virtual void Show()
    {
        gameObject.SetActive(true);

        for (int i = 0; i < menuItems.Length; ++i)
        {
            menuItems[i].Show();
        }
    }

    public virtual void Close()
    {
        if (!Active)
        {
            gameObject.SetActive(false);
            if (parent != null)
                parent.Close();
        }
    }

    public virtual void ForceClose()
    {
        Active = false;
        Close();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        StartCoroutine(DelayedPointerExit());
    }

    public IEnumerator DelayedPointerExit()
    {
        yield return new WaitForEndOfFrame();

        Active = false;
        foreach (ContextMenu menu in subMenus)
        {
            if (menu.Active)
            {
                Active = true;
                break;
            }
        }

        Close();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Active = true;
    }
}
