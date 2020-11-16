using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hex : MonoBehaviour
{
    [SerializeField]
    private Tokken tokken;
    private int hexPositionX; //Also row number
    private int hexPositionY;
    public bool isOccupied = false;
    private Hex[] neighbours;

    public bool IsOccupied { get => isOccupied; set => isOccupied = value; }

    public void InputPosition(int X, int Y)
    {
        hexPositionX = X;
        hexPositionY = Y;
    }

    public void AddNeighbour(Hex neighbourObject, int neighbourID)
    {
        if (neighbours == null)
        {
            neighbours = new Hex[6];
        }
        neighbours[neighbourID] = neighbourObject;
    }

    public Hex[] GetNeighbours()
    {
        return neighbours;
    }

    public Hex GetNeighbour(int direction)
    {
        return neighbours[direction];
    }

    public void InsertTokken(Tokken tokkenToInsert)
    {
        tokken = tokkenToInsert;
        isOccupied = true;

    }

    public Tokken ReturnTokken()
    {
        return tokken;
    }

    public int ReturnPositionX()
    {
        return hexPositionX;
    }

    public int ReturnPositionY()
    {
        return hexPositionY;
    }
}
