public class ValueBinding<T> : IValueBinding
{
    private readonly IObservableValue<T> value1;
    private readonly IObservableValue<T> value2;

    private bool sync;

    public ValueBinding(IObservableValue<T> value1, IObservableValue<T> value2)
    {
        sync = false;
        this.value1 = value1;
        this.value2 = value2;
    }

    public void Bind()
    {
        value1.Subscribe(SyncValue2);
        value2.Subscribe(SyncValue1);
    }

    public void Unbind()
    {
        value1.Unsubscribe(SyncValue2);
        value2.Unsubscribe(SyncValue1);
    }

    private void SyncValue2(T newValue)
    {
        if (sync)
            return;

        sync = true;
        value2.Value = newValue;
        sync = false;
    }

    private void SyncValue1(T newValue)
    {
        if (sync)
            return;

        sync = true;
        value1.Value = newValue;
        sync = false;
    }
}
