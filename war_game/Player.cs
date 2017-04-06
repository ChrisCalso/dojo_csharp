using System;
using System.Collections.Generic;
using System.Linq;

namespace War
{
    public class Player
    {
        public string player_name {get; set;}
        public List<Card> player_hand {get; set;}

        public Player(string name1)
        {
        player_name = name1;
        player_hand = new List<Card>();
        }

        public void Buildhands(Deck dealdeck){
            dealdeck.Shuffle();
            Card newcard;
            for(int i = 0; i < 26; i++)
            {
                newcard = dealdeck.Deal();
                player_hand.Add(newcard);
            }
        }

        public Card DealHand(List<Card> hand)
        {
            hand = player_hand;
            Card card = hand.First();
            hand.RemoveAt(0);
            return card;
        }
    }
}