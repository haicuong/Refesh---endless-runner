using System;

public static class EventExtensions
{
    public static void SafeRegister<T>(Action<T> action, Action<T> method)
    {
        if (action != null && method != null) action += method;
    }
    public static void SafeRegister(Action action, Action method)
    {
        if (action != null && method != null) action += method;
    }
}
