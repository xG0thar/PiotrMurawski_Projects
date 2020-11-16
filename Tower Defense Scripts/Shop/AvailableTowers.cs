using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TowerDefence/AvailableTowers")]
public class AvailableTowers : ScriptableObject
{
    public List<TowerStructure> towers;
}

