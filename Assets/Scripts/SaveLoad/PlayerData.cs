[System.Serializable]
public class PlayerData
{

    // This Data depends on what you want to save
    public int health;
    public int life;
    public float[] position;
    public bool isMirrored;

    public PlayerData (PlayerController player, GameController game)
    {
        health = player.currentHealth;
        life = player.currentLife;
        position = new float[2];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        isMirrored = game.isMirrored;
    }
}
