using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLoadHandler : MonoBehaviour
{
    #region Singleton

    public static SaveLoadHandler instance;

    void Awake()
    {
        if (GameObject.FindGameObjectsWithTag("SLH").Length == 1)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Debug.Log("SLH already existing!");
        }
    }

    #endregion
    public bool shouldLoad;


    // To use this functionallity, simply set
    // SaveLoadHandler.instance.shouldLoad = true;
    // when you load the GameScene (already implemented in MainMenu.cs)
    //Requires SaveSystem.cs and PlayerData.cs to be avaliable
    public void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            if (shouldLoad)
            {
                PlayerData data = SaveSystem.LoadPlayer();
                // From here Comes the Data you want to assing after loading...
                Vector2 position;
                position.x = data.position[0];
                position.y = data.position[1];
                PlayerController.instance.currentHealth = data.health;
                PlayerController.instance.currentLife = data.life;
                PlayerController.instance.transform.position = position;
                GameController.instance.isMirrored = data.isMirrored;
                // ...until here
                instance.shouldLoad = false;
            }
        }
    }
}
