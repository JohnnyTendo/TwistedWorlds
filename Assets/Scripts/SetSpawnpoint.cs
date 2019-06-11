using UnityEngine;

public class SetSpawnpoint : MonoBehaviour
{
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerController.instance.SetSpawnLocation(this.transform.position);
        }
    }
}
