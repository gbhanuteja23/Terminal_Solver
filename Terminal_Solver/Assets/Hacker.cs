/*using System;
using System.Collections;
using System.Collections.Generic;
*/

using UnityEngine;

public class Hacker : MonoBehaviour
{
    //Game Configuratuon data
    string menuHint = "You may type Menu to go to Menu at any time";     //To go to Menu again if user wants.

    string[] level1Passwords = { "books", "aisle", "shelf", "password", "font", "borrow" };

    string[] level2Passwords = { "prisoner", "handcuffs", "holster", "uniform", "arrest" };

    string[] level3Passwords = { "starfield", "telescope", "environment", "exploration", "astronauts" };


    //Game States are the following
    //globally defined variables and enum

    int level;                       //Global variable, it is accesible throughout the program. 
                                    //It is also known as MemberVariable.  Both are the same. 
    
    enum Screen           //Custom Define Data Type ( Refer Enumerations in C# to know about it.)
    {
        MainMenu, Password, Win
    };

    Screen currentScreen;         //Creating variable of type Screen(enum)

    string password;     //Variable for storing Password input by user

    // Start is called before the first frame update
    void Start()
    {
        Terminal.ClearScreen();
        ShowMainMenu();   
    }

    void ShowGreeting()    //Function to show Greeting.
    {
        string greeting = "Game Made by Bhanuteja!";
        Terminal.WriteLine(greeting);
        Terminal.WriteLine("");
    }

    void ShowMainMenu()   //Function to show the Game Menu on the Terminal
    {
        currentScreen = Screen.MainMenu;
        ShowGreeting();

        Terminal.WriteLine("What would you like to hack into? (:");
        Terminal.WriteLine("Press 1 for hacking the local library");
        Terminal.WriteLine("Press 2 for hacking the police station");
        Terminal.WriteLine("Press 3 for hacking into ISRO");

        Terminal.WriteLine("");
        Terminal.WriteLine(menuHint);                   //To go to Menu again if user wants.
        Terminal.WriteLine("");

        Terminal.WriteLine("Enter your Selection:");
    }


    void OnUserInput(string input)    //OnUserInput() function prints whatever is entered in Terminal onto the Console
    {

        if (input == "Menu")     //By typing Menu, we can always go back to the main Menu.
        {
            Terminal.ClearScreen();
            Terminal.WriteLine("");
            ShowMainMenu();
           
        }

        // If user types any of these keywords, game will exit
        else if(input=="quit" || input=="close" || input=="exit" || input=="end")
        {
            Terminal.WriteLine("If on web-browser, close the tab");
            Application.Quit();    //To close the game if the game platform is windows, linux or mac.
        }

        else if (currentScreen == Screen.MainMenu)    //If user is on the CurrentScreen, there is no need to show 
        {                                             //You are on Level 1, you can proceed to Ask for Password
            RunMainMenu(input);                       // By running the function RunMainMenu()
        }

        else if(currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
            
    }

    void RunMainMenu(string input)           //Function to check level and then start the game
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input=="3");    // boolean variable which is either true or false

        if(isValidLevelNumber)
        {
            level = int.Parse(input);   //Parse() converts input string into integer
            AskForPassword();
        }
                
        else if (input == "007")         //Special case, just for fun
        {
            Terminal.ClearScreen();
            Terminal.WriteLine("Hey James Bond! Choose a valid Level!");
            Terminal.WriteLine("");
            ShowMainMenu();
        }

        else
        {
            Terminal.ClearScreen();
            Terminal.WriteLine("You have entered an invalid level!");
            Terminal.WriteLine("Choose the level again!");
            Terminal.WriteLine("");
            Terminal.WriteLine(menuHint);                  //To go to Menu again if user wants.
            ShowMainMenu();
        }
    }

    void AskForPassword()      //Function generate password and check for the password
    {
        currentScreen = Screen.Password;

        Terminal.ClearScreen();

        SetRandomPassword();    //Function for genrating random password

        Terminal.WriteLine("You have chosen level " + level + "!");
        Terminal.WriteLine("Enter your password, hint:" + password.Anagram());
        Terminal.WriteLine("");
    }

    //Anagram() is a cutom defined function which provides hint for a particular password in particular level
    //It is defined in WM2000.


    void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                int index1 = Random.Range(0, level1Passwords.Length);   //Random.Range(min,max) creates any random no. between
                password = level1Passwords[index1];                     // min and max. Read about it from concepts folder.
                break;

            case 2:
                int index2 = Random.Range(0, level2Passwords.Length);
                password = level2Passwords[index2];
                break;

            case 3:
                int index3 = Random.Range(0, level3Passwords.Length);
                password = level3Passwords[index3];
                break;

            default:
                Debug.LogError("You have entered an invalid Level number!!!");   //Debug.LogError(" "); lets you show error
                break;                                                           // error messages on the console.
        }
    }

    void CheckPassword(string input)    //Function to check the password entered.
    {
        if(input== password)
        {
            DisplayWinScreen();   //If password is correct DisplayWinScreen() is called. 
        }

        else
        {
            AskForPassword();
        }
    }

    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();

        ShowLevelReward();           //Then ShowLevelreward() is called.

    }

    void ShowLevelReward()
    {
        switch(level)
        {
            case 1:
                Terminal.WriteLine("Have a Book as your gift!!!");    //Terminal.WriteLine(@"   "); lets to to split into many lines
                Terminal.WriteLine(@"                               
     _______
   /      //
  /      //
 /______//
(______(/
                ");
                break;

            case 2:
                Terminal.WriteLine("Have a Prison Key as gift!!!");
                Terminal.WriteLine(@"
ooo,    .---.
 o`  o   /    |\________________
o`   'oooo()  | ________   _   _)
`oo   o` \    |/        | | | | |
  `ooo'   `---'         ' - ' |_|


                ");
                break;

            case 3:
                Terminal.WriteLine("Have a trip to moon as gift!!!");
                Terminal.WriteLine(@"
    /\
   /  \
  |    |
  |ISRO|
  |    |
  |____|
   /..\
  /....\
                ");
                break;

            default:
                Debug.LogError("Invalid Level Reached!!!");
                break;

        }
    }

    // Update is called once per frame
    void Update()
    {        

    }
}
