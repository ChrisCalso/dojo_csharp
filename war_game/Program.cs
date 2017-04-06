using System;
using System.Collections.Generic;
using System.Linq;

namespace War
{
    public class Program
    {
        public static void Battle(Player player1, Player player2)
        {
            System.Console.WriteLine();
            System.Console.WriteLine();
            System.Console.WriteLine("*-*-*-*-*-*-*-* Entering a Battle! -*-*-*-*-*-*-*-*-*-");
            System.Console.WriteLine();
            List<Card> pile = new List<Card>();
            List<Card> war_cards_plyer1 = new List<Card>();
            List<Card> war_cards_plyer2 = new List<Card>();
            war_cards_plyer1.Add(player1.DealHand(player1.player_hand));
            war_cards_plyer1.Add(player1.DealHand(player1.player_hand));
            war_cards_plyer1.Add(player1.DealHand(player1.player_hand));
            war_cards_plyer2.Add(player2.DealHand(player2.player_hand));
            war_cards_plyer2.Add(player2.DealHand(player2.player_hand));
            war_cards_plyer2.Add(player2.DealHand(player2.player_hand));
            System.Console.WriteLine(player1.player_name + " has a " + war_cards_plyer1[2].card_val + " as the third card");
            System.Console.WriteLine(player2.player_name + " has a " + war_cards_plyer2[2].card_val + " as the third card");
            if (war_cards_plyer1[2].card_val > war_cards_plyer2[2].card_val)
            {
                System.Console.WriteLine(player1.player_name + " won the battle!");
                for (int i = 0; i < war_cards_plyer1.Count; i++)
                {
                    pile.Add(war_cards_plyer1[i]);
                }
                for (int k = 0; k < war_cards_plyer2.Count; k++)
                {
                    pile.Add(war_cards_plyer1[k]);
                }
                for (int j = 0; j < pile.Count; j++)
                {
                    player1.player_hand.Add(pile[j]);
                }

                war_cards_plyer1.Clear();
                war_cards_plyer2.Clear();
                pile.Clear();
                
            }

            else if (war_cards_plyer2[2].card_val > war_cards_plyer1[2].card_val)
            {
                System.Console.WriteLine(player2.player_name + " won the battle!");
                for (int i = 0; i < war_cards_plyer1.Count; i++)
                {
                    pile.Add(war_cards_plyer1[i]);
                }
                for (int k = 0; k < war_cards_plyer2.Count; k++)
                {
                    pile.Add(war_cards_plyer2[k]);
                }
                for (int j = 0; j < pile.Count; j++)
                {
                    player2.player_hand.Add(pile[j]);
                }

                war_cards_plyer1.Clear();
                war_cards_plyer2.Clear();
                pile.Clear();
                
            }

            else
            {
                war_cards_plyer1.Clear();
                war_cards_plyer2.Clear();
                Battle(player1, player2);

            }
        }
        public static void Main(string[] args)
        {
            bool gameOn = true;
            while (gameOn == true)
            {
                System.Console.WriteLine("********************************************");
                System.Console.WriteLine(" ");
                System.Console.WriteLine("            WELCOME TO WAR!                 ");
                System.Console.WriteLine(" ");
                System.Console.WriteLine("********************************************");
                System.Console.WriteLine(" ");
                System.Console.WriteLine("        What Would You Like To Do?           ");
                System.Console.WriteLine(" ");
                System.Console.WriteLine(" 1 - Start Game");
                System.Console.WriteLine(" 2 - Quit Game");
                System.Console.WriteLine(" ");
                string input = Console.ReadLine();
                // string input = "1";
                switch (input)
                {
                    case "1":
                        System.Console.WriteLine("Alright! Let's start a game...");
                        System.Console.WriteLine();
                        Deck mydeck = new Deck();
                        System.Console.WriteLine("Enter player 1's name: ");
                        string name1 = Console.ReadLine();
                        // string name1 = "Michelle";
                        Player player1 = new Player(name1);
                        // System.Console.WriteLine(player1.player1_name);
                        System.Console.WriteLine();
                        System.Console.WriteLine("Enter player 2's name: ");                        
                        string name2 = Console.ReadLine();
                        // string name2 = "Brenna";
                        Player player2 = new Player(name2);
                        player1.Buildhands(mydeck);
                        player2.Buildhands(mydeck);

                        Card compare1;
                        Card compare2;
                        List<Card> pile2 = new List<Card>();
                        // System.Console.WriteLine("player 1 hand count: " + player1.player_hand.Count);
                        // System.Console.WriteLine("player 2 hand count: " + player2.player_hand.Count);
                        while (player1.player_hand.Count >= 4 && player2.player_hand.Count >= 4)
                        {
                            compare1 = player1.DealHand(player1.player_hand);
                            System.Console.WriteLine();
                            System.Console.WriteLine(player1.player_name + " drew: " + compare1.card_val);
                            compare2 = player2.DealHand(player2.player_hand);
                            System.Console.WriteLine(player2.player_name + " drew: " + compare2.card_val);
                            pile2.Add(compare1);
                            pile2.Add(compare2);

                            if (compare1.card_val == compare2.card_val)
                            {
                                Battle(player1, player2);
                                if (player1.player_hand.Count > player2.player_hand.Count)
                                {
                                    // System.Console.WriteLine("PLayer 1 hand count: " + player1.player_hand.Count);
                                    // System.Console.WriteLine("PLayer 2 hand count: " + player2.player_hand.Count);
                                    for (int i = 0; i < pile2.Count; i++)
                                    {
                                        player1.player_hand.Add(pile2[i]);
                                    }
                                    pile2.Clear();
                                    System.Console.WriteLine();
                                    System.Console.WriteLine("*-*-*-*-*-*-*-* Exiting a Battle! -*-*-*-*-*-*-*-*-*-");

                                }

                                else if (player2.player_hand.Count > player1.player_hand.Count)
                                {
                                    for (int j = 0; j < pile2.Count; j++)
                                    {
                                        player2.player_hand.Add(pile2[j]);
                                    }
                                    pile2.Clear();
                                    System.Console.WriteLine();
                                    System.Console.WriteLine("*-*-*-*-*-*-*-* Exiting a Battle! -*-*-*-*-*-*-*-*-*-");
                                    
                                }
                            }

                            else
                            {
                                continue;
                            }
                        }
                        if (player1.player_hand.Count > player2.player_hand.Count)
                        {
                            System.Console.WriteLine();
                            System.Console.WriteLine();
                            System.Console.WriteLine("*************************************************");
                            System.Console.WriteLine();
                            System.Console.WriteLine("          " + player1.player_name + " won the game!      ");
                            System.Console.WriteLine("          Score was: " + player1.player_hand.Count + " cards vs. " + player2.player_hand.Count + " cards");
                            System.Console.WriteLine();
                            System.Console.WriteLine("*************************************************");
                        }

                        else if (player2.player_hand.Count > player1.player_hand.Count)
                        {
                            System.Console.WriteLine();
                            System.Console.WriteLine();
                            System.Console.WriteLine("*************************************************");
                            System.Console.WriteLine();
                            System.Console.WriteLine("           "+ player2.player_name + " won the game!      ");
                            System.Console.WriteLine("           Score was: " + player2.player_hand.Count + " cards vs. " + player1.player_hand.Count + " cards");
                            System.Console.WriteLine();
                            System.Console.WriteLine("*************************************************");
                        }

                        else
                        {
                            System.Console.WriteLine();
                            System.Console.WriteLine();
                            System.Console.WriteLine("*************************************************");
                            System.Console.WriteLine();
                            System.Console.WriteLine("           There was a tie!                   ");
                            System.Console.WriteLine("           Score was: " + player2.player_hand.Count + " vs. " + player1.player_hand.Count);
                            System.Console.WriteLine();
                            System.Console.WriteLine("*************************************************");
                        }
                        System.Console.WriteLine();
                        System.Console.WriteLine("Play again? [y/n]");
                        string gameend = Console.ReadLine();
                        // string gameend = "y";
                        if (gameend == "y")
                        {
                            gameOn = true;
                        }
                        else
                        {
                            System.Console.WriteLine("Okay, bye...");
                            gameOn = false;
                        }
                        break;
                    case "2":
                        System.Console.WriteLine("Okay, bye...");
                        gameOn = false;
                        break;
                    default:
                        System.Console.WriteLine("Sorry didn't recognize that");
                        break;
                }
            }
        }
    }
}
