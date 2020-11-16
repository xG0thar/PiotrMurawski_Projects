using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitDeathEventInfo : EventInfo
{
    public GameObject _gameObject;
    public int _value;

    public UnitDeathEventInfo(GameObject gameObject, int unitValue)
    {
        _gameObject = gameObject;
        _value = unitValue;
    }

    public UnitDeathEventInfo(GameObject gameObject, int unitValue, string description)
    {
        _gameObject = gameObject;
        _value = unitValue;
        base.eventDescription = description;
    }
}