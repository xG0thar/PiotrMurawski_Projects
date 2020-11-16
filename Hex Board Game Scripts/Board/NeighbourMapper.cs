using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeighbourMapper
{
    public Vector2[] neighboursCoords;
    public Vector2[] ReturnNeighboursCoords(int rowNumber, int centerRow, bool isOddBoard)
    {
        neighboursCoords = new Vector2[6];
        if (isOddBoard)
        {
            if (rowNumber < centerRow)
            {
                neighboursCoords[0] = new Vector2(-1, 0);
                neighboursCoords[5] = new Vector2(-1, -1);

                neighboursCoords[1] = new Vector2(0, 1);
                neighboursCoords[4] = new Vector2(0, -1);

                neighboursCoords[2] = new Vector2(1, 1);
                neighboursCoords[3] = new Vector2(1, 0);



                return neighboursCoords;
            }
            else if (rowNumber == centerRow)
            {
                neighboursCoords[0] = new Vector2(-1, 0);
                neighboursCoords[5] = new Vector2(-1, -1);

                neighboursCoords[1] = new Vector2(0, 1);
                neighboursCoords[4] = new Vector2(0, -1);

                neighboursCoords[2] = new Vector2(1, 0);
                neighboursCoords[3] = new Vector2(1, -1);

                return neighboursCoords;
            }
            else if (rowNumber > centerRow)
            {
                neighboursCoords[0] = new Vector2(-1, 1);
                neighboursCoords[5] = new Vector2(-1, 0);

                neighboursCoords[1] = new Vector2(0, 1);
                neighboursCoords[4] = new Vector2(0, -1);

                neighboursCoords[2] = new Vector2(1, 0);
                neighboursCoords[3] = new Vector2(1, -1);

                return neighboursCoords;
            }
            else
            {
                Debug.LogError("Neighbours mapping error!");
                return null;
            }
        }
        else
        {
            Debug.LogError("Can't handle even board");
            return null;
        }

    }
}
