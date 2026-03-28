using System;

public interface IEvent { };

public static class EventBus<T> where T : struct, IEvent
{
    private static event Action<T> OnEvent;

    public static void Subscribe(Action<T> listener) => OnEvent += listener;
    public static void UnSubscribe(Action<T> listener) => OnEvent -= listener;

    public static void Publish(T eventData) => OnEvent?.Invoke(eventData);
}
