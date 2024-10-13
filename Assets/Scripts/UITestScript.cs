using DSA.UI.CharacterContainer;
using UnityEngine;
using UnityEngine.UIElements;

public class UITestScript : MonoBehaviour
{
    [SerializeField]
    private VisualTreeAsset testAsset;

    [SerializeField]
    private StyleSheet stylesheet;

    [SerializeField]
    private UICharacterContainer container;

    // Start is called before the first frame update
    void Start()
    {
        //container.Add(testAsset, stylesheet);
        //container.Add(testAsset, stylesheet);
    }
}
