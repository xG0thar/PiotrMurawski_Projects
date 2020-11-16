using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelResourceManager : MonoBehaviour
{
    private AvailableTowers _availableTowers;
    private int _currentGold;
    private int _currentHearts;
    private GoldDisplay _goldDisplay;
    private HeartDisplay _heartDisplay;
    [SerializeField] private InitialLevelData _initialLevelData;
    [SerializeField] private Text goldText;
    [SerializeField] private Text heartText;

    public int CurrentGold
    {
        get => _currentGold;
        set
        {
            _currentGold = value;
            _goldDisplay.UpdateDisplay(_currentGold);
        }
    }

    public int CurrentHearts {
        get => _currentHearts;
        set
        {
            _currentHearts = value;
            _heartDisplay.UpdateDisplay(_currentHearts);
        }
    }

    private void Awake()
    {
        _goldDisplay = new GoldDisplay(goldText);
        _heartDisplay = new HeartDisplay(heartText);
        InitializeData();

        EventsManager.AddListener(Event_Type.base_reached_Event, EnemyUnitAtBase);
        EventsManager.AddListener(Event_Type.unit_death_Event, EnemyKilled);
    }


    private void InitializeData()
    {
        _availableTowers = _initialLevelData.AvailableTowers;
        this.CurrentGold = _initialLevelData.CurrentGold;
        this.CurrentHearts = _initialLevelData.CurrentHearts;
    }

    public AvailableTowers GetAvailableTowers()
    {
        return _availableTowers;
    }

    public bool TryToBuy(int price)
    {
        if(CurrentGold > price)
        {
            CurrentGold -= price;
            return true;
        }
        else
        {
            return false;
        }
    }

    private void EnemyUnitAtBase(EventInfo brei)
    {
        BaseReachedEventInfo _brei = (BaseReachedEventInfo)brei;
        CurrentHearts -= _brei._heartsToLose;
    } 

    private void EnemyKilled(EventInfo eventInfo)
    {
        UnitDeathEventInfo udei = (UnitDeathEventInfo)eventInfo;
        CurrentGold += udei._value;
    }
}

public class HeartDisplay
{
    [SerializeField] private Text heartTextDisplay;

    public HeartDisplay(Text textDisplay)
    {
        heartTextDisplay = textDisplay;
    }

    public void UpdateDisplay(int currentAmount)
    {
        heartTextDisplay.text = currentAmount.ToString();
    }
}

public class GoldDisplay
{
    [SerializeField] private Text goldTextDisplay;

    public GoldDisplay(Text textDisplay)
    {
        this.goldTextDisplay = textDisplay;
    }

    public void UpdateDisplay(int currentAmount)
    {
        goldTextDisplay.text = currentAmount.ToString();
    }
}
