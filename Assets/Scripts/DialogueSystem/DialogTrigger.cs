using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    private bool wasTriggered;
    public Dialog dialogue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!wasTriggered)
        {
            if (collision.tag == "Player")
            {
                DialogManager.instance.StartDialog(dialogue);
                wasTriggered = true;
            }
        }
    }
}
