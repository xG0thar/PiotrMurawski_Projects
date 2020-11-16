using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BoardBlueprint", menuName = "Hex Scriptables/Board", order = 1)]
public class BoardBlueprint : ScriptableObject
{
    public GameObject basicHex;
    public Vector3 startingPoint; 
    public float hexOffSet;
    public int[] board; //Parameters to create board No. rows and elements in each row
}
