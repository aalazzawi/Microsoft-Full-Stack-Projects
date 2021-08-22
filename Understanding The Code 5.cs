
// Declaring the usage of the resources
using System;

//Assigning the main container to this class
namespace _10_4Lab
{
    // Declaring the Class Program (Main) to be imlemented first and run the program
    class Program
    {

        // Declaring the class Main as the follow.
        // public access modifaier.
        // It can be accessed without creating the instance of the Class.
        // will not return any value
        public static void Main()

            // the class method will add an artist, add lists, run the player, run the audio book, run movie sound track.
        {
            // the adding procedure as the follow.
            // using the system new operator to creat an instance of class artist and assign it to a variable
            // using the AddToPlaylist function for the object prince stored in it's variable to add 4 items
            Artist prince = new Artist("Prince");
            prince.AddToPlaylist("Purple Rain");
            prince.AddToPlaylist("Little Red Corvette");
            prince.AddToPlaylist("Kiss");
            prince.AddToPlaylist("When Doves Cry");


            // use the new operator to instantiate the MediaPlayer class and assign it to a variable of it's type
            // using PlayMedia method of the object player with the new artist name as an argument
            MediaPlayer player = new MediaPlayer();
            player.PlayMedia(prince);

            // using new operator to instantiate AudioBook class adding some text as an argument and storing it in a variable.
            // using the variable value to play the PlayMedia method of the new object player
            AudioBook howto = new AudioBook("How to Win Friends & Influence People", "Dale Carnegie");
            player.PlayMedia(howto);


            // using the new operator to instantiate the MovieSoundTrack class and store the new object with it's name in a variable.
            // adding some text as an argument to the method SelectTrack of the new object
            // using the value of the new object starWars as an argument in  the PlayMedia method of the new Player object
            MovieSoundTrack starWars = new MovieSoundTrack("Star Wars");
            starWars.SelectTrack("Opening Credits Theme");
            player.PlayMedia(starWars);

        }
    }
}
