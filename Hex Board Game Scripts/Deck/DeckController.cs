using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckController
{
    private Deck _deck;
    private Queue<Tokken> _deckAsQueue;

    public DeckController(Deck deck)
    {
        _deck = deck;
    }

    public void ShuffleDeck()
    {
        DeckShuffler shuffler = new DeckShuffler();
        shuffler.Shuffle(ref _deck);

        OrganizeQueue();
    }

    public Tokken FindFirstTokkenOfType(TokkenType type)
    {
        foreach(Tokken tokken in _deck.tokkens)
        {
            if (tokken.tokkenType == type)
                return tokken;
        }
        return null;
    }

    public void OrganizeQueue()
    {
        _deckAsQueue = new Queue<Tokken>();

        foreach(Tokken tokken in _deck.tokkens)
        {
            _deckAsQueue.Enqueue(tokken);
        }
    }

    public Tokken GetOneTokkenFromDeck()
    {
        if (_deckAsQueue.Count > 0)
            return _deckAsQueue.Dequeue();
        else
            return null;
    }
}
