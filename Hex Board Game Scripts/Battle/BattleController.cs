using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController
{
    private Hex[][] board;
    private BattleHasteController _battleHasteController;
    private BoardController boardController;

    public BattleController(Hex[][] boardHex, BoardController controller)
    {
        board = boardHex;
        boardController = controller;
        _battleHasteController = new BattleHasteController(board);
    }
    public void HandleBattle()
    {
        for (int i = 4; i >= 0; i--)
        {
            List<Tokken> tokkensToAttack = _battleHasteController.FindsTokkensWithHaste(i);
            foreach(Tokken item in tokkensToAttack)
            {
                item.GetTokkenAction().TriggerBattleActions(boardController);
                Debug.Log("Battle!");
            }
        }
    }
}