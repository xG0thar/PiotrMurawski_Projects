using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(fileName = "Tokken", menuName = "Hex Scriptables/Tokken", order = 0)]
public class TokkenScriptable : ScriptableObject
{
    public Sprite tokkenSprite;
    
    public Faction faction;
    public TokkenType tokkenType;

    public BoardTokkenType boardTokkenType;
    public List<ActionStruct> action;

    public int[] initiative;

    public void Do() {
    Type type = typeof(ActionStruct).MakeGenericType(typeof(ActionStruct));
    ActionStruct obj = (ActionStruct)Activator.CreateInstance(type);
    }

    //Bonus?
    //Efect - for instant tokkens
}

