using DSA.Character.Value;
using UnityEngine;
using UnityEngine.UIElements;

namespace DSA.UI.Window
{
    public class WindowsController : MonoBehaviour
    {
        private UIDocument uiDocument;
        private VisualElement root;

        private ValueInspectorWindow valueInspectorWindow;

        private static WindowsController instance;
        public static WindowsController Instance => instance;

        private void Awake()
        {
            if(instance == null)
            {
                instance = this;
                InitSingleton();
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        private void OnDestroy()
        {
            instance = null;
        }

        private void InitSingleton()
        {
            uiDocument = GetComponent<UIDocument>();
            root = uiDocument.rootVisualElement;

            valueInspectorWindow = new ValueInspectorWindow();
        }

        public void ShowValueInspectorWindow(CharacterValueBase value)
        {
            valueInspectorWindow.SetValue(value);
            root.Clear();
            root.Add(valueInspectorWindow);
        }
    }
}

