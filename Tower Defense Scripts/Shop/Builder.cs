using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Builder : MonoBehaviour
{
    private LevelResourceManager levelResourceManager;
    private BuildingPlace _buildingPlace;
    private Transform _buildingPosition;
    private List<TowerStructure> _towers;
    //private PlayerStats _playerStats;
    private TowerBlueprint towerToBuild;
    private int defaultStage;

    private void Awake()
    {
        _buildingPlace = GetComponentInChildren<BuildingPlace>();
        _buildingPosition = _buildingPlace.ReturnBuildingPosition();
        //_playerStats = FindObjectOfType<PlayerInfo>().GetPlayerStats();
        defaultStage = 0;
    }

    private void Start()
    {
        _towers = FindObjectOfType<LevelResourceManager>().GetAvailableTowers().towers;
        
    }

    private void Build(TowerBlueprint towerToBuild)
    {
        Instantiate(towerToBuild.towerPrefab, _buildingPosition.position, Quaternion.identity, _buildingPlace.transform);
        _buildingPlace.SetOccupy(true);
    }

    public void ChooseTowerToBuild(int index)
    {
        towerToBuild = _towers[index].towerBlueprints[defaultStage];
    }

    public void PrepareToBuild()
    {
        if(TowerExist() && /*EnoughMoney() &&*/ _buildingPlace.isEmpty())
        {
            _buildingPlace.SetOccupy(true);
            Build(towerToBuild);
        }
    }

    //private bool EnoughMoney()
    //{
    //    return (_playerStats.Money >= towerToBuild.towerCost);
    //}

    private bool TowerExist()
    {
        return (towerToBuild.towerPrefab != null);
    }

    public void FreeBuildingPlace()
    {
        _buildingPlace.SetOccupy(false);
    }
}
