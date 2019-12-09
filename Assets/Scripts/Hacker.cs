using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    int level;

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
        Terminal.WriteLine("LET'S GET HACKIN'");
    }

    void OnUserInput(string input) {
        if (input == "menu") {
            ShowMenu();
        } else if (currentScreen == Screen.MainMenu) {
            RunMenu(input);
        }
    }

    private void RunMenu(string input) {
        if (input == "1") {
            StartGame(input);
        } else if (input == "2") {
            StartGame(input);
        } else {
            Terminal.WriteLine("Invalid selection");
        }
    }

    void StartGame(string input) {
        Terminal.WriteLine("You've selected level " + input);
        currentScreen = Screen.WaitingForPassword;
        Terminal.WriteLine("Please enter your password: ");
    }

}
