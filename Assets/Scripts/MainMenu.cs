using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public Menu currentMenu;
    public enum Menu
    {
        MainMenu,
        NewGame,
        Continue,
        Options,
        Quit
    }

    private Rect menuTitle;
    private Rect butMainMenuNewGame;
    private Rect butMainMenuContinue;
    private Rect butMainMenuOptions;
    private Rect butMainMenuQuit;
    private Rect butNewGameSave;
    private Rect butNewGameCancel;
    private Rect textNewGameName;
    private Rect butContinueSelectSave;
    private Rect butContinueCancel;
    private Rect butOptionsToggleFS;
    private Rect butOptionsCancel;


    void OnGUI()
    {
        float ctrlWidth = Screen.width / 2;
        float ctrlHeight = Screen.height / 8;
        if (currentMenu == Menu.MainMenu)
        {
            menuTitle = new Rect(Screen.width / 2, 0, ctrlWidth, ctrlHeight);
            butMainMenuNewGame = new Rect((Screen.width - ctrlWidth) / 2, 0, ctrlWidth, ctrlHeight);
            butMainMenuContinue = new Rect((Screen.width - ctrlWidth) / 2, 0, ctrlWidth, ctrlHeight);
            butMainMenuOptions = new Rect((Screen.width - ctrlWidth) / 2, 0, ctrlWidth, ctrlHeight);
            butMainMenuQuit = new Rect((Screen.width - ctrlWidth) / 2, 0, ctrlWidth, ctrlHeight);
            butMainMenuNewGame.y = (Screen.height - ctrlHeight) / 4;
            GUI.Label(menuTitle, "Journey");
            if (GUI.Button(butMainMenuNewGame, "New Game"))
                currentMenu = Menu.NewGame;
            butMainMenuContinue.y = butMainMenuNewGame.y + ctrlHeight;
            if (GUI.Button(butMainMenuContinue, "Continue"))
                currentMenu = Menu.Continue;
            butMainMenuOptions.y = butMainMenuContinue.y + ctrlHeight;
            if (GUI.Button(butMainMenuOptions, "Options"))
                currentMenu = Menu.Options;
            butMainMenuQuit.y = butMainMenuOptions.y + ctrlHeight;
            if (GUI.Button(butMainMenuQuit, "Quit"))
                Application.Quit();
        }
        else if (currentMenu == Menu.NewGame)
        {
            textNewGameName = new Rect((Screen.width - ctrlWidth) / 2, 0, ctrlWidth, ctrlHeight);
            butNewGameSave = new Rect((Screen.width - ctrlWidth) / 2, 0, ctrlWidth, ctrlHeight);
            butNewGameCancel = new Rect((Screen.width - ctrlWidth) / 2, 0, ctrlWidth, ctrlHeight);
            menuTitle = new Rect(Screen.width / 2, 0, ctrlWidth, ctrlHeight);
            GUI.Label(menuTitle, "New Game");
            textNewGameName.y = (Screen.height - ctrlHeight) / 2;
            butNewGameSave.y = textNewGameName.y + ctrlHeight;
            butNewGameCancel.y = butNewGameSave.y + ctrlHeight;
            if (GUI.Button(butNewGameSave, "Save & Start"))
            {
                SceneManager.LoadScene(1);
            }
            if (GUI.Button(butNewGameCancel, "Cancel"))
            {
                currentMenu = Menu.MainMenu;
            }
        }
        else if (currentMenu == Menu.Continue)
        {
            butContinueSelectSave = new Rect((Screen.width - ctrlWidth) / 2, 0, ctrlWidth, ctrlHeight);
            butContinueCancel = new Rect((Screen.width - ctrlWidth) / 2, 0, ctrlWidth, ctrlHeight);
            menuTitle = new Rect(Screen.width / 2, 0, ctrlWidth, ctrlHeight);
            GUI.Label(menuTitle, "Continue");
            butContinueCancel.y = (Screen.height - ctrlHeight) / 2;
            if (GUI.Button(butContinueCancel, "Cancel"))
            {
                currentMenu = Menu.MainMenu;
            }
            if (GUI.Button(butContinueSelectSave, "Load"))
            {
                //SaveLoad.Load();
            }
        }
        else if (currentMenu == Menu.Options)
        {
            butOptionsToggleFS = new Rect((Screen.width - ctrlWidth) / 2, 0, ctrlWidth, ctrlHeight);
            butOptionsCancel = new Rect((Screen.width - ctrlWidth) / 2, 0, ctrlWidth, ctrlHeight);
            menuTitle = new Rect(Screen.width / 2, 0, ctrlWidth, ctrlHeight);
            GUI.Label(menuTitle, "Options");
            butOptionsToggleFS.y = (Screen.height - ctrlHeight) / 2;
            butOptionsCancel.y = butOptionsToggleFS.y + ctrlHeight;
            if (GUI.Button(butOptionsToggleFS, "Toggle Nothing"))
            {

            }
            if (GUI.Button(butOptionsCancel, "Cancel"))
            {
                currentMenu = Menu.MainMenu;
            }
        }
    }
}