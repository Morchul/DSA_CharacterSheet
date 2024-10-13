using System;
using UnityEngine.UIElements;

public class ObservableValue<T> : IObservableValue<T>
{
    private T value;
    public T Value
    { 
        get => value;
        set
        {
            this.value = value;
            OnValueChanged?.Invoke(value);
        }
    }

    private event Action<T> OnValueChanged;

    public void Subscribe(Action<T> onValueChanged)
    {
        OnValueChanged += onValueChanged;
    }

    public void Unsubscribe(Action<T> onValueChanged)
    {
        OnValueChanged -= onValueChanged;
    }

    public void UnsubscribeAll()
    {
        OnValueChanged = null;
    }
}

public class ObservableINotifyValueChanged<T> : IObservableValue<T>
{
    public T Value { get; set; }

    private event Action<T> OnValueChanged;

    private readonly INotifyValueChanged<T> notifyValue;

    public ObservableINotifyValueChanged(INotifyValueChanged<T> notifyValue)
    {
        this.Value = notifyValue.value;
        this.notifyValue = notifyValue;
        this.notifyValue.RegisterValueChangedCallback(OnNotifyValueChanged);
    }

    ~ObservableINotifyValueChanged()
    {
        notifyValue.UnregisterValueChangedCallback(OnNotifyValueChanged);
    }

    private void OnNotifyValueChanged(ChangeEvent<T> changeEvent)
    {
        Value = changeEvent.newValue;
        OnValueChanged.Invoke(changeEvent.newValue);
    }

    public void Subscribe(Action<T> onValueChanged)
    {
        OnValueChanged += onValueChanged;
    }

    public void Unsubscribe(Action<T> onValueChanged)
    {
        OnValueChanged -= onValueChanged;
    }

    public void UnsubscribeAll()
    {
        OnValueChanged = null;
    }
}
