using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckLoader : MonoBehaviour
{
    private Deck _playersDeck;
    private GameObject _deckGameObject;
    private Transform _deckPosition;

    public Deck GetPlayersDeck()
    {
        if(_playersDeck != null)
        {
            return _playersDeck;
        }
        else
        {
            LoadDeck(_deckPosition);
            return _playersDeck;
        }
    }

    private void LoadDeck(Transform deckPosition)
    {
        //Instantiate()
    }
}
