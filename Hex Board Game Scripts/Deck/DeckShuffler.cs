using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckShuffler
{
    public void Shuffle(ref Deck deck)
    {
        System.Random random = new System.Random();
        Tokken[] _tokkens = deck.tokkens;
        for(int i = 0; i < _tokkens.Length; i++)
        {
            int j = random.Next(i, _tokkens.Length);
            Tokken temp = _tokkens[i];
            _tokkens[i] = _tokkens[j];
            _tokkens[j] = temp;
        }
        deck.tokkens = _tokkens;
    }
}
