using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokkenAction
{
    private Tokken _tokken;

    private List<ActionStruct> actions;

    public TokkenAction(Tokken tokken)
    { 
        _tokken = tokken;
        actions = _tokken.action;
    }
    
    public void TriggerBattleActions(BoardController boardController)
    {
        for(int i = 0; i < actions.Count; i++)
        {
            ActionStruct action = actions[i];
            if (action.type == ActionType.melee || action.type == ActionType.ranged)
            {
                Attack(action, boardController);
            }
            
        }
    }

    public void Attack(ActionStruct action, BoardController boardController)
    {
        if (action.type == ActionType.melee)
        {
            Debug.Log($"{_tokken.posOnBoardX}, {_tokken.posOnBoardY}, {action.direction}, {_tokken.faction}");
            Tokken target = boardController.CheckForFirstTargetInLine(_tokken.posOnBoardX, _tokken.posOnBoardY, action.direction, 1, _tokken.faction);
            if (target != null)
            {
                Debug.Log($"Atakujo");
                Debug.Log($"{target.name}");
                target.GetComponent<IDamage>().TakeDamage(action.damage);

            }
            else
            {
                Debug.Log("Brak targetu");
            }
        }
        if (action.type == ActionType.ranged)
        {
            Tokken target = boardController.CheckForFirstTargetInLine(_tokken.posOnBoardX, _tokken.posOnBoardY, action.direction, 5, _tokken.faction);
            if (target != null)
                target.GetComponent<IDamage>().TakeDamage(action.damage);
        }
    }
}
