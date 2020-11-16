using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    /*
     * Każe załadować talię
     * podpina controller
     * zwraca controller
     */


    public DeckController GetDeckController()
    {
        DeckLoader deckLoader = new DeckLoader();
        DeckController deckController = new DeckController(deckLoader.GetPlayersDeck());

        return deckController;
    }
}
