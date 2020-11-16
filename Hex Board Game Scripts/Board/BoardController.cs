using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardController
{
    private Hex[][] hexBoard;

    public BoardController(Hex[][] _hexBoard)
    {
        hexBoard = _hexBoard;
    }

    public Tokken CheckForFirstTargetInLine(int attackerPosX, int attackerPosY, int attackDirection, int attackDistance, Faction myFaction)
    {
        bool noTarget = true;
        Tokken target = null;
        Hex currenHex = hexBoard[attackerPosX][attackerPosY];

        Debug.Log($"HEX:{hexBoard[1][1].GetNeighbour(5).name}");

        while (noTarget)
        {
            if(currenHex.GetNeighbour(attackDirection) != null)
            {
                Hex neighbour = currenHex.GetNeighbour(attackDirection);
                Debug.Log(neighbour.name);
                currenHex = neighbour;
                if (neighbour.isOccupied) 
                {
                    if (neighbour.ReturnTokken().faction != myFaction)
                    {
                        target = neighbour.ReturnTokken();
                        noTarget = false;
                    }
                }
            }
            else
            {
                break;
            }
        }

        return target;
    }

    public List<Tokken> CheckForTargetsInLine(int attackerPosX, int attackerPosY, int attackDirection, Faction myFaction)
    {
        List<Tokken> targets = new List<Tokken>();
        Hex currenHex = hexBoard[attackerPosX][attackerPosY];

        while (currenHex.GetNeighbour(attackDirection) != null)
        {
                Hex neighbour = currenHex.GetNeighbour(attackDirection);
                currenHex = neighbour;

                if (neighbour.ReturnTokken().faction != myFaction)
                {
                    targets.Add(neighbour.ReturnTokken());    
                }
        }
        return targets;
    }

    public List<Tokken> CheckForTargetsAround(int attackerPosX, int attackerPosY, Faction myFaction)
    {
        List<Tokken> targets = new List<Tokken>();
        Hex currenHex = hexBoard[attackerPosX][attackerPosY];
        Hex[] neighbours = currenHex.GetNeighbours();

        for (int i = 0; i < neighbours.Length; i++)
        {
            Hex neighbour = neighbours[i];
            if(neighbour != null && neighbour.ReturnTokken() != null)
            {

                if (neighbour.ReturnTokken().faction != myFaction)
                {
                    
                    targets.Add(neighbours[i].ReturnTokken());
                }
            }
        }
        return targets;
    }

    public bool CheckIfFullBoard()
    {
        for(int i = 0; i < hexBoard.Length; i++)
        {
            for(int j = 0; j < hexBoard[i].Length; j++)
            {
                if (!hexBoard[i][j].IsOccupied)
                    return false;
            }
        }
        return true;
    }

}
