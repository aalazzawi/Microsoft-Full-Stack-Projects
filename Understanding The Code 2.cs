
// Declaring the usage of System, System.Collections.Generic, System.Text in this program.
using System;
using System.Collections.Generic;
using System.Text;

// Seting the main container of the program with a name.
/* The program is to set up a company website to allow it to accept online applications for new contestants.
   There are several different TV shows and the online application has to ask different
   questions based on which show the contestants choose to apply for.*/
// the program has 1 base class, 3 differents show classes AND the 1 unique Main program class to be executed first.
namespace _8_5RealityTV
{

    // Creating the base class Application
    class Application
    {
        // Creating the properties (variables where to store the data with there names) included the proper types.
        public string firstName;
        public string lastName;
        public string dateOfBirth;
        public string address;
        public string city;
        public string state;
        public int zip;
        public string phoneNumber;
        public string email;
        public bool isSubmitted;
        public bool isAccepted;

        // Creating the Constructor whith it's only 9 arguments.
        // and 2 initiated bools to be set in each Object (no input from the user)
        // and the process of storing the inputs data to the variables of this Object.
        public Application(string firstName, string lastName, string dateOfBirth, string address, string city, string state, int zip,
            string phoneNumber, string email)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.dateOfBirth = dateOfBirth;
            this.address = address;
            this.city = city;
            this.state = state;
            this.zip = zip;
            this.phoneNumber = phoneNumber;
            this.email = email;
            isSubmitted = false;
            isAccepted = false;

        }

        // Creating a method for the submission, set the submission status and print a message
        public void Submit()
        {
            isSubmitted = true;
            Console.WriteLine("Application has been submitted");
        }

        // Creating a method for the accepting, set the status and printing a message.
        // Using the keyword virtual gives the flexability to redefine (override) the method as needed in any show class.
        public virtual void Accept()
        {
            isAccepted = true;
            Console.WriteLine("Application Accepted");
        }
    }



    // Creating child class of Application for working on a yacht show 
    // Class has only 2 additional information variables.
    class AboveDeck : Application
    {
        public int yearsExperience;
        public string nationality;

        // Creating the constructor using the 2 variables of the class and only 9 of the base class.
        // And the process of storing the inputs data of the 2 new variables into this class variables
        public AboveDeck(int yearsExperience, string nationality,
            string firstName, string lastName, string dateOfBirth, string address, string city, string state, int zip,
            string phoneNumber, string email) : base(firstName, lastName, dateOfBirth, address, city, state, zip, phoneNumber, email)
        {

            this.yearsExperience = yearsExperience;
            this.nationality = nationality;
        }

        // Creating a method to override the base virtual method Accept as needed in this class
        // and print the proper message.
        public override void Accept()
        {
            base.Accept();
            Console.WriteLine("You've been accepted to Above Deck");
        }
    }



    // Creating a class for the HouseHunter show, child of Application.
    // Class has 5 new added properties 
    class HouseHunter : Application
    {
        public string jobTitle;
        public int currentAnnualIncome;
        public int whenBuyingMonths;
        public int bedrooms;
        public int bathrooms;

        // Creating the constructor using the 5 class added variables + 9 from the base class
        // And the process of storing the inputs data to this class variables
        public HouseHunter(string jobTitle, int currentIncome, int whenBuying, int bedrooms, int bathrooms,
            string firstName, string lastName, string dateOfBirth, string address, string city, string state, int zip,
            string phoneNumber, string email) : base(firstName, lastName, dateOfBirth, address, city, state, zip, phoneNumber, email)
        {

            this.jobTitle = jobTitle;
            this.currentAnnualIncome = currentIncome;
            this.whenBuyingMonths = whenBuying;
            this.bedrooms = bedrooms;
            this.bathrooms = bathrooms;
        }

        // Creating a method to override the base Accept method as needed in this Class.
        // and printing the proper message.
        public override void Accept()
        {
            base.Accept();
            Console.WriteLine("You've been accepted to Dream House Hunters");
        }
    }



    // Creating a Class for the ParadiseIsland show, child of Application
    class ParadiseIsland : Application
    {
        public string gender;
        public string nameOfBoyOrGirlFriend;
        public int yearsDating;

        // Creating the constructor using the 3 class added variables + 9 from the base class
        // And the process of storing the inputs data to this class variables
        public ParadiseIsland(string gender, string nameOfBoyOrGirlFriend, int yearsDating,
            string firstName, string lastName, string dateOfBirth, string address, string city, string state, int zip,
            string phoneNumber, string email) : base(firstName, lastName, dateOfBirth, address, city, state, zip, phoneNumber, email)
        {

            this.gender = gender;
            this.nameOfBoyOrGirlFriend = nameOfBoyOrGirlFriend;
            this.yearsDating = yearsDating;
        }

        // Creating a method to override the base Accept method as needed in this Class.
        // and printing the proper message.
        public override void Accept()
        {
            base.Accept();
            Console.WriteLine("You've been accepted to Paradise Island");
        }
    }



    // Creating the unique Main Class in the program to be executed first.
    //The Class has only the Main section as any Main Class.
    // The Class is a Creating action Class that create 3 different classes for 3 contestants, one for each show
    // And Create 6 methods for the 3 Classes
    class Program
    {
        // declaring the Main section of the Class
        static void Main(string[] args)
        {
            // Creating 3 Classes 1 for each show, each class adds a contestant data using the certain class of the show
            HouseHunter hhContestant = new HouseHunter("Full Stack Web Developer", 100000, 6, 3, 2, "Omar", "Smith", "2/4/1975",
                "111 Bravo Way", "Los Angeles", "California", 90001, "888-233-1234", "omar.smith@hotmail.com");

            ParadiseIsland piContestant = new ParadiseIsland("Female", "Carl", 2, "Patti", "Johnson", "5/4/1994", "211 Love Rd", "Los Angeles",
                "California", 90001, "988-444-1234", "patti.johnson@gmail.com");

            AboveDeck adContestant = new AboveDeck(20, "American", "Captian", "Lee", "7/12/1964", "311 Bravo Rd", "Los Angeles",
            "California", 90001, "711-333-1234", "captian@gmail.com");

            // Creating 2 methods for each Class of type Submit and Accept using the base Class.
            hhContestant.Submit();
            hhContestant.Accept();

            piContestant.Submit();
            piContestant.Accept();

            adContestant.Submit();
            adContestant.Accept();


        }
    }
}
