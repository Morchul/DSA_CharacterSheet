using UnityEngine.UIElements;

namespace DSA.UI.CustomControls
{
    public class EditableText : EditableCustomControl<TextField, string>
    {
        protected override string GetNewValue(string newValue)
        {
            return newValue;
        }
    }
}
