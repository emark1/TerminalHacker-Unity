using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    int level;
    [SerializeField] string password;
    string[] levelOnePasswords = {"books", "aisle", "shelf", "password", "nerd", "worm"};
    string[] levelTwoPasswords = {"taser", "sirens", "badge", "crime", "swat", "squad"};
    int passwordIndex;



    enum Screen { MainMenu, WaitingForPassword, WinScreen };
    Screen currentScreen = Screen.MainMenu;
    // Start is called before the first frame update
    void Start()
    {
        ShowMenu();
    }

    void ShowMenu () {
        Terminal.ClearScreen();
        currentScreen = Screen.MainMenu;
        Terminal.WriteLine("SUP BOY");
        Terminal.WriteLine("");
        Terminal.WriteLine("TYPE 1 FOR LIBRARY");
        Terminal.WriteLine("TYPE 2 FOR POLICE");
        Terminal.WriteLine("TYPE MENU TO RETURN");
    }

    void OnUserInput(string input) {
        if (input == "menu") {
            ShowMenu();
        } else if (currentScreen == Screen.MainMenu) {
            RunMenu(input);
        }

        else if (currentScreen == Screen.WaitingForPassword) {
            CheckPassword(input);
        }
    }

    private void RunMenu(string input) {
        bool isValidLevel = (input == "1" || input == "2");
        if (isValidLevel) {
            level = int.Parse(input);
            StartGame();
        }


        // if (input == "1") {
        //     level = 1;
        //     password = levelOnePasswords[0];
        //     StartGame();
        // } else if (input == "2") {
        //     level = 2;
        //     password = levelTwoPasswords[0];
        //     StartGame(); }

        else {
            Terminal.WriteLine("Invalid selection");
        }
    }

    void StartGame() {
        passwordIndex = Random.Range(0, 5);
        Terminal.ClearScreen();
        currentScreen = Screen.WaitingForPassword;

        switch(level) {
            case 1:
                password = levelOnePasswords[passwordIndex];
                break;
            case 2:
                password = levelTwoPasswords[passwordIndex];
                break;
            default:
                Debug.LogError("Uh oh");
                break;
        }

        Terminal.WriteLine("You've selected level " + level);
        Terminal.WriteLine("Please enter your password: ");
        Terminal.WriteLine("Hint: " + password.Anagram());
    }

    void CheckPassword(string input) {
        if (input == password) {
            DisplayWinScreen();
        } else {
            Terminal.WriteLine("Incorrect password. Please try again (type menu to return)");
        }
    }

    void DisplayWinScreen() {
        currentScreen = Screen.WinScreen;
        Terminal.ClearScreen();
        ShowLevelReward();
    }

    void ShowLevelReward() {
        switch(level) {
            case 1:
                Terminal.WriteLine("AYYY NICE BRUH");
                Terminal.WriteLine(@"
    (________(/
   /         /
  /         /
 /_________/
(________(/
                
                ");
                break;
            case 2:
                Terminal.WriteLine("OH CRAP THE COPS");
                Terminal.WriteLine("<(''<)");
                break;
        }
    }
}
