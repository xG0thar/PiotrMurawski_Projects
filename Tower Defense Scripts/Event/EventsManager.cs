using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventsManager
{
    public delegate void EventListener(EventInfo eventInfo);

    public static Dictionary<Event_Type, List<EventListener>> ListenersContainer;


    public static void AddListener(Event_Type eventType, EventListener eventListener)
    {
        if (ListenersContainer == null)
        {
            ListenersContainer = new Dictionary<Event_Type, List<EventListener>>();
            ListenersContainer.Add(eventType, new List<EventListener>());
        }
        if (!ListenersContainer.ContainsKey(eventType))
        {
            ListenersContainer.Add(eventType, new List<EventListener>());
        }
        ListenersContainer[eventType].Add(eventListener);
    }

    public static void RemoveListener(Event_Type eventType, EventListener eventListener)
    {
        if (ListenersContainer == null || ListenersContainer[eventType] == null)
        {
            Debug.Log("No listeners of type " + eventType + " existing. Cannot remove!");
            return;
        }
        ListenersContainer[eventType].Remove(eventListener);
    }

    public static void FireEvent(Event_Type eventType, EventInfo eventInfo)
    {
        Debug.Log(System.Reflection.MethodBase.GetCurrentMethod().Name);
        if (ListenersContainer == null || ListenersContainer[eventType] == null)
        {
            Debug.Log("Noone listening for " + eventType + " events!");
            return;
        }

        foreach (EventListener eventListener in ListenersContainer[eventType])
        {
            eventListener(eventInfo);
        }
    }
}
