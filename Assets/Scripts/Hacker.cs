using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    int level;
    string password;

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
        if (input == "1") {
            level = 1;
            password = "library";
            StartGame();
        } else if (input == "2") {
            level = 2;
            password = "police";
            StartGame();
        } else {
            Terminal.WriteLine("Invalid selection");
        }
    }

    void StartGame() {
        Terminal.WriteLine("You've selected level " + level);
        currentScreen = Screen.WaitingForPassword;
        Terminal.WriteLine("Please enter your password: ");
    }

    void CheckPassword(string input) {
        if (input == password) {
            Terminal.WriteLine("That's correct");
        } else {
            Terminal.WriteLine("Incorrect password. Please try again (type menu to return)");
        }
    }

}
