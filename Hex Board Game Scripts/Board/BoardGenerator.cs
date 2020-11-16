using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class BoardGenerator : MonoBehaviour
{
    private float hexPd; //Hex R (Longer radius)
    private float hexPk; //Hex shorter R
    private float hexA;  //Hex Side (hexPd / 2)

    private void CalculateHexNumbers(GameObject basicHex)
    {
        RectTransform hexRT = basicHex.GetComponentInChildren<RectTransform>();

        //Zmiana PD Z PK!
        /*hexPd = hexRT.rect.width;
        hexPk = hexRT.rect.height;
        hexA = hexPd / 2;*/

        // ^ Orientacja pozioma wierzchołki na lewo i na prawo!
        // V Orientacja pionowa wierzchołki na górze i na dole!
        hexPd = hexRT.rect.height;
        hexPk = hexRT.rect.width;
        hexA = hexPd / 2;

        //Debug.Log($"Hex PD: {hexPd} HEX PK {hexPk} HEX A {hexA}");

    }
    public Hex[][] GenerateBoard(BoardBlueprint blueprint)
    {
        GameObject boardParent = new GameObject();
        boardParent.name = "Board";
        CalculateHexNumbers(blueprint.basicHex);
        int[] board = blueprint.board;

        Hex[][] hexBoard = new Hex[board.Length][] ;
        Vector3 startingPos = blueprint.startingPoint;
        int halvedTable = (int)Mathf.Round(board.Length / 2);


        for (int i = 0; i < board.Length; i++)
        {
            GenerateLine(startingPos, board[i], i, hexBoard, blueprint, boardParent);
         
            if(i < halvedTable)
            {
                startingPos = new Vector3(startingPos.x - hexPk / 2 - blueprint.hexOffSet/2 , startingPos.y - ((3 * hexA) / 2) - blueprint.hexOffSet, startingPos.z);
            }
            else
            {
                startingPos = new Vector3(startingPos.x + hexPk / 2 + blueprint.hexOffSet /2, startingPos.y - ((3 * hexA) / 2) - blueprint.hexOffSet, startingPos.z);
            }
        }

        return hexBoard;
    }
    private void GenerateLine(Vector3 linePosition, int lineSize, int lineNumber, Hex[][] hexBoard, BoardBlueprint blueprint, GameObject parent)
    {
        hexBoard[lineNumber] = new Hex[lineSize]; 
        Vector3 position;
        for (int i = 0; i < lineSize; i++)
        {            
            position = new Vector3(linePosition.x + (hexPk * i) + blueprint.hexOffSet * i, linePosition.y, 0);
            blueprint.basicHex.GetComponent<Hex>();
            Hex hex = Instantiate(blueprint.basicHex, position, blueprint.basicHex.transform.rotation, parent.gameObject.transform).GetComponent<Hex>() ;
            hex.name = $"Hex X: {lineNumber} Y: {i}";
            hex.InputPosition(lineNumber, i);
            //Initialize HEX inner info about its line and element number for ex. [lineNumber][i]
            hexBoard[lineNumber][i] = hex; //Add hex to HEX board
        }
    }
}