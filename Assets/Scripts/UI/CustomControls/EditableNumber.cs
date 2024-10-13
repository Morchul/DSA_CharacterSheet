using UnityEngine.UIElements;

namespace DSA.UI.CustomControls
{
    public class EditableNumber : EditableCustomControl<IntegerField, int>
    {
        protected override string GetNewValue(int newValue)
        {
            return newValue.ToString();
        }
    }
}

