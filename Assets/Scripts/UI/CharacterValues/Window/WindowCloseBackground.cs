using UnityEngine;
using UnityEngine.EventSystems;

public class WindowCloseBackground : MonoBehaviour, IPointerClickHandler
{
    private WindowManager windowManager;

    private void Start()
    {
        windowManager = WindowManager.Instance;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        windowManager.CloseWindow();
    }
}
