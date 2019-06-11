using UnityEngine;

public class PortalScript : MonoBehaviour
{
    public GameObject targetPortal;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameController.instance.isPortable == true)
        {
            if (collision.CompareTag("Player"))
            {
                Interact();
            }
        }
    }

    public virtual void Interact()
    {
        //Do some stuff here Like teleportation or scene change
        PlayerController.instance.transform.position = targetPortal.transform.position;
        FollowPlayer.instance.CorruptionProgress();
    }
}
