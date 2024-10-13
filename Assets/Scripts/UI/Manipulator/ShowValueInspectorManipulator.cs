using DSA.Character.Value;
using DSA.UI.Window;
using UnityEngine.UIElements;

public class ShowValueInspectorManipulator : PointerManipulator
{
    private CharacterValueBase value;

    public ShowValueInspectorManipulator()
    {
        activators.Add(new ManipulatorActivationFilter { button = MouseButton.LeftMouse });
    }

    public void SetValue(CharacterValueBase value)
    {
        this.value = value;
    }

    protected override void RegisterCallbacksOnTarget()
    {
        target.RegisterCallback<PointerUpEvent>(OnPointerUp);
    }

    protected override void UnregisterCallbacksFromTarget()
    {
        target.UnregisterCallback<PointerUpEvent>(OnPointerUp);
    }

    private void OnPointerUp(PointerUpEvent evt)
    {
        if (!CanStopManipulation(evt) && value != null) 
            return;

        WindowsController.Instance.ShowValueInspectorWindow(value);

        evt.StopPropagation();
    }
}
