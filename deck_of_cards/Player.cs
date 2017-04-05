using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class Player
    {
        public string name;
        public List<Card> hand;

        public Player(string player_name)
        {
            name = player_name;
            hand = new List<Card>();
        }
        // draw method of which draws a card from a deck, adds it to the player's hand and returns the Card
        public Card Draw(Deck deck)
        {
            Card the_card = deck.Deal();
            hand.Add(the_card);
            return the_card;
        }
        // discard method which discards the Card at the specified index from the player's hand and returns this Card or null if the index does not exist.
        public Card Discard(int index)
        {
            index--;
            if (index >= hand.Count || index < 0)
            {
                return null;
            }

            Card the_card = hand[index];
            hand.RemoveAt(index);
            return the_card;
        }
    }
}
// Give the Player class a name property 
// Give the Player a hand property that is a List of type Card
// Give the Player a draw method of which draws a card from a deck, adds it to the player's hand and returns the Card
// Note this method will require reference to a deck object
//  Give the Player a discard method which discards the Card at the specified index from the player's hand and returns this Card or null if the index does not exist.