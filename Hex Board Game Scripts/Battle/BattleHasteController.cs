using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleHasteController
{
    private Hex[][] board;

    public BattleHasteController(Hex[][] _board)
    {
        board = _board;
        Debug.Log("I got boarded");
    }

    public List<Tokken> FindsTokkensWithHaste(int haste)
    {
        List<Tokken> tokkensWithHaste = new List<Tokken>();
        for (int i = 0; i < board.Length; i++)
        {
            for (int j = 0; j < board[i].Length; j++)
            {
                Tokken tokken = board[i][j].ReturnTokken();
                if (tokken != null)
                    for(int k = 0; k < tokken.initiative.Length; k++)
                    {
                        if (tokken.initiative[k] == haste)
                            tokkensWithHaste.Add(tokken);
                    }
            }
        }
        return tokkensWithHaste;
    }
}
