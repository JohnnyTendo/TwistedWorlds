using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   
    public void StartNewGame()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadGame()
    {
        SaveLoadHandler.instance.shouldLoad = true;
        SceneManager.LoadScene(2);
    }

    public void OpenOptionsMenu()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}