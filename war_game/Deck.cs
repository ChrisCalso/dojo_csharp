using System.Collections.Generic;
using System;
using System.Linq;
// Give the Deck class a property called "cards" which is a list of Card object. When initializing the deck make sure that it has a list of 52 unique cards as its "cards" property
// Give the Deck a deal method that selects the "top-most" card, removes it from the list of cards, and returns the Card 
// Give the Deck a reset method that resets the cards property to the contain the original 52 cards 
// Give the Deck a shuffle method that randomly reorders the deck's cards
namespace War
{
    // Give the Card class a property "stringVal" which will hold the value of the card ex. (Ace, 2, 3, 4, 5, 6, 7, 8, 9, 10, Jack, Queen, King). This "val" should be a String
    // Give the Card a property "suit" which will hold the suit of the card (Clubs, Spades, Hearts, Diamonds)
    // Give the Card a property "val" which will hold the numerical value of the card 1-13 as integers
    public class Deck
    {
        public List<Card> card_deck = new List<Card>();

        public Deck()
        {
            BuildDeck();
        }
        // Give the Deck class a property called "cards" which is a list of Card objects
        public void BuildDeck()
        {
            int[] vals = {2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14};
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < vals.Length; j++)
                {
                    card_deck.Add(new Card(vals[j]));
                }
            }
        }
        // Give the Deck a reset method that resets the cards property to the contain the original 52 cards
        public void Reset()
        {
            card_deck.Clear();
            BuildDeck();
        }
        // Give the Deck a shuffle method that randomly reorders the deck's cards
        public void Shuffle()
        {
            Random rand = new Random();
            for (int i = 0; i < card_deck.Count; i++)
            {
                int rand_idx = rand.Next(i, card_deck.Count);
                Card temp = card_deck[i];
                card_deck[i] = card_deck[rand_idx];
                card_deck[rand_idx] = temp;
            }
        }
        // Give the Deck a deal method that selects the "top-most" card, removes it from the list of cards, and returns the Card
        public Card Deal()
        {
            Card card = card_deck.First();
            card_deck.RemoveAt(0);
            return card;
        }
    }
}
