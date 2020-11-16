using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardMapper
{
    public NeighbourMapper neighbourMapper;
    public void MapNeighbours(Hex[][] hexBoard)
    {
        neighbourMapper = new NeighbourMapper();
        for (int i = 0; i < hexBoard.Length; i++)
        {
            for(int j = 0; j < hexBoard[i].Length; j++)
            {
                Hex hex = hexBoard[i][j];
                Vector2[] neighbourTab = neighbourMapper.ReturnNeighboursCoords(hex.ReturnPositionX(), Mathf.RoundToInt(hexBoard.Length / 2), true);

                for(int k = 0; k < neighbourTab.Length; k++)
                {
                    int x = (int)neighbourTab[k].x + hex.ReturnPositionX();
                    int y = (int)neighbourTab[k].y + hex.ReturnPositionY();
                    try
                    {
                        hex.AddNeighbour(hexBoard[x][y], k);
                    }
                    catch
                    {
                        //Debug.Log("Brak sasiada");
                    }
                }
            }
        }
    }
}
