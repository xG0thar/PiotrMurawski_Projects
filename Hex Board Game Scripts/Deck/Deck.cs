using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Deck", menuName = "Hex Scriptables/Deck", order =2)]
public class Deck : ScriptableObject
{
    public string deckTitle;

    public Tokken[] tokkens;
}
