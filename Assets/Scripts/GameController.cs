using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    #region Singleton

    public static GameController instance;

    void Awake()
    {
        instance = this;
        isPortable = true;
        Time.timeScale = 1;
    }

    #endregion

    public bool isMirrored;
    public bool isPortable;
    bool isPaused;
    Rect buttonQuitGame;
    Rect buttonSaveGame;

    private void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            isPaused = !isPaused;
            if (!isPaused)
            {
                Time.timeScale = 1;
            }
            if(isPaused)
            {
                Time.timeScale = 0;
            }
        }
    }

    void OnGUI()
    {
        float ctrlWidth = Screen.width / 2;
        float ctrlHeight = Screen.height / 8;
        if (isPaused)
        {
            buttonSaveGame = new Rect((Screen.width - ctrlWidth) / 2, Screen.height / 4, ctrlWidth, ctrlHeight);
            buttonQuitGame = new Rect((Screen.width - ctrlWidth) / 2, Screen.height / 2, ctrlWidth, ctrlHeight);
            if (GUI.Button(buttonQuitGame, "Really want to Quit?"))
                SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);
            if (GUI.Button(buttonSaveGame, "Save Game"))
                SaveSystem.SavePlayer(PlayerController.instance, GameController.instance);
        }
    }
}
