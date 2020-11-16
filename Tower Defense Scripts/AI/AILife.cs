using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class AILife : MonoBehaviour, IKillable
{
    [SerializeField]
    private float startingHealth;
    private float health;
    [SerializeField]
    private int value = 35;
    private float livesToLost = 1;
    //private PlayerStats playerStats;
    public event Action OnDamaged;
    public event Action OnDeath;

    private void Awake()
    {
        health = startingHealth;
    }

    public void Damage(float amount)
    {
        health -= amount;
        if (health <= 0)
            Die();
    }

    private void Die()
    {
        if (OnDeath != null)
            OnDeath();
        UnitDeathEventInfo udei = new UnitDeathEventInfo(this.gameObject, value);
        EventsManager.FireEvent(Event_Type.unit_death_Event, udei);
        Destroy(gameObject);
    }

    //public void InjectStats(PlayerStats _playerStats)
    //{
    //    playerStats = _playerStats;
    //}
}
