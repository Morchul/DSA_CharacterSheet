public interface IObservableValue<T>
{
    public T Value { get; set; }

    public void Subscribe(System.Action<T> onValueChanged);
    public void Unsubscribe(System.Action<T> onValueChanged);
    public void UnsubscribeAll();
}
