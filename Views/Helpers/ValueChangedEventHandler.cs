namespace Views.Helpers
{
    public delegate void ValueChangedEventHandler<T>(object sender, ValueChangedEventArgs<T> e);

    public class ValueChangedEventArgs<T> : EventArgs
    {
        public T NewValue { get; }

        public ValueChangedEventArgs(T newValue)
        {
            NewValue = newValue;
        }
    }
}
