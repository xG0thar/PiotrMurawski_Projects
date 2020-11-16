using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
public class Upgrader : MonoBehaviour
{
    [SerializeField]
    private TowerBlueprint higherTowerBlueprint;
    private int upgradeCost;
    private GameObject nextLevelPrefab;
    private PlayerStats playerStats;
    public Transform buildingAnchor;

    private void OnEnable()
    {
        //buildingAnchor = GetComponentInParent<Transform>();
        playerStats = GameObject.FindObjectOfType<PlayerInfo>().GetPlayerStats();
        higherTowerBlueprint = GetComponent<Tower>().higherLevelBlueprint;

        nextLevelPrefab = higherTowerBlueprint.towerPrefab;
        upgradeCost = higherTowerBlueprint.towerCost;
    }

    public void Upgrade()
    {
        if (CheckIfCanUpgrade())
        {
            var tower = Instantiate(nextLevelPrefab, buildingAnchor);
            tower.transform.SetParent(buildingAnchor);
            playerStats.Money -= upgradeCost;
            Destroy(gameObject);
        }
    } 
    public bool CheckIfCanUpgrade()
    {
        return (upgradeCost <= playerStats.Money && higherTowerBlueprint != null);
    }
}
*/