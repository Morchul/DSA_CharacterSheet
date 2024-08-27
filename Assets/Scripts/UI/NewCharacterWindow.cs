using System.Linq;
using TMPro;
using UnityEngine;

public class NewCharacterWindow : MonoBehaviour
{
    [SerializeField]
    private TMP_Dropdown selectExperienceLevel;

    [SerializeField]
    private TMP_InputField nameInput;

    [SerializeField]
    private ExperienceLevel[] possibleExperienceLevels;

    [SerializeField]
    private System.Action<NewCharacterWindowReturnValue> callback;

    private void Start()
    {
        selectExperienceLevel.options.Clear();

        selectExperienceLevel.AddOptions(possibleExperienceLevels.Select((experience) => experience.name).ToList());
    }

    public void Show()
    {
        this.gameObject.SetActive(true);
    }

    public void Hide()
    {
        this.gameObject.SetActive(false);
    }

    public void SetCallback(System.Action<NewCharacterWindowReturnValue> callback)
    {
        this.callback = callback;
    }

    public void ContinueCharacterCreationButton()
    {
        NewCharacterWindowReturnValue returnValue = new NewCharacterWindowReturnValue()
        {
            ExperienceLevel = possibleExperienceLevels[selectExperienceLevel.value],
            Name = nameInput.text
        };

        callback.Invoke(returnValue);
    }

    public struct NewCharacterWindowReturnValue
    {
        public ExperienceLevel ExperienceLevel;
        public string Name;
    }
}
