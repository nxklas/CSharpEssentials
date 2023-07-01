namespace CSharpEssentials
{
    /// <summary>
    /// Represents the method that will handle property changed events
    /// </summary>
    /// <typeparam name="T">The datatype of the property</typeparam>
    /// <param name="sender">The source of the event</param>
    /// <param name="e">The event data of the occured property changed event</param>
    public delegate void PropertyChangedEventHandler<T>(object? sender, PropertyChangedEventArgs<T> e);
}