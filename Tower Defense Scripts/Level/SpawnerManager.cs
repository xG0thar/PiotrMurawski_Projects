using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnerManager : MonoBehaviour
{
    private List<Spawner> spawners;
    private Timer timer;
    private int spawnersFinishedCount;
    private int waveIndex = 0;
    [SerializeField] private Text currentWaveDisplay;
    private int numberOfWaves;
    private float timeBetweenWaves = 10;

    private void Awake()
    {
        timer = GetComponent<Timer>();
        spawners = new List<Spawner>();
        InitializeSpawners();
        GetNumberOfWaves();
        SetWaveDisplay(0);
    }

    private void GetNumberOfWaves()
    {
        numberOfWaves = 0;

        foreach(var spawner in spawners)
        {
            if (spawner.ReturnNumberOfWaves() > numberOfWaves)
                numberOfWaves = spawner.ReturnNumberOfWaves();
        }
    }

    private void SetWaveDisplay(int waveIndex)
    {
        currentWaveDisplay.text = $"Waves {waveIndex + 1}/{numberOfWaves}";
    }

    private void InitializeSpawners()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            Spawner spawner = transform.GetChild(i).GetComponent<Spawner>();
            spawners.Add(spawner);
            spawner.InitializeSpawner(this);
        }
    }

    public void StartWaveButton()
    {
        if(waveIndex == 0)
        {
            timer.GameStarted();
            StartWave();

        }
        else
        {
            timer.SkipTime();
        }
    }

    private void StartWave()
    {
        if(waveIndex != numberOfWaves)
        {
            SetWaveDisplay(waveIndex);
            foreach (Spawner spawner in spawners)
            {
                spawner.BeginWave(waveIndex);
            }
        }
        else
        {
            Debug.Log("Koniec fal!");
        }
    }

    public void SpawnerFinished()
    {
        spawnersFinishedCount++;

        if (spawners.Count == spawnersFinishedCount)
        {
            spawnersFinishedCount = 0;
            waveIndex++;
            SetTimerForNextWave(timeBetweenWaves);
        }
    }

    private void SetTimerForNextWave(float _time)
    {
        timer.startTimer(_time, StartWave);
    }

    
}
