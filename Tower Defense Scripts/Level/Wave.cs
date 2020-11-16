using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TowerDefence/Wave")]
public class Wave : ScriptableObject
{
    //Dodac mozliwosc pustej fali!!!!!!@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
    [SerializeField]
    public EnemyStruct[] enemies;
}

[System.Serializable]
public struct EnemyStruct
{
    public GameObject enemyPrefab;
    public int amount;
    public float spawnRate;
    public float delayBeforeNextEnemy;
}
