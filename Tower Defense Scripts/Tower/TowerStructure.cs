using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName ="TowerDefence/TowerStructure")]
public class TowerStructure : ScriptableObject
{
    [SerializeField]
    public TowerBlueprint[] towerBlueprints; 
}
[System.Serializable]
public struct TowerBlueprint
{
    public int stageIndex; //Basic tower stage = 0
    public GameObject towerPrefab;
    public Sprite towerIcon;
    public int towerCost;
}
[System.Serializable]
public struct TowerAbility
{
    //zaplanować umiejętności wieży
}