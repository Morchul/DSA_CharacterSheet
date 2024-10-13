using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace DSA.UI.CustomControls
{
    public abstract class EditableCustomControl<T, F> : VisualElement where T : VisualElement, INotifyValueChanged<F>, new()
    {
        protected Label label;
        protected T editField;

        private IValueBinding binding;
        private IObservableValue<F> data;

        private F originalValue;

        public EditableCustomControl()
        {
            label = new Label("-");
            editField = new T();

            this.AddToClassList(StyleClass.EDITABLE_FIELD);

            editField.AddToClassList(StyleClass.HIDE);
            editField.AddToClassList(StyleClass.EDITABLE_FIELD_TEXTFIELD);

            this.Add(label);
            this.Add(editField);
        }

        public void SetData(IObservableValue<F> data)
        {
            if (this.data != null)
            {
                binding.Unbind();
                this.data.Unsubscribe(UpdateLabel);
            }
            this.data = data;

            binding = editField.BindWith(data);
            data.Subscribe(UpdateLabel);
        }

        private void UpdateLabel(F newValue)
        {
            label.text = GetNewValue(newValue);
        }

        public void ActivateIncreaser(IIncreaser increaser)
        {
            originalValue = data.Value;

            if (increaser.IsAllowed(IIncreaserPermissions.EditPersonalData))
            {
                editField.RemoveFromClassList(StyleClass.HIDE);
            }
        }

        public void DeactivateIncreaser(bool reset)
        {
            if (reset)
            {
                data.Value = originalValue;
            }

            editField.AddToClassList(StyleClass.HIDE);
        }

        protected abstract string GetNewValue(F newValue);
    }
}