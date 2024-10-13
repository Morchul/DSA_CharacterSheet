using UnityEngine.UIElements;

public static class ObservableExtensions
{
    public static IValueBinding BindWith<T>(this INotifyValueChanged<T> changeValue, IObservableValue<T> observable)
    {
        IValueBinding binding = new ValueBinding<T>(new ObservableINotifyValueChanged<T>(changeValue), observable);
        binding.Bind();
        return binding;
    }
}
