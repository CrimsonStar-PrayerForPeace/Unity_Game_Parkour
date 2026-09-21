using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventBus<TEvent> where TEvent : IEvent
{
    private static readonly List<Action<TEvent>> _events;

    public static void Subscribe(Action<TEvent> callback)
    {
        _events.Add(callback);
    }
    public static void UnSubscribe(Action<TEvent> callback)
    {
        _events.Remove(callback);
    }
    public static void Trigger(TEvent data)
    {
        for(int i = _events.Count - 1; i >= 0; i--)
        {
            _events[i]?.Invoke(data);
        }
    }
}
