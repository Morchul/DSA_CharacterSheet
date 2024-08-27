using DSA.Character.Value;
using UnityEngine;

public class WindowManager : MonoBehaviour
{
    [SerializeField]
    private GameObject windowCloseBackground;

    [Header("Windows")]
    [SerializeField]
    private CharacterValueWindow characterValueWindow;

    private bool windowActive;

    private static WindowManager instance;
    public static WindowManager Instance => instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void ShowCharacterValueWindow(CharacterValueBase characterValue)
    {
        characterValueWindow.SetCharacterValue(characterValue);

        if (!windowActive)
        {
            windowCloseBackground.SetActive(true);
            windowActive = true;
            characterValueWindow.Show();
        }
    }

    public void CloseWindow()
    {
        characterValueWindow.Hide();
        windowCloseBackground.SetActive(false);
        windowActive = false;
    }
}
