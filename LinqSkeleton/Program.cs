using System;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Collections to work with
            List<Artist> Artists = JsonToFile<Artist>.ReadJson();
            List<Group> Groups = JsonToFile<Group>.ReadJson();

            //========================================================
            //Solve all of the prompts below using various LINQ queries
            //========================================================

            //There is only one artist in this collection from Mount Vernon, what is their name and age?
            Artist mt_vernon_guy = Artists.First(arteest => arteest.Hometown == "Mount Vernon");
            System.Console.WriteLine(mt_vernon_guy.ArtistName + " " + mt_vernon_guy.Age);

            //Who is the youngest artist in our collection of artists?
            Artist young_guy = Artists.OrderBy(artist => artist.Age).First();
            System.Console.WriteLine(young_guy.ArtistName);

            //Display all artists with 'William' somewhere in their real name
            List<Artist> william_artists = Artists.Where(artist3 => artist3.RealName.Contains("William")).ToList();
            System.Console.WriteLine("Williams in Real Name:");
            for (int i = 0; i < william_artists.Count; i++)
            {
                System.Console.WriteLine(" - " + william_artists[i].RealName + " / " + william_artists[i].ArtistName);
            }

            // Display all groups with names less than 8 characters in length.
            List<Group> groups_with_names_lt_8_chars = Groups.Where(group => group.GroupName.Length < 8).ToList();
            System.Console.WriteLine("Groups with names less than 8 characters in length: ");
            for (int j = 0; j < groups_with_names_lt_8_chars.Count; j++)
            {
                System.Console.WriteLine(" - "+ groups_with_names_lt_8_chars[j].GroupName);
            }

            //Display the 3 oldest artist from Atlanta
            List<Artist> all_artists = Artists.Where(artist4 => artist4.Hometown == "Atlanta").OrderBy(artist4 => artist4.ArtistName).Reverse().Take(3).ToList();
            System.Console.WriteLine("3 Oldest Artists from Atlanta: ");
            for (int k = 0; k < all_artists.Count; k++)
            {
                System.Console.WriteLine(" - " + all_artists[k].ArtistName + " / Age: " + all_artists[k].Age);
            }
            //(Optional) Display the Group Name of all groups that have members that are not from New York City

            //(Optional) Display the artist names of all members of the group 'Wu-Tang Clan'
            List<string> wu_tang_members = Artists.Where(artist => artist.GroupId == 1).Select(artist => artist.ArtistName).ToList();
            System.Console.WriteLine("Wu-Tang Members: ");
            foreach (string name in wu_tang_members)
            {
                System.Console.WriteLine(name);
            }
        }
    }
}
