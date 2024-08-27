using DSA.Character;
using DSA.Character.Modifier;
using DSA.Character.Value;
using UnityEngine;
using UnityEngine.EventSystems;

public class SkillDisplay : MonoBehaviour, ICharacterValueDisplay, IPointerClickHandler
{
    [Header("Settings")]
    [SerializeField]
    private SkillType type;

    [SerializeField]
    protected UIIncreaseHandler increaseHandler;

    [SerializeField]
    protected ValueDisplay valueDisplay;

    [SerializeField]
    protected TextDisplay nameDisplay;

    private Skill skill;

    public void Bind(Character character)
    {
        skill = character.GetSkill(type);

        nameDisplay.SetValue(skill.Data.Name);

        valueDisplay.SetValue(skill);

        increaseHandler.SetIncreasable(skill.Increasable);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        WindowManager.Instance.ShowCharacterValueWindow(skill);
    }
}
