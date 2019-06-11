using System.Collections;
using UnityEngine;

public class ContactDamage : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //PlayerController.instance.TakeDamage();
            PlayerController.instance.Die();
        }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //StartCoroutine(DealDamage());
            //coroutine is still too fast
        }
    }

    IEnumerator DealDamage(int amount = 1)
    {
        PlayerController.instance.TakeDamage();
        yield return null;
    }
}
