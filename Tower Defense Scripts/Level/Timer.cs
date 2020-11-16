using System;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    [SerializeField]private Text textToDisplay;
    private bool hasGameStarted = false;
    public Action TimerUserCallback;
    private float timeToCount = 4;
    private bool callbackSent = true;
    [SerializeField] private Button skipButton;

    public float TimeToCount
    {
        get => timeToCount;
        set
        {
            timeToCount = value;
            textToDisplay.text = string.Format("{0:#0}:{1:00}",
                     Mathf.Floor(TimeToCount / 60),//minutes
                     Mathf.Floor(TimeToCount) % 60);//seconds
        }
    }

    public void AddDisplay(Text display)
    {
        textToDisplay = display;
    }

    public void startTimer(float time, Action callback) //With new callbackfunc
    {
        callbackSent = false;
        timeToCount = time;
        TimerUserCallback = callback;
    }

    public void startTimer(float time)
    {
        timeToCount = time;
        callbackSent = false;
    } //With previously added callback func

    private void CountTime()
    {
        TimeToCount -= Time.deltaTime;
    }

    private void Update()
    {
        TimeFlow();
        if(hasGameStarted)
            CanButtonBeActive();

    }

    private void TimeFlow()
    {
        if (callbackSent == false)
        {
            if (TimeToCount > 0)
                CountTime();
            else
            {
                callbackSent = true;
                TimeToCount = 0f;
                TimerUserCallback();
            }
        }
    }

    public void SkipTime()
    {
        TimeToCount = 3f;
    }

    private void CanButtonBeActive()
    {
        if (TimeToCount > 4f && Time.timeScale != 0)
            skipButton.interactable = true;
        else
            skipButton.interactable = false;
    }

    public void GameStarted()
    {
        hasGameStarted = true;
    }
}