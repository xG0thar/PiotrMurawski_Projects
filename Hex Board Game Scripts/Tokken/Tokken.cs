using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tokken : MonoBehaviour, IDamage
{
    [SerializeField]
    public TokkenScriptable _tokkenScriptable;

    public Sprite tokkenSprite;

    public Faction faction;
    public TokkenType tokkenType;
    public BoardTokkenType boardTokkenType;

    public List<ActionStruct> action;

    public bool isPlaced;
    TokkenAction _tokkenAction;
    public int[] initiative;

    public int posOnBoardX, posOnBoardY;
    private void Awake()
    {
        tokkenSprite = _tokkenScriptable.tokkenSprite;
        faction = _tokkenScriptable.faction;
        tokkenType = _tokkenScriptable.tokkenType;
        boardTokkenType = _tokkenScriptable.boardTokkenType;
        action = _tokkenScriptable.action;
        _tokkenAction = new TokkenAction(this);
    }

    public TokkenAction GetTokkenAction()
    {
        return _tokkenAction;
    }

    public void TakeDamage(int amount)
    {
        
        Destroy(this.gameObject); //TODO,Destroy only for testing purposes! CHANGE!!
    }

    public void Die()
    {
        
    }
}
